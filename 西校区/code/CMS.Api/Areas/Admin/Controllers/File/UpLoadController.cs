using CMS.Core.Common;
using CMS.IService.Admin;
using CMS.IService.Admin.Account.Dto;
using ElementUI.Admin.Common.Infrastructure;
using ElementUI.Admin.Filters;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;

namespace ElementUI.Admin.Areas.Admin.Controllers.File
{
    public class UpLoadController : ApiController
    {
        private readonly IUpLoadService service;
        public UpLoadController(IUpLoadService _service)
        {
            service = _service;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Task<IQueryable<FileResult>> FileUpLoad()
        {
            try
            {
                string uploadFolderPath = HostingEnvironment.MapPath(WebSettingsConfig.UploadFile);
                //如果路径不存在，创建路径
                if (!Directory.Exists(uploadFolderPath))
                    Directory.CreateDirectory(uploadFolderPath);
                if (Request.Content.IsMimeMultipartContent())
                {
                    var streamProvider = new WithExtensionMultipartFormDataStreamProvider(uploadFolderPath);
                    var task = Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith<IQueryable<FileResult>>(t =>
                    {
                        if (t.IsFaulted || t.IsCanceled)
                        {
                            throw new HttpResponseException(HttpStatusCode.InternalServerError);
                        }
                        var fileInfo = streamProvider.FileData.Select(i =>
                        {
                            var info = new FileInfo(i.LocalFileName);
                            return new FileResult()
                            {
                                FileNames = info.Name,
                                Description = "描述文本",
                                ContentTypes = info.Extension.ToString(),
                                CreatedTimestamp = info.CreationTime,
                                OriginalNames = info.Name.ToString(),
                                FileLength = info.Length.ToString()
                            };
                        });
                        return fileInfo.AsQueryable();
                    });

                    return task;
                }
                else
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DownloadFile(string fileName)
        {
            HttpResponseMessage result = null;
            DirectoryInfo directoryInfo = new DirectoryInfo(HostingEnvironment.MapPath(WebSettingsConfig.UploadFile));
            FileInfo foundFileInfo = directoryInfo.GetFiles().Where(x => x.Name == fileName).FirstOrDefault();
            if (foundFileInfo != null)
            {
                FileStream fs = new FileStream(foundFileInfo.FullName, FileMode.Open);

                result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StreamContent(fs);
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = foundFileInfo.Name;
            }
            else
            {
                result = new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            return result;
        }

        /// <summary>  
        /// 压缩文件下载  
        /// </summary>  
        /// <param name="fileIds">文件编号</param>  
        /// <returns></returns>  
        [HttpGet]
        public HttpResponseMessage DownLoad(string fileIds)
        {
            string customFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip";//客户端保存的文件名
            string path = HostingEnvironment.MapPath(WebSettingsConfig.UploadFile);
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                string[] filenames = { "202006011026360080196.psd" };
                using (ZipOutputStream s = new ZipOutputStream(System.IO.File.Create(path + "/" + customFileName)))
                {
                    s.SetLevel(9);
                    byte[] buffer = new byte[4096];

                    foreach (string file in filenames)
                    {
                        var entry = new ZipEntry(Path.GetFileName(path + "/" + file));
                        entry.DateTime = DateTime.Now;
                        s.PutNextEntry(entry);
                        using (FileStream fs = System.IO.File.OpenRead(path + "/" + file))
                        {
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }
                    s.Finish();
                    s.Close();
                }
                FileStream fileStream = new FileStream(path + "/" + customFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                response.Content = new StreamContent(fileStream);
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                response.Content.Headers.ContentDisposition.FileName = customFileName;
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");  // 这句话要告诉浏览器要下载文件  
                response.Content.Headers.ContentLength = new FileInfo(path + "/" + customFileName).Length;
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
            }
            return response;
        }

        /// <summary>
        /// 上传图片  [FromBody]string token
        /// </summary>
        /// <returns></returns>
        [HttpPost, AppletResultFilter]
        public Task<IQueryable<Hashtable>> ImageUpload()
        {
            // Check whether the POST operation is MultiPart?
            // 检查该请求是否含有multipart/form-data
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
            }
            // 文件保存目录路径 
            string uploadFolderPath = HostingEnvironment.MapPath(WebSettingsConfig.UploadPicFile);
            //检查上传的物理路径是否存在，不存在则创建
            if (!Directory.Exists(uploadFolderPath))
            {
                Directory.CreateDirectory(uploadFolderPath);
            }
            // 检测文件大小
            var request = System.Web.HttpContext.Current.Request;
            for (int i = 0; i < request.Files.Count; i++)
            {
                // 图片文件
                var imageFile = request.Files.Get(i);
                // 图片文件名称
                var imageFileName = imageFile.FileName.ToLower();
                // 图片文件内容类型
                var imageFileType = imageFile.ContentType.ToLower();
                var imageTypeList = new List<string>() { "gif", "jpg", "jpeg", "png", "bmp" };
                // 检测类型
                if (!imageFileType.Contains("image/") || !imageTypeList.Contains(imageFileName.Split('.').LastOrDefault()))
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.UnsupportedMediaType, "请上传图片格式的文件，如：gif,jpg,jpeg,png,bmp 结尾的文件"));
                }
                // 检测文件大小
                // 最大为 10M
                if (imageFile.ContentLength >= 10485760)
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "图片大小不能超过 10M"));
                }
            }
            var streamProvider = new WithExtensionMultipartFormDataStreamProvider(uploadFolderPath);
            var task = Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith<IQueryable<Hashtable>>(t =>
            {
                if (t.IsFaulted || t.IsCanceled)
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }
                var fileInfo = streamProvider.FileData.Select(i =>
                {
                    FileInfo info = new FileInfo(i.LocalFileName);
                    string orfilename = GetOrginFileName(i.Headers.ContentDisposition.FileName);
                    //上传图片更新记录
                    return service.UploadPictures(info);
                });
                return fileInfo.AsQueryable();
            });
            return task;
        }

        /// <summary>
        /// 获取缩略图
        /// </summary>
        /// <param name="id">唯一Id</param>
        /// <param name="w_h">生成缩略图宽高,下划线隔开</param>
        /// <param name="r">随机数</param>
        /// <returns>Image图片</returns>
        [HttpGet]
        public HttpResponseMessage GetImage(int id, string w_h = "", string r = "")
        {
            try
            {
                bool isThumb = false;
                string uploadFolderPath = HostingEnvironment.MapPath(WebSettingsConfig.UploadPicFile);
                int w = -1;
                int h = -1;
                if (!string.IsNullOrEmpty(w_h) && w_h.Split('_').Length == 2)
                {
                    bool isW = int.TryParse(w_h.Split('_')[0], out w);
                    bool isH = int.TryParse(w_h.Split('_')[1], out h);
                    if (isW && isH)
                    {
                        isThumb = true;
                    }
                }
                string PrefixThumbnail = id.ToString();
                if (isThumb)
                {
                    PrefixThumbnail = string.Format("{0}_{1}", PrefixThumbnail, w_h);
                }
                if (!string.IsNullOrEmpty(r))
                {
                    r = "_" + r;
                }
                //获取图片名称
                string fileName = service.GetPictureById(id);
                if (!string.IsNullOrEmpty(fileName))
                {
                    if (isThumb)
                    {
                        var thumbnail = uploadFolderPath + "/" + PrefixThumbnail + "_" + fileName;
                        //生成缩略图的方式 HW：指定高宽缩放（补白）W：指定宽，高按比例 H：指定高，宽按比例 Cut：指定高宽裁减（不变形）
                        MakeThumbnailImage(uploadFolderPath + "/" + fileName, thumbnail, w, h, "Cut");
                        //Redis.Set<string>(redisKey, thumbnail);

                        var thumbByte = System.IO.File.ReadAllBytes(thumbnail);
                        string contentType = System.Web.MimeMapping.GetMimeMapping(thumbnail);
                        //从图片中读取流
                        Stream thumbStream = new MemoryStream(System.IO.File.ReadAllBytes(thumbnail));
                        var resp = new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StreamContent(thumbStream)
                        };
                        resp.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                        return resp;
                    }
                    else
                    {
                        var thumbnail = uploadFolderPath + "/" + fileName;
                        //Redis.Set<string>(redisKey, thumbnail);
                        var thumbByte = System.IO.File.ReadAllBytes(thumbnail);
                        string contentType = System.Web.MimeMapping.GetMimeMapping(thumbnail);
                        //从图片中读取流
                        Stream thumbStream = new MemoryStream(System.IO.File.ReadAllBytes(thumbnail));
                        var resp = new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StreamContent(thumbStream)
                        };
                        resp.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                        return resp;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return Request.CreateResponse(HttpStatusCode.NoContent, "Please open the redis-server.exe ");
            }
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        #region 缩略图

        /// <summary>
        /// 获取原始文件名
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private string GetOrginFileName(string filePath)
        {
            string result = "";
            try
            {
                var filename = Regex.Match(filePath, @"[^\\]+$");
                result = filename.ToString().Replace("\"", "");
            }
            catch (Exception)
            { }
            return result;
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="fileName">源图路径（绝对路径）</param>
        /// <param name="newFileName">缩略图路径（绝对路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        private void MakeThumbnailImage(string fileName, string newFileName, int width, int height, string mode)
        {
            Image originalImage = Image.FromFile(fileName);
            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW"://指定高宽缩放（补白）
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    else
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    break;
                case "W"://指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            Bitmap b = new Bitmap(towidth, toheight);
            try
            {
                //新建一个画板
                Graphics g = Graphics.FromImage(b);
                //设置高质量插值法
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                //设置高质量,低速度呈现平滑程度
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                //清空画布并以透明背景色填充
                g.Clear(Color.White);
                //g.Clear(Color.Transparent);
                //在指定位置并且按指定大小绘制原图片的指定部分
                g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight), new Rectangle(x, y, ow, oh), GraphicsUnit.Pixel);

                SaveImage(b, newFileName, GetCodecInfo("image/" + GetFormat(newFileName).ToString().ToLower()));
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                b.Dispose();
            }
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="image">Image 对象</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="ici">指定格式的编解码参数</param>
        private static void SaveImage(Image image, string savePath, ImageCodecInfo ici)
        {
            //设置 原图片 对象的 EncoderParameters 对象
            EncoderParameters parameters = new EncoderParameters(1);
            parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, ((long)100));
            image.Save(savePath, ici, parameters);
            parameters.Dispose();
        }

        /// <summary>
        /// 获取图像编码解码器的所有相关信息
        /// </summary>
        /// <param name="mimeType">包含编码解码器的多用途网际邮件扩充协议 (MIME) 类型的字符串</param>
        /// <returns>返回图像编码解码器的所有相关信息</returns>
        private static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo ici in CodecInfo)
            {
                if (ici.MimeType == mimeType)
                    return ici;
            }
            return null;
        }

        /// <summary>
        /// 得到图片格式
        /// </summary>
        /// <param name="name">文件名称</param>
        /// <returns></returns>
        public static ImageFormat GetFormat(string name)
        {
            string ext = name.Substring(name.LastIndexOf(".") + 1);
            switch (ext.ToLower())
            {
                case "jpg":
                case "jpeg":
                    return ImageFormat.Jpeg;
                case "bmp":
                    return ImageFormat.Bmp;
                case "png":
                    return ImageFormat.Png;
                case "gif":
                    return ImageFormat.Gif;
                default:
                    return ImageFormat.Jpeg;
            }
        }

        #endregion
    }
}

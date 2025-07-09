using CMS.Core.Common;
using CMS.Core.Responsity;
using CMS.Core.Responsity.BLL;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using CMS.IService;
using CMS.IService.Admin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Service.Admin
{
    public class UpLoadService : IUpLoadService
    {
        private IBaseRepository<SqlServercfg> bll;
        public UpLoadService(IBaseRepository<SqlServercfg> _bll)
        {
            bll = _bll;
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="catalog">分类目录</param>
        /// <param name="info">System.IO.FileInfo</param>
        /// <returns></returns>
        public Hashtable UploadPictures(FileInfo info)
        {
            var request = System.Web.HttpContext.Current.Request;
            string catalog = request.QueryString["catalog"];//上传分类
            APP_TEMP file = new APP_TEMP(DealModel.New);
            file.FILE_TYPE = "01";
            file.FILE_NAME = info.Name;
            file.FILE_PATH = string.Format("{0}{1}", WebSettingsConfig.ImagePath, info.Name);
            file.FILE_DESC = catalog;
            file.REMARK = (info.Length / 1024).ToString() + "KB";
            decimal id = bll.Update(file);
            if (file.CurModel == DealModel.Modify)
            {
                id = file.FILE_ID;
            }
            Hashtable hs = new Hashtable();
            hs["fileid"] = id;
            hs["filename"] = info.Name;
            hs["filepath"] = file.FILE_PATH;
            hs["fileurl"] = string.Format("{0}{1}", WebSettingsConfig.ImageDomain, file.FILE_ID);
            return hs;
        }

        /// <summary>
        /// 获取图片名称
        /// </summary>
        /// <param name="decid"></param>
        /// <returns></returns>
        public string GetPictureById(decimal decid)
        {
            string fileName = "";
            var info = bll.Get<APP_TEMP>(decid);
            if (info != null)
            {
                //更新时间
                info.CurModel = DealModel.Modify;
                bll.Update(info);
                fileName = info.FILE_NAME;
            }
            return fileName;
        }
    }
}

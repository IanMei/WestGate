using CMS.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Web;

namespace ElementUI.Admin.Common.Infrastructure
{
    /// <summary>
    /// 多文件上传
    /// </summary>
    public class WithExtensionMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootPath"></param>
        public WithExtensionMultipartFormDataStreamProvider(string rootPath)
            : base(rootPath)
        {

        }

        /// <summary>
        /// 获取本地文件名，该文件名将与用于创建存储当前 MIME 正文部分内容的绝对文件名的根路径组合在一起。
        /// </summary>
        /// <param name="headers">当前 MIME 正文部分的标头。</param>
        /// <returns>不包含路径部分的相对文件名。</returns>
        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            string extension = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? Path.GetExtension(GetValidFileName(headers.ContentDisposition.FileName)) : "";
            return SerialNumberExtend.GenerateNumber() + extension.ToLower();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private string GetValidFileName(string filePath)
        {
            char[] invalids = System.IO.Path.GetInvalidFileNameChars();
            return String.Join("_", filePath.Split(invalids, StringSplitOptions.RemoveEmptyEntries)).TrimEnd('.');
        }
    }
}
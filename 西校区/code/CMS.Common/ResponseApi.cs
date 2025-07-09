using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Common
{
    /// <summary>
    /// 响应数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseApi<T>
    {
        /// <summary>
        /// 返回状态
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public T data { get; set; }
    }
}

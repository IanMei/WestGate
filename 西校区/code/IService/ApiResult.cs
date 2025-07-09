using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IService
{
    /// <summary>
    /// API返回值数据传输对象
    /// </summary>
    public class ApiResult
    {
        public int Code { get; set; } = -1;
        /// <summary>
        /// API调用是否成功
        /// </summary>
        public bool Success { get; set; } = false;
        /// <summary>
        /// 服务器回应消息提示
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 服务器回应的返回值对象(API调用失败则返回异常对象)
        /// </summary>
        public object ResultObject { get; set; }
        /// <summary>
        /// 设置API调用结果为成功
        /// </summary>
        /// <returns></returns>
        public ApiResult SetSuccessResult()
        {
            Code = 200;
            Success = true;
            Message = "Success";
            ResultObject = string.Empty;
            return this;
        }
        /// <summary>
        /// 设置API调用结果为成功
        /// </summary>
        /// <param name="resultObject">不需要从Data里面读取返回值对象时，存储简单的值对象或者string</param>
        /// <returns></returns>
        public ApiResult SetSuccessResult(string resultObject)
        {
            Code = 200;
            Success = true;
            Message = "Success";
            ResultObject = resultObject;
            return this;
        }
        /// <summary>
        /// 设置API调用结果为失败
        /// </summary>
        /// <param name="errorMessage">错误消息</param>
        /// <returns></returns>
        public ApiResult SetFailedResult(string errorMessage)
        {
            Code = -1;
            Success = false;
            Message = errorMessage;
            ResultObject = string.Empty;
            return this;
        }
        /// <summary>
        /// 设置API调用结果为失败
        /// </summary>
        /// <param name="errorCode">错误代码</param>
        /// <param name="errorMessage">错误消息</param>
        /// <returns></returns>
        public ApiResult SetFailedResult(int errorCode, string errorMessage)
        {
            Code = errorCode;
            Success = false;
            Message = errorMessage;
            ResultObject = string.Empty;
            return this;
        }
        /// <summary>
        /// 设置API调用结果为失败
        /// </summary>
        /// <param name="errorCode">错误代码</param>
        /// <param name="errorMessage">错误消息</param>
        /// <param name="e">异常对象</param>
        /// <returns></returns>
        public ApiResult SetFailedResult(int errorCode, string errorMessage, Exception e)
        {
            Code = errorCode;
            Success = false;
            Message = errorMessage;
            ResultObject = e;
            return this;
        }
    }

    /// <summary>
    /// API返回值数据传输对象（泛型版）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T> : ApiResult
    {
        public virtual T Data { get; set; }

        public virtual ApiResult<T> SetSuccessResult(T t)
        {
            var result = new ApiResult<T>();
            result.SetSuccessResult().ResultObject = t.GetType().Name;
            result.Data = t;
            result.Code = 200;
            result.Success = true;
            result.Message = "Success";
            return result;
        }
    }
}

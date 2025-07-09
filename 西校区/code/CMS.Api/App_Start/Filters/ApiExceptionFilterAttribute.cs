using CMS.Core.Common;
using CMS.IService;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Filters;

namespace ElementUI.Admin.Filters
{
    /// <summary>
    /// Api异常处理
    /// </summary>
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 统一对调用异常信息进行处理，返回自定义的异常信息
        /// </summary>
        /// <param name="actionExecutedContext">HTTP上下文对象</param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //1.异常日志记录（正式项目里面一般是用log4net记录异常日志）
            //Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "——" +
            //    actionExecutedContext.Exception.GetType().ToString() + "：" + actionExecutedContext.Exception.Message + "——堆栈信息：" +
            //    actionExecutedContext.Exception.StackTrace);

            //2.返回调用方具体的异常信息
            if (actionExecutedContext.Exception is NotImplementedException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }
            else if (actionExecutedContext.Exception is TimeoutException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.RequestTimeout);
            }
            else
            {
                ApiResult result = new ApiResult().SetFailedResult(-1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), actionExecutedContext.Exception);
                var oResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                oResponse.Content = new StringContent(
                    JsonConvert.SerializeObject(
                    result,
                    Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ContractResolver = new UnderlineSplitContractResolver(),    //小写命名法。
                        DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                        DateFormatString = "yyyy/MM/dd HH:mm:ss",   //解决json时间带T的问题
                        Formatting = Formatting.Indented,   //解决json格式化缩进问题
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,   //解决json序列化时的循环引用问题
                        NullValueHandling = NullValueHandling.Ignore
                    }),
                    Encoding.GetEncoding("UTF-8"), "application/json");
                oResponse.ReasonPhrase = "InternalServerError";
                actionExecutedContext.Response = oResponse;
                //actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            base.OnException(actionExecutedContext);
        }
    }
}
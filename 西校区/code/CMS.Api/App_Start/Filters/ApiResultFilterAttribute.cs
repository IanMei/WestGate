using CMS.Core.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Filters;

namespace ElementUI.Admin.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiResultFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 统一响应格式
        /// </summary>
        public override void OnActionExecuted(HttpActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if (filterContext.ActionContext.Response != null)
            {
                //ResponseApi<object> result = new ResponseApi<object>();
                //// 取得由 API 返回的状态代码
                //result.code = (int)filterContext.ActionContext.Response.StatusCode;
                //// 取得由 API 返回的资料
                //result.data = filterContext.ActionContext.Response.Content.ReadAsAsync<object>().Result;
                HttpResponseMessage response = new HttpResponseMessage
                {
                    Content = new StringContent(
                        JsonConvert.SerializeObject(
                            filterContext.ActionContext.Response.Content.ReadAsAsync<object>().Result,
                            Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ContractResolver = new UnderlineSplitContractResolver(),    //小写命名法。
                                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                                DateFormatString = "yyyy-MM-dd HH:mm:ss",   //解决json时间带T的问题
                                Formatting = Formatting.Indented,   //解决json格式化缩进问题
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,   //解决json序列化时的循环引用问题
                                //NullValueHandling = NullValueHandling.Ignore,
                            }),
                    Encoding.GetEncoding("UTF-8"), "application/json")
                };
                //结果转为自定义消息格式
                HttpResponseMessage httpResponseMessage = response;

                // 重新封装回传格式
                filterContext.Response = httpResponseMessage;

            }
        }
    }
}
using CMS.Core.Common;
using CMS.IService;
using CMS.IService.Admin.Account.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ElementUI.Admin.Filters
{
    /// <summary>
    /// Api数据权限验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class ApiPermissionAttribute : ActionFilterAttribute
    {
        private const string LogonToken = "Token";
        /// <summary>
        /// 操作编号
        /// </summary>
        public string OperationCode { get; set; }
        /// <summary>
        /// 进入action之前做权限验证
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            int isRights = 0;
            var service = AutofacUtil.GetFromFac<CMS.IService.Admin.IAccountService>();
            //if (SkipAuthorization(actionContext))
            //    return;
            string sessionKey = Guid.Empty.ToString(); // MD5值
            actionContext.Request.Headers.TryGetValues(LogonToken, out IEnumerable<string> tokens);
            if (tokens != null && tokens.Any())
            {
                sessionKey = tokens.FirstOrDefault();
                //功能权限
                if (!string.IsNullOrEmpty(OperationCode))
                {
                    string[] roleArrs = OperationCode.Split('|');
                    foreach (string item in roleArrs)
                    {
                        ApiResult<int> result = service.GetUserRight(sessionKey, item) as ApiResult<int>;
                        isRights = result.Data;// service.GetUserRight(sessionKey, item);
                        if (isRights > 0)
                        {
                            break;
                        }
                    }
                }
            }
            if (isRights <= 0)
            {
                if (isRights == 0)
                {
                    PermissionValidationFailed(actionContext);
                }
                else if (isRights == -1) {
                    TokenTimeout(actionContext);
                }
            }
            else
            {
                ApiResult<UserInfo> result = service.GetUserByToken(sessionKey) as ApiResult<UserInfo>;
                if (result.Success)
                {
                    SetPrincipal(new UserPrincipal<int>(result.Data));
                }
                //UserInfo logonUser = service.GetUserByToken(sessionKey);
                //if (logonUser != null)
                //{
                //    SetPrincipal(new UserPrincipal<int>(logonUser));
                //}
            }
        }

        /// <summary>
        /// 设置主体上下文
        /// </summary>
        /// <param name="principal"></param>
        public static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        /// <summary>
        /// 判断是否匿名使用接口
        /// </summary>
        //private static bool SkipAuthorization(HttpActionContext actionContext)
        //{
        //    if (!actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any<AllowAnonymousAttribute>())
        //        return actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any<AllowAnonymousAttribute>();
        //    return true;
        //}

        /// <summary>
        /// token超时
        /// </summary>
        /// <param name="actionContext"></param>
        private void TokenTimeout(HttpActionContext actionContext)
        {
            ResponseApi<object> result = new ResponseApi<object>();
            result.code = (int)StatusType.AccountError;
            result.message = StatusType.UnauthorizedAccess.GetEnumText();
            result.data = null;
            HttpResponseMessage response = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(result),
                   Encoding.GetEncoding("UTF-8"), "application/json"),
            };
            //结果转为自定义消息格式
            HttpResponseMessage httpResponseMessage = response;
            //httpResponseMessage.StatusCode = HttpStatusCode.Forbidden;
            // 重新封装回传格式
            actionContext.Response = httpResponseMessage;
        }

        /// <summary>
        /// 没有权限
        /// </summary>
        /// <param name="actionContext"></param>
        private void PermissionValidationFailed(HttpActionContext actionContext)
        {
            ResponseApi<object> result = new ResponseApi<object>();
            result.code = (int)StatusType.UnauthorizedAccess;
            result.message = StatusType.UnauthorizedAccess.GetEnumText();
            result.data = null;
            HttpResponseMessage response = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(result),
                   Encoding.GetEncoding("UTF-8"), "application/json"),
            };
            //结果转为自定义消息格式
            HttpResponseMessage httpResponseMessage = response;
            //httpResponseMessage.StatusCode = HttpStatusCode.Forbidden;
            // 重新封装回传格式
            actionContext.Response = httpResponseMessage;
        }
    }
}
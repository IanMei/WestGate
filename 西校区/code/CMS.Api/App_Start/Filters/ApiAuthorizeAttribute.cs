
using CMS.IService;
using CMS.IService.Admin.Account.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Security;

namespace ElementUI.Admin.Filters
{
    /// <summary>
    /// Api授权认证
    /// </summary>
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        private const string LogonToken = "Token";
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (HttpContext.Current != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var ticket = (System.Web.HttpContext.Current.User.Identity as FormsIdentity).Ticket;
            }

            if (SkipAuthorization(actionContext))
                return;
            string sessionKey = Guid.Empty.ToString(); // MD5值
            actionContext.Request.Headers.TryGetValues(LogonToken, out IEnumerable<string> tokens);
            if (tokens != null && tokens.Any())
            {
                sessionKey = tokens.FirstOrDefault();
                var service = AutofacUtil.GetFromFac<CMS.IService.Admin.IAccountService>();
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
                else
                {
                    throw new Exception("Token失效");
                }
            }
            else
            {
                base.IsAuthorized(actionContext);
                //throw new Exception("InvalidSession");
            }
        }

        /// <summary>
        /// 
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
        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            if (!actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any<AllowAnonymousAttribute>())
                return actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any<AllowAnonymousAttribute>();
            return true;
        }
    }
}
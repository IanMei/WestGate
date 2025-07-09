
using CMS.Core.Common;
using CMS.Core.Responsity;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using System;
using System.Data;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ElementUI.Admin.Filters
{
    /// <summary>
    /// 执行顺序 OnAuthorization-->AuthorizeCore-->HandleUnauthorizedRequest
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class LoginAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 授权验证的逻辑处理。返回true则通过授权，false则相反
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool Pass = false;
            string token = CacheHelper.GetTokenCookie();
            if (HttpContext.Current != null && !string.IsNullOrEmpty(token))
            {
                //var service = AutofacUtil.GetFromFac<CMS.IService.FrontEnd.Login.IMineService>();
                //Pass = service.GetUserVerifyToken(token).Success;
            }
            return Pass;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (SkipAuthorization(filterContext))
                return;
            base.OnAuthorization(filterContext);//执行父类的OnAuthorization方法，调用 asp.net的授权验证机制！
        }

        /// <summary>
        /// 验证失败时触发
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            else
            {
                //filterContext.HttpContext.Response.Redirect("/login.html");
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
                {
                    controller = "Account",
                    action = "Login",
                    returnUrl = filterContext.HttpContext.Request.Url
                }));
            }
        }

        /// <summary>
        /// 判断是否匿名使用接口
        /// </summary>
        private static bool SkipAuthorization(AuthorizationContext filterContext)
        {
            //判断是否跳过授权过滤器
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
               || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return true;
            }
            return false;
        }
    }
}
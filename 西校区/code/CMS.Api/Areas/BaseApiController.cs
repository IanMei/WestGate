//using CMS.IService.Dto;
using System;
using System.Web.Http;

namespace ElementUI.Admin.Areas
{
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        //public UserIdentity<int> CurrentUser {
        //    get {
        //        var httpContext = System.Web.HttpContext.Current;
        //        if (httpContext != null && httpContext.User.Identity.IsAuthenticated)
        //        {
        //            UserIdentity<int> model = httpContext.User.Identity as UserIdentity<int>;
        //            return model;
        //        }
        //        throw new Exception("没有登录或登录超时，请重新登录");
        //    }
        //}
    }
}

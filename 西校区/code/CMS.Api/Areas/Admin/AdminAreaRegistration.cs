using System.Web.Http;
using System.Web.Mvc;

namespace ElementUI.Admin.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName {
            get {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
            //新加，注意namespace ApiRoute
            //GlobalConfiguration.Configuration.Routes.MapHttpRoute(
            // this.AreaName + "Api",
            // "api/" + this.AreaName + "/{controller}/{action}/{id}",
            // new { area = this.AreaName, action = RouteParameter.Optional, id = RouteParameter.Optional, namespaceName = new string[] { string.Format("ApiRoute.Areas.{0}.Controllers", this.AreaName) } }
            //  );
        }
    }
}
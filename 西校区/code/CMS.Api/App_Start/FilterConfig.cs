using ElementUI.Admin.Filters;
using System.Web;
using System.Web.Mvc;

namespace ElementUI.Admin {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

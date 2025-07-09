using CMS.Core.Responsity;
using CMS.Core.Responsity.Db;
using CMS.IService;
using System.Web.Mvc;

namespace ElementUI.Admin.Controllers
{
    /// <summary>
    /// 首页
    /// </summary>
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [MetaInfo]
        public ActionResult Index()
        {
            return Redirect("/swagger");
            //return View();
        }
     
    }
}

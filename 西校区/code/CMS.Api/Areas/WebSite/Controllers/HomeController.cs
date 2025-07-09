using CMS.IService;
using CMS.IService.WebSite.Home;
using CMS.IService.WebSite.Home.Dto;
using ElementUI.Admin.Filters;
using System.Web.Http;

namespace ElementUI.Admin.Areas.WebSite.Controllers
{
    [ApiResultFilter, ApiExceptionFilter]
    public class HomeController : ApiController
    {
        private readonly IHomeService service;
        public HomeController(IHomeService _service) {
            service = _service;
        }

        /// <summary>
        /// 轮播
        /// </summary>
        [HttpGet]
        public ApiResult Banners()
        {
            var rs = service.Banners();
            return rs;
        }


        /// <summary>
        /// 选择我们
        /// </summary>
        [HttpGet]
        public ApiResult ChooseUs()
        {
            var rs = service.ChooseUs();
            return rs;
        }


        /// <summary>
        /// 关于我们
        /// </summary>
        [HttpGet]
        public ApiResult AboutUs()
        {
            var rs = service.AboutUs();
            return rs;
        }


        /// <summary>
        /// 活动
        /// </summary>
        [HttpGet]
        public ApiResult Activitys(int size = 3)
        {
            var rs = service.Activitys(size);
            return rs;
        }

        /// <summary>
        /// 活动详情
        /// </summary>
        [HttpGet]
        public ApiResult Activity(decimal id)
        {
            var rs = service.Activity(id);
            return rs;
        }

        /// <summary>
        /// 站点信息
        /// </summary>
        [HttpGet]
        public ApiResult SiteInfo()
        {
            var rs = service.SiteInfo();
            return rs;
        }


        /// <summary>
        /// 每周专访
        /// </summary>
        [HttpGet]
        public ApiResult Interview()
        {
            var rs = service.Interview();
            return rs;
        }


        /// <summary>
        /// 学校详情
        /// </summary>
        [HttpGet]
        public ApiResult School(decimal id)
        {
            var rs = service.School(id);
            return rs;
        }


        /// <summary>
        /// 学校列表
        /// </summary>
        [HttpGet]
        public ApiResult SchoolList(int size = 10,int page =1)
        {
            var rs = service.SchoolList(size, page);
            return rs;
        }

        /// <summary>
        /// 字典数据
        /// </summary>
        [HttpGet]
        public ApiResult Dictionarys(string code)
        {
            var rs = service.Dictionarys(code);
            return rs;
        }
        /// <summary>
        /// 字典数据
        /// </summary>
        [HttpGet]
        public ApiResult DictionarysEn(string code)
        {
            var rs = service.DictionarysEn(code);
            return rs;
        }
        /// <summary>
        /// 省市区
        /// </summary>
        [HttpGet]
        public ApiResult AreaList()
        {
            var rs = service.AreaList();
            return rs;
        }

        /// <summary>
        /// 省市区
        /// </summary>
        [HttpGet]
        public ApiResult AreaListEn()
        {
            var rs = service.AreaListEn();
            return rs;
        }
        /// <summary>
        /// 服务条款
        /// </summary>
        [HttpGet]
        public ApiResult Service()
        {
            var rs = service.Service();
            return rs;
        }

        /// <summary>
        /// 评委详情
        /// </summary>
        [HttpGet]
        public ApiResult Judges(decimal id)
        {
            var rs = service.Judges(id);
            return rs;
        }

        /// <summary>
        /// 活动报名
        /// </summary>
        [HttpPost]
        public ApiResult Enroll(EnrollDto form)
        {
            var rs = service.Enroll(form);
            return rs;
        }
    }
}

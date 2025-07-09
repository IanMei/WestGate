using CMS.IService;
using CMS.IService.WebSite.Home;
using CMS.IService.WebSite.Home.Dto;
using CMS.IService.WebSite.Member.Dto;
using ElementUI.Admin.Filters;
using System.Web.Http;

namespace ElementUI.Admin.Areas.WebSite.Controllers
{
    [ApiResultFilter, ApiExceptionFilter]
    public class MemberController : ApiController
    {
        private readonly IMemberService service;
        public MemberController(IMemberService _service) {
            service = _service;
        }

        [HttpPost]
        public ApiResult Login(LoginDto form)
        {
            var rs = service.Login( form);
            return rs;
        }


        [HttpPost]
        public ApiResult Register(MemberDto form)
        {
            var rs = service.Register(form);
            return rs;
        }
        [HttpGet]
        public ApiResult SendSms([FromUri] string mobile, string type ="01")
        {
            var rs = service.SendSms(mobile, type);
            return rs;
        }

        [HttpGet]
        public ApiResult SendChangeMobileSms([FromUri] string old, string mobile)
        {
            var rs = service.SendChangeMobileSms(old, mobile);
            return rs;
        }


        [HttpPost]
        public ApiResult ChangeMobile(ChangeMobileDto form)
        {
            var rs = service.ChangeMobile(form);
            return rs;
        }

        [HttpGet]
        public ApiResult Info()
        {
            var rs = service.Info();
            return rs;
        }

        [HttpGet]
        public ApiResult Help()
        {
            var rs = service.Help();
            return rs;
        }


        [HttpGet]
        public ApiResult HelpInfo(decimal id)
        {
            var rs = service.HelpInfo(id);
            return rs;
        }
        [HttpPost]
        public ApiResult Update(MemberDto form)
        {
            var rs = service.Update(form);
            return rs;
        }

        [HttpPost]
        public ApiResult Feedback(FeedbackDto form)
        {
            var rs = service.Feedback(form);
            return rs;
        }



        [HttpGet]
        public ApiResult Files()
        {
            var rs = service.Files();
            return rs;
        }
        [HttpGet]
        public ApiResult DeleteFile(string ids)
        {
            var rs = service.DeleteFile(ids);
            return rs;
        }
        [HttpPost]
        public ApiResult UpdateFile(MemberFileDto form)
        {
            var rs = service.UpdateFile(form);
            return rs;
        }


        [HttpGet]
        public ApiResult Online()
        {
            var rs = service.Online();
            return rs;
        }
    }
}

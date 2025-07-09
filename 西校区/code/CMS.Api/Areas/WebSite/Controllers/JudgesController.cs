using CMS.IService;
using CMS.IService.WebSite.Home;
using CMS.IService.WebSite.Home.Dto;
using CMS.IService.WebSite.Judges.Dto;
using CMS.IService.WebSite.Member.Dto;
using ElementUI.Admin.Filters;
using System.Web.Http;

namespace ElementUI.Admin.Areas.WebSite.Controllers
{
    [ApiResultFilter, ApiExceptionFilter]
    public class JudgesController : ApiController
    {
        private readonly IJudgesService service;
        public JudgesController(IJudgesService _service)
        {
            service = _service;
        }

        [HttpPost]
        public ApiResult Login(JudgesLoginDto form)
        {
            var rs = service.Login(form);
            return rs;
        }


        [HttpPost]
        public ApiResult Register(JudgesDto form)
        {
            var rs = service.Register(form);
            return rs;
        }


        [HttpPost]
        public ApiResult Update(JudgesDto form)
        {
            var rs = service.Update(form);
            return rs;
        }
        [HttpGet]
        public ApiResult SendSms([FromUri] string mobile, string type = "01")
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
        public ApiResult ChangeMobile(JudgesChangeMobileDto form)
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
        public ApiResult Online()
        {
            var rs = service.Online();
            return rs;
        }
        [HttpGet]
        public ApiResult QuestionnaireInfo()
        {
            var rs = service.QuestionnaireInfo();
            return rs;
        }

        [HttpPost]
        public ApiResult Questionnaire(JudgesQuestionnaireDto form)
        {
            var rs = service.Questionnaire(form);
            return rs;
        }

        [HttpPost]
        public ApiResult Feedback(FeedbackDto form)
        {
            var rs = service.Feedback(form);
            return rs;
        }


        [HttpGet]
        public ApiResult List(int size = 6, int page = 1)
        {
            var rs = service.List(size, page);
            return rs;
        }
    }
}

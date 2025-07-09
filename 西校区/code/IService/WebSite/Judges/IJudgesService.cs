using CMS.IService.WebSite.Judges.Dto;
using CMS.IService.WebSite.Member.Dto;

namespace CMS.IService.WebSite.Home
{
    public interface IJudgesService
    {
        ApiResult Register(JudgesDto form);

        ApiResult Login(JudgesLoginDto form);

        ApiResult ChangeMobile(JudgesChangeMobileDto form);

        ApiResult SendSms(string mobile, string type = "01");

        ApiResult Online();

        ApiResult Info();

        ApiResult SendChangeMobileSms(string old, string mobile);

        ApiResult Update(JudgesDto form);

        ApiResult QuestionnaireInfo();

        ApiResult Questionnaire(JudgesQuestionnaireDto form);

        ApiResult Feedback(FeedbackDto form);


        ApiResult List(int size, int page);
    }
}

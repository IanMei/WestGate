using CMS.IService.WebSite.Member.Dto;

namespace CMS.IService.WebSite.Home
{
    public interface IMemberService
    {
        ApiResult Register(MemberDto form);

        ApiResult Login(LoginDto form);

        ApiResult SendSms(string mobile, string type = "01");

        ApiResult Info();


        ApiResult Help();

        ApiResult Online();

        ApiResult HelpInfo(decimal id);

        ApiResult SendChangeMobileSms(string old, string mobile);

        ApiResult Update(MemberDto form);


        ApiResult Feedback(FeedbackDto form);

        ApiResult ChangeMobile(ChangeMobileDto form);

        ApiResult Files();

        ApiResult DeleteFile(string ids);

        ApiResult UpdateFile(MemberFileDto form);
    }
}

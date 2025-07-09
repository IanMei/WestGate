using CMS.IService.Admin.Judges.Dto;

namespace CMS.IService.Admin
{
    public interface IQuestionnaireService
    {
        ApiResult List(int page, int size);
        ApiResult Get(decimal id);
        ApiResult Result(decimal id);
        ApiResult Update(QuestionnaireDto item);
        ApiResult Delete(string ids);
        ApiResult State(decimal id);
    }
}

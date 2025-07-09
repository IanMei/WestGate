using CMS.IService.Admin.School.Dto;

namespace CMS.IService.Admin
{
    public interface IInterviewService
    {
        ApiResult List(int page, int size);
        ApiResult Get(decimal id);
        ApiResult Update(InterviewDto item);
        ApiResult Delete(string ids);
    }
}

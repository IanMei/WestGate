using CMS.IService.Admin.Judges.Dto;

namespace CMS.IService.Admin
{
    public interface IJudgesService
    {
        ApiResult List(int page, int size);
        ApiResult Get(decimal id);
        ApiResult Update(JudgesInfoDto item);
        ApiResult Delete(string ids);
        ApiResult State(decimal id);
        ApiResult Main(decimal id);
        ApiResult Special(decimal id);
    }
}

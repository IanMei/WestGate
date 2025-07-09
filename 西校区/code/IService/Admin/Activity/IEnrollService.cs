using CMS.IService.Admin.Activity.Dto;

namespace CMS.IService.Admin
{
    public interface IEnrollService
    {
        ApiResult List(int page, int size);
        ApiResult Get(decimal id);
        ApiResult Update(EnrollDto item);
        ApiResult Delete(string ids);
    }
}

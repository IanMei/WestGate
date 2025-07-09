using CMS.IService.Admin.BaseData.Dto;

namespace CMS.IService.Admin
{
    public interface IAboutService
    {
        ApiResult List(int page, int size);
        ApiResult Get(decimal id);
        ApiResult Update(AboutDto item);
        ApiResult Delete(string ids);
        ApiResult State(decimal id);
    }
}

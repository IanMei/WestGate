using CMS.IService.Admin.Settings.Dto;

namespace CMS.IService.Admin.Settings
{
    public interface IBannerService
    {
        ApiResult List(int page, int size);
        ApiResult Get(decimal id);
        ApiResult Update(BannerDto item);
        ApiResult Delete(string ids);
        ApiResult State(decimal id);

        ApiResult Types();
    }
}

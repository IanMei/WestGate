using CMS.IService.Admin.BaseData.Dto;

namespace CMS.IService.Admin
{
    public interface IHelpService
    {
        ApiResult List(int page, int size);
        ApiResult Get(decimal id);
        ApiResult Update(HelpDto item);
        ApiResult Delete(string ids);
        ApiResult State(decimal id);
    }
}

using CMS.IService.Admin.BaseData.Dto;

namespace CMS.IService.Admin
{
    public interface IDictionaryService
    {
        ApiResult Index();
        ApiResult List(int page, int size);
        ApiResult Get(decimal id);
        ApiResult Update(DictionaryDto item);
        ApiResult Delete(string ids);
        ApiResult State(decimal id);
        ApiResult Select(string indexCode);
    }
}

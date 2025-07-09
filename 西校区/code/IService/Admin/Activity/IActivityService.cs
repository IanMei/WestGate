using CMS.IService.Admin.Activity.Dto;

namespace CMS.IService.Admin
{
    public interface IActivityService {

        ApiResult List(int page, int size);
        ApiResult Get(decimal id);
        ApiResult Update(ActivityDto item);
        ApiResult Delete(string ids);
        ApiResult State(decimal id);
        ApiResult Recommend(decimal id);
        ApiResult Select();
    }
}

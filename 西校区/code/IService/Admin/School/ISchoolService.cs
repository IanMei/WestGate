using CMS.IService.Admin.School.Dto;

namespace CMS.IService.Admin
{
    public interface ISchoolService
    {
        ApiResult List(int page, int size);
        ApiResult Get(decimal id);
        ApiResult Update(SchoolDto item);
        ApiResult Delete(string ids);
        ApiResult State(decimal id);
        ApiResult Hot(decimal id);
        ApiResult AreaList();
        ApiResult Select();
    }
}

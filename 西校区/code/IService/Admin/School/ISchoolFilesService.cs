using CMS.IService.Admin.School.Dto;

namespace CMS.IService.Admin
{
    public interface ISchoolFilesService
    {
        ApiResult List(int page, int size);
        ApiResult Get(decimal id);
        ApiResult Update(SchoolFileDto item);
        ApiResult Delete(string ids);
    }
}

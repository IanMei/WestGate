using CMS.IService.WebSite.Home.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IService.WebSite.Home
{
    public interface IHomeService
    {
        ApiResult Banners();
        ApiResult Service();
        ApiResult ChooseUs();
        ApiResult AboutUs();
        ApiResult Activitys(int size);
        ApiResult Activity(decimal id);
        ApiResult Enroll(EnrollDto form);
        ApiResult SiteInfo();
        ApiResult Interview();
        ApiResult SchoolList(int size, int page);
        ApiResult School(decimal id);
        ApiResult Dictionarys(string indexCode);
        ApiResult DictionarysEn(string indexCode);
        ApiResult AreaList();
        ApiResult AreaListEn();


        ApiResult Judges(decimal id);
    }
}

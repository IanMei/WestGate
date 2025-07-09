using CMS.Core.Responsity.Tables;
using CMS.IService.Admin.Account.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IService.WebSite.Home.Dto
{
    public class SchoolDto : APP_SCHOOL
    {

        public string link_man { get; set; }
        public string service_tel { get; set; }
        public string email { get; set; }


        public List<SchoolHonorDto> Honors { get; set; } = new List<SchoolHonorDto>();


        public string Facilities { get; set; }
        public string EnFacilities { get; set; }
        public List<string> Facilities1 { get; set; } = new List<string>();
        public List<string> Facilities2 { get; set; } = new List<string>();
        public List<string> Facilities3 { get; set; } = new List<string>();

    }

    public class SchoolHonorDto : APP_HONOR
    {

    }
}

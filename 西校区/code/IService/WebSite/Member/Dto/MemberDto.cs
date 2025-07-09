using CMS.Core.Responsity.Tables;
using CMS.IService.Admin.School.Dto;
using CMS.IService.WebSite.Home.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IService.WebSite.Member.Dto
{
    public class MemberDto :APP_SCHOOL
    {
        public string CheckCode { get; set; }
        public string Sms { get; set; }
        public string npwd { get; set; }
        public string cpwd { get; set; }


        public List<string> ArrayArea { get; set; } = new List<string>();

        public List<SchoolHonorDto> Honors { get; set; } = new List<SchoolHonorDto>();

        public List<FacilitiesDto> Facilities1 { get; set; } = new List<FacilitiesDto>();
        public List<FacilitiesDto> Facilities2 { get; set; } = new List<FacilitiesDto>();
        public List<FacilitiesDto> Facilities3 { get; set; } = new List<FacilitiesDto>();

        public List<string> FacilitiesVal1 { get; set; } = new List<string>();
        public List<string> FacilitiesVal2 { get; set; } = new List<string>();
        public List<string> FacilitiesVal3 { get; set; } = new List<string>();

    }
    public class HelpDto :APP_HELP
    {

    }

    public class LoginDto
    {
        public string uid { get; set; }
        public string pwd { get; set; }
    }


    public class ChangeMobileDto
    {
        public string old { get; set; }
        public string mobile { get; set; }
        public string sms { get; set; }
        public string CheckCode { get; set; }

    }

    public class FeedbackDto :APP_MSG
    {
        
    }
    public class MemberFile 
    {
        public List<MemberFileDto> img { get; set; } = new List<MemberFileDto>();

        public List<MemberFileDto> video { get; set; } = new List<MemberFileDto>();
    }
    public class MemberFileDto : APP_SCHOOL_FILE
    {
        public bool ischecked { get; set; }
    }
}

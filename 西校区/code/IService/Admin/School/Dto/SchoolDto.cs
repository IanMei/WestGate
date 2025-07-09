using CMS.Core.Responsity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IService.Admin.School.Dto
{
    public class SchoolDto : APP_SCHOOL
    {
        public List<string> ArrayArea { get; set; } = new List<string>();

        public List<HonorDto> Honors { get; set; } = new List<HonorDto>();

        public List<FacilitiesDto> Facilities1 { get; set; } = new List<FacilitiesDto>();
        public List<FacilitiesDto> Facilities2 { get; set; } = new List<FacilitiesDto>();
        public List<FacilitiesDto> Facilities3 { get; set; } = new List<FacilitiesDto>();

        public List<string> FacilitiesVal1 { get; set; } = new List<string>();
        public List<string> FacilitiesVal2 { get; set; } = new List<string>();
        public List<string> FacilitiesVal3 { get; set; } = new List<string>();

        public bool enabled { get; set; }
        public bool hot { get; set; }
    }


    public class HonorDto : APP_HONOR
    {

    }

    public class FacilitiesDto : APP_FACILITIES
    {
        public bool enabled { get; set; }
    }


    public class SchoolFileDto : APP_SCHOOL_FILE
    {

    }


    public class InterviewDto : APP_INTERVIEW
    {

    }
}

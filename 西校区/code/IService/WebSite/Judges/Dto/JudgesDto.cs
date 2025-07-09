using CMS.Core.Responsity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IService.WebSite.Judges.Dto
{
    public class JudgesDto : APP_JUDGES
    {
        public string CheckCode { get; set; }
        public string Sms { get; set; }
        public string npwd { get; set; }
        public string cpwd { get; set; }


        public List<string> ArrayArea { get; set; } = new List<string>();

        public List<JudgesHonorDto> Honors { get; set; } = new List<JudgesHonorDto>();
        public List<JudgesHonorDto> Resume { get; set; } = new List<JudgesHonorDto>();

    }

    public class JudgesHonorDto : APP_JUDGES_HONOR
    {

    }


    public class JudgesLoginDto
    {
        public string uid { get; set; }
        public string pwd { get; set; }
    }


    public class JudgesChangeMobileDto
    {
        public string old { get; set; }
        public string mobile { get; set; }
        public string sms { get; set; }
        public string CheckCode { get; set; }

    }

    public class JudgesQuestionnaireDto :APP_QUESTIONNAIRE {


        public bool loaded { get; set; } = false;


        public string surplus { get; set; }

        public string reciewDate { get; set; }

        public List<JudgesQuestionnaireItemDto> list { get; set; } = new List<JudgesQuestionnaireItemDto>();
    }

    public class JudgesQuestionnaireItemDto
    {
        public decimal id { get; set; }
        public string title { get; set; }
        public List<JudgesQuestionnaireItemResultDto> result { get; set; } = new List<JudgesQuestionnaireItemResultDto>();
    }
    public class JudgesQuestionnaireItemResultDto
    {
        public decimal id { get; set; }
        public string school_name { get; set; }
        public string reason { get; set; }
    }
}

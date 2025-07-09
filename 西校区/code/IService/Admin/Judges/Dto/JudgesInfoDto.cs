using CMS.Core.Responsity.Tables;
using CMS.IService.Admin.School.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IService.Admin.Judges.Dto
{
    public class JudgesInfoDto : APP_JUDGES
    {
        public List<string> ArrayArea { get; set; } = new List<string>();

        public List<JudgesResumeDto> Honors { get; set; } = new List<JudgesResumeDto>();


        public List<JudgesResumeDto> Resume { get; set; } = new List<JudgesResumeDto>();


        public bool enabled { get; set; }
        public bool main { get; set; }
        public bool special { get; set; }
    }

    public class JudgesResumeDto : APP_JUDGES_HONOR { 
    
    }

    public class QuestionnaireDto : APP_QUESTIONNAIRE
    {
        public List<string> span { get; set; } = new List<string>();

        public List<QuestionnaireItemDto> list { get; set; } = new List<QuestionnaireItemDto>();


        public bool enabled { get; set; }
    }
    public class QuestionnaireItemDto : APP_QUESTIONNAIRE_ITEM
    {

    }


    public class QuestionnaireResultDto : APP_QUESTIONNAIRE_JUDGES
    {

    }
}

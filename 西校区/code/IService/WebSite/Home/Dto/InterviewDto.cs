using CMS.Core.Responsity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IService.WebSite.Home.Dto
{
    public class InterviewDto : APP_INTERVIEW
    {
        public string facilities { get; set; }
        public string link_man { get; set; }
        public string service_tel { get; set; }
        public string email { get; set; }
    }
}

using CMS.Core.Responsity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IService.Admin.Settings.Dto
{
    public class SettingsDto : APP_SETUP
    {
        public List<string> tags { get; set; } = new List<string>();
        public List<LinkDto> details { get; set; } = new List<LinkDto>();

        public bool questionnaire { get; set; } = false;
    }

    public class LinkDto : APP_LINK
    {

    }
}

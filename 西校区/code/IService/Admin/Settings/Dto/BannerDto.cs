using CMS.Core.Responsity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IService.Admin.Settings.Dto
{
    public class BannerDto : APP_BANNER
    {
        public bool enabled { get; set; }
    }

}

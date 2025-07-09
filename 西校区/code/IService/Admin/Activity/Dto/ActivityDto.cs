using CMS.Core.Responsity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IService.Admin.Activity.Dto
{
    public class ActivityDto : APP_ACTIVITY
    {
        public bool enabled { get; set; }
        public bool hot { get; set; }
    }
}

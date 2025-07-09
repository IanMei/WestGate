using CMS.Core.Responsity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IService.Admin.Account.Dto {
    public class AdminInfo : SYS_USER  {
        public string role_no { get; set; }
        public bool enabled { get; set; }
    }
}

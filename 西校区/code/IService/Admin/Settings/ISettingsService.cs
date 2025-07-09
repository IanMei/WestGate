using CMS.IService.Admin.Settings.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IService.Admin
{
    public interface ISettingsService
    {
        ApiResult GetInfo();
        ApiResult Update(SettingsDto request);
    }
}

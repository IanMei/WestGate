using CMS.Core.Common;
using CMS.IService;
using CMS.IService.Admin;
using CMS.IService.Admin.Settings.Dto;
using ElementUI.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElementUI.Admin.Areas.Admin.Controllers.Settings
{
    /// <summary>
    /// 网站设置
    /// </summary>
    [ApiResultFilter, ApiExceptionFilter]
    public class SettingsController : BaseApiController
    {
        private ISettingsService service;
        public SettingsController(ISettingsService _service)
        {
            service = _service;
        }
        /// <summary>
        /// 获取详情
        /// </summary>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "900030032")]
        public ApiResult GetInfo()
        {
            var rs = service.GetInfo();
            return rs;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="request"></param>
        [HttpPost, ApiPermission(OperationCode = "900030032")]
        public ApiResult Update([FromBody]SettingsDto request)
        {
            return service.Update(request);
        }
    }
}

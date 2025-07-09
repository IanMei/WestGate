using CMS.Core.Common;
using CMS.IService;
using CMS.IService.Admin;
using CMS.IService.Admin.Account.Dto;
using ElementUI.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElementUI.Admin.Areas.Admin.Controllers.Account
{
    /// <summary>
    /// 附件管理
    /// </summary>
    [ApiResultFilter, ApiExceptionFilter]
    public class FileController : BaseApiController
    {
        private readonly IFileService service;

        public FileController(IFileService _service)
        {
            service = _service;
        }

        [HttpGet]
        public ApiResult List()
        {
            var rs = service.List();
            return rs;
        }
       
        [HttpPost]
        public ApiResult Update([FromBody]FileForm request)
        {
            var rs = service.Update(request);
            return rs;
        }
    }
}

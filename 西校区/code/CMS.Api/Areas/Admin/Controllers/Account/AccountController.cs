using CMS.IService;
using CMS.IService.Admin;
using CMS.IService.Admin.Account.Dto;
using ElementUI.Admin.Filters;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElementUI.Admin.Areas.Admin.Controllers.Account
{
    /// <summary>
    /// 账户管理
    /// </summary>
    [ApiResultFilter, ApiExceptionFilter]
    public class AccountController : BaseApiController {
        private readonly IAccountService service;
        public AccountController(IAccountService _service)
        {
            service = _service;
        }
        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, AllowAnonymous]
        [SwaggerResponse(HttpStatusCode.OK, "接口返回值结构和字段含义", Type = typeof(ApiResult<loginUserDto>))]
        public ApiResult Login(loginManageDto request)
        {
            var rs = service.Login(request);
            return rs;
        }

        /// <summary>
        /// 用户菜单
        /// </summary>
        /// <param name="uuid">uuid</param>
        /// <returns></returns>
        [HttpGet, AllowAnonymous]
        public ApiResult UserMenus(decimal uuid)
        {
            var rs = service.UserMenus(uuid);
            return rs;
        }



    }
}

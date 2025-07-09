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
    /// 账户管理
    /// </summary>
    [ApiResultFilter, ApiExceptionFilter]
    public class RoleController : BaseApiController {
        private readonly IRoleService service;

        public RoleController(IRoleService _service)
        {
            service = _service;
        }
        /// <summary>
        /// 角色分页数据获取
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "900010030")]
        public ApiResult GetPagedList([FromUri] int page, int size)
        {
            var rs = service.GetPagedRolesList(page, size);
            return rs;
        }
        /// <summary>
        /// 获取单个角色数据
        /// </summary>
        /// <param name="id">记录Id</param>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "900010032")]
        public ApiResult Get([FromUri]decimal id)
        {
            var rs = service.Get(id);
            return rs;
        }
        /// <summary>
        /// 设置角色状态
        /// </summary>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "900010032")]
        public ApiResult SetStatus([FromUri]decimal recordId)
        {
            var rs = service.SetStatus(recordId);
            return rs;
        }
        /// <summary>
        /// 保存角色数据（新增、编辑）
        /// </summary>
        /// <param name="request"></param>
        [HttpPost, ApiPermission(OperationCode = "900010031|900010032")]
        public ApiResult UpdateData([FromBody]RoleInfo request)
        {
            var rs = service.Update(request);
            return rs;
        }
        /// <summary>
        /// 删除角色数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "900010033")]
        public ApiResult Delete([FromUri]string ids)
        {
            var rs = service.Delete(ids);
            return rs;
        }
    }
}

using CMS.Core.Common;
using CMS.IService;
using CMS.IService.Admin;
using CMS.IService.Admin.Account.Dto;
using CMS.IService.Admin.Activity.Dto;
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
    /// 活动管理
    /// </summary>
    [ApiResultFilter, ApiExceptionFilter]
    public class ActivityController : BaseApiController
    {
        private readonly IActivityService service;

        public ActivityController(IActivityService _service)
        {
            service = _service;
        }
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "100010030")]
        public ApiResult GetPagedList([FromUri] int page, int size)
        {
            var rs = service.List(page, size);
            return rs;
        }
        /// <summary>
        /// 获取行
        /// </summary>
        /// <param name="id">记录Id</param>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "100010032")]
        public ApiResult Get([FromUri]decimal id)
        {
            var rs = service.Get(id);
            return rs;
        }
        /// <summary>
        /// 设置状态
        /// </summary>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "100010032")]
        public ApiResult State([FromUri]decimal recordId)
        {
            var rs = service.State(recordId);
            return rs;
        }
        /// <summary>
        /// 设置状态
        /// </summary>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "100010032")]
        public ApiResult Recommend([FromUri] decimal recordId)
        {
            var rs = service.Recommend(recordId);
            return rs;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="request"></param>
        [HttpPost, ApiPermission(OperationCode = "100010031|100010032")]
        public ApiResult UpdateData([FromBody] ActivityDto request)
        {
            var rs = service.Update(request);
            return rs;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "100010033")]
        public ApiResult Delete([FromUri]string ids)
        {
            var rs = service.Delete(ids);
            return rs;
        }

        /// <summary>
        /// 活动下拉框
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ApiResult Select()
        {
            var rs = service.Select();
            return rs;
        }
    }
}

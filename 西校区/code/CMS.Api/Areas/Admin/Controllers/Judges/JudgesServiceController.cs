using CMS.IService;
using CMS.IService.Admin;
using CMS.IService.Admin.Judges.Dto;
using ElementUI.Admin.Filters;
using System.Web.Http;

namespace ElementUI.Admin.Areas.Admin.Controllers.Account
{
    /// <summary>
    /// 活动管理
    /// </summary>
    [ApiResultFilter, ApiExceptionFilter]
    public class JudgesServiceController : BaseApiController
    {
        private readonly IJudgesService service;

        public JudgesServiceController(IJudgesService _service)
        {
            service = _service;
        }



        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "400010030")]
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
        [HttpGet, ApiPermission(OperationCode = "400010032")]
        public ApiResult Get([FromUri]decimal id)
        {
            var rs = service.Get(id);
            return rs;
        }
        /// <summary>
        /// 设置状态
        /// </summary>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "400010032")]
        public ApiResult State([FromUri]decimal recordId)
        {
            var rs = service.State(recordId);
            return rs;
        }

        /// <summary>
        /// 设置主审
        /// </summary>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "400010032")]
        public ApiResult Main([FromUri] decimal recordId)
        {
            var rs = service.Main(recordId);
            return rs;
        }

        /// <summary>
        /// 设置特邀
        /// </summary>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "400010032")]
        public ApiResult Special([FromUri] decimal recordId)
        {
            var rs = service.Special(recordId);
            return rs;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="request"></param>
        [HttpPost, ApiPermission(OperationCode = "400010031|400010032")]
        public ApiResult UpdateData([FromBody] JudgesInfoDto request)
        {
            var rs = service.Update(request);
            return rs;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "400010033")]
        public ApiResult Delete([FromUri]string ids)
        {
            var rs = service.Delete(ids);
            return rs;
        }


    }
}

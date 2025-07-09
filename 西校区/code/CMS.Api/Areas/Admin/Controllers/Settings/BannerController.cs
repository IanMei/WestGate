using CMS.IService;
using CMS.IService.Admin.Settings;
using CMS.IService.Admin.Settings.Dto;
using ElementUI.Admin.Filters;
using System.Web.Http;

namespace ElementUI.Admin.Areas.Admin.Controllers.Course
{
    /// <summary>
    /// 账户管理
    /// </summary>
    [ApiResultFilter, ApiExceptionFilter]
    public class BannerController : BaseApiController
    {
        private readonly IBannerService service;

        public BannerController(IBannerService _service)
        {
            service = _service;
        }

        /// <summary>
        /// 图片位置
        /// </summary>
        [HttpGet]
        public ApiResult Types()
        {
            var rs = service.Types();
            return rs;
        }

        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "900040030")]
        public ApiResult List( int page =1, int size = 15)
        {
            var rs = service.List(page, size);
            return rs;
        }
        /// <summary>
        /// 获取单个条记录
        /// </summary>
        /// <param name="id">记录Id</param>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "900040032")]
        public ApiResult Get([FromUri]decimal id)
        {
            var rs = service.Get(id);
            return rs;
        }
        /// <summary>
        /// 设置可用
        /// </summary>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "900040032")]
        public ApiResult State([FromUri]decimal recordId)
        {
            var rs = service.State(recordId);
            return rs;
        }
        /// <summary>
        /// 保存单条数据
        /// </summary>
        /// <param name="request"></param>
        [HttpPost, ApiPermission(OperationCode = "900040031|900040032")]
        public ApiResult UpdateData([FromBody] BannerDto request)
        {
            var rs = service.Update(request);
            return rs;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "900040033")]
        public ApiResult Delete([FromUri]string ids)
        {
            var rs = service.Delete(ids);
            return rs;
        }
       
    }
}

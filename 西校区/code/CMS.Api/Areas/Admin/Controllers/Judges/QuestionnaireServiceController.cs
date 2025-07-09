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
    public class QuestionnaireServiceController : BaseApiController
    {
        private readonly IQuestionnaireService service;

        public QuestionnaireServiceController(IQuestionnaireService _service)
        {
            service = _service;
        }



        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "400020030")]
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
        [HttpGet, ApiPermission(OperationCode = "400020032")]
        public ApiResult Get([FromUri]decimal id)
        {
            var rs = service.Get(id);
            return rs;
        }


        /// <summary>
        /// 获取问卷结果
        /// </summary>
        /// <param name="id">记录Id</param>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "400020032")]
        public ApiResult Result([FromUri] decimal id)
        {
            var rs = service.Result(id);
            return rs;
        }

        /// <summary>
        /// 设置状态
        /// </summary>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "400020032")]
        public ApiResult State([FromUri]decimal recordId)
        {
            var rs = service.State(recordId);
            return rs;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="request"></param>
        [HttpPost, ApiPermission(OperationCode = "400020031|400020032")]
        public ApiResult UpdateData([FromBody] QuestionnaireDto request)
        {
            var rs = service.Update(request);
            return rs;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet, ApiPermission(OperationCode = "400020033")]
        public ApiResult Delete([FromUri]string ids)
        {
            var rs = service.Delete(ids);
            return rs;
        }


    }
}

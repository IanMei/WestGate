using CMS.Core.Common;
using CMS.Core.Common.TableExtend;
using CMS.Core.Responsity;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using CMS.IService;
using CMS.IService.Admin;
using CMS.IService.Admin.Account.Dto;
using CMS.IService.Admin.BaseData.Dto;
using CMS.IService.Admin.School.Dto;
using System;
using System.Collections.Generic;
using System.Data;

namespace CMS.Service.Admin
{
    public class InterviewService : IInterviewService
    {
        private ParamCollection query = new ParamCollection();
        private IBaseRepository<SqlServercfg> bll;
        public InterviewService(IBaseRepository<SqlServercfg> _bll)
        {
            bll = _bll;
        }

        /// <summary>
        /// 角色分页数据获取
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ApiResult List(int page, int size)
        {
            ParamCollection paraList = new ParamCollection();
            string clause = string.Empty;
            string column = "";

            var query = System.Web.HttpContext.Current.Request.QueryString;
            if (!string.IsNullOrEmpty(query["school_no"]))
            {
                column = APP_INTERVIEW.SCHOOL_NO_FIELD;
                clause += string.Format("AND ({0}.{1} = @{1})", APP_INTERVIEW.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, query["school_no"]));
            }
            if (clause.Length > 3)
            {
                clause = clause.Substring(3, clause.Length - 3);
            }
            paraList.Clause = clause;
            var queryList = bll.SelectByPageIndex<APP_INTERVIEW>(paraList, "APP_INTERVIEW.CREATE_TIME DESC", page, size, out int pageCount);
            if (queryList.Count == 0 && page > 1)
            {
                var sp = page - 1;
                return List(page, sp);
            }
            var list = new List<InterviewDto>();
            foreach (var item in queryList)
            {
                var row = item.ConvertTo<InterviewDto>();
                list.Add(row);
            }
            var result = new RequestMessagePageList<List<InterviewDto>>(list, pageCount, page, size);
            return new ApiResult<RequestMessageBase<List<InterviewDto>>>().SetSuccessResult(result);
        }

        /// <summary>
        /// 获取单个角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ApiResult Get(decimal id)
        {
            var info = new InterviewDto() { PICTURE_MINI = -1 };
            var item = bll.Get<APP_INTERVIEW>(id);
            if (item != null)
            {
                info = item.ConvertTo<InterviewDto>();
            }
            return new ApiResult<InterviewDto>().SetSuccessResult(info);
        }
        /// <summary>
        /// 更新角色
        /// </summary>
        public ApiResult Update(InterviewDto form)
        {
            var item = form.ConvertTo<APP_INTERVIEW>();

            if (item.ID > 0)
            {
                item.CurModel = DealModel.Modify;
            }
            else
            {
                item.CurModel = DealModel.New;
                item.DATE_PUBLISH = DateTime.Now;
            }
            decimal id = bll.Update(item);
            if (item.CurModel == DealModel.Modify)
            {
                id = item.ID;
            }
            return new ApiResult<decimal>().SetSuccessResult(id);
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="rodeIdSplitStr">角色Id</param>
        public ApiResult Delete(string rodeIdSplitStr)
        {
            string[] arrs = rodeIdSplitStr.Split(',');
            if (arrs.Length > 0)
            {
                int rows = 0;
                foreach (string item in arrs)
                {
                    var model = bll.Get<APP_INTERVIEW>(Convert.ToDecimal(item));
                    if (model != null)
                    {
                        decimal id = bll.Delete(model);
                        rows += (int)id;
                    }
                }
                if (rows < arrs.Length)
                {
                    return new ApiResult().SetFailedResult(-1, string.Format("{0}条数据删除成功", rows));
                }
                return new ApiResult<int>().SetSuccessResult(rows);
            }
            else
            {
                return new ApiResult().SetFailedResult(-1, "数据删除失败");
            }
        }
    }
}

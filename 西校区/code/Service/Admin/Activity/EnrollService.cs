using CMS.Core.Common;
using CMS.Core.Common.TableExtend;
using CMS.Core.Responsity;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using CMS.IService;
using CMS.IService.Admin;
using CMS.IService.Admin.Activity.Dto;
using System;
using System.Collections.Generic;
using System.Data;

namespace CMS.Service.Admin
{
    public class EnrollService : IEnrollService
    {
        private IBaseRepository<SqlServercfg> bll;
        public EnrollService(IBaseRepository<SqlServercfg> _bll)
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
            if (!string.IsNullOrEmpty(query["activity_no"]))
            {
                column = APP_ACTIVITY_ENROLL.ACTIVITY_NO_FIELD;
                clause += string.Format("AND ({0}.{1} = @{1})", APP_ACTIVITY_ENROLL.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String,  query["activity_no"]));
            }
            if (clause.Length > 3)
            {
                clause = clause.Substring(3, clause.Length - 3);
            }
            paraList.Clause = clause;
            var queryList = bll.SelectByPageIndex<APP_ACTIVITY_ENROLL>(paraList, "APP_ACTIVITY_ENROLL.CREATE_TIME DESC", page, size, out int pageCount);
            if (queryList.Count == 0 && page > 1)
            {
                var sp = page - 1;
                return List(page, sp);
            }
            var list = new List<EnrollDto>();
            foreach (var item in queryList)
            {
                var row = item.ConvertTo<EnrollDto>();

                list.Add(row);
            }

            var result = new RequestMessagePageList<List<EnrollDto>>(list, pageCount, page, size);
            return new ApiResult<RequestMessageBase<List<EnrollDto>>>().SetSuccessResult(result);
        }
        /// <summary>
        /// 获取单个角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ApiResult Get(decimal id)
        {
            var info = new EnrollDto() { };
            var item = bll.Get<APP_ACTIVITY_ENROLL>(id);
            if (item != null)
            {
                info = item.ConvertTo<EnrollDto>();
            }
            return new ApiResult<EnrollDto>().SetSuccessResult(info);
        }
        /// <summary>
        /// 更新角色
        /// </summary>
        public ApiResult Update(EnrollDto form)
        {
            var item = form.ConvertTo<APP_ACTIVITY_ENROLL>();
            if (item.ID > 0)
            {
                item.CurModel = DealModel.Modify;
            }
            else
            {
                item.CurModel = DealModel.New;
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
                    var model = bll.Get<APP_ACTIVITY_ENROLL>(Convert.ToDecimal(item));
                    if (model != null )
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

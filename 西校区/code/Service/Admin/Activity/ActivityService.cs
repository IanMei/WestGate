using CMS.Core.Common;
using CMS.Core.Common.TableExtend;
using CMS.Core.Responsity;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using CMS.IService;
using CMS.IService.Admin;
using CMS.IService.Admin.Account.Dto;
using CMS.IService.Admin.Activity.Dto;
using System;
using System.Collections.Generic;
using System.Data;

namespace CMS.Service.Admin
{
    public class ActivityService : IActivityService
    {
        private IBaseRepository<SqlServercfg> bll;
        public ActivityService(IBaseRepository<SqlServercfg> _bll)
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
            if (!string.IsNullOrEmpty(query["title"]))
            {
                column = APP_ACTIVITY.ACTIVITY_NAME_FIELD;
                clause += string.Format("AND ({0}.{1} LIKE @{1})", APP_ACTIVITY.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, "%" + query["title"] + "%"));
            }
            if (clause.Length > 3)
            {
                clause = clause.Substring(3, clause.Length - 3);
            }
            paraList.Clause = clause;
            var queryList = bll.SelectByPageIndex<APP_ACTIVITY>(paraList, "APP_ACTIVITY.IS_HOT DESC,APP_ACTIVITY.SEQ_NO ASC,APP_ACTIVITY.CREATE_TIME DESC", page, size, out int pageCount);
            if (queryList.Count == 0 && page > 1)
            {
                var sp = page - 1;
                return List(page, sp);
            }
            var list = new List<ActivityDto>();
            foreach (var item in queryList)
            {
                var row = item.ConvertTo<ActivityDto>();

                row.enabled = item.IS_ENABLED == 1;
                row.hot = item.IS_HOT == 1;
                list.Add(row);
            }

            var result = new RequestMessagePageList<List<ActivityDto>>(list, pageCount, page, size);
            return new ApiResult<RequestMessageBase<List<ActivityDto>>>().SetSuccessResult(result);
        }
        /// <summary>
        /// 获取单个角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ApiResult Get(decimal id)
        {
            var info = new ActivityDto() { PICTURE_MINI = -1 };
            var item = bll.Get<APP_ACTIVITY>(id);
            if (item != null)
            {
                info = item.ConvertTo<ActivityDto>();
                info.enabled = info.IS_ENABLED == 1;
            }
            return new ApiResult<ActivityDto>().SetSuccessResult(info);
        }
        /// <summary>
        /// 更新角色
        /// </summary>
        public ApiResult Update(ActivityDto form)
        {
            var item = form.ConvertTo<APP_ACTIVITY>();
            if (item.ID > 0)
            {
                item.CurModel = DealModel.Modify;
            }
            else
            {
                item.ACTIVITY_NO = bll.GetSeqNo("ANN");
                item.CurModel = DealModel.New;
                item.IS_ENABLED = 1;
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
                    var model = bll.Get<APP_ACTIVITY>(Convert.ToDecimal(item));
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
        /// <summary>
        /// 设置角色状态
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ApiResult State(decimal roleId)
        {
            bool state = false;
            var currentRow = bll.Get<APP_ACTIVITY>(roleId);
            if (currentRow != null)
            {
                currentRow.CurModel = DealModel.Modify;
                currentRow.IS_ENABLED = currentRow.IS_ENABLED.Equals(0) ? 1 : 0;
                decimal id = bll.Update(currentRow);
                if (currentRow.CurModel == DealModel.Modify)
                {
                    id = currentRow.ID;
                }
                if (id > 0)
                {
                    state = Convert.ToBoolean(currentRow.IS_ENABLED);
                }
            }
            return new ApiResult<bool>().SetSuccessResult(state);
        }

        public ApiResult Recommend(decimal id)
        {
            bool state = false;
            var currentRow = bll.Get<APP_ACTIVITY>(id);
            if (currentRow != null)
            {
                currentRow.CurModel = DealModel.Modify;
                currentRow.IS_HOT = currentRow.IS_HOT.Equals(0) ? 1 : 0;
                decimal ss = bll.Update(currentRow);
                if (currentRow.CurModel == DealModel.Modify)
                {
                    ss = currentRow.ID;
                }
                if (ss > 0)
                {
                    state = Convert.ToBoolean(currentRow.IS_ENABLED);
                }
            }
            return new ApiResult<bool>().SetSuccessResult(state);
        }

        public ApiResult Select()
        {
            ParamCollection paraList = new ParamCollection();
            string clause = string.Empty;
            var queryList = bll.Select<APP_ACTIVITY>(paraList);
            var droplist = new List<DropdownItem>();
            queryList.ForEach(a =>
            {
                droplist.Add(new DropdownItem
                {
                    Value = a.ACTIVITY_NO,
                    Label = a.ACTIVITY_NAME
                });
            });
            return new ApiResult<List<DropdownItem>>().SetSuccessResult(droplist);
        }
    }
}

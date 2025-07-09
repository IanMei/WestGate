using CMS.Core.Common;
using CMS.Core.Common.TableExtend;
using CMS.Core.Responsity;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using CMS.IService;
using CMS.IService.Admin;
using CMS.IService.Admin.Account.Dto;
using CMS.IService.Admin.Activity.Dto;
using CMS.IService.Admin.BaseData.Dto;
using System;
using System.Collections.Generic;
using System.Data;

namespace CMS.Service.Admin
{
    public class HelpService : IHelpService
    {
        private string aboutType = "02";
        private IBaseRepository<SqlServercfg> bll;
        public HelpService(IBaseRepository<SqlServercfg> _bll)
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
                column = APP_HELP.TITLE_FIELD;
                clause += string.Format("AND ({0}.{1} LIKE @{1})", APP_HELP.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, "%" + query["title"] + "%"));
            }
            if (clause.Length > 3)
            {
                clause = clause.Substring(3, clause.Length - 3);
            }
            paraList.Clause = clause;
            var queryList = bll.SelectByPageIndex<APP_HELP>(paraList, "APP_HELP.CREATE_TIME DESC", page, size, out int pageCount);
            if (queryList.Count == 0 && page > 1)
            {
                var sp = page - 1;
                return List(page, sp);
            }
            var list = new List<HelpDto>();
            foreach (var item in queryList)
            {
                var row = item.ConvertTo<HelpDto>();
                row.enabled = item.IS_ENABLED == 1;
                list.Add(row);
            }
            var result = new RequestMessagePageList<List<HelpDto>>(list, pageCount, page, size);
            return new ApiResult<RequestMessageBase<List<HelpDto>>>().SetSuccessResult(result);
        }

        /// <summary>
        /// 获取单个角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ApiResult Get(decimal id)
        {
            var info = new HelpDto() { PICTURE_MINI = -1 };
            var item = bll.Get<APP_HELP>(id);
            if (item != null)
            {
                info = item.ConvertTo<HelpDto>();
                info.enabled = info.IS_ENABLED == 1;
            }
            return new ApiResult<HelpDto>().SetSuccessResult(info);
        }
        /// <summary>
        /// 更新角色
        /// </summary>
        public ApiResult Update(HelpDto form)
        {
            var item = form.ConvertTo<APP_HELP>();
            if (item.ID > 0)
            {
                item.CurModel = DealModel.Modify;
            }
            else
            {
                item.HELP_NO = bll.GetSeqNo("HPN");
                item.DATE_PUBLISH = DateTime.Now;
                item.CurModel = DealModel.New;
                item.IS_ENABLED = 1;
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
                    var model = bll.Get<APP_HELP>(Convert.ToDecimal(item));
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
        /// <summary>
        /// 设置角色状态
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ApiResult State(decimal roleId)
        {
            bool state = false;
            var currentRow = bll.Get<APP_HELP>(roleId);
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
    }
}

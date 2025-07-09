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
    public class DictionaryService : IDictionaryService
    {
        private IBaseRepository<SqlServercfg> bll;
        public DictionaryService(IBaseRepository<SqlServercfg> _bll)
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
                column = BASE_TYPE.TYPE_NAME_FIELD;
                clause += string.Format("AND ({0}.{1} LIKE @{1})", BASE_TYPE.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, "%" + query["title"] + "%"));
            }
            if (!string.IsNullOrEmpty(query["state"]))
            {
                column = BASE_TYPE.CLASS_NO_FIELD;
                clause += string.Format("AND ({0}.{1} = @{1})", BASE_TYPE.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, query["state"]));
            }
            if (clause.Length > 3)
            {
                clause = clause.Substring(3, clause.Length - 3);
            }
            paraList.Clause = clause;
            var queryList = bll.SelectByPageIndex<BASE_TYPE>(paraList, "BASE_TYPE.CREATE_TIME DESC", page, size, out int pageCount);
            if (queryList.Count == 0 && page > 1)
            {
                var sp = page - 1;
                return List(page, sp);
            }
            var list = new List<DictionaryDto>();
            foreach (var item in queryList)
            {
                var row = item.ConvertTo<DictionaryDto>();
                row.enabled = item.IS_ENABLED == 1;
                list.Add(row);
            }

            var result = new RequestMessagePageList<List<DictionaryDto>>(list, pageCount, page, size);
            return new ApiResult<RequestMessageBase<List<DictionaryDto>>>().SetSuccessResult(result);
        }
        /// <summary>
        /// 获取单个角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ApiResult Get(decimal id)
        {
            var info = new DictionaryDto() {  };
            var item = bll.Get<BASE_TYPE>(id);
            if (item != null)
            {
                info = item.ConvertTo<DictionaryDto>();
                info.enabled = info.IS_ENABLED == 1;
            }
            return new ApiResult<DictionaryDto>().SetSuccessResult(info);
        }
        /// <summary>
        /// 更新角色
        /// </summary>
        public ApiResult Update(DictionaryDto form)
        {
            var item = form.ConvertTo<BASE_TYPE>();
            if (item.ID > 0)
            {
                item.CurModel = DealModel.Modify;
            }
            else
            {
                item.TYPE_NO = bll.GetSeqNo("TPN");
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
                    var model = bll.Get<BASE_TYPE>(Convert.ToDecimal(item));
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
            var currentRow = bll.Get<BASE_TYPE>(roleId);
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

        public ApiResult Index()
        {
            ParamCollection paraList = new ParamCollection();
            string clause = string.Empty;
            string column = "";
            var query = System.Web.HttpContext.Current.Request.QueryString;
            column = BASE_CLASS.IS_ENABLED_FIELD;
            clause += string.Format("AND ({0}.{1} = 1)", BASE_CLASS.TABLE_NAME, column);
            if (clause.Length > 3)
            {
                clause = clause.Substring(3, clause.Length - 3);
            }
            paraList.Clause = clause;

            var queryList = bll.Select<BASE_CLASS>(paraList);
            var droplist = new List<DropdownItem>();
            queryList.ForEach(a =>
            {
                droplist.Add(new DropdownItem
                {
                    Value = a.CLASS_NO,
                    Label = a.CLASS_NAME
                });
            });
            return new ApiResult<List<DropdownItem>>().SetSuccessResult(droplist);
        }

        public ApiResult Select(string indexCode)
        {
            ParamCollection paraList = new ParamCollection();
            string clause = string.Empty;
            string column = "";
            var query = System.Web.HttpContext.Current.Request.QueryString;

            column = BASE_TYPE.CLASS_NO_FIELD;
            clause += string.Format("AND ({0}.{1} = @{1})", BASE_TYPE.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.String, indexCode));
            if (clause.Length > 3)
            {
                clause = clause.Substring(3, clause.Length - 3);
            }
            paraList.Clause = clause;
            var queryList = bll.Select<BASE_TYPE>(paraList);
            var droplist = new List<DropdownItem>();
            queryList.ForEach(a =>
            {
                droplist.Add(new DropdownItem
                {
                    Value = a.TYPE_NO,
                    Label = a.TYPE_NAME
                });
            });
            return new ApiResult<List<DropdownItem>>().SetSuccessResult(droplist);
        }
    }
}

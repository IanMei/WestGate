using CMS.Core.Common;
using CMS.Core.Common.TableExtend;
using CMS.Core.Responsity;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using CMS.IService;
using CMS.IService.Admin.Account.Dto;
using CMS.IService.Admin.Settings;
using CMS.IService.Admin.Settings.Dto;
using System;
using System.Collections.Generic;
using System.Data;

namespace CMS.Service.Admin
{
    public class BannerService : IBannerService
    {
        private IBaseRepository<SqlServercfg> bll;
        public BannerService(IBaseRepository<SqlServercfg> _bll)
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
                column = APP_BANNER.BANNER_TITLE_FIELD;
                clause += string.Format("AND ({0}.{1} LIKE @{1})", APP_BANNER.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, "%" + query["title"] + "%"));
            }
            if (!string.IsNullOrEmpty(query["state"]))
            {
                column = APP_BANNER.BANNER_TYPE_FIELD;
                clause += string.Format("AND ({0}.{1} = @{1})", APP_BANNER.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, query["state"] ));
            }
            if (clause.Length > 3)
            {
                clause = clause.Substring(3, clause.Length - 3);
            }
            paraList.Clause = clause;
            var queryList = bll.SelectByPageIndex<APP_BANNER>(paraList, "APP_BANNER.BANNER_TYPE ASC,APP_BANNER.SEQ_NO ASC ", page, size, out int pageCount);
            if (queryList.Count == 0 && page > 1)
            {
                var sp = page - 1;
                return List(page, sp);
            }
            var list = new List<BannerDto>();
            foreach (var item in queryList)
            {
                var row = item.ConvertTo<BannerDto>();
                row.enabled = item.IS_ENABLED == 1;
                list.Add(row);
            }

            var result = new RequestMessagePageList<List<BannerDto>>(list, pageCount, page, size);
            return new ApiResult<RequestMessageBase<List<BannerDto>>>().SetSuccessResult(result);
        }

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ApiResult Get(decimal id)
        {
            var info = new BannerDto() {  IMAGE_ID=-1 };
            var item = bll.Get<APP_BANNER>(id);
            if (item != null)
            {
                info = item.ConvertTo<BannerDto>();
               
            }
           
            return new ApiResult<BannerDto>().SetSuccessResult(info);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        public ApiResult Update(BannerDto form)
        {
            var item = form.ConvertTo<APP_BANNER>();
            if (item.ID > 0)
            {
                item.CurModel = DealModel.Modify;
            }
            else
            {
                item.CurModel = DealModel.New;
                item.BANNER_NO = bll.GetSeqNo("ABN",3);
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
        /// 删除数据
        /// </summary>
        /// <param name="rodeIdSplitStr">ID字符串英文逗号分割</param>
        public ApiResult Delete(string idStr)
        {
            string[] arrs = idStr.Split(',');
            if (arrs.Length > 0)
            {
                int rows = 0;
                foreach (string item in arrs)
                {
                    if (RegHelper.IsDecimal(item)) {
                        var model = bll.Get<APP_BANNER>(Convert.ToDecimal(item));
                        if (model != null)
                        {
                            decimal id = bll.Delete(model);

                            rows += (int)id;
                        }
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
        /// 设置可用
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ApiResult State(decimal id)
        {
            bool state = false;
            var currentRow = bll.Get<APP_BANNER>(id);
            if (currentRow != null)
            {
                currentRow.CurModel = DealModel.Modify;
                currentRow.IS_ENABLED = currentRow.IS_ENABLED.Equals(0) ? 1 : 0;
                decimal rs = bll.Update(currentRow);
                if (currentRow.CurModel == DealModel.Modify)
                {
                    rs = currentRow.ID;
                }
                if (id > 0)
                {
                    state = Convert.ToBoolean(currentRow.IS_ENABLED);
                }
            }
            return new ApiResult<bool>().SetSuccessResult(state);
        }


        public ApiResult Types()
        {

            var list = new List<DropdownItem>();
            list.Add(new DropdownItem
            {
                Value = "01",
                Label = "首页"
            });
            list.Add(new DropdownItem
            {
                Value = "02",
                Label = "活动管理"
            });
            list.Add(new DropdownItem
            {
                Value = "03",
                Label = "会员校长"
            });
            list.Add(new DropdownItem
            {
                Value = "04",
                Label = "每周名校"
            });
            list.Add(new DropdownItem
            {
                Value = "05",
                Label = "School - Wiki"
            });
            list.Add(new DropdownItem
            {
                Value = "06",
                Label = "评委详情"
            });
            return new ApiResult<List<DropdownItem>>().SetSuccessResult(list);
        }
    }
}

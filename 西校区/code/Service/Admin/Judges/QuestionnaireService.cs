using CMS.Core.Common;
using CMS.Core.Common.TableExtend;
using CMS.Core.Responsity;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using CMS.IService;
using CMS.IService.Admin;
using CMS.IService.Admin.Account.Dto;
using CMS.IService.Admin.BaseData.Dto;
using CMS.IService.Admin.Judges.Dto;
using CMS.IService.Admin.School.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CMS.Service.Admin
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private ParamCollection query = new ParamCollection();
        private IBaseRepository<SqlServercfg> bll;
        public QuestionnaireService(IBaseRepository<SqlServercfg> _bll)
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
                column = APP_QUESTIONNAIRE.QUESTIONNAIRE_TITLE_FIELD;
                clause += string.Format("AND ({0}.{1} LIKE @{1})", APP_QUESTIONNAIRE.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, "%" + query["title"] + "%"));
            }
            if (clause.Length > 3)
            {
                clause = clause.Substring(3, clause.Length - 3);
            }
            paraList.Clause = clause;
            var queryList = bll.SelectByPageIndex<APP_QUESTIONNAIRE>(paraList, "APP_QUESTIONNAIRE.CREATE_TIME DESC", page, size, out int pageCount);
            if (queryList.Count == 0 && page > 1)
            {
                var sp = page - 1;
                return List(page, sp);
            }
            var list = new List<QuestionnaireDto>();
            foreach (var item in queryList)
            {
                var row = item.ConvertTo<QuestionnaireDto>();
                row.enabled = item.IS_ENABLED == 1;
                list.Add(row);
            }
            var result = new RequestMessagePageList<List<QuestionnaireDto>>(list, pageCount, page, size);
            return new ApiResult<RequestMessageBase<List<QuestionnaireDto>>>().SetSuccessResult(result);
        }

        /// <summary>
        /// 获取单个角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ApiResult Get(decimal id)
        {
            var info = new QuestionnaireDto() { };
            var item = bll.Get<APP_QUESTIONNAIRE>(id);
            if (item != null)
            {

                info = item.ConvertTo<QuestionnaireDto>();
                query.Clause = string.Format("APP_QUESTIONNAIRE_ITEM.QUESTIONNAIRE_NO = '{0}'", item.QUESTIONNAIRE_NO);
                var list = bll.Select<APP_QUESTIONNAIRE_ITEM>(query);
                list.ForEach(a =>
                {
                    info.list.Add(a.ConvertTo<QuestionnaireItemDto>());
                });
                if (item.QUESTIONNAIRE_START != null && item.QUESTIONNAIRE_END != null)
                {

                    info.span.Add(item.QUESTIONNAIRE_START.Value.ToString("yyyy-MM-dd HH:mm"));
                    info.span.Add(item.QUESTIONNAIRE_END.Value.ToString("yyyy-MM-dd HH:mm"));
                }

                info.enabled = info.IS_ENABLED == 1;
            }
            return new ApiResult<QuestionnaireDto>().SetSuccessResult(info);
        }

        public ApiResult Result(decimal id)
        {
            var info = new List<QuestionnaireResultDto>();
            var item = bll.Get<APP_QUESTIONNAIRE>(id);
            if (item != null)
            {
                query.Clause = string.Format("APP_QUESTIONNAIRE_JUDGES.QUESTIONNAIRE_NO = '{0}'", item.QUESTIONNAIRE_NO);
                var data = bll.Select<APP_QUESTIONNAIRE_JUDGES>(query, "APP_QUESTIONNAIRE_JUDGES.JUDGES_NO ASC,APP_QUESTIONNAIRE_JUDGES.ITEM_ID ASC");

                data.ForEach(a => {
                    info.Add(a.ConvertTo<QuestionnaireResultDto>());
                });
            }
            return new ApiResult<List<QuestionnaireResultDto>>().SetSuccessResult(info);
        }
        /// <summary>
        /// 更新角色
        /// </summary>
        public ApiResult Update(QuestionnaireDto form)
        {
            var item = form.ConvertTo<APP_QUESTIONNAIRE>();

            if (item.ID > 0)
            {
                item.CurModel = DealModel.Modify;
            }
            else
            {
                item.QUESTIONNAIRE_NO = bll.GetSeqNo("QUN");
                item.CurModel = DealModel.New;
                item.IS_ENABLED = 1;
            }

            if (form.span.Count > 1)
            {
                if (RegHelper.IsDateTime(form.span[0]))
                {
                    item.QUESTIONNAIRE_START = DateTime.Parse(form.span[0]);
                }
                if (RegHelper.IsDateTime(form.span[1]))
                {
                    item.QUESTIONNAIRE_END = DateTime.Parse(form.span[1]);
                }
            }

            #region 荣誉

            var details = new BaseList();
            query.Clause = string.Format("APP_QUESTIONNAIRE_ITEM.QUESTIONNAIRE_NO = @JUDGES_NO");
            query.Add(new ParamData { ParamName = "JUDGES_NO", DataType = DbType.String, Value = item.QUESTIONNAIRE_NO });
            var list = bll.Select<APP_QUESTIONNAIRE_ITEM>(query);
            list.ForEach(a => a.CurModel = DealModel.Delete);

            form.list.ForEach(a =>
            {
                var x = list.Find(y => y.ID == a.ID);
                if (x != null)
                {
                    x.CurModel = DealModel.Modify;
                    x.TITLE = a.TITLE;
                    x.RESULT_MAX = a.RESULT_MAX;
                    details.Add(x);
                }
                else
                {
                    var honor = a.ConvertTo<APP_QUESTIONNAIRE_ITEM>();
                    honor.CurModel = DealModel.New;
                    honor.QUESTIONNAIRE_NO = item.QUESTIONNAIRE_NO;
                    details.Add(honor);
                }
            });

            list.ForEach(a =>
            {
                if (a.CurModel == DealModel.Delete)
                {
                    details.Add(a);
                }
            });

            #endregion

            decimal id = bll.UpdateMasterDetail(item, details);
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
                    var model = bll.Get<APP_QUESTIONNAIRE>(Convert.ToDecimal(item));
                    if (model != null)
                    {
                        decimal id = bll.Delete(model);

                        query.Clause = string.Format("APP_QUESTIONNAIRE_ITEM.QUESTIONNAIRE_NO = @JUDGES_NO");
                        query.Add(new ParamData { ParamName = "JUDGES_NO", DataType = DbType.String, Value = model.QUESTIONNAIRE_NO });
                        bll.Delete<APP_QUESTIONNAIRE_ITEM>(query);
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
            var currentRow = bll.Get<APP_QUESTIONNAIRE>(roleId);
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

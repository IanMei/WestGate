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

namespace CMS.Service.Admin
{
    public class JudgesService : IJudgesService
    {
        private ParamCollection query = new ParamCollection();
        private IBaseRepository<SqlServercfg> bll;
        public JudgesService(IBaseRepository<SqlServercfg> _bll)
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
                column = APP_JUDGES.NICK_NAME_FIELD;
                clause += string.Format("AND ({0}.{1} LIKE @{1})", APP_JUDGES.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, "%" + query["title"] + "%"));
            }
            if (clause.Length > 3)
            {
                clause = clause.Substring(3, clause.Length - 3);
            }
            paraList.Clause = clause;
            var queryList = bll.SelectByPageIndex<APP_JUDGES>(paraList, "APP_JUDGES.CREATE_TIME DESC", page, size, out int pageCount);
            if (queryList.Count == 0 && page > 1)
            {
                var sp = page - 1;
                return List(page, sp);
            }
            var list = new List<JudgesInfoDto>();
            foreach (var item in queryList)
            {
                var row = item.ConvertTo<JudgesInfoDto>();

                row.enabled = item.IS_ENABLED == 1;
                row.main = item.IS_MAIN == 1;
                row.special = item.IS_SPECIAL == 1;
                list.Add(row);
            }
            var result = new RequestMessagePageList<List<JudgesInfoDto>>(list, pageCount, page, size);
            return new ApiResult<RequestMessageBase<List<JudgesInfoDto>>>().SetSuccessResult(result);
        }

        /// <summary>
        /// 获取单个角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ApiResult Get(decimal id)
        {
            var info = new JudgesInfoDto() { IMAGE_ID = -1 };
            var item = bll.Get<APP_JUDGES>(id);
            if (item != null)
            {
                item.USER_PWD = DEncryptHelper.Decrypt(item.USER_PWD);
                info = item.ConvertTo<JudgesInfoDto>();
                info.ArrayArea = new List<string> {
                    item.PROVINCE_NO,
                    item.CITY_NO
                };
                query.Clause = string.Format("APP_JUDGES_HONOR.JUDGES_NO = '{0}'", item.JUDGES_NO);
                var list = bll.Select<APP_JUDGES_HONOR>(query);
                list.ForEach(a =>
                {
                    if (a.HONOR_TYPE == "02") {
                        info.Honors.Add(a.ConvertTo<JudgesResumeDto>());
                    }else if (a.HONOR_TYPE == "01")
                    {
                        info.Resume.Add(a.ConvertTo<JudgesResumeDto>());
                    }
                });



                info.enabled = info.IS_ENABLED == 1;
                info.main = info.IS_MAIN == 1;
                info.special = info.IS_SPECIAL == 1;
            }
            return new ApiResult<JudgesInfoDto>().SetSuccessResult(info);
        }
        /// <summary>
        /// 更新角色
        /// </summary>
        public ApiResult Update(JudgesInfoDto form)
        {
            var item = form.ConvertTo<APP_JUDGES>();

            query.Clause = string.Format("APP_JUDGES.MOBILE = @MOBILE AND APP_JUDGES.JUDGES_ID <> {0}", item.ID);
            query.Add(new ParamData { DataType = DbType.String, ParamName = "MOBILE", Value = item.MOBILE });

            var ex = bll.GetCount<APP_JUDGES>(query);
            if (ex > 0)
            {
                return new ApiResult().SetFailedResult("用户名/手机号已注册");
            }

            if (item.ID > 0)
            {
                item.CurModel = DealModel.Modify;
            }
            else
            {
                item.JUDGES_NO = bll.GetSeqNo("HPN");
                item.CurModel = DealModel.New;
                item.IS_ENABLED = 1;
            }
            if (!string.IsNullOrEmpty(form.USER_PWD))
            {
                item.USER_PWD = DEncryptHelper.Encrypt(form.USER_PWD);
            }

            #region 荣誉

            var details = new BaseList();
            query.Clause = string.Format("APP_JUDGES_HONOR.JUDGES_NO = @JUDGES_NO");
            query.Add(new ParamData { ParamName = "JUDGES_NO", DataType = DbType.String, Value = item.JUDGES_NO });
            var list = bll.Select<APP_JUDGES_HONOR>(query);
            list.ForEach(a => a.CurModel = DealModel.Delete);

            form.Honors.ForEach(a =>
            {
                var x = list.Find(y => y.ID == a.ID && a.HONOR_TYPE == "02");
                if (x != null)
                {
                    x.CurModel = DealModel.Modify;
                    x.HONOR_YEAR = a.HONOR_YEAR;
                    x.HONOR_DESC = a.HONOR_DESC;
                    details.Add(x);
                }
                else
                {
                    var honor = a.ConvertTo<APP_JUDGES_HONOR>();
                    honor.CurModel = DealModel.New;
                    honor.JUDGES_NO = item.JUDGES_NO;
                    honor.HONOR_TYPE = "02";
                    details.Add(honor);
                }
            });


            form.Resume.ForEach(a =>
            {
                var x = list.Find(y => y.ID == a.ID && a.HONOR_TYPE == "01");
                if (x != null)
                {
                    x.CurModel = DealModel.Modify;
                    x.HONOR_YEAR = a.HONOR_YEAR;
                    x.HONOR_DESC = a.HONOR_DESC;
                    details.Add(x);
                }
                else
                {
                    var honor = a.ConvertTo<APP_JUDGES_HONOR>();
                    honor.CurModel = DealModel.New;
                    honor.JUDGES_NO = item.JUDGES_NO;
                    honor.HONOR_TYPE = "01";
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
                    var model = bll.Get<APP_JUDGES>(Convert.ToDecimal(item));
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
            var currentRow = bll.Get<APP_JUDGES>(roleId);
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

        public ApiResult Main(decimal rid)
        {
            bool state = false;
            var currentRow = bll.Get<APP_JUDGES>(rid);
            if (currentRow != null)
            {
                currentRow.CurModel = DealModel.Modify;
                currentRow.IS_MAIN = currentRow.IS_MAIN.Equals(0) ? 1 : 0;
                decimal id = bll.Update(currentRow);
                if (currentRow.CurModel == DealModel.Modify)
                {
                    id = currentRow.ID;
                }
                if (id > 0)
                {
                    state = Convert.ToBoolean(currentRow.IS_MAIN);
                }
            }
            return new ApiResult<bool>().SetSuccessResult(state);
        }

        public ApiResult Special(decimal rid)
        {
            bool state = false;
            var currentRow = bll.Get<APP_JUDGES>(rid);
            if (currentRow != null)
            {
                currentRow.CurModel = DealModel.Modify;
                currentRow.IS_SPECIAL = currentRow.IS_SPECIAL.Equals(0) ? 1 : 0;
                decimal id = bll.Update(currentRow);
                if (currentRow.CurModel == DealModel.Modify)
                {
                    id = currentRow.ID;
                }
                if (id > 0)
                {
                    state = Convert.ToBoolean(currentRow.IS_MAIN);
                }
            }
            return new ApiResult<bool>().SetSuccessResult(state);
        }

    }
}

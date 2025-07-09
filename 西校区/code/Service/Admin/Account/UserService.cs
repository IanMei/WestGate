using CMS.Core.Common;
using CMS.Core.Common.TableExtend;
using CMS.Core.Responsity;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using CMS.IService;
using CMS.IService.Admin;
using CMS.IService.Admin.Account.Dto;
using System;
using System.Collections.Generic;
using System.Data;

namespace CMS.Service.Admin
{
    public class UserService : IUserService
    {
        private IBaseRepository<SqlServercfg> bll;
        public UserService(IBaseRepository<SqlServercfg> _bll)
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
            if (!string.IsNullOrEmpty(query["user_name"]))
            {
                column = SYS_USER.USER_NAME_FIELD;
                clause += string.Format("AND ({0}.{1} LIKE @{1})", SYS_USER.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, "%" + query["user_name"] + "%"));
            }

            column = SYS_USER.IS_ADMIN_FIELD;
            clause += string.Format("AND ({0}.{1} = @{1})", SYS_USER.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.Int32, 0));

            if (clause.Length > 3)
            {
                clause = clause.Substring(3, clause.Length - 3);
            }
            paraList.Clause = clause;
            var queryList = bll.SelectByPageIndex<SYS_USER>(paraList, "SYS_USER.CREATE_TIME DESC", page, size, out int pageCount);
            if (queryList.Count == 0 && page > 1)
            {
                var sp = page - 1;
                return List(page, sp);
            }
            var list = new List<AdminInfo>();
            foreach (var item in queryList)
            {
                var row = item.ConvertTo<AdminInfo>();

                list.Add(row);
            }

            var result = new RequestMessagePageList<List<AdminInfo>>(list, pageCount, page, size);
            return new ApiResult<RequestMessageBase<List<AdminInfo>>>().SetSuccessResult(result);
            //return new RequestMessagePageList<List<AdminInfo>>(list, pageCount, page, size);
        }
        /// <summary>
        /// 获取单个角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ApiResult Get(decimal id)
        {
            var info = new AdminInfo();
            var item = bll.Get<SYS_USER>(id);
            if (item != null)
            {
                info = item.ConvertTo<AdminInfo>();
                info.USER_PWD = DEncryptHelper.Decrypt(info.USER_PWD);
                info.enabled = info.IS_AVAILABLE == 1;
                ParamCollection paraList = new ParamCollection();
                string clause = string.Empty;
                string column = "";

                column = SYS_USER_ROLE.USER_ID_FIELD;
                clause += string.Format("AND ({0}.{1} = @{1})", SYS_USER_ROLE.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.Decimal, item.ID));

                if (clause.Length > 3)
                {
                    clause = clause.Substring(3, clause.Length - 3);
                }
                paraList.Clause = clause;
                var roles = bll.Select<SYS_USER_ROLE>(paraList);
                if (roles.Count > 0)
                {

                    info.role_no = roles[0].ROLE_NO;
                }
            }
            return new ApiResult<AdminInfo>().SetSuccessResult(info);
        }
        /// <summary>
        /// 更新角色
        /// </summary>
        public ApiResult Update(AdminInfo form)
        {
            var item = form.ConvertTo<SYS_USER>();
            if (item.ID > 0)
            {
                item.CurModel = DealModel.Modify;
            }
            else
            {
                item.CurModel = DealModel.New;
                item.IS_AVAILABLE = 1;
                item.ROLE_TYPE = "01";
            }
            item.USER_PWD = DEncryptHelper.Encrypt(item.USER_PWD);
       
          
          
            decimal id = bll.Update(item);
            if (item.CurModel == DealModel.Modify)
            {
                id = item.ID;
            }

            ParamCollection paraList = new ParamCollection();
            string clause = string.Empty;
            string column = "";

            column = SYS_USER_ROLE.USER_ID_FIELD;
            clause += string.Format("AND ({0}.{1} = @{1})", SYS_USER_ROLE.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.Decimal, id));
            if (clause.Length > 3)
            {
                clause = clause.Substring(3, clause.Length - 3);
            }
            paraList.Clause = clause;

            var roles = bll.Select<SYS_USER_ROLE>(paraList);
            SYS_USER_ROLE roleRole;
            if (roles.Count > 0)
            {
                roleRole = roles[0];
                roleRole.CurModel = DealModel.Modify;
                roleRole.ROLE_NO = form.role_no;
            }
            else
            {
                roleRole = new SYS_USER_ROLE(DealModel.New);
                roleRole.USER_ID = id;
                roleRole.ROLE_NO = form.role_no;
            }
            bll.Update(roleRole);
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
                    var model = bll.Get<SYS_USER>(Convert.ToDecimal(item));
                    if (model != null && model.IS_ADMIN == 0)
                    {
                        decimal id = bll.Delete(model);
                        if (id > 0)
                        {
                            ParamCollection paraList = new ParamCollection();
                            string clause = string.Empty;
                            string column = "";

                            column = SYS_USER_ROLE.USER_ID_FIELD;
                            clause += string.Format("AND ({0}.{1} = @{1})", SYS_USER_ROLE.TABLE_NAME, column);
                            paraList.Add(new ParamData(column, DbType.Decimal, model.ID));

                            if (clause.Length > 3)
                            {
                                clause = clause.Substring(3, clause.Length - 3);
                            }
                            paraList.Clause = clause;
                            int permRows = bll.Delete<SYS_USER_ROLE>(paraList);
                        }
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
            var currentRow = bll.Get<SYS_USER>(roleId);
            if (currentRow != null)
            {
                currentRow.CurModel = DealModel.Modify;
                currentRow.IS_AVAILABLE = currentRow.IS_AVAILABLE.Equals(0) ? 1 : 0;
                decimal id = bll.Update(currentRow);
                if (currentRow.CurModel == DealModel.Modify)
                {
                    id = currentRow.ID;
                }
                if (id > 0)
                {
                    state = Convert.ToBoolean(currentRow.IS_AVAILABLE);
                }
            }
            return new ApiResult<bool>().SetSuccessResult(state);
        }

        public ApiResult Radios()
        {
            ParamCollection paraList = new ParamCollection();
            string clause = string.Empty;
            string column = "";

            column = SYS_ROLE.IS_ENABLED_FIELD;
            clause += string.Format("AND ({0}.{1} = @{1})", SYS_ROLE.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.Int32, 1));


            column = SYS_ROLE.IS_ADMIN_FIELD;
            clause += string.Format("AND ({0}.{1} = @{1})", SYS_ROLE.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.Int32, 0));

            if (clause.Length > 3)
            {
                clause = clause.Substring(3, clause.Length - 3);
            }
            paraList.Clause = clause;

            var list = bll.Select<SYS_ROLE>(paraList);
            var radios = new List<RadioItem>();

            foreach (var item in list)
            {
                radios.Add(new RadioItem
                {
                    key = item.ROLE_NO,
                    text = item.ROLE_NAME
                });
            }
            return new ApiResult<List<RadioItem>>().SetSuccessResult(radios);
        }
    }
}

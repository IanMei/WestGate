using CMS.Core.Common;
using CMS.Core.Responsity;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using CMS.IService;
using CMS.IService.Admin;
using CMS.IService.Admin.Account.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CMS.Service.Admin {
    public class RoleService : IRoleService {
        private IBaseRepository<SqlServercfg> bll;
        public RoleService(IBaseRepository<SqlServercfg> _bll)
        {
            bll = _bll;
        }

        /// <summary>
        /// 角色分页数据获取
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ApiResult GetPagedRolesList(int page, int size)
        {
            ParamCollection paraList = new ParamCollection();
            string clause = string.Empty;
            string column = "";

            var query = System.Web.HttpContext.Current.Request.QueryString;
            if (!string.IsNullOrEmpty(query["roleName"]))
            {
                column = SYS_ROLE.ROLE_NAME_FIELD;
                clause += string.Format("AND ({0}.{1} LIKE @{1})", SYS_ROLE.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, "%" + query["roleName"] + "%"));
            }


            column = SYS_ROLE.ROLE_TYPE_FIELD;
            clause += string.Format("AND ({0}.{1} = @{1})", SYS_ROLE.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.String, query["roleType"]));

            column = SYS_ROLE.IS_ADMIN_FIELD;
            clause += string.Format("AND ({0}.{1} = @{1})", SYS_ROLE.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.Int32, 0));

            if (clause.Length > 3)
            {
                clause = clause.Substring(3, clause.Length - 3);
            }
            paraList.Clause = clause;
            var queryList = bll.SelectByPageIndex<SYS_ROLE>(paraList, "SYS_ROLE.CREATE_TIME DESC", page, size, out int pageCount);
            if (queryList.Count == 0 && page > 1)
            {
                var sp = page - 1;
                return GetPagedRolesList(page, sp);
            }
            var resultList = from item in queryList
                             select new RoleInfo
                             {
                                 RoleId = item.ROLE_ID,
                                 RoleNo = item.ROLE_NO,
                                 RoleType = item.ROLE_TYPE,
                                 RoleName = item.ROLE_NAME,
                                 IsEnabled = Convert.ToBoolean(item.IS_ENABLED),
                                 Remark = item.REMARK
                             };

            return new ApiResult<RequestMessagePageList<List<RoleInfo>>>().SetSuccessResult(new RequestMessagePageList<List<RoleInfo>>(resultList.ToList(), pageCount, page, size));
            //return new RequestMessagePageList<List<RoleInfo>>(resultList.ToList(), pageCount, page, size);
        }
        /// <summary>
        /// 获取单个角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ApiResult Get(decimal id)
        {
            var info = new RoleInfo();
            var item = bll.Get<SYS_ROLE>(id);
            if (item != null)
            {
                info.RoleId = item.ROLE_ID;
                info.RoleNo = item.ROLE_NO;
                info.RoleType = item.ROLE_TYPE;
                info.RoleName = item.ROLE_NAME;
                info.IsEnabled = Convert.ToBoolean(item.IS_ENABLED);
                info.Remark = item.REMARK;
            }
            ParamCollection where = new ParamCollection();
            where.Clause = string.Format(" (SYS_PERM.ROLE_NO = '{0}')", info.RoleNo);
            var perms = bll.Select<SYS_PERM>(where);

            where.Clause = string.Format(" (SYS_WEB_MODULE.MODULE_TYPE = '{0}' AND SYS_WEB_MODULE.IS_AVAILABLE = 1)", info.RoleType);
            var modules = bll.Select<SYS_FUNCTION>(where);
            foreach (var module in modules.FindAll(a => a.FUNCTION_CODE == Operation.Cate))
            {
                var moduleItem = new ModuleItem
                {
                    code = module.FUNCTION_ID,
                    name = module.MODULE_NAME
                };
                moduleItem.selected = perms.Find(a => a.FUNCTION_ID == moduleItem.code) != null;
                var pages = modules.FindAll(x => x.PARENT_CODE == module.MODULE_CODE && x.FUNCTION_CODE == Operation.Module);
                foreach (var page in pages)
                {
                    var pageItem = new PageItem
                    {
                        code = page.FUNCTION_ID,
                        name = page.MODULE_NAME
                    };

                    pageItem.selected = perms.Find(a => a.FUNCTION_ID == pageItem.code) != null;
                    foreach (var func in modules.FindAll(f => f.MODULE_CODE == page.MODULE_CODE && f.FUNCTION_CODE > Operation.Module))
                    {
                        var operationItem = new OperationItem
                        {
                            code = func.FUNCTION_ID,
                            name = func.FUNCTION_NAME
                        };
                        operationItem.selected = perms.Find(a => a.FUNCTION_ID == operationItem.code) != null;
                        pageItem.Operations.Add(operationItem);
                    }
                    moduleItem.Pages.Add(pageItem);
                }
                info.Modules.Add(moduleItem);
            }
            return new ApiResult<RoleInfo>().SetSuccessResult(info);
        }
        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="role"></param>
        public ApiResult Update(RoleInfo role)
        {
            SYS_ROLE currentRow = bll.Get<SYS_ROLE>(role.RoleId);
            if (currentRow != null)
            {
                currentRow.CurModel = DealModel.Modify;
            }
            else
            {
                currentRow = new SYS_ROLE(DealModel.New);
                currentRow.ROLE_NO = bll.GetSeqNo("URP");
                currentRow.ROLE_TYPE = role.RoleType;
                currentRow.IS_ADMIN = 0;
                currentRow.IS_ENABLED = 1;
            }
            currentRow.ROLE_NAME = role.RoleName;
            currentRow.IS_ENABLED = role.IsEnabled ? 1 : 0;
            currentRow.REMARK = role.Remark;

            var where = new ParamCollection();
            where.Clause = string.Format(" (SYS_PERM.ROLE_NO = '{0}')", currentRow.ROLE_NO);
            List<SYS_PERM> perms = bll.Select<SYS_PERM>(where);
            var data = new BaseList();
            foreach (var module in role.Modules)    //模块
            {
                var dbModule = perms.Find(a => a.FUNCTION_ID == module.code);
                if (module.selected)
                {
                    if (dbModule == null)
                    {
                        dbModule = new SYS_PERM(DealModel.New);
                        dbModule.ROLE_NO = currentRow.ROLE_NO;
                        dbModule.FUNCTION_ID = module.code;
                        data.Add(dbModule);
                    }
                }
                else
                {
                    if (dbModule != null)
                    {
                        dbModule.CurModel = DealModel.Delete;
                        data.Add(dbModule);
                    }
                }
                foreach (var page in module.Pages)  //页面
                {
                    var dbPage = perms.Find(a => a.FUNCTION_ID == page.code);
                    if (page.Operations.FindAll(x => x.selected).Count > 0)
                    {
                        if (dbPage == null)
                        {
                            dbPage = new SYS_PERM(DealModel.New);
                            dbPage.ROLE_NO = currentRow.ROLE_NO;
                            dbPage.FUNCTION_ID = page.code;
                            data.Add(dbPage);
                        }
                    }
                    else
                    {
                        if (dbPage != null)
                        {
                            dbPage.CurModel = DealModel.Delete;
                            data.Add(dbPage);
                        }
                    }
                    foreach (var operation in page.Operations)  //功能
                    {
                        var dbOperation = perms.Find(a => a.FUNCTION_ID == operation.code);
                        if (operation.selected)
                        {
                            if (dbOperation == null)
                            {
                                dbOperation = new SYS_PERM(DealModel.New);
                                dbOperation.ROLE_NO = currentRow.ROLE_NO;
                                dbOperation.FUNCTION_ID = operation.code;
                                data.Add(dbOperation);
                            }
                        }
                        else
                        {
                            if (dbOperation != null)
                            {
                                dbOperation.CurModel = DealModel.Delete;
                                data.Add(dbOperation);
                            }
                        }
                    }
                }
            }

            decimal id = bll.UpdateMasterDetail(currentRow, data);
            if (currentRow.CurModel == DealModel.Modify)
            {
                id = currentRow.ROLE_ID;
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
                    var model = bll.Get<SYS_ROLE>(Convert.ToDecimal(item));
                    if (model != null && model.IS_ADMIN == 0)
                    {
                        decimal id = bll.Delete(model);
                        if (id > 0)
                        {
                            ParamCollection paraList = new ParamCollection();
                            string clause = string.Empty;
                            string column = "";

                            column = SYS_PERM.ROLE_NO_FIELD;
                            clause += string.Format("AND ({0}.{1} = @{1})", SYS_PERM.TABLE_NAME, column);
                            paraList.Add(new ParamData(column, DbType.String, model.ROLE_NO));

                            if (clause.Length > 3)
                            {
                                clause = clause.Substring(3, clause.Length - 3);
                            }
                            paraList.Clause = clause;
                            int permRows = bll.Delete<SYS_PERM>(paraList);
                        }
                        rows += (int)id;
                    }
                }
                if (rows < arrs.Length)
                {
                    //throw new CustomException(string.Format("{0}条数据删除成功", rows));
                    return new ApiResult().SetFailedResult(-1, string.Format("{0}条数据删除成功", rows));
                }
                //return rows;
                return new ApiResult<int>().SetSuccessResult(rows);
            }
            else
            {
                //throw new CustomException(string.Format("数据删除失败"));
                return new ApiResult().SetFailedResult(-1, "数据删除失败");
            }
        }
        /// <summary>
        /// 设置角色状态
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ApiResult SetStatus(decimal roleId)
        {
            bool state = false;
            var currentRow = bll.Get<SYS_ROLE>(roleId);
            if (currentRow != null)
            {
                if (currentRow.IS_ENABLED == 1)
                {
                    ParamCollection where = new ParamCollection();
                    where.Clause = string.Format(" (SYS_USER_ROLE.ROLE_NO = '{0}')", currentRow.ROLE_NO);
                    var list = bll.Select<SYS_USER_ROLE>(where);
                    if (list.Count > 0)
                    {
                        //throw new CustomException("操作失败，角色无法禁用！");
                        return new ApiResult().SetFailedResult(-1, "操作失败，角色无法禁用！");
                    }
                }
                currentRow.CurModel = DealModel.Modify;
                currentRow.IS_ENABLED = currentRow.IS_ENABLED.Equals(0) ? 1 : 0;
                decimal id = bll.Update(currentRow);
                if (currentRow.CurModel == DealModel.Modify)
                {
                    id = currentRow.ROLE_ID;
                }
                if (id > 0)
                {
                    state = Convert.ToBoolean(currentRow.IS_ENABLED);
                }
            }
            //return state;
            return new ApiResult<bool>().SetSuccessResult(state);
        }
    }
}

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
    public class SchoolService : ISchoolService
    {
        private ParamCollection query = new ParamCollection();
        private IBaseRepository<SqlServercfg> bll;
        public SchoolService(IBaseRepository<SqlServercfg> _bll)
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
                column = APP_SCHOOL.SCHOOL_NAME_FIELD;
                clause += string.Format("AND ({0}.{1} LIKE @{1})", APP_SCHOOL.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, "%" + query["title"] + "%"));
            }
            if (clause.Length > 3)
            {
                clause = clause.Substring(3, clause.Length - 3);
            }
            paraList.Clause = clause;
            var queryList = bll.SelectByPageIndex<APP_SCHOOL>(paraList, "APP_SCHOOL.CREATE_TIME DESC", page, size, out int pageCount);
            if (queryList.Count == 0 && page > 1)
            {
                var sp = page - 1;
                return List(page, sp);
            }
            var list = new List<SchoolDto>();
            foreach (var item in queryList)
            {
                var row = item.ConvertTo<SchoolDto>();
                row.enabled = item.IS_ENABLED == 1;
                list.Add(row);
            }
            var result = new RequestMessagePageList<List<SchoolDto>>(list, pageCount, page, size);
            return new ApiResult<RequestMessageBase<List<SchoolDto>>>().SetSuccessResult(result);
        }

        /// <summary>
        /// 获取单个角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ApiResult Get(decimal id)
        {
            var info = new SchoolDto() { IMAGE_ID = -1 };
            var item = bll.Get<APP_SCHOOL>(id);
            if (item != null)
            {
                item.USER_PWD = DEncryptHelper.Decrypt(item.USER_PWD);
                info = item.ConvertTo<SchoolDto>();
                info.ArrayArea = new List<string> {
                    item.PROVINCE_NO,
                    item.CITY_NO
                };
                query.Clause = string.Format("APP_HONOR.SCHOOL_NO = '{0}'", item.SCHOOL_NO);
                var list = bll.Select<APP_HONOR>(query);
                list.ForEach(a =>
                {
                    info.Honors.Add(a.ConvertTo<HonorDto>());
                });


                query.Clause = string.Format("APP_FACILITIES.SCHOOL_NO = '{0}'", item.SCHOOL_NO);
                var facilities = bll.Select<APP_FACILITIES>(query);

                query.Clause = string.Format("BASE_TYPE.CLASS_NO IN ('02','03','04')");

                var dbfacilities = bll.Select<BASE_TYPE>(query);

                foreach (var fs in dbfacilities)
                {
                    var ex = facilities.Find(a => a.TITLE == fs.TYPE_NAME);
                    if (ex == null)
                    {
                        facilities.Add(new APP_FACILITIES
                        {
                            FACILITIES_TYPE = fs.CLASS_NO,
                            SCHOOL_NO = item.SCHOOL_NO,
                            TITLE = fs.TYPE_NAME,
                            IS_ENABLED = 0
                        });
                    }
                }

                facilities.ForEach(a =>
                {
                    var temp = a.ConvertTo<FacilitiesDto>();
                    temp.enabled = a.IS_ENABLED == 1;
                    if (a.FACILITIES_TYPE == "02")
                    {
                        if (a.IS_ENABLED == 1) {
                            info.FacilitiesVal1.Add(a.TITLE);
                        }
                        info.Facilities1.Add(temp);
                    }
                    else if (a.FACILITIES_TYPE == "03")
                    {
                        if (a.IS_ENABLED == 1)
                        {
                            info.FacilitiesVal2.Add(a.TITLE);
                        }
                        info.Facilities2.Add(temp);
                    }
                    else if (a.FACILITIES_TYPE == "04")
                    {
                        if (a.IS_ENABLED == 1)
                        {
                            info.FacilitiesVal3.Add(a.TITLE);
                        }
                        info.Facilities3.Add(temp);
                    }
                });

                info.enabled = info.IS_ENABLED == 1;
                info.hot = info.IS_RECOMMEND == 1;
            }
            return new ApiResult<SchoolDto>().SetSuccessResult(info);
        }
        /// <summary>
        /// 更新角色
        /// </summary>
        public ApiResult Update(SchoolDto form)
        {
            var item = form.ConvertTo<APP_SCHOOL>();

            query.Clause = string.Format("APP_SCHOOL.MOBILE = @MOBILE AND APP_SCHOOL.SCHOOL_ID <> {0}", item.ID);
            query.Add(new ParamData { DataType = DbType.String, ParamName = "MOBILE", Value = item.MOBILE });

            var ex = bll.GetCount<APP_SCHOOL>(query);
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
                item.SCHOOL_NO = bll.GetSeqNo("HPN");
                item.CurModel = DealModel.New;
                item.IS_ENABLED = 1;
            }
            if (!string.IsNullOrEmpty(form.USER_PWD))
            {
                item.USER_PWD = DEncryptHelper.Encrypt(form.USER_PWD);
            }

            #region 荣誉

            var details = new BaseList();
            query.Clause = string.Format("APP_HONOR.SCHOOL_NO = '{0}'", item.SCHOOL_NO);
            var list = bll.Select<APP_HONOR>(query);
            list.ForEach(a => a.CurModel = DealModel.Delete);


            form.Honors.ForEach(a =>
            {
                var x = list.Find(y => y.ID == a.ID);
                if (x != null)
                {
                    x.CurModel = DealModel.Modify;
                    x.HONOR_YEAR = a.HONOR_YEAR;
                    x.HONOR_DESC = a.HONOR_DESC;
                    details.Add(x);
                }
                else
                {
                    details.Add(a.ConvertTo<APP_HONOR>());
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

            #region 设施
            var facilitiesData = new BaseList();
            query.Clause = string.Format("APP_FACILITIES.SCHOOL_NO = '{0}'", item.SCHOOL_NO);
            var facilities = bll.Select<APP_FACILITIES>(query);
            foreach (var fs in form.Facilities1) {
                var exitem = facilities.Find(a => a.TITLE == fs.TITLE && a.FACILITIES_TYPE == "02");
                var fsitem = fs.ConvertTo<APP_FACILITIES>();
                if (exitem == null)
                {
                    fsitem.CurModel = DealModel.New;
                    facilitiesData.Add(fsitem);
                }
                else
                {
                    if (exitem.IS_ENABLED != fsitem.IS_ENABLED) {
                        fsitem.CurModel = DealModel.Modify;
                        facilitiesData.Add(fsitem);
                    }
                }
            }

            foreach (var fs in form.Facilities2)
            {
                var exitem = facilities.Find(a => a.TITLE == fs.TITLE && a.FACILITIES_TYPE == "03");
                var fsitem = fs.ConvertTo<APP_FACILITIES>();
                if (exitem == null)
                {
                    fsitem.CurModel = DealModel.New;
                    facilitiesData.Add(fsitem);
                }
                else
                {
                    if (exitem.IS_ENABLED != fsitem.IS_ENABLED)
                    {
                        fsitem.CurModel = DealModel.Modify;
                        facilitiesData.Add(fsitem);
                    }
                }
            }

            foreach (var fs in form.Facilities3)
            {
                var exitem = facilities.Find(a => a.TITLE == fs.TITLE && a.FACILITIES_TYPE == "04");
                var fsitem = fs.ConvertTo<APP_FACILITIES>();
                if (exitem == null)
                {
                    fsitem.CurModel = DealModel.New;
                    facilitiesData.Add(fsitem);
                }
                else
                {
                    if (exitem.IS_ENABLED != fsitem.IS_ENABLED)
                    {
                        fsitem.CurModel = DealModel.Modify;
                        facilitiesData.Add(fsitem);
                    }
                }
            }

            #endregion

            decimal id = bll.UpdateMasterDetail(item, details, facilitiesData);
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
                    var model = bll.Get<APP_SCHOOL>(Convert.ToDecimal(item));
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
            var currentRow = bll.Get<APP_SCHOOL>(roleId);
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

        public ApiResult Hot(decimal rid)
        {
            bool state = false;
            var currentRow = bll.Get<APP_SCHOOL>(rid);
            if (currentRow != null)
            {
                currentRow.CurModel = DealModel.Modify;
                currentRow.IS_RECOMMEND = currentRow.IS_RECOMMEND.Equals(0) ? 1 : 0;
                decimal id = bll.Update(currentRow);
                if (currentRow.CurModel == DealModel.Modify)
                {
                    id = currentRow.ID;
                }
                if (id > 0)
                {
                    state = Convert.ToBoolean(currentRow.IS_RECOMMEND);
                }
            }
            return new ApiResult<bool>().SetSuccessResult(state);
        }
        public ApiResult AreaList()
        {
            var data = new List<AreaItem>();
            ParamCollection where = new ParamCollection();
            where.Clause = string.Format("BASE_PROVINCE.IS_ENABLED = 1");
            var provincesList = bll.Select<BASE_PROVINCE>(where, "BASE_PROVINCE.PROVINCE_NO ASC");
            where.Clause = string.Format("BASE_CITY.IS_ENABLED = 1");
            var citysList = bll.Select<BASE_CITY>(where, "BASE_CITY.CITY_NO ASC");
            where.Clause = string.Format("BASE_DISYRICT.IS_ENABLED = 1");
            var areasList = bll.Select<BASE_DISYRICT>(where, "BASE_DISYRICT.DISYRICT_NO ASC");
            bool options = false;
            foreach (BASE_PROVINCE shen in provincesList)
            {
                options = false;
                AreaItem optionRow = new AreaItem();
                optionRow.value = shen.PROVINCE_NO;
                optionRow.label = shen.PROVINCE_NAME;
                var citys = citysList.FindAll(x => x.PROVINCE_NO == shen.PROVINCE_NO);
                if (citys.Count > 0)
                {
                    optionRow.children = new List<AreaItem>();
                    foreach (BASE_CITY di in citys)
                    {
                        AreaItem diRow = new AreaItem { value = di.CITY_NO, label = di.CITY_NAME };
                        //var areas = areasList.FindAll(x => x.CITY_NO == di.CITY_NO);
                        //if (areas.Count > 0)
                        //{
                        //    options = true;
                        //    diRow.children = new List<AreaItem>();
                        //    foreach (BASE_DISYRICT xian in areas)
                        //    {
                        //        diRow.children.Add(new AreaItem { value = xian.DISYRICT_NO, label = xian.DISYRICT_NAME });
                        //    }
                        //}
                        optionRow.children.Add(diRow);
                    }
                }
                data.Add(optionRow);
            }
            return new ApiResult<List<AreaItem>>().SetSuccessResult(data);
        }

        public ApiResult Select()
        {
            ParamCollection paraList = new ParamCollection();
            string clause = string.Empty;
            var queryList = bll.Select<APP_SCHOOL>(paraList);
            var droplist = new List<DropdownItem>();
            queryList.ForEach(a =>
            {
                droplist.Add(new DropdownItem
                {
                    Value = a.SCHOOL_NO,
                    Label = a.SCHOOL_NAME
                });
            });
            return new ApiResult<List<DropdownItem>>().SetSuccessResult(droplist);
        }

    }
}

using CMS.Core.Common;
using CMS.Core.Common.TableExtend;
using CMS.Core.Responsity;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using CMS.IService;
using CMS.IService.Admin.Account.Dto;
using CMS.IService.Admin.Home.Dto;
using CMS.IService.WebSite.Home;
using CMS.IService.WebSite.Home.Dto;
using CMS.IService.WebSite.Judges.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CMS.Service.Home
{
    public class BannerService : IHomeService
    {
        ParamCollection paraList = new ParamCollection();
        private IBaseRepository<SqlServercfg> bll;
        public BannerService(IBaseRepository<SqlServercfg> _bll)
        {
            bll = _bll;
        }

        public ApiResult Activitys(int size)
        {
            var query = System.Web.HttpContext.Current.Request.QueryString;

            paraList.Clause = string.Format(" APP_ACTIVITY.IS_ENABLED = 1");


            var queryList = bll.Select<APP_ACTIVITY>(paraList, "APP_ACTIVITY.SEQ_NO ASC,APP_ACTIVITY.CREATE_TIME DESC ", (short)size);

            var list = new List<ActivityDto>();
            foreach (var item in queryList)
            {
                var row = item.ConvertTo<ActivityDto>();
                list.Add(row);
            }

            return new ApiResult<List<ActivityDto>>().SetSuccessResult(list);
        }

        public ApiResult Activity(decimal id)
        {
            var info = new ActivityDto();

            var item = bll.Get<APP_ACTIVITY>(id);
            if (item != null)
            {
                info = item.ConvertTo<ActivityDto>();
            }
            return new ApiResult<ActivityDto>().SetSuccessResult(info);
        }
        public ApiResult Enroll(EnrollDto form)
        {
            if (string.IsNullOrEmpty(form.USER_NAME))
            {
                return new ApiResult().SetFailedResult("姓名不能空");
            }
            if (string.IsNullOrEmpty(form.COMPANY))
            {
                return new ApiResult().SetFailedResult("单位不能空");
            }
            if (string.IsNullOrEmpty(form.MOBILE))
            {
                return new ApiResult().SetFailedResult("手机不能空");
            }
            var item = form.ConvertTo<APP_ACTIVITY_ENROLL>();
            if (form.ID > 0)
            {

                var row = bll.Get<APP_ACTIVITY>(form.ID);
                if (row == null)
                {
                    return new ApiResult().SetFailedResult("活动信息无效");
                }
                else
                {
                    item.ACTIVITY_NO = row.ACTIVITY_NO;
                }
            }
            item.CurModel = DealModel.New;
            var rs = bll.Update(item);
            if (rs > 0)
            {
                return new ApiResult().SetSuccessResult();
            }
            else
            {
                return new ApiResult().SetFailedResult("服务器忙");
            }


        }

        public ApiResult Banners()
        {
            var query = System.Web.HttpContext.Current.Request.QueryString;
            string clause = string.Empty;
            string column = "";

            paraList.Clause = string.Format("AND APP_BANNER.IS_ENABLED = 1");
            if (!string.IsNullOrEmpty(query["type"]))
            {
                column = APP_BANNER.BANNER_TYPE_FIELD;
                clause += string.Format("AND ({0}.{1} = @{1})", APP_BANNER.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, query["type"]));
            }
            if (clause.Length > 3)
            {
                clause = clause.Substring(3, clause.Length - 3);
            }
            paraList.Clause = clause;
            var queryList = bll.Select<APP_BANNER>(paraList, "APP_BANNER.SEQ_NO ASC ,APP_BANNER.CREATE_TIME DESC", 5);

            var list = new List<BannerDto>();
            foreach (var item in queryList)
            {
                var row = item.ConvertTo<BannerDto>();
                list.Add(row);
            }

            return new ApiResult<List<BannerDto>>().SetSuccessResult(list);
        }

        public ApiResult ChooseUs()
        {
            var query = System.Web.HttpContext.Current.Request.QueryString;
            string clause = string.Empty;
            string column = "";

            paraList.Clause = string.Format("AND APP_ABOUT.IS_ENABLED = 1");

            column = APP_ABOUT.TYPE_NO_FIELD;
            clause += string.Format("AND ({0}.{1} = @{1})", APP_ABOUT.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.String, "01"));
            if (clause.Length > 3)
            {
                clause = clause.Substring(3, clause.Length - 3);
            }
            paraList.Clause = clause;
            var queryList = bll.Select<APP_ABOUT>(paraList, "APP_ABOUT.SEQ_NO ASC,APP_ABOUT.CREATE_TIME DESC ", 4);

            var list = new List<ChooseUsDto>();
            foreach (var item in queryList)
            {
                var row = item.ConvertTo<ChooseUsDto>();
                list.Add(row);
            }

            return new ApiResult<List<ChooseUsDto>>().SetSuccessResult(list);
        }

        public ApiResult AboutUs()
        {

            var query = System.Web.HttpContext.Current.Request.QueryString;
            string clause = string.Empty;
            string column = "";

            paraList.Clause = string.Format("AND APP_ABOUT.IS_ENABLED = 1");

            column = APP_ABOUT.TYPE_NO_FIELD;
            clause += string.Format("AND ({0}.{1} = @{1})", APP_ABOUT.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.String, "02"));
            if (clause.Length > 3)
            {
                clause = clause.Substring(3, clause.Length - 3);
            }
            paraList.Clause = clause;
            var queryList = bll.Select<APP_ABOUT>(paraList, "APP_ABOUT.SEQ_NO ASC,APP_ABOUT.CREATE_TIME DESC ", 10);

            var list = new List<ChooseUsDto>();
            foreach (var item in queryList)
            {
                var row = item.ConvertTo<ChooseUsDto>();
                list.Add(row);
            }
            return new ApiResult<List<ChooseUsDto>>().SetSuccessResult(list);
        }

        public ApiResult Interview()
        {
            var query = System.Web.HttpContext.Current.Request.QueryString;

            var queryList = bll.Select<APP_INTERVIEW>(paraList, "APP_INTERVIEW.CREATE_TIME DESC ", 1);

            var info = new InterviewDto();
            if (queryList.Count > 0)
            {
                info = queryList[0].ConvertTo<InterviewDto>();

                paraList.Clause = string.Format("APP_FACILITIES.SCHOOL_NO = '{0}' AND APP_FACILITIES.IS_ENABLED = 1", info.SCHOOL_NO);

                var queryDb = bll.Select<APP_FACILITIES>(paraList);

                foreach (var item in queryDb)
                {
                    info.facilities += item.TITLE + " /";
                }
                if (string.IsNullOrEmpty(info.facilities))
                {
                    info.facilities = info.facilities.TrimEnd('/');
                }

                var settings = bll.Select<APP_SETUP>();

                if (settings.Count > 0)
                {
                    info.link_man = settings[0].LINK_MAN;
                    info.service_tel = settings[0].SERVICE_TEL;
                    info.email = settings[0].EMAIL;
                }
            }
            return new ApiResult<InterviewDto>().SetSuccessResult(info);
        }

        public ApiResult School(decimal id)
        {
            ParamCollection query = new ParamCollection();
            var info = new SchoolDto();

            var querystr = System.Web.HttpContext.Current.Request.QueryString;
            var record = bll.Get<APP_SCHOOL>(id);
            if (record != null)
            {
                info = record.ConvertTo<SchoolDto>();

                query.Clause = string.Format("APP_HONOR.SCHOOL_NO = '{0}'", record.SCHOOL_NO);
                var list = bll.Select<APP_HONOR>(query);
                list.ForEach(a =>
                {
                    info.Honors.Add(a.ConvertTo<SchoolHonorDto>());
                });

                query.Clause = string.Format("APP_FACILITIES.SCHOOL_NO = '{0}'", record.SCHOOL_NO);
                var facilities = bll.Select<APP_FACILITIES>(query);

                facilities.ForEach(a =>
                {
                    if (a.FACILITIES_TYPE == "02")
                    {
                        if (a.IS_ENABLED == 1)
                        {
                            if (querystr["l"] == "en")
                            {
                                info.Facilities1.Add(a.TITLE_EN);
                            }
                            else
                            {
                                info.Facilities1.Add(a.TITLE);
                            }
                        }
                    }
                    else if (a.FACILITIES_TYPE == "03")
                    {
                        if (querystr["l"] == "en")
                        {
                            info.Facilities1.Add(a.TITLE_EN);
                        }
                        else
                        {
                            info.Facilities1.Add(a.TITLE);
                        }
                    }
                    else if (a.FACILITIES_TYPE == "04")
                    {
                        if (querystr["l"] == "en")
                        {
                            info.Facilities1.Add(a.TITLE_EN);
                        }
                        else
                        {
                            info.Facilities1.Add(a.TITLE);
                        }
                    }
                });

                var settings = bll.Select<APP_SETUP>();

                if (settings.Count > 0)
                {
                    info.link_man = settings[0].LINK_MAN;
                    info.service_tel = settings[0].SERVICE_TEL;
                    info.email = settings[0].EMAIL;
                }
            }
            return new ApiResult<SchoolDto>().SetSuccessResult(info);
        }

        public ApiResult SchoolList(int size, int page)
        {
            ParamCollection paraList = new ParamCollection();
            string clause = string.Empty;
            string column = "";

            var query = System.Web.HttpContext.Current.Request.QueryString;
            if (!string.IsNullOrEmpty(query["keywords"]))
            {
                column = APP_SCHOOL.SCHOOL_NAME_FIELD;
                clause += string.Format("AND ({0}.{1} LIKE @{1})", APP_SCHOOL.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, "%" + query["keywords"] + "%"));
            }
            if (!string.IsNullOrEmpty(query["en"]))
            {
                column = APP_SCHOOL.EN_NAME_FIELD;
                clause += string.Format("AND ({0}.{1} LIKE @{1})", APP_SCHOOL.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, "%" + query["en"] + "%"));
            }
            if (!string.IsNullOrEmpty(query["type"]))
            {
                column = APP_SCHOOL.RECRUIT_TYPE_FIELD;
                clause += string.Format("AND ({0}.{1} = @{1})", APP_SCHOOL.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, query["type"]));
            }
            if (!string.IsNullOrEmpty(query["p"]))
            {
                column = APP_SCHOOL.PROVINCE_NO_FIELD;
                clause += string.Format("AND ({0}.{1} = @{1})", APP_SCHOOL.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, query["p"]));
            }

            if (!string.IsNullOrEmpty(query["c"]))
            {
                column = APP_SCHOOL.CITY_NO_FIELD;
                clause += string.Format("AND ({0}.{1} = @{1})", APP_SCHOOL.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, query["c"]));
            }


            if (!string.IsNullOrEmpty(query["areap"]))
            {
                column = BASE_PROVINCE.PROVINCE_NAME_FIELD;
                clause += string.Format("AND ({0}.{1} like @{1})", BASE_PROVINCE.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, "%" + query["areap"] + "%"));
            }

            if (!string.IsNullOrEmpty(query["areac"]))
            {
                column = BASE_CITY.CITY_NAME_FIELD;
                clause += string.Format("AND ({0}.{1} like @{1})", BASE_CITY.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, "%" + query["areac"] + "%"));
            }
            if (!string.IsNullOrEmpty(query["coutype"]))
            {
                column = "ESPECIALLY_COURSE";
                clause += string.Format("AND ({0}.{1} = @{1})", APP_SCHOOL.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, query["coutype"]));
            }
            if (!string.IsNullOrEmpty(query["cny"]))
            {
                if (query["cny"] == "1")
                {
                    clause += string.Format("AND (APP_SCHOOL.TUITION_CNY >= 0 AND APP_SCHOOL.TUITION_CNY <= 100000)", APP_SCHOOL.TABLE_NAME, column);
                }
                else if (query["cny"] == "2")
                {
                    clause += string.Format("AND (APP_SCHOOL.TUITION_CNY >= 100000 AND APP_SCHOOL.TUITION_CNY <= 200000)", APP_SCHOOL.TABLE_NAME, column);
                }
                else if (query["cny"] == "3")
                {
                    clause += string.Format("AND (APP_SCHOOL.TUITION_CNY >= 200000 AND APP_SCHOOL.TUITION_CNY <= 300000)", APP_SCHOOL.TABLE_NAME, column);
                }
                else if (query["cny"] == "4")
                {
                    clause += string.Format("AND (APP_SCHOOL.TUITION_CNY >= 300000)", APP_SCHOOL.TABLE_NAME, column);
                }
            }
            column = APP_SCHOOL.IS_ENABLED_FIELD;
            clause += string.Format("AND ({0}.{1} = @{1})", APP_SCHOOL.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.Int32, 1));
            if (clause.Length > 3)
            {
                clause = clause.Substring(3, clause.Length - 3);
            }
            paraList.Clause = clause;


            var sort = "APP_SCHOOL.CREATE_TIME DESC";
            if (!string.IsNullOrEmpty(query["sort"]))
            {
                if (query["sort"] == "1")
                {

                    sort = "APP_SCHOOL.POINT DESC, APP_SCHOOL.CREATE_TIME DESC";
                }
                else if (query["sort"] == "2")
                {
                    sort = "APP_SCHOOL.POINT ASC,APP_SCHOOL.CREATE_TIME DESC";
                }
            }
            var queryList = bll.SelectByPageIndex<APP_SCHOOL>(paraList, sort, page, size, out int pageCount);
            if (queryList.Count == 0 && page > 1)
            {
                var sp = page - 1;
                return SchoolList(page, sp);
            }
            var list = new List<SchoolDto>();
            foreach (var item in queryList)
            {
                var row = item.ConvertTo<SchoolDto>();
                paraList.Clause = string.Format("APP_FACILITIES.SCHOOL_NO = '{0}'", item.SCHOOL_NO);
                var facilities = bll.Select<APP_FACILITIES>(paraList);

                facilities.ForEach(a =>
                {
                    if (a.IS_ENABLED == 1)
                    {
                        row.Facilities += a.TITLE + "/";
                        if(!string.IsNullOrEmpty(a.TITLE_EN))
                        row.EnFacilities += a.TITLE_EN + "/";
                    }
                });
                list.Add(row);
            }
            var result = new RequestMessagePageList<List<SchoolDto>>(list, pageCount, page, size);
            result.Move = list.Count >= size && pageCount % size != 0;
            return new ApiResult<RequestMessageBase<List<SchoolDto>>>().SetSuccessResult(result);
        }

        public ApiResult Dictionarys(string indexCode)
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
        public ApiResult DictionarysEn(string indexCode)
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
                    Label = a.REMARK
                });
            });
            return new ApiResult<List<DropdownItem>>().SetSuccessResult(droplist);
        }
        public ApiResult SiteInfo()
        {
            var queryDb = bll.Select<APP_SETUP>();
            if (queryDb != null && queryDb.Count > 0)
            {
                var rs = queryDb[0];
                var info = rs.ConvertTo<SettingsDto>();
                if (!string.IsNullOrEmpty(rs.HOT_SEARCH))
                {
                    info.tags = rs.HOT_SEARCH.Split(new char[] { '|' }).ToList();
                }
                var linkList = bll.Select<APP_LINK>(new ParamCollection(), "APP_LINK.CREATE_TIME ASC", 10);
                foreach (APP_LINK item in linkList)
                {
                    info.details.Add(item.ConvertTo<LinkDto>());
                }

                var hotSchool = bll.Select<APP_SCHOOL>(new ParamCollection()
                {
                    Clause = "APP_SCHOOL.IS_ENABLED = 1"

                }, "APP_SCHOOL.IS_RECOMMEND ASC,APP_SCHOOL.CREATE_TIME DESC", 20);
                foreach (APP_SCHOOL item in hotSchool)
                {
                    info.HotSchool.Add(item.ConvertTo<HotSchoolDto>());
                }


                paraList.Clause = string.Format("APP_QUESTIONNAIRE.IS_ENABLED = 1 AND APP_QUESTIONNAIRE.QUESTIONNAIRE_START <= GETDATE() and APP_QUESTIONNAIRE.QUESTIONNAIRE_END >= GETDATE()");
                var query = bll.Select<APP_QUESTIONNAIRE>(paraList, "APP_QUESTIONNAIRE.QUESTIONNAIRE_END desc", 1);
                if (query.Count > 0)
                {
                    info.questionnaire = true;
                }

                return new ApiResult<SettingsDto>().SetSuccessResult(info);
            }
            return new ApiResult<SettingsDto>().SetFailedResult("暂无数据");
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


        public ApiResult AreaListEn()
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
                optionRow.label = shen.PINYIN;
                var citys = citysList.FindAll(x => x.PROVINCE_NO == shen.PROVINCE_NO);
                if (citys.Count > 0)
                {
                    optionRow.children = new List<AreaItem>();
                    foreach (BASE_CITY di in citys)
                    {
                        AreaItem diRow = new AreaItem { value = di.CITY_NO, label = di.PINYIN };
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
            data = data.OrderBy(a => a.label).ToList();
            return new ApiResult<List<AreaItem>>().SetSuccessResult(data);
        }

        public ApiResult Service()
        {
            var html = "";
            var settings = bll.Select<APP_SETUP>();
            if (settings.Count > 0)
            {
                html = settings[0].SERVICE_CLAUSE;
            }
            return new ApiResult<string>().SetSuccessResult(html);
        }

        public ApiResult Judges(decimal id)
        {
            var item = bll.Get<APP_JUDGES>(id);
            if (item != null) {
                var info = item.ConvertTo<JudgesDto>();
                paraList.Clause = string.Format("APP_JUDGES_HONOR.JUDGES_NO = '{0}'", item.JUDGES_NO);
                var list = bll.Select<APP_JUDGES_HONOR>(paraList);
                list.ForEach(a =>
                {
                    if (a.HONOR_TYPE == "01")
                    {
                        info.Resume.Add(a.ConvertTo<JudgesHonorDto>());
                    }
                    else if (a.HONOR_TYPE == "02")
                    {
                        info.Honors.Add(a.ConvertTo<JudgesHonorDto>());
                    }
                });
                return new ApiResult<JudgesDto>().SetSuccessResult(info);
            }

            return new ApiResult().SetFailedResult("参数无效");

        }
    }
}

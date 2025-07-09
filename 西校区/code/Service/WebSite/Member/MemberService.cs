using CMS.Core.Common;
using CMS.Core.Common.TableExtend;
using CMS.Core.Responsity;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using CMS.IService;
using CMS.IService.Admin.Account.Dto;
using CMS.IService.Admin.Home.Dto;
using CMS.IService.Admin.School.Dto;
using CMS.IService.WebSite.Home;
using CMS.IService.WebSite.Home.Dto;
using CMS.IService.WebSite.Member.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CMS.Service.Home
{
    public class MemberService : MemberContext, IMemberService
    {
        ParamCollection paraList = new ParamCollection();
        private IBaseRepository<SqlServercfg> bll;
        public MemberService(IBaseRepository<SqlServercfg> _bll)
        {
            bll = _bll;
        }


        #region 注册、登录

        public ApiResult Login(LoginDto form)
        {
            if (string.IsNullOrEmpty(form.uid))
            {
                return new ApiResult().SetFailedResult("用户名不能空");
            }
            if (string.IsNullOrEmpty(form.pwd))
            {
                return new ApiResult().SetFailedResult("密码不能空");
            }
            paraList.Clause = string.Format("APP_SCHOOL.MOBILE = @MOBILE");
            paraList.Add(new ParamData { DataType = DbType.String, ParamName = "MOBILE", Value = form.uid });
            var schools = bll.Select<APP_SCHOOL>(paraList);
            if (schools.Count > 0)
            {
                var school = schools[0];
                if (school.USER_PWD != DEncryptHelper.Encrypt(form.pwd))
                {
                    return new ApiResult().SetFailedResult("密码错误");
                }
                else
                {
                    school.CurModel = DealModel.Modify;
                    school.CLIENT_ID = Guid.NewGuid().ToString("N");
                    bll.Update(school);
                    return new ApiResult<string>().SetSuccessResult(school.CLIENT_ID);
                }
            }
            return new ApiResult().SetFailedResult("用户名不存在");
        }

        public ApiResult Register(MemberDto form)
        {

            if (string.IsNullOrEmpty(form.SCHOOL_NAME))
            {
                return new ApiResult().SetFailedResult("学校名称不能空");
            }
          
            if (string.IsNullOrEmpty(form.MOBILE))
            {
                return new ApiResult().SetFailedResult("手机号不能空");
            }
            else
            {
                paraList.Clause = string.Format("APP_SCHOOL.MOBILE = @MOBILE");
                paraList.Add(new ParamData { DataType = DbType.String, ParamName = "MOBILE", Value = form.MOBILE });
                var ex = bll.GetCount<APP_SCHOOL>(paraList);
                if (ex > 0)
                {
                    return new ApiResult().SetFailedResult("手机号已被注册");
                }
            }
            if (string.IsNullOrEmpty(form.USER_PWD))
            {
                return new ApiResult().SetFailedResult("密码不能空");
            }

            paraList = new ParamCollection();

            paraList.Clause = String.Format("APP_SMS.MOBILE = @MOBILE ");
            paraList.Add(new ParamData { DataType = DbType.String, ParamName = "MOBILE", Value = form.MOBILE });
            var smsList = bll.Select<APP_SMS>(paraList, "APP_SMS.CREATE_TIME DESC", 1);
            if (smsList.Count > 0)
            {
                APP_SMS sms = smsList[0] as APP_SMS;
                if (sms.CREATE_TIME.AddMinutes(WebSettingsConfig.Minute) >= DateTime.Now)
                {
                    if (form.CheckCode == sms.NUMBER)
                    {
                        if (sms.IS_READ == 0)
                        {
                            sms.CurModel = DealModel.Modify;
                            sms.IS_READ = 1;
                            var item = new APP_SCHOOL(DealModel.New);
                            item.SCHOOL_NO = bll.GetSerialNo("SLN");
                            item.SCHOOL_NAME = form.SCHOOL_NAME;
                            item.MOBILE = form.MOBILE;
                            item.USER_PWD = DEncryptHelper.Encrypt(form.USER_PWD);
                            var id = bll.UpdateMasterDetail(item, new BaseList { sms });
                            if (id > 0)
                            {
                                return new ApiResult<decimal>().SetSuccessResult(id);
                            }
                            else
                            {
                                return new ApiResult().SetFailedResult("服务器忙");
                            }
                        }
                    }
                    else
                    {
                        return new ApiResult().SetFailedResult("验证码错误");
                    }
                }
                return new ApiResult().SetFailedResult("验证码已失效");
            }
            return new ApiResult().SetFailedResult("请重新获取验证码");

        }
        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="type">01 注册 02找回</param>
        /// <returns></returns>
        public ApiResult SendSms(string mobile, string type = "01")
        {
            if (string.IsNullOrEmpty(mobile))
            {
                return new ApiResult().SetFailedResult("手机号不能空");
            }

            if (type == "01")
            {
                paraList.Clause = string.Format("APP_SCHOOL.MOBILE = @MOBILE");
                paraList.Add(new ParamData { DataType = DbType.String, ParamName = "MOBILE", Value = mobile });
                var distinctUser = bll.GetCount<APP_SCHOOL>(paraList);
                if (distinctUser > 0)
                {
                    return new ApiResult().SetFailedResult("该手机已注册");
                }

            }

            if (type == "02")
            {
                paraList.Clause = string.Format("APP_SCHOOL.MOBILE = @MOBILE");
                paraList.Add(new ParamData { DataType = DbType.String, ParamName = "MOBILE", Value = mobile });
                var distinctUser = bll.GetCount<APP_SCHOOL>(paraList);
                if (distinctUser == 0)
                {
                    return new ApiResult().SetFailedResult("该手机尚未注册");
                }

            }

            paraList = new ParamCollection();
            var ip = HttpHelper.GetWebClientIp();

            if (!string.IsNullOrEmpty(ip))
            {

                paraList.Clause = String.Format("APP_SMS.REMARK = '{0}'", ip);
                var historyList = bll.Select<APP_SMS>(paraList, "APP_SMS.CREATE_TIME DESC", 1);
                if (historyList.Count > 0)
                {
                    var item = historyList[0];

                    var sp = item.CREATE_TIME.AddSeconds(60) - DateTime.Now;

                    if (sp.TotalSeconds > 0)
                    {
                        return new ApiResult().SetFailedResult(string.Format("请等待 {0} s,再试", Math.Abs((int)sp.TotalSeconds)));
                    }
                }
            }
            APP_SMS sms = new APP_SMS(DealModel.New);
            sms.SMS_NO = bll.GetSeqNo("SMS");
            sms.SMS_TYPE = type;
            sms.MOBILE = mobile;
            sms.IS_READ = 0;
            sms.NUMBER = StringExtend.RandCode(6);
            sms.MESSAGE = string.Format("@1@={0}||@2@={1}", sms.NUMBER, WebSettingsConfig.Minute);
            sms.REMARK = ip;
            //sms.REMARK = string.Format("您的验证码是{0}，{1}分钟内有效，如非本人操作，请忽略此消息。模板：16f47dfb71e544c5854833191c4ebe7d", sms.NUMBER, WebSettingsConfig.Minute);
            decimal id = bll.Update(sms);
            if (id > 0)
            {
                bool isSend = MessageService.sendTplSms("16f47dfb71e544c5854833191c4ebe7d", sms.MOBILE, sms.MESSAGE);
                if (isSend)
                {
                    return new ApiResult<string>().SetSuccessResult(sms.SMS_NO);
                }
            }
            return new ApiResult().SetFailedResult("获取失败");
        }


        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="type">01 注册 02找回</param>
        /// <returns></returns>
        public ApiResult SendChangeMobileSms(string old, string mobile)
        {
            if (string.IsNullOrEmpty(old))
            {
                return new ApiResult().SetFailedResult("原手机号不能空");
            }
            if (string.IsNullOrEmpty(mobile))
            {
                return new ApiResult().SetFailedResult("手机号不能空");
            }

            if (LoginMember == null)
            {
                return new ApiResult().SetFailedResult(100001, "获取用户信息失败，请重新登录");
            }
            else
            {
                if (old != LoginMember.MOBILE)
                {
                    return new ApiResult().SetFailedResult("原手机号码错误");
                }
            }

            paraList.Clause = string.Format("APP_SCHOOL.MOBILE = @MOBILE and APP_SCHOOL.SCHOOL_ID <> {0}", LoginMember.SCHOOL_ID);
            paraList.Add(new ParamData { DataType = DbType.String, ParamName = "MOBILE", Value = mobile });
            var distinctUser = bll.GetCount<APP_SCHOOL>(paraList);
            if (distinctUser > 0)
            {
                return new ApiResult().SetFailedResult("新手机号已被注册");
            }

            paraList = new ParamCollection();
            var ip = HttpHelper.GetWebClientIp();

            if (!string.IsNullOrEmpty(ip))
            {

                paraList.Clause = String.Format("APP_SMS.REMARK = '{0}'", ip);
                var historyList = bll.Select<APP_SMS>(paraList, "APP_SMS.CREATE_TIME DESC", 1);
                if (historyList.Count > 0)
                {
                    var item = historyList[0];

                    var sp = item.CREATE_TIME.AddSeconds(60) - DateTime.Now;

                    if (sp.TotalSeconds > 0)
                    {
                        return new ApiResult().SetFailedResult(string.Format("请等待 {0} s,再试", Math.Abs((int)sp.TotalSeconds)));
                    }
                }
            }
            APP_SMS sms = new APP_SMS(DealModel.New);
            sms.SMS_NO = bll.GetSeqNo("SMS");
            sms.SMS_TYPE = "01";
            sms.MOBILE = mobile;
            sms.IS_READ = 0;
            sms.NUMBER = StringExtend.RandCode(6);
            sms.MESSAGE = string.Format("@1@={0}||@2@={1}", sms.NUMBER, WebSettingsConfig.Minute);
            sms.REMARK = ip;
            //sms.REMARK = string.Format("您的验证码是{0}，{1}分钟内有效，如非本人操作，请忽略此消息。模板：16f47dfb71e544c5854833191c4ebe7d", sms.NUMBER, WebSettingsConfig.Minute);
            decimal id = bll.Update(sms);
            if (id > 0)
            {
                bool isSend = MessageService.sendTplSms("16f47dfb71e544c5854833191c4ebe7d", sms.MOBILE, sms.MESSAGE);
                if (isSend)
                {
                    return new ApiResult<string>().SetSuccessResult(sms.SMS_NO);
                }
            }
            return new ApiResult().SetFailedResult("获取失败");
        }

        public ApiResult ChangeMobile(ChangeMobileDto form)
        {
            if (string.IsNullOrEmpty(form.old))
            {
                return new ApiResult().SetFailedResult("原手机号不能空");
            }
            if (string.IsNullOrEmpty(form.mobile))
            {
                return new ApiResult().SetFailedResult("手机号不能空");
            }

            if (LoginMember == null)
            {
                return new ApiResult().SetFailedResult(100001, "获取用户信息失败，请重新登录");
            }
            else
            {
                if (form.old != LoginMember.MOBILE)
                {
                    return new ApiResult().SetFailedResult("原手机号码错误");
                }
            }
            paraList.Clause = string.Format("APP_SCHOOL.MOBILE = @MOBILE and APP_SCHOOL.SCHOOL_ID <> {0}", LoginMember.SCHOOL_ID);
            paraList.Add(new ParamData { DataType = DbType.String, ParamName = "MOBILE", Value = form.mobile });
            var distinctUser = bll.GetCount<APP_SCHOOL>(paraList);
            if (distinctUser > 0)
            {
                return new ApiResult().SetFailedResult("新手机号已被注册");
            }

            paraList = new ParamCollection();

            paraList.Clause = String.Format("APP_SMS.MOBILE = @MOBILE ");
            paraList.Add(new ParamData { DataType = DbType.String, ParamName = "MOBILE", Value = form.mobile });
            var smsList = bll.Select<APP_SMS>(paraList, "APP_SMS.CREATE_TIME DESC", 1);
            if (smsList.Count > 0)
            {
                APP_SMS sms = smsList[0] as APP_SMS;
                if (sms.CREATE_TIME.AddMinutes(WebSettingsConfig.Minute) >= DateTime.Now)
                {
                    if (form.CheckCode == sms.NUMBER)
                    {
                        if (sms.IS_READ == 0)
                        {
                            sms.CurModel = DealModel.Modify;
                            sms.IS_READ = 1;
                            LoginMember.CurModel = DealModel.Modify;
                            LoginMember.MOBILE = form.mobile;
                            var id = bll.Update(LoginMember);
                            if (id > 0)
                            {
                                return new ApiResult<decimal>().SetSuccessResult(id);
                            }
                            else
                            {
                                return new ApiResult().SetFailedResult("服务器忙");
                            }
                        }
                    }
                    else
                    {
                        return new ApiResult().SetFailedResult("验证码错误");
                    }
                }
                return new ApiResult().SetFailedResult("验证码已失效");
            }

            return new ApiResult().SetFailedResult("请重新获取验证码");

        }

        public ApiResult Online() {

            var online = 1;
            if (LoginMember == null) {
                online = 0;
            }
            return new ApiResult<int>().SetSuccessResult(online);
        }

        #endregion

        #region 会员信息

        public ApiResult Update(MemberDto form)
        {
            if (LoginMember == null)
            {
                return new ApiResult().SetFailedResult(100001, "获取用户信息失败，请重新登录");
            }
            var item = LoginMember;
            item.CurModel = DealModel.Modify;
            if (!string.IsNullOrEmpty(form.npwd))
            {
                item.USER_PWD = DEncryptHelper.Encrypt(form.npwd);
            }
            item.SCHOOL_NAME = form.SCHOOL_NAME;
            item.EN_NAME = form.EN_NAME;
            item.NICK_NAME = form.NICK_NAME;
            item.IMAGE_ID = form.IMAGE_ID;
            item.HEAD_ID = form.HEAD_ID;
            item.FILE_ID = form.FILE_ID;
            item.PROVINCE_NO = form.PROVINCE_NO;
            item.CITY_NO = form.CITY_NO;
            item.DISYRICT_NO = form.DISYRICT_NO;
            item.ADDRESS = form.ADDRESS;
            item.ADDRESS_EN = form.ADDRESS_EN;
            item.HOME_PAGE = form.HOME_PAGE;
            item.ESPECIALLY_COURSE = form.ESPECIALLY_COURSE;
            item.STU_QTY = form.STU_QTY;
            item.RECRUIT_QTY = form.RECRUIT_QTY;
            item.TAS_RATE = form.TAS_RATE;
            item.FT_QTY = form.FT_QTY;
            item.ENROLL_RATE = form.ENROLL_RATE;
            item.ENROLL_QTY = form.ENROLL_QTY;
            item.TUITION_CNY = form.TUITION_CNY;
            item.TUITION_USD = form.TUITION_USD;
            item.STAY_CNY = form.STAY_CNY;
            item.STAY_USD = form.STAY_USD;

            #region 荣誉

            var details = new BaseList();
            paraList.Clause = string.Format("APP_HONOR.SCHOOL_NO = @SCHOOL_NO");
            paraList.Add(new ParamData { ParamName = "SCHOOL_NO", DataType = DbType.String, Value = item.SCHOOL_NO });
            var list = bll.Select<APP_HONOR>(paraList);
            list.ForEach(a => a.CurModel = DealModel.Delete);

            form.Honors.ForEach(a =>
            {
                var x = list.Find(y => y.ID == a.ID);
                if (x != null)
                {
                    x.CurModel = DealModel.Modify;
                    x.HONOR_YEAR = a.HONOR_YEAR;
                    x.HONOR_DESC = a.HONOR_DESC;
                    x.HONOR_EN = a.HONOR_EN;
                    details.Add(x);
                }
                else
                {
                    var honor = a.ConvertTo<APP_HONOR>();
                    honor.CurModel = DealModel.New;
                    honor.SCHOOL_NO = item.SCHOOL_NO ;
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

            #region 设施

            var facilitiesData = new BaseList();
            paraList = new ParamCollection();
            paraList.Clause = string.Format("APP_FACILITIES.SCHOOL_NO = @SCHOOL_NO");
            paraList.Add(new ParamData { ParamName = "SCHOOL_NO", DataType = DbType.String, Value = item.SCHOOL_NO });
            var facilities = bll.Select<APP_FACILITIES>(paraList);
            facilities.ForEach(a => a.CurModel = DealModel.Delete);
            foreach (var fs in form.Facilities1)
            {
                var exitem = facilities.Find(a => a.TITLE == fs.TITLE && a.FACILITIES_TYPE == "02");
                var fsitem = fs.ConvertTo<APP_FACILITIES>();
                if (exitem == null)
                {
                    fsitem.CurModel = DealModel.New;
                    facilitiesData.Add(fsitem);
                }
                else
                {
                    exitem.CurModel = DealModel.None;
                    fsitem.CurModel = DealModel.Modify;
                    facilitiesData.Add(fsitem);
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

                    exitem.CurModel = DealModel.None;
                    fsitem.CurModel = DealModel.Modify;
                    facilitiesData.Add(fsitem);
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
                    exitem.CurModel = DealModel.None;
                    fsitem.CurModel = DealModel.Modify;
                    facilitiesData.Add(fsitem);
                }
            }
            facilities.ForEach(a =>
            {
                if (a.CurModel == DealModel.Delete) {
                    facilitiesData.Add(a);
                }
            });
            #endregion 
            decimal id = bll.UpdateMasterDetail(item, details, facilitiesData);
            if (item.CurModel == DealModel.Modify)
            {
                id = item.ID;
            }
            return new ApiResult<decimal>().SetSuccessResult(id);
        }

        public ApiResult Info()
        {
            if (LoginMember != null)
            {
                var item = LoginMember;
                var info = item.ConvertTo<MemberDto>();
                info.ArrayArea = new List<string> {
                    item.PROVINCE_NO,
                    item.CITY_NO
                };
                paraList.Clause = string.Format("APP_HONOR.SCHOOL_NO = '{0}'", item.SCHOOL_NO);
                var list = bll.Select<APP_HONOR>(paraList);
                list.ForEach(a =>
                {
                    info.Honors.Add(a.ConvertTo<SchoolHonorDto>());
                });
                if (info.Honors.Count == 0) {
                    info.Honors.Add(new SchoolHonorDto());
                }

                paraList.Clause = string.Format("APP_FACILITIES.SCHOOL_NO = '{0}'", item.SCHOOL_NO);
                var facilities = bll.Select<APP_FACILITIES>(paraList);

                paraList.Clause = string.Format("BASE_TYPE.CLASS_NO IN ('02','03','04')");

                var dbfacilities = bll.Select<BASE_TYPE>(paraList);
                if (facilities.Count == 0)
                {
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
                }


                facilities.ForEach(a =>
                {
                    var temp = a.ConvertTo<FacilitiesDto>();
                    temp.enabled = a.IS_ENABLED == 1;
                    if (a.FACILITIES_TYPE == "02")
                    {
                        if (a.IS_ENABLED == 1)
                        {
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

                return new ApiResult<MemberDto>().SetSuccessResult(info);
            }
            return new ApiResult().SetFailedResult(100001, "获取用户信息失败，请重新登录");
        }

        #endregion

        #region 帮助中心

        public ApiResult Help()
        {
            var list = new List<HelpDto>();
            paraList.Clause = string.Format("APP_HELP.IS_ENABLED = 1");

            var queryDb = bll.Select<APP_HELP>(paraList, "APP_HELP.SEQ_NO ASC, APP_HELP.CREATE_TIME DESC", 6);

            queryDb.ForEach(item =>
            {
                list.Add(item.ConvertTo<HelpDto>());
            });

            return new ApiResult<List<HelpDto>>().SetSuccessResult(list);
        }
        public ApiResult HelpInfo(decimal id)
        {
            var info = new HelpDto();
            var item = bll.Get<APP_HELP>(id);
            if (item != null)
            {
                info = item.ConvertTo<HelpDto>();
            }

            return new ApiResult<HelpDto>().SetSuccessResult(info);
        }
        #endregion

        #region 意见建议

        public ApiResult Feedback(FeedbackDto form)
        {
            if (string.IsNullOrEmpty(form.MESSAGE))
            {
                return new ApiResult().SetFailedResult("请输入反馈内容");
            }

            if (LoginMember == null)
            {
                return new ApiResult().SetFailedResult(100001, "获取用户信息失败，请重新登录");
            }
            var ip = HttpHelper.GetWebClientIp();

            if (!string.IsNullOrEmpty(ip))
            {

                paraList.Clause = String.Format("APP_MSG.REMARK = '{0}'", ip);
                var historyList = bll.Select<APP_MSG>(paraList, "APP_MSG.CREATE_TIME DESC", 1);
                if (historyList.Count > 0)
                {
                    var item = historyList[0];

                    var sp = item.CREATE_TIME.AddSeconds(60) - DateTime.Now;

                    if (sp.TotalSeconds > 0)
                    {
                        return new ApiResult().SetFailedResult(string.Format("请等待 {0} s,再试", Math.Abs((int)sp.TotalSeconds)));
                    }
                }
            }

            var message = new APP_MSG(DealModel.New);
            message.MSG_NO = bll.GetSeqNo("MSGN");
            message.MSG_TYPE = "01";
            message.TITLE = "意见反馈";
            message.DATE_PUBLISH =DateTime.Now;
            message.LINK_MAN = LoginMember.NICK_NAME;
            message.LINK_TEL = LoginMember.MOBILE;
            message.MESSAGE = form.MESSAGE;
            message.IS_ENABLED = 0;
            message.REMARK = ip;
            var id = bll.Update(message);
            if (id > 0)
            {
                return new ApiResult<decimal>().SetSuccessResult(id);
            }
            else
            {
                return new ApiResult().SetFailedResult("服务器忙");
            }


        }

        #endregion

        #region 素材管理

        public ApiResult Files()
        {
            if (LoginMember == null)
            {
                return new ApiResult().SetFailedResult(100001, "获取用户信息失败，请重新登录");
            }

            var info = new MemberFile();

            paraList.Clause = string.Format("APP_SCHOOL_FILE.SCHOOL_NO = '{0}'", LoginMember.SCHOOL_NO);

            var queryDB = bll.Select<APP_SCHOOL_FILE>(paraList);

            foreach (var item in queryDB) {

                if (item.FILE_TYPE == "01") {
                    info.img.Add(item.ConvertTo<MemberFileDto>());
                }
                else if (item.FILE_TYPE == "02")
                {
                    info.video.Add(item.ConvertTo<MemberFileDto>());
                }
            }
            return new ApiResult<MemberFile>().SetSuccessResult(info);
        }

        public ApiResult DeleteFile(string ids)
        {
            if (LoginMember == null)
            {
                return new ApiResult().SetFailedResult(100001, "获取用户信息失败，请重新登录");
            }
            string[] arrs = ids.Split(',');
            if (arrs.Length > 0)
            {
                int rows = 0;
                foreach (string item in arrs)
                {
                    if (RegHelper.IsDecimal(item))
                    {
                        var model = bll.Get<APP_SCHOOL_FILE>(Convert.ToDecimal(item));
                        if (model != null)
                        {
                            decimal id = bll.Delete(model);
                            rows += (int)id;
                        }
                    }
                  
                }
                return new ApiResult<int>().SetSuccessResult(rows);
            }
            else
            {
                return new ApiResult().SetFailedResult("请选择需要删除的数据");
            }
        }

        public ApiResult UpdateFile(MemberFileDto form)
        {
            if (LoginMember == null)
            {
                return new ApiResult().SetFailedResult(100001, "获取用户信息失败，请重新登录");
            }

            var item = form.ConvertTo<APP_SCHOOL_FILE>();

            if (item.ID > 0)
            {
                item.CurModel = DealModel.Modify;
            }
            else
            {
                item.CurModel = DealModel.New;
                item.SCHOOL_NO = LoginMember.SCHOOL_NO;
            }

            decimal id = bll.Update(item);
            if (item.CurModel == DealModel.Modify)
            {
                id = item.ID;
            }
            return new ApiResult<decimal>().SetSuccessResult(id);
        }

        #endregion
    }
}

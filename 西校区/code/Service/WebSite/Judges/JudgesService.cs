using CMS.Core.Common;
using CMS.Core.Common.TableExtend;
using CMS.Core.Responsity;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using CMS.IService;
using CMS.IService.WebSite.Home;
using CMS.IService.WebSite.Judges.Dto;
using CMS.IService.WebSite.Member.Dto;
using System;
using System.Collections.Generic;
using System.Data;

namespace CMS.Service.Judges
{
    public class JudgesService : JudgesContext, IJudgesService
    {
        ParamCollection paraList = new ParamCollection();
        private IBaseRepository<SqlServercfg> bll;
        public JudgesService(IBaseRepository<SqlServercfg> _bll)
        {
            bll = _bll;
        }


        #region 注册、登录

        public ApiResult Login(JudgesLoginDto form)
        {
            if (string.IsNullOrEmpty(form.uid))
            {
                return new ApiResult().SetFailedResult("用户名不能空");
            }
            if (string.IsNullOrEmpty(form.pwd))
            {
                return new ApiResult().SetFailedResult("密码不能空");
            }
            paraList.Clause = string.Format("APP_JUDGES.MOBILE = @MOBILE");
            paraList.Add(new ParamData { DataType = DbType.String, ParamName = "MOBILE", Value = form.uid });
            var schools = bll.Select<APP_JUDGES>(paraList);
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

        public ApiResult Register(JudgesDto form)
        {
            if (string.IsNullOrEmpty(form.NICK_NAME))
            {
                return new ApiResult().SetFailedResult("昵称不能空");
            }
            if (string.IsNullOrEmpty(form.COMPANY))
            {
                return new ApiResult().SetFailedResult("单位不能空");
            }
            if (string.IsNullOrEmpty(form.POSITION))
            {
                return new ApiResult().SetFailedResult("职位不能空");
            }
            if (string.IsNullOrEmpty(form.MOBILE))
            {
                return new ApiResult().SetFailedResult("手机号不能空");
            }
            else
            {
                paraList.Clause = string.Format("APP_JUDGES.MOBILE = @MOBILE");
                paraList.Add(new ParamData { DataType = DbType.String, ParamName = "MOBILE", Value = form.MOBILE });
                var ex = bll.GetCount<APP_JUDGES>(paraList);
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
                            var item = new APP_JUDGES(DealModel.New);
                            item.JUDGES_NO = bll.GetSerialNo("JDN");
                            item.NICK_NAME = form.NICK_NAME;
                            item.MOBILE = form.MOBILE;
                            item.POSITION = form.POSITION;
                            item.COMPANY = form.COMPANY;
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
                paraList.Clause = string.Format("APP_JUDGES.MOBILE = @MOBILE");
                paraList.Add(new ParamData { DataType = DbType.String, ParamName = "MOBILE", Value = mobile });
                var distinctUser = bll.GetCount<APP_JUDGES>(paraList);
                if (distinctUser > 0)
                {
                    return new ApiResult().SetFailedResult("该手机已注册");
                }

            }

            if (type == "02")
            {
                paraList.Clause = string.Format("APP_JUDGES.MOBILE = @MOBILE");
                paraList.Add(new ParamData { DataType = DbType.String, ParamName = "MOBILE", Value = mobile });
                var distinctUser = bll.GetCount<APP_JUDGES>(paraList);
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

            if (LoginJudges == null)
            {
                return new ApiResult().SetFailedResult(100002, "获取用户信息失败，请重新登录");
            }
            else
            {
                if (old != LoginJudges.MOBILE)
                {
                    return new ApiResult().SetFailedResult("原手机号码错误");
                }
            }

            paraList.Clause = string.Format("APP_JUDGES.MOBILE = @MOBILE and APP_JUDGES.JUDGES_ID <> {0}", LoginJudges.JUDGES_ID);
            paraList.Add(new ParamData { DataType = DbType.String, ParamName = "MOBILE", Value = mobile });
            var distinctUser = bll.GetCount<APP_JUDGES>(paraList);
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

        public ApiResult ChangeMobile(JudgesChangeMobileDto form)
        {
            if (string.IsNullOrEmpty(form.old))
            {
                return new ApiResult().SetFailedResult("原手机号不能空");
            }
            if (string.IsNullOrEmpty(form.mobile))
            {
                return new ApiResult().SetFailedResult("手机号不能空");
            }

            if (LoginJudges == null)
            {
                return new ApiResult().SetFailedResult(100002, "获取用户信息失败，请重新登录");
            }
            else
            {
                if (form.old != LoginJudges.MOBILE)
                {
                    return new ApiResult().SetFailedResult("原手机号码错误");
                }
            }
            paraList.Clause = string.Format("APP_JUDGES.MOBILE = @MOBILE and APP_JUDGES.JUDGES_ID <> {0}", LoginJudges.JUDGES_ID);
            paraList.Add(new ParamData { DataType = DbType.String, ParamName = "MOBILE", Value = form.mobile });
            var distinctUser = bll.GetCount<APP_JUDGES>(paraList);
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
                            LoginJudges.CurModel = DealModel.Modify;
                            LoginJudges.MOBILE = form.mobile;
                            var id = bll.Update(LoginJudges);
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

        #endregion

        #region 会员信息

        public ApiResult Update(JudgesDto form)
        {
            if (LoginJudges == null)
            {
                return new ApiResult().SetFailedResult(100002, "获取用户信息失败，请重新登录");
            }
            var item = LoginJudges;
            item.CurModel = DealModel.Modify;
            if (!string.IsNullOrEmpty(form.npwd))
            {
                item.USER_PWD = DEncryptHelper.Encrypt(form.npwd);
            }
            item.NICK_NAME = form.NICK_NAME;
            item.IMAGE_ID = form.IMAGE_ID;
            item.PROVINCE_NO = form.PROVINCE_NO;
            item.IMAGE_ID = form.IMAGE_ID;
            item.CITY_NO = form.CITY_NO;
            item.PROVINCE_NO = form.PROVINCE_NO;
            item.DISYRICT_NO = form.DISYRICT_NO;
            item.DISYRICT_NO = form.DISYRICT_NO;
            item.ADDRESS = form.ADDRESS;
            item.COMPANY = form.COMPANY;
            item.POSITION = form.POSITION;
            item.LINK_TEL = form.LINK_TEL;
            item.EMAIL = form.EMAIL;
            item.WECHAT = form.WECHAT;
            item.LINK_MAN = form.LINK_MAN;
            item.IMAGE_ID = form.IMAGE_ID;

            #region 荣誉

            var details = new BaseList();
            paraList.Clause = string.Format("APP_JUDGES_HONOR.JUDGES_NO = @JUDGES_NO");
            paraList.Add(new ParamData { ParamName = "JUDGES_NO", DataType = DbType.String, Value = item.JUDGES_NO });
            var list = bll.Select<APP_JUDGES_HONOR>(paraList);
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

        public ApiResult Info()
        {
            if (LoginJudges != null)
            {
                var item = LoginJudges;
                var info = item.ConvertTo<JudgesDto>();
                info.ArrayArea = new List<string> {
                    item.PROVINCE_NO,
                    item.CITY_NO
                };
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
                if (info.Honors.Count == 0)
                {
                    info.Honors.Add(new JudgesHonorDto());
                }
                if (info.Resume.Count == 0)
                {
                    info.Resume.Add(new JudgesHonorDto());
                }

                return new ApiResult<JudgesDto>().SetSuccessResult(info);
            }
            return new ApiResult().SetFailedResult(100002, "获取用户信息失败，请重新登录");
        }

        public ApiResult Online()
        {
            var online = 1;
            if (LoginJudges == null)
            {
                online = 0;
            }
            return new ApiResult<int>().SetSuccessResult(online);
        }

        public ApiResult Feedback(FeedbackDto form)
        {
            if (string.IsNullOrEmpty(form.MESSAGE))
            {
                return new ApiResult().SetFailedResult("请输入反馈内容");
            }

            if (LoginJudges == null)
            {
                return new ApiResult().SetFailedResult(100002, "获取用户信息失败，请重新登录");
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
            message.DATE_PUBLISH = DateTime.Now;
            message.LINK_MAN = LoginJudges.NICK_NAME;
            message.LINK_TEL = LoginJudges.MOBILE;
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

        public ApiResult QuestionnaireInfo()
        {
            //if (LoginJudges == null)
            //{
            //    return new ApiResult().SetFailedResult(100002, "获取用户信息失败，请重新登录");
            //}

            var info = new JudgesQuestionnaireDto() { };

            paraList.Clause = string.Format("APP_QUESTIONNAIRE.IS_ENABLED = 1 AND APP_QUESTIONNAIRE.QUESTIONNAIRE_START <= GETDATE() and APP_QUESTIONNAIRE.QUESTIONNAIRE_END >= GETDATE()");
            var query = bll.Select<APP_QUESTIONNAIRE>(paraList, "APP_QUESTIONNAIRE.QUESTIONNAIRE_END desc", 1);
            if (query.Count > 0)
            {
                var item = query[0];
                info = item.ConvertTo<JudgesQuestionnaireDto>();
                info.loaded = true;
                var span = item.QUESTIONNAIRE_END - DateTime.Now;
                if (span != null) {

                    info.surplus = $"{span.Value.Days}天 {span.Value.Hours}小时 {span.Value.Minutes} 分 ";
                }
                info.reciewDate = item.QUESTIONNAIRE_START.Value.ToString("yyyy-MM-dd") + " 至 " + item.QUESTIONNAIRE_END.Value.ToString("yyyy-MM-dd");
                paraList.Clause = string.Format("APP_QUESTIONNAIRE_ITEM.QUESTIONNAIRE_NO = '{0}'", item.QUESTIONNAIRE_NO);
                var list = bll.Select<APP_QUESTIONNAIRE_ITEM>(paraList);
                foreach (var rw in list)
                {
                    var row = new JudgesQuestionnaireItemDto
                    {
                        id = rw.ID,
                        title = rw.TITLE,
                    };
                    if (LoginJudges != null) {
                        paraList.Clause = string.Format("APP_QUESTIONNAIRE_JUDGES.QUESTIONNAIRE_NO = '{0}' AND APP_QUESTIONNAIRE_JUDGES.JUDGES_NO = '{1}' AND APP_QUESTIONNAIRE_JUDGES.ITEM_ID = {2}", item.QUESTIONNAIRE_NO, LoginJudges.JUDGES_NO, rw.ID);

                        var reslts = bll.Select<APP_QUESTIONNAIRE_JUDGES>(paraList);

                        for (int i = 0; i < rw.RESULT_MAX; i++)
                        {

                            var rs = new JudgesQuestionnaireItemResultDto();
                            if (i < reslts.Count)
                            {
                                rs.school_name = reslts[i].SCHOOL_NAME;
                                rs.reason = reslts[i].REASON;
                                rs.id = reslts[i].ID;
                            }
                            row.result.Add(rs);
                        }
                    }
                    info.list.Add(row);
                }

            }
            return new ApiResult<JudgesQuestionnaireDto>().SetSuccessResult(info);
        }

        public ApiResult Questionnaire(JudgesQuestionnaireDto form)
        {
            if (LoginJudges == null)
            {
                return new ApiResult().SetFailedResult(100002, "获取用户信息失败，请重新登录");
            }
            var item = bll.Get<APP_QUESTIONNAIRE>(form.QUESTIONNAIRE_NO);
            if (item != null)
            {
                var data = new BaseList();
                foreach (var rw in form.list)
                {
                    var questItem = bll.Get<APP_QUESTIONNAIRE_ITEM>(rw.id);
                    if (questItem != null)
                    {
                        paraList.Clause = string.Format("APP_QUESTIONNAIRE_JUDGES.QUESTIONNAIRE_NO = '{0}' AND APP_QUESTIONNAIRE_JUDGES.JUDGES_NO = '{1}' AND APP_QUESTIONNAIRE_JUDGES.ITEM_ID = {2}", item.QUESTIONNAIRE_NO, LoginJudges.JUDGES_NO, rw.id);
                        var reslts = bll.Select<APP_QUESTIONNAIRE_JUDGES>(paraList);

                        foreach (var rs in rw.result)
                        {
                            var ex = reslts.Find(a => a.ID == rs.id);
                            if (ex == null)
                            {
                                ex = new APP_QUESTIONNAIRE_JUDGES(DealModel.New);
                                ex.QUESTIONNAIRE_NO = item.QUESTIONNAIRE_NO;
                                ex.ITEM_ID = questItem.ITEM_ID;
                                ex.JUDGES_NO = LoginJudges.JUDGES_NO;
                                ex.TITLE = questItem.TITLE;
                                ex.SCHOOL_NAME = rs.school_name;
                                ex.REASON = rs.reason;
                                data.Add(ex);
                            }
                            else
                            {
                                ex.CurModel = DealModel.Modify;
                                ex.SCHOOL_NAME = rs.school_name;
                                ex.REASON = rs.reason;
                                data.Add(ex);
                            }
                        }
                    }

                }

                bll.UpdateAllByParams(data);

                return new ApiResult().SetSuccessResult();
            }

            return new ApiResult().SetFailedResult("提交的信息无效");
        }

        public ApiResult List(int size, int page)
        {
            ParamCollection paraList = new ParamCollection();
            string clause = string.Empty;
            string column = "";

            var query = System.Web.HttpContext.Current.Request.QueryString;
            if (query["type"] == "01")
            {
                clause += string.Format("AND (APP_JUDGES.IS_MAIN = 1)", APP_JUDGES.TABLE_NAME, column);
            }
            else if (query["type"] == "02")
            {
                clause += string.Format("AND (APP_JUDGES.IS_SPECIAL = 1)", APP_JUDGES.TABLE_NAME, column);
            }
            clause += string.Format("AND (APP_JUDGES.IS_ENABLED = 1)", APP_JUDGES.TABLE_NAME, column);
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
            var list = new List<JudgesDto>();
            foreach (var item in queryList)
            {
                var row = item.ConvertTo<JudgesDto>();

                list.Add(row);
            }
            var result = new RequestMessagePageList<List<JudgesDto>>(list, pageCount, page, size);
            result.Move = list.Count >= size && pageCount % size != 0;
            return new ApiResult<RequestMessageBase<List<JudgesDto>>>().SetSuccessResult(result);
        }

        #endregion

    }
}

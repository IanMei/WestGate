using CMS.Core.Common;
using CMS.Core.Responsity;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using CMS.IService.Admin.Account.Dto;
using System;
using System.Data;

namespace CMS.Service {
    public class UserContext {
        private UserInfo userInfo = null;
        public UserInfo LoginInfo
        {
            get
            {
                if (userInfo != null)
                    return userInfo;

                var token = System.Web.HttpContext.Current.Request.Headers["token"];
                var bll = new BaseRepository<SqlServercfg>();
                ParamCollection paraList = new ParamCollection();
                string Clause = "", column = "";
                column = USER_DEVICE.TOKEN_FIELD;
                Clause += String.Format("AND ({0}.{1} = @{1}) ", USER_DEVICE.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, token));
                if (Clause.Length > 3)
                {
                    Clause = Clause.Substring(3, Clause.Length - 3);
                }
                paraList.Clause = Clause;
                var queryList = bll.Select<USER_DEVICE>(paraList, "USER_DEVICE.CREATE_TIME DESC", 1);
                if (queryList.Count > 0)
                {
                    USER_DEVICE device = queryList[0];
                    SYS_USER item = bll.Get<SYS_USER>(device.USER_ID);
                    if (item != null)
                    {
                        userInfo = new UserInfo
                        {
                            UserId = Convert.ToInt32(item.USER_ID),
                            UserCode = item.USER_CODE,
                            RoleType = item.ROLE_TYPE,
                            UserName = item.USER_NAME,
                            Mobile = item.MOBILE,
                            IsActive = Convert.ToBoolean(item.IS_AVAILABLE),
                            Token = item.Token,
                            OrganCode = item.ORGAN_CODE
                        };
                    }
                }
                return userInfo;
            }
        }
    }
}

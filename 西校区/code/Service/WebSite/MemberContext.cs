using CMS.Core.Common;
using CMS.Core.Responsity;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using CMS.IService.WebSite.Member.Dto;
using System;
using System.Data;

namespace CMS.Service {
    public class MemberContext
    {
        private APP_SCHOOL userInfo = null;
        public APP_SCHOOL LoginMember
        {
            get
            {
                if (userInfo != null)
                    return userInfo;
                var token = System.Web.HttpContext.Current.Request.Headers["m-sessionid"];
                if (string.IsNullOrEmpty(token)) {
                    return null;
                }
                var bll = new BaseRepository<SqlServercfg>();
                ParamCollection paraList = new ParamCollection();
                paraList.Clause = String.Format("APP_SCHOOL.CLIENT_ID = '{0}' ", token);
            
                var queryList = bll.Select<APP_SCHOOL>(paraList, "APP_SCHOOL.CREATE_TIME DESC", 1);
                if (queryList.Count > 0)
                {
                    userInfo = queryList[0];
                }
                return userInfo;
            }
        }
    }
}

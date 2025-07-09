using CMS.Core.Common;
using CMS.Core.Responsity;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using CMS.IService.WebSite.Member.Dto;
using System;
using System.Data;

namespace CMS.Service {
    public class JudgesContext
    {
        private APP_JUDGES userInfo = null;
        public APP_JUDGES LoginJudges
        {
            get
            {
                if (userInfo != null)
                    return userInfo;
                var token = System.Web.HttpContext.Current.Request.Headers["j-sessionid"];
                if (string.IsNullOrEmpty(token)) {
                    return null;
                }
                var bll = new BaseRepository<SqlServercfg>();
                ParamCollection paraList = new ParamCollection();
                paraList.Clause = String.Format("APP_JUDGES.CLIENT_ID = '{0}' ", token);
            
                var queryList = bll.Select<APP_JUDGES>(paraList, "APP_JUDGES.CREATE_TIME DESC", 1);
                if (queryList.Count > 0)
                {
                    userInfo = queryList[0];
                }
                return userInfo;
            }
        }
    }
}

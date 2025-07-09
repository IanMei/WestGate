using CMS.Core.Common;
using CMS.Core.DAL;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace CMS.Core.Responsity.BLL {

    public class DynamicRepository<C> : IDynamicRepository<C> where C : DataBasecfg {

        public string QueryList(string _table)
        {
            throw new NotImplementedException();
        }
    }
}

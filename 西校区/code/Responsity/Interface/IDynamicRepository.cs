using CMS.Core.Common;
using CMS.Core.Responsity.BLL;
using CMS.Core.Responsity.Db;
using System;
using System.Collections.Generic;

namespace CMS.Core.Responsity
{
    public interface IDynamicRepository<T> where T : DataBasecfg {
        string QueryList(string _table);
    }
}

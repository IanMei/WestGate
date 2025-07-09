using CMS.Core.Common;
using CMS.Core.Responsity.Db;
using System.Collections.Generic;

namespace CMS.Core.Responsity.BLL {

    public interface IExtendRepository<T> where T : DataBasecfg {
        List<T> SelectBySql<T>(string sql) where T : class, new();
        List<T> SelectProcedure<T>(string ProcName, ParamCollection param) where T : class, new();
    }
}

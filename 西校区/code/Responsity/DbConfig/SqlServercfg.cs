using CMS.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Core.Responsity.Db {

    public class SqlServercfg : DataBasecfg {

        public override string getConfigString()
        {
            return base.getConfigString(); //这里放不同连接或者不同数据库的字符串，按需求扩展，目前暂未实现
        }
    }
}

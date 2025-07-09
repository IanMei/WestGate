using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Responsity.Db {
    public abstract class DataBasecfg {

        /// <summary>
        /// 连接串
        /// </summary>
        public virtual string getConfigString() {
            return "";
        }
    }
}

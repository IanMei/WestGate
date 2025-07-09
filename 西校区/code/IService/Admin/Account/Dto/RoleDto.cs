using System.Collections.Generic;

namespace CMS.IService.Admin.Account.Dto {
    public class PagedRolesResponse {
        /// <summary>
        /// 返回数据
        /// </summary>
        public List<RoleInfo> List { get; set; }
        /// <summary>
        /// 当前页数
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int size { get; set; }
        /// <summary>
        /// 总数量
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 是否最后一页
        /// </summary>
        public bool islast { get; set; }
        /// <summary>
        /// 刷新
        /// </summary>
        public bool refreshing { get; set; }
    }

    public class RoleInfo {
        public RoleInfo()
        {
            RoleType = "01";
            Modules = new List<ModuleItem>();
        }
        /// <summary>
        /// 角色Id
        /// </summary>
        public decimal RoleId { get; set; }
        /// <summary>
        /// 唯一编号
        /// </summary>
        public string RoleNo { get; set; }
        /// <summary>
        /// 角色类别
        /// </summary>
        public string RoleType { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        public List<ModuleItem> Modules { get; set; }
    }

    public class ModuleItem {
        public ModuleItem()
        {
            Pages = new List<PageItem>();
        }
        public bool selected { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public List<PageItem> Pages { get; set; }
    }

    public class PageItem {
        public PageItem()
        {
            Operations = new List<OperationItem>();
        }
        public bool selected { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public List<OperationItem> Operations { get; set; }
    }

    public class OperationItem {
        public bool selected { get; set; }
        public string code { get; set; }
        public string name { get; set; }
    }
}

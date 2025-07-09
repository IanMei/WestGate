using System; 
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IService.Admin.Account.Dto {
    public class loginManageDto
    {
        public string uid { get; set; }
        public string pwd { get; set; }
    }

    public class loginUserDto {
        public loginUserDto() {
            
        }

        /// <summary>
        /// Uid
        /// </summary>
        public decimal Uid { get; set; }
        /// <summary>
        /// token字符串
        /// </summary>
        public string AccessToken { get; set; }


        /// <summary>
        /// 用户昵称
        /// </summary>
        public string Name { get; set; }

        public Array Prems { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public int ExpiresIn { get; set; }

        public string Menus { get; set; }
    }
    /// <summary>
    /// 密码变更
    /// </summary>
    public class ChangePwd {
        public string oldpwd { get; set; }
        public string newpwd { get; set; }
        public string confirmpwd { get; set; }
    }
    /// <summary>
    /// 权限模块
    /// </summary>
    public class NavMenuNode {
        public NavMenuNode()
        {
           
        }
        public string path { get; set; }
        public string title { get; set; }
        public string icon { get; set; }
        public List<ItemNode> children { get; set; }
    }
    /// <summary>
    /// 页面模块
    /// </summary>
    public class ItemNode {
        public string path { get; set; }
        public string title { get; set; }
        public string icon { get; set; }
    }
    /// <summary>
    /// 用户设备
    /// </summary>
    public class UserDevice {
        /// <summary>
        /// 设备Id
        /// </summary>
        public int UserDeviceId { get; set; }
        /// <summary>
        /// Ip地址
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public decimal UserId { get; set; }
        /// <summary>
        /// 有效时间
        /// </summary>
        public DateTime ActiveTime { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpiredTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 设备类别
        /// </summary>
        public int DeviceType { get; set; }
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
    }


    public class UserIdentity<TKey> : IIdentity {
        public UserIdentity(IUser<TKey> user)
        {
            if (user != null)
            {
                IsAuthenticated = true;
                UserId = user.UserId;
                Name = user.UserName.ToString();
                UserCode = user.UserCode;
                RoleType = user.RoleType;
                //Permissions = user.Permissions;
                //Permlist = user.Permlist;
            }
        }

        public string AuthenticationType
        {
            get { return "CustomAuthentication"; }
        }

        public TKey UserId { get; private set; }

        public bool IsAuthenticated { get; private set; }

        public string Name { get; private set; }

        public string UserCode { get; private set; }

        public string RoleType { get; private set; }

        //public string Permissions { get; private set; }

        //public IList<Permission> Permlist { get; private set; }
    }

    public class UserPrincipal<TKey> : IPrincipal {
        public UserPrincipal(UserIdentity<TKey> identity)
        {
            Identity = identity;
        }

        public UserPrincipal(IUser<TKey> user)
            : this(new UserIdentity<TKey>(user))
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public UserIdentity<TKey> Identity { get; private set; }

        IIdentity IPrincipal.Identity
        {
            get { return Identity; }
        }

        bool IPrincipal.IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }

    public interface IUser<T> {
        /// <summary>
        /// 用户Id
        /// </summary>
        T UserId { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        string UserCode { get; set; }
        /// <summary>
        /// 权限类别
        /// </summary>
        string RoleType { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        string UserName { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        //string Permissions { get; set; }
        /// <summary>
        /// 权限列表
        /// </summary>
        //IList<Permission> Permlist { get; set; }
    }

    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo : IUser<int> {
        /// <summary>
		/// 用户Id
		/// </summary>
		public int UserId { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 用户类别
        /// </summary>
        public string RoleType { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 机构代号
        /// </summary>
        public string OrganCode { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// 用户权限
        /// </summary>
        //public string Permissions { get; set; }
        /// <summary>
        /// 权限列表
        /// </summary>
        //public IList<Permission> Permlist { get; set; }
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { get; set; }
    }
}

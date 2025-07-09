using CMS.IService.Admin.Account.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IService.Admin {
    public interface IAccountService {
        ApiResult Login(loginManageDto form);

        /// <summary>
        /// 用户树形权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ApiResult UserMenus(decimal userId);

        /// <summary>
        /// 根据Token获取用户信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        ApiResult GetUserByToken(string token);
        /// <summary>
        /// 根据用户账号获得用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        ApiResult GetUserByName(string userName);
        /// <summary>
        /// 获得UserDevice
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deviceType"></param>
        /// <returns></returns>
        //ApiResult GetUserDevice(decimal userId, int deviceType = 0);
        /// <summary>
        /// 根据sessionKey获得UserDevice
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        ApiResult GetUserDevice(string token);
        /// <summary>
        /// 添加UserDevice
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //ApiResult AddUserDevice(UserDevice model);
        /// <summary>
        /// 更新UserDevice
        /// </summary>
        /// <param name="userSession"></param>
        /// <returns></returns>
        ApiResult UpdateUserDevice(UserDevice userSession);


        ApiResult ChangePassWord(ChangePwd ChangePwd);
        
        /// <summary>
        /// 用户权限验证
        /// </summary>
        /// <param name="token">TOKEN</param>
        /// <param name="funid">功能代码</param>
        /// <returns></returns>
        ApiResult GetUserRight(string token, string funid);
        /// <summary>
        /// 模块权限功能
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleType"></param>
        /// <param name="mcode"></param>
        /// <returns></returns>
        ApiResult GetPermissions(decimal userId, string roleType, string mcode);
    }
}

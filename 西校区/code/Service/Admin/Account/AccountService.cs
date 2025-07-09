using CMS.Core.Common;
using CMS.Core.Responsity;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using CMS.IService;
using CMS.IService.Admin;
using CMS.IService.Admin.Account.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CMS.Service.Admin.Account {
    public class AccountService : UserContext, IAccountService {
        private IBaseRepository<SqlServercfg> bll;
        public AccountService(IBaseRepository<SqlServercfg> _bll)
        {
            bll = _bll;
        }

        public ApiResult ChangePassWord(ChangePwd ChangePwd)
        {
            if (string.IsNullOrEmpty(ChangePwd.oldpwd))
            {
                return new ApiResult().SetFailedResult(-1, "旧密码不能空");
            }
            if (string.IsNullOrEmpty(ChangePwd.newpwd))
            {
                return new ApiResult().SetFailedResult(-1, "新密码不能空");
            }
            if (ChangePwd.newpwd != ChangePwd.confirmpwd)
            {
                return new ApiResult().SetFailedResult(-1, "两次密码不一致");
            }
            var login = LoginInfo;
            if (login != null) {

                var user = bll.Get<SYS_USER>(decimal.Parse(login.UserId + ""));
                if (user != null) {

                    var pwd = DEncryptHelper.Encrypt(ChangePwd.oldpwd);
                    if (user.USER_PWD != pwd)
                    {
                        return new ApiResult().SetFailedResult(-1, "旧密码错误");
                    }
                    else
                    {
                        user.CurModel = DealModel.Modify;
                        user.USER_PWD = DEncryptHelper.Encrypt(ChangePwd.newpwd);

                        var count = bll.Update(user);
                        if (count >0)
                        {
                            return new ApiResult().SetSuccessResult("修改成功");
                        }
                        else {
                            return new ApiResult().SetFailedResult(-1, "修改失败，服务器错误");
                        }
                    }
                }
            }
            return new ApiResult().SetFailedResult(-1, "获取用户信息失败");
        }
        public ApiResult Login(loginManageDto form)
        {
            LogHelper.Log("登陆==>");
            if (string.IsNullOrEmpty(form.uid))
            {
                return new ApiResult().SetFailedResult(-1, "账号必填");
            }
            if (string.IsNullOrEmpty(form.pwd))
            {
                return new ApiResult().SetFailedResult(-1, "密码必填");
            }
            int timeout = 7200;
            SYS_USER nowUser = bll.Get<SYS_USER>(form.uid);
            if (nowUser != null)
            {
                var encryptPwd = DEncryptHelper.Encrypt(form.pwd);
                if (encryptPwd == nowUser.USER_PWD)
                {
                    if (!nowUser.IS_AVAILABLE.Equals(1))
                    {
                        return new ApiResult().SetFailedResult(-1, "账号处于禁用状态");
                    }
                    UserDevice existsDevice = GetUserDevice(nowUser.USER_ID);
                    if (existsDevice == null)
                    {
                        string passkey = MD5CryptoProvider.GetMD5Hash(nowUser.USER_ID + nowUser.USER_CODE + DateTime.UtcNow + Guid.NewGuid());
                        existsDevice = new UserDevice()
                        {
                            UserId = nowUser.USER_ID,
                            CreateTime = DateTime.Now,
                            ActiveTime = DateTime.Now,
                            ExpiredTime = DateTime.Now.AddMinutes(timeout),
                            DeviceType = 0,
                            Token = passkey
                        };
                        AddUserDevice(existsDevice);
                    }
                    else
                    {
                        existsDevice.ActiveTime = DateTime.Now;
                        existsDevice.ExpiredTime = DateTime.Now.AddMinutes(timeout);
                        string passkey = MD5CryptoProvider.GetMD5Hash(nowUser.USER_ID + nowUser.USER_CODE + DateTime.UtcNow + Guid.NewGuid());
                        existsDevice.Token = passkey;
                        UpdateUserDevice(existsDevice);
                    }
                    nowUser.Token = existsDevice.Token;
                    CacheHelper.SetUser(nowUser.USER_ID, nowUser.USER_CODE, nowUser.Token, timeout);

                    Array prems = bll.GetPermissionArray(nowUser.USER_ID, nowUser.ROLE_TYPE).Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    List<NavMenuNode> pList = new List<NavMenuNode>();
                    ParamCollection _paramCollection = new ParamCollection();
                    _paramCollection.Clause = String.Format("{0}.{1} IN (select ROLE_NO from {2} where {2}.USER_ID = {3} AND SYS_WEB_MODULE.IS_AVAILABLE = 1 AND SYS_WEB_MODULE.MODULE_TYPE = '{4}')"
                       , new object[] { SYS_PERM.TABLE_NAME, SYS_PERM.ROLE_NO_FIELD, SYS_USER_ROLE.TABLE_NAME, nowUser.USER_ID, nowUser.ROLE_TYPE });
                    var queryList = bll.SelectGroup<SYS_PERM>(_paramCollection, "  SYS_PERM.FUNCTION_ID ", " SORT_NO,MODULE_CODE,FUNCTION_CODE ");
                    var menus = string.Empty;
                    var nodeList = queryList;
                    foreach (SYS_PERM node in nodeList)
                    {
                        menus += node.FUNCTION_ID + "|";
                    }
                    if (menus.Length > 0)
                    {
                        menus = menus.TrimEnd('|');
                    }
                    var result = new loginUserDto
                    {
                        Uid = nowUser.USER_ID,
                        AccessToken = nowUser.Token,
                        ExpiresIn = timeout,
                        Prems = prems,
                        Name = nowUser.USER_NAME,
                        Menus = menus
                    };
                    return new ApiResult<loginUserDto>().SetSuccessResult(result);
                }
                else
                {
                    return new ApiResult().SetFailedResult(-1, "密码错误");
                }
            }
            return new ApiResult().SetFailedResult(-1, "帐户不存在");
        }
        /// <summary>
        /// 获得UserDevice
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deviceType"></param>
        /// <returns></returns>
        private UserDevice GetUserDevice(decimal userId, int deviceType = 0)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "", column = "";
            column = USER_DEVICE.USER_ID_FIELD;
            Clause += String.Format("AND ({0}.{1} = @{1}) ", USER_DEVICE.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.Decimal, userId));
            column = USER_DEVICE.DEVICE_TYPE_FIELD;
            Clause += String.Format("AND ({0}.{1} = @{1}) ", USER_DEVICE.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.Int32, deviceType));
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            List<USER_DEVICE> queryList = bll.Select<USER_DEVICE>(paraList, "USER_DEVICE.CREATE_TIME DESC", 1);
            var resultList = from item in queryList
                             select new UserDevice
                             {
                                 UserDeviceId = Convert.ToInt32(item.USER_DEVICE_ID),
                                 Ip = item.IP,
                                 UserId = Convert.ToInt32(item.USER_ID),
                                 ActiveTime = item.ACTIVE_TIME,
                                 ExpiredTime = item.EXPIRED_TIME,
                                 CreateTime = item.CREATE_TIME,
                                 DeviceType = item.DEVICE_TYPE,
                                 Token = item.TOKEN
                             };
            return resultList.SingleOrDefault();
        }
        /// <summary>
        /// 添加UserDevice
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool AddUserDevice(UserDevice model)
        {
            USER_DEVICE currentRow = new USER_DEVICE(DealModel.New);
            currentRow.USER_ID = model.UserId;
            currentRow.DEVICE_TYPE = model.DeviceType;
            currentRow.IP = model.Ip;
            currentRow.TOKEN = model.Token;
            currentRow.ACTIVE_TIME = model.ActiveTime;
            currentRow.EXPIRED_TIME = model.ExpiredTime;
            currentRow.CREATE_TIME = model.CreateTime;
            return bll.Update(currentRow) > 0;
        }
        /// <summary>
        /// 根据Token获取用户信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public ApiResult GetUserByToken(string token)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "", column = "";
            column = USER_DEVICE.TOKEN_FIELD;
            Clause += String.Format("AND ({0}.{1} = @{1}) ", USER_DEVICE.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.String, token));
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            var queryList = bll.Select<USER_DEVICE>(paraList, "USER_DEVICE.CREATE_TIME DESC", 1);
            if (queryList.Count > 0)
            {
                USER_DEVICE device = queryList[0];
                SYS_USER item = bll.Get<SYS_USER>(device.USER_ID);
                if (item != null)
                {
                    return new ApiResult<UserInfo>().SetSuccessResult(new UserInfo
                    {
                        UserId = Convert.ToInt32(item.USER_ID),
                        UserCode = item.USER_CODE,
                        RoleType = item.ROLE_TYPE,
                        UserName = item.USER_NAME,
                        Mobile = item.MOBILE,
                        IsActive = Convert.ToBoolean(item.IS_AVAILABLE),
                        //Permissions = string.Format("userPermission_{0}", item.USER_ID),
                        //Permlist = pList,
                        Token = item.Token
                    });
                    //return new UserInfo
                    //{
                    //    UserId = Convert.ToInt32(item.USER_ID),
                    //    UserCode = item.USER_CODE,
                    //    RoleType = item.ROLE_TYPE,
                    //    UserName = item.USER_NAME,
                    //    Mobile = item.MOBILE,
                    //    IsActive = Convert.ToBoolean(item.IS_AVAILABLE),
                    //    //Permissions = string.Format("userPermission_{0}", item.USER_ID),
                    //    //Permlist = pList,
                    //    Token = item.Token
                    //};
                }
            }
            //return null;
            return new ApiResult().SetFailedResult(-1, "Token无效");
        }

        /// <summary>
        /// 根据sessionKey获得UserDevice
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <returns></returns>
        public ApiResult GetUserDevice(string token)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "", column = "";
            column = USER_DEVICE.TOKEN_FIELD;
            Clause += String.Format("AND ({0}.{1} = @{1}) ", USER_DEVICE.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.String, token));
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            List<USER_DEVICE> queryList = bll.Select<USER_DEVICE>(paraList, "USER_DEVICE.CREATE_TIME DESC", 1);
            var resultList = from item in queryList.ConvertAll<USER_DEVICE>(USER_DEVICE.Convert)
                             select new UserDevice
                             {
                                 UserDeviceId = Convert.ToInt32(item.USER_DEVICE_ID),
                                 Ip = item.IP,
                                 UserId = Convert.ToInt32(item.USER_ID),
                                 ActiveTime = item.ACTIVE_TIME,
                                 ExpiredTime = item.EXPIRED_TIME,
                                 CreateTime = item.CREATE_TIME,
                                 DeviceType = item.DEVICE_TYPE,
                                 Token = item.TOKEN
                             };
            //return resultList.SingleOrDefault();
            return new ApiResult<UserDevice>().SetSuccessResult(resultList.SingleOrDefault());
        }
        /// <summary>
        /// 更新UserDevice
        /// </summary>
        /// <param name="userSession"></param>
        /// <returns></returns>
        public ApiResult UpdateUserDevice(UserDevice userSession)
        {
            bool isupdate = false;
            ParamCollection paraList = new ParamCollection();
            string Clause = "", column = "";
            column = USER_DEVICE.USER_ID_FIELD;
            Clause += String.Format("AND ({0}.{1} = @{1}) ", USER_DEVICE.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.Decimal, userSession.UserId));
            column = USER_DEVICE.DEVICE_TYPE_FIELD;
            Clause += String.Format("AND ({0}.{1} = @{1}) ", USER_DEVICE.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.Int32, userSession.DeviceType));
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            var queryList = bll.Select<USER_DEVICE>(paraList);
            if (queryList.Count > 0)
            {
                USER_DEVICE currentRow = queryList[0];
                currentRow.CurModel = DealModel.Modify;
                currentRow.USER_ID = userSession.UserId;
                currentRow.DEVICE_TYPE = userSession.DeviceType;
                currentRow.IP = userSession.Ip;
                currentRow.TOKEN = userSession.Token;
                currentRow.ACTIVE_TIME = userSession.ActiveTime;
                currentRow.EXPIRED_TIME = userSession.ExpiredTime;
                currentRow.CREATE_TIME = userSession.CreateTime;
                isupdate = bll.Update(currentRow) > 0;
            }
            return new ApiResult<bool>().SetSuccessResult(isupdate);
        }

        /// <summary>
        /// 根据用户账号获得用户信息
        /// </summary>
        /// <param name="userName">登陆账号</param>
        /// <returns></returns>
        public ApiResult GetUserByName(string userName)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "", column = "";
            column = SYS_USER.USER_CODE_FIELD;
            Clause += String.Format("AND ({0}.{1} = @{1}) ", SYS_USER.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.String, userName.Trim()));
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            var queryList = bll.Select<SYS_USER>(paraList);
            var resultList = from item in queryList
                             select new UserInfo
                             {
                                 UserId = Convert.ToInt32(item.USER_ID),
                                 UserCode = item.USER_CODE,
                                 RoleType = item.ROLE_TYPE,
                                 //Password = item.USER_PWD,
                                 UserName = item.USER_NAME,
                                 Mobile = item.MOBILE,
                                 IsActive = Convert.ToBoolean(item.IS_AVAILABLE)
                             };
            //return resultList.SingleOrDefault();
            return new ApiResult<UserInfo>().SetSuccessResult(resultList.SingleOrDefault());
        }

        /// <summary>
        /// 用户权限验证
        /// </summary>
        /// <param name="token">TOKEN</param>
        /// <param name="funid">功能代码</param>
        /// <returns></returns>
        public ApiResult GetUserRight(string token, string funid)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "", column = "";
            column = USER_DEVICE.TOKEN_FIELD;
            Clause += String.Format("AND ({0}.{1} = @{1}) ", USER_DEVICE.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.String, token));
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            var queryList = bll.Select<USER_DEVICE>(paraList, "USER_DEVICE.CREATE_TIME DESC", 1);
            if (queryList.Count > 0)
            {
                var auth = bll.GetUserRight(token, funid);
                if (auth)
                {
                    return new ApiResult<int>().SetSuccessResult(1);
                }
                else
                {
                    return new ApiResult<int>().SetSuccessResult(0);
                }
            }
            else
            {
                return new ApiResult<int>().SetSuccessResult(-1);
            }
        }

        public ApiResult GetPermissions(decimal userId, string roleType, string mcode)
        {
            ParamCollection _paramCollection = new ParamCollection();
            _paramCollection.Clause = String.Format("{0}.{1} IN (select ROLE_NO from {2} where {2}.USER_ID = {3} " +
                "AND SYS_WEB_MODULE.IS_AVAILABLE = 1 AND SYS_WEB_MODULE.MODULE_TYPE = '{4}')"
               , new object[] { SYS_PERM.TABLE_NAME, SYS_PERM.ROLE_NO_FIELD, SYS_USER_ROLE.TABLE_NAME, userId, roleType });
            var premList = bll.SelectGroup<SYS_PERM>(_paramCollection, " SYS_PERM.FUNCTION_ID ", " SORT_NO,MODULE_CODE,FUNCTION_CODE ");
            IEnumerable<string> resultList = from item in premList
                                             where item.MODULE_CODE == mcode
                                             select item.FUNCTION_ID;
            //return resultList.ToList();
            return new ApiResult<IList<string>>().SetSuccessResult(resultList.ToList());
        }

        public ApiResult UserMenus(decimal userId)
        {
            List<NavMenuNode> pList = new List<NavMenuNode>();
            var user = bll.Get<SYS_USER>(userId);
            if (user != null)
            {
                ParamCollection _paramCollection = new ParamCollection();
                _paramCollection.Clause = String.Format("{0}.{1} IN (select ROLE_NO from {2} where {2}.USER_ID = {3} AND SYS_WEB_MODULE.IS_AVAILABLE = 1 AND SYS_WEB_MODULE.MODULE_TYPE = '{4}')"
                   , new object[] { SYS_PERM.TABLE_NAME, SYS_PERM.ROLE_NO_FIELD, SYS_USER_ROLE.TABLE_NAME, userId, user.ROLE_TYPE });
                var queryList = bll.SelectGroup<SYS_PERM>(_paramCollection, "  SYS_PERM.FUNCTION_ID ", " SORT_NO,MODULE_CODE,FUNCTION_CODE ");
                NavMenuNode model = new NavMenuNode();
                model.title = "首页";
                model.icon = "home";
                model.path = "/index";
                pList.Add(model);
                foreach (SYS_PERM pe in queryList.FindAll(x => x.FUNCTION_CODE == Operation.Cate))
                {
                    model = new NavMenuNode();
                    model.title = pe.MODULE_NAME;
                    model.icon = pe.PICTURE_NAME;
                    var nodeList = queryList.FindAll(x => x.FUNCTION_CODE == Operation.Module && x.PARENT_CODE == pe.MODULE_CODE);
                    if (nodeList.Count > 0)
                    {
                        model.children = new List<ItemNode>();
                    }
                    foreach (SYS_PERM node in nodeList)
                    {
                        var item = new ItemNode()
                        {
                            title = node.MODULE_NAME,
                            path = node.MODULE_URL,
                            icon = node.PICTURE_NAME
                        };
                        model.children.Add(item);
                    }
                    pList.Add(model);
                }
            }
            return new ApiResult<List<NavMenuNode>>().SetSuccessResult(pList);
        }

    }
}

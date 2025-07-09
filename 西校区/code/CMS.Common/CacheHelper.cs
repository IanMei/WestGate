using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;

namespace CMS.Core.Common {
    /// <summary>
    /// 提供缓存的存取方法
    /// </summary>
    public class CacheHelper {
        private static Dictionary<string, object> CacheDictionary = new Dictionary<string, object>();
        /// <summary>
        /// 添加缓存
        /// </summary>
        public static void Add(string key, object value)
        {
            if (!CacheDictionary.ContainsKey(key))
                CacheDictionary.Add(key, value);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        public static T Get<T>(string key)
        {
            if (CacheDictionary.ContainsKey(key))
                return (T)CacheDictionary[key];
            else
                return default(T);
        }

        /// <summary>
        /// 获取登录凭证
        /// </summary>
        public static string GetLoginToken()
        {
            return System.Web.HttpContext.Current.Request.Headers["token"];
        }

        /// <summary>
        /// 判断缓存是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Exsits(string key)
        {
            return CacheDictionary.ContainsKey(key);
        }

        public static void SetUser(decimal Uid, string loginName, string token, int expiration)
        {
            var authTicket = new FormsAuthenticationTicket(
               Convert.ToInt32(Uid),                                // 版本
               loginName,                                           // 用户名称    
               DateTime.Now,                                        // 创建日期        
               DateTime.Now.AddMinutes(expiration),                 // 过期时间    
               true,                                                // 是否记住
               string.Format("{0}", token),                         // 用户角色
               FormsAuthentication.FormsCookiePath);
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            authCookie.HttpOnly = true;                             //客户端脚本不能访问
            //authCookie.Secure = FormsAuthentication.RequireSSL;   //是否仅用https传递cookie
            authCookie.Domain = FormsAuthentication.CookieDomain;   //与cookie关联的域
            authCookie.Path = FormsAuthentication.FormsCookiePath;  //cookie关联的虚拟路径
            if (expiration > 0)
                authCookie.Expires = DateTime.Now.AddMinutes(expiration);
            HttpContext context = HttpContext.Current;
            if (context == null)
                throw new InvalidOperationException();
            // 5. 写登录Cookie
            context.Response.Cookies.Remove(authCookie.Name);
            context.Response.Cookies.Add(authCookie);
        }
        /// <summary>
        /// 设置用户登陆Token
        /// </summary>
        /// <param name="token"></param>
        /// <param name="expiration"></param>
        public static void SetTokenCookie(string token , int expiration)
        {
            var authCookie = new HttpCookie("u-sessionid", token);
            authCookie.HttpOnly = true;                             //客户端脚本不能访问
            //authCookie.Secure = FormsAuthentication.RequireSSL;   //是否仅用https传递cookie
            authCookie.Domain = FormsAuthentication.CookieDomain;   //与cookie关联的域
            authCookie.Path = FormsAuthentication.FormsCookiePath;  //cookie关联的虚拟路径
            if (expiration > 0)
                authCookie.Expires = DateTime.Now.AddMinutes(expiration);
            HttpContext context = HttpContext.Current;
            if (context == null)
                throw new InvalidOperationException();
            // 5. 写登录Cookie
            context.Response.Cookies.Remove(authCookie.Name);
            context.Response.Cookies.Add(authCookie);
        }
        /// <summary>
        /// 删除用户登陆Token
        /// </summary>
        public static void DelTokenCookie()
        {
            var authCookie = new HttpCookie("u-sessionid", "");
            authCookie.HttpOnly = true;                             //客户端脚本不能访问
            //authCookie.Secure = FormsAuthentication.RequireSSL;   //是否仅用https传递cookie
            authCookie.Domain = FormsAuthentication.CookieDomain;   //与cookie关联的域
            authCookie.Path = FormsAuthentication.FormsCookiePath;  //cookie关联的虚拟路径
            HttpContext context = HttpContext.Current;
            authCookie.Expires = DateTime.Now.AddMinutes(-12);
            context.Response.Cookies.Remove("u-sessionid");
            context.Response.Cookies.Add(authCookie);
        }
        /// <summary>
        /// 获取用户登陆Token
        /// </summary>
        /// <returns></returns>
        public static string GetTokenCookie()
        {
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["u-sessionid"];
            string str = string.Empty;
            if (cookie != null)
            {
                str = cookie.Value;
            }
            return str;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;

namespace CMS.Core.Common {
    /// <summary>
    /// �ṩ����Ĵ�ȡ����
    /// </summary>
    public class CacheHelper {
        private static Dictionary<string, object> CacheDictionary = new Dictionary<string, object>();
        /// <summary>
        /// ��ӻ���
        /// </summary>
        public static void Add(string key, object value)
        {
            if (!CacheDictionary.ContainsKey(key))
                CacheDictionary.Add(key, value);
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        public static T Get<T>(string key)
        {
            if (CacheDictionary.ContainsKey(key))
                return (T)CacheDictionary[key];
            else
                return default(T);
        }

        /// <summary>
        /// ��ȡ��¼ƾ֤
        /// </summary>
        public static string GetLoginToken()
        {
            return System.Web.HttpContext.Current.Request.Headers["token"];
        }

        /// <summary>
        /// �жϻ����Ƿ����
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
               Convert.ToInt32(Uid),                                // �汾
               loginName,                                           // �û�����    
               DateTime.Now,                                        // ��������        
               DateTime.Now.AddMinutes(expiration),                 // ����ʱ��    
               true,                                                // �Ƿ��ס
               string.Format("{0}", token),                         // �û���ɫ
               FormsAuthentication.FormsCookiePath);
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            authCookie.HttpOnly = true;                             //�ͻ��˽ű����ܷ���
            //authCookie.Secure = FormsAuthentication.RequireSSL;   //�Ƿ����https����cookie
            authCookie.Domain = FormsAuthentication.CookieDomain;   //��cookie��������
            authCookie.Path = FormsAuthentication.FormsCookiePath;  //cookie����������·��
            if (expiration > 0)
                authCookie.Expires = DateTime.Now.AddMinutes(expiration);
            HttpContext context = HttpContext.Current;
            if (context == null)
                throw new InvalidOperationException();
            // 5. д��¼Cookie
            context.Response.Cookies.Remove(authCookie.Name);
            context.Response.Cookies.Add(authCookie);
        }
        /// <summary>
        /// �����û���½Token
        /// </summary>
        /// <param name="token"></param>
        /// <param name="expiration"></param>
        public static void SetTokenCookie(string token , int expiration)
        {
            var authCookie = new HttpCookie("u-sessionid", token);
            authCookie.HttpOnly = true;                             //�ͻ��˽ű����ܷ���
            //authCookie.Secure = FormsAuthentication.RequireSSL;   //�Ƿ����https����cookie
            authCookie.Domain = FormsAuthentication.CookieDomain;   //��cookie��������
            authCookie.Path = FormsAuthentication.FormsCookiePath;  //cookie����������·��
            if (expiration > 0)
                authCookie.Expires = DateTime.Now.AddMinutes(expiration);
            HttpContext context = HttpContext.Current;
            if (context == null)
                throw new InvalidOperationException();
            // 5. д��¼Cookie
            context.Response.Cookies.Remove(authCookie.Name);
            context.Response.Cookies.Add(authCookie);
        }
        /// <summary>
        /// ɾ���û���½Token
        /// </summary>
        public static void DelTokenCookie()
        {
            var authCookie = new HttpCookie("u-sessionid", "");
            authCookie.HttpOnly = true;                             //�ͻ��˽ű����ܷ���
            //authCookie.Secure = FormsAuthentication.RequireSSL;   //�Ƿ����https����cookie
            authCookie.Domain = FormsAuthentication.CookieDomain;   //��cookie��������
            authCookie.Path = FormsAuthentication.FormsCookiePath;  //cookie����������·��
            HttpContext context = HttpContext.Current;
            authCookie.Expires = DateTime.Now.AddMinutes(-12);
            context.Response.Cookies.Remove("u-sessionid");
            context.Response.Cookies.Add(authCookie);
        }
        /// <summary>
        /// ��ȡ�û���½Token
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

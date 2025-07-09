using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CMS.Core.Common
{
    /// <summary>
    /// 短信服务
    /// </summary>
    public class MessageService
    {
        //本地测试开发
        private static string TestKey = ConfigurationManager.AppSettings["TestKey"];
        /// <summary>
        /// 接口服务器IP地址
        /// </summary>
        private static string SERVER_IP_SendSms = ConfigurationManager.AppSettings["SERVER_IP_SendSms"];
        private static string SERVER_IP_OtherApi = ConfigurationManager.AppSettings["SERVER_IP_OtherApi"];
        /// <summary>
        /// 接口服务器端口
        /// </summary>
        private static string SERVER_PORT_SendSms = ConfigurationManager.AppSettings["SERVER_PORT_SendSms"];
        private static string SERVER_PORT_OtherApi = ConfigurationManager.AppSettings["SERVER_PORT_OtherApi"];
        /// <summary>
        /// 短信账号（就是登录帐号）
        /// </summary>
        private static string ACCOUNT_SID = ConfigurationManager.AppSettings["ACCOUNT_SID"];
        /// <summary>
        /// APIKEY（从会员中心--短信设置-帐号管理中获取，APIKEY可以自主在会员中心更新）
        /// </summary>
        private static string ACCOUNT_APIKEY = ConfigurationManager.AppSettings["ACCOUNT_APIKEY"];

        /// <summary>
        /// POST请求
        /// </summary>
        /// <param name="url">路径</param>
        ///  <param name="paramData">参数</param>
        /// <returns>请求结果</returns>
        public static string SendHttpPost(string url, string paramData)
        {
            Stream respStream = null;
            HttpWebResponse httpResp = null;
            StreamReader respStreamReader = null;

            HttpWebRequest httpReq = null;
            string res = null;
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(paramData); //转化
                httpReq = (HttpWebRequest)WebRequest.Create(new Uri(url));
                httpReq.Method = "POST";
                httpReq.ContentType = "application/x-www-form-urlencoded";
                httpReq.Headers.Add("Content-Encoding", "utf-8");
                httpReq.ContentLength = byteArray.Length;
                respStream = httpReq.GetRequestStream();
                respStream.Write(byteArray, 0, byteArray.Length);//写入参数
                respStream.Close();
                httpResp = (HttpWebResponse)httpReq.GetResponse();
                respStreamReader = new StreamReader(httpResp.GetResponseStream(), Encoding.UTF8);
                res = respStreamReader.ReadToEnd();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (respStream != null)
                {
                    respStream.Close();
                }
                if (httpResp != null)
                {
                    httpResp.Close();
                }
                if (respStreamReader != null)
                {
                    respStreamReader.Close();
                }
            }
            return res;
        }

        /// <summary>
        /// 获取大写的MD5签名结果
        /// </summary>
        /// <param name="encypStr"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static string GetMD5(string encypStr)
        {
            string charset = "utf-8";
            string retStr;
            MD5CryptoServiceProvider m5 = new MD5CryptoServiceProvider();
            //创建md5对象
            byte[] inputBye;
            byte[] outputBye;

            //使用GB2312编码方式把字符串转化为字节数组．
            inputBye = Encoding.GetEncoding(charset).GetBytes(encypStr);
            outputBye = m5.ComputeHash(inputBye);

            retStr = System.BitConverter.ToString(outputBye);
            retStr = retStr.Replace("-", "").ToUpper();
            return retStr;
        }

        private static string GetBaseSmsUrl(string action, string sign)
        {
            string url = string.Format("http://{0}:{1}/api/rest/{2}?sid={3}&sign={4}", SERVER_IP_SendSms, SERVER_PORT_SendSms, action, ACCOUNT_SID, sign);
            return url;
        }

        /// <summary>
        /// 发送模板短信
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="mobiles">手机号码</param>
        /// <param name="content">短信内容  多个参数用||分隔，如：@1@=value1||@2@=value2</param>
        /// <param name="extno">扩展码（从会员中心帐号列表中获取）</param>
        /// <returns></returns>
        public static bool sendTplSms(string templateId, string mobiles, string content, string extno = "")
        {
            if (TestKey == "0")
            {
                return true;
            }
            string resultJson = "";
            try
            {
                //请求头部设置认证信息
                string src = string.Format("{0}{1}{2}{3}{4}", ACCOUNT_SID, ACCOUNT_APIKEY, templateId, mobiles, content);
                string sign = GetMD5(src);
                //短信发送的相关参数
                StringBuilder dic = new StringBuilder();
                dic.AppendFormat("&sid={0}", ACCOUNT_SID);
                dic.AppendFormat("&sign={0}", sign);
                dic.AppendFormat("&tplid={0}", templateId);
                dic.AppendFormat("&mobile={0}", mobiles);
                dic.AppendFormat("&content={0}", HttpContext.Current.Server.UrlEncode(content));
                dic.AppendFormat("&extno={0}", extno);

                //构建请求URL，所有url都必须包含sign、sid参数
                string url = GetBaseSmsUrl("sms/sendTplSms", sign);
                resultJson = SendHttpPost(url.ToString(), dic.ToString());
                JObject jo = (JObject)JsonConvert.DeserializeObject(resultJson);
                LogHelper.Log(resultJson);
                string zone = jo["code"].ToString();
                if (zone == "0")
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                //异常处理
            }
            return false;
        }
    }
}

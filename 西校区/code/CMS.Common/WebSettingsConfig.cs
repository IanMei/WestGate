using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Common
{
    public class WebSettingsConfig
    {
        /// <summary>
        /// 过期时间
        /// </summary>
        public static string UrlExpireTime
        {
            get
            {
                return AppSettingValue();
            }
        }

        public static string TenPayV3_AppId
        {
            get
            {
                return AppSettingValue();
            }
        }

        public static string TenPayV3_AppSecret
        {
            get
            {
                return AppSettingValue();
            }
        }
        /// <summary>
        /// 退款证书
        /// </summary>
        public static string wxCertPath
        {
            get
            {
                return AppSettingValue();
            }
        }
        
        /// <summary>
        /// 图片域名
        /// </summary>
        public static string ImagePath
        {
            get
            {
                return AppSettingValue();
            }
        }
        /// <summary>
        /// 图片域名
        /// </summary>
        public static string ImageDomain
        {
            get
            {
                return AppSettingValue();
            }
        }
        /// <summary>
        /// 上传图片路径
        /// </summary>
        public static string UploadPicFile
        {
            get
            {
                return AppSettingValue();
            }
        }
        /// <summary>
        /// 文件域名
        /// </summary>
        public static string FileDomain
        {
            get
            {
                return AppSettingValue();
            }
        }
        /// <summary>
        /// 上传文件路径
        /// </summary>
        public static string UploadFile
        {
            get
            {
                return AppSettingValue();
            }
        }
        /// <summary>
        /// 有效分钟
        /// </summary>
        public static int Minute
        {
            get
            {

                int termMin = 5;
                Int32.TryParse(AppSettingValue(), out termMin);
                return termMin;
            }
        }
        /// <summary>
        /// 测试支付
        /// </summary>
        public static string TestPay
        {
            get
            {
                return AppSettingValue();
            }
        }
        /// <summary>
        /// 支付宝同步回调地址
        /// </summary>
        public static string AlipayReturnUrl
        {
            get
            {
                return AppSettingValue();
            }
        }
        /// <summary>
        /// 支付宝异步通知接收地址
        /// </summary>
        public static string AlipayNotifyUrl
        {
            get
            {
                return AppSettingValue();
            }
        }
        /// <summary>
        /// 支付宝用户付款中途退出返回商户网站的地址
        /// </summary>
        public static string AlipayQuitUrl
        {
            get
            {
                return AppSettingValue();
            }
        }
        /// <summary>
        /// 平台域名
        /// </summary>
        public static string domainName
        {
            get
            {
                return AppSettingValue();
            }
        }


        /// <summary>
        /// 即时通信 IM AppID
        /// </summary>
        public static string imAppID
        {
            get
            {
                return AppSettingValue();
            }
        }
        /// <summary>
        /// 即时通信 IM Secretkey
        /// </summary>
        public static string imSecretkey
        {
            get
            {
                return AppSettingValue();
            }
        }
        
        /// <summary>
        /// 腾讯云 AppId
        /// </summary>
        public static string TencentCloudAppID
        {
            get
            {
                return AppSettingValue();
            }
        }
        /// <summary>
        /// 腾讯云 SecId
        /// </summary>
        public static string TencentCloudSecId
        {
            get
            {
                return AppSettingValue();
            }
        }
        /// <summary>
        /// 腾讯云 SecKey
        /// </summary>
        public static string TencentCloudSecKey
        {
            get
            {
                return AppSettingValue();
            }
        }
        /// <summary>
        /// 腾讯云 推流 域名
        /// </summary>
        public static string TencentCloudLivePushDomain
        {
            get
            {
                return AppSettingValue();
            }
        }

        /// <summary>
        /// 腾讯云 拉流 域名
        /// </summary>
        public static string TencentCloudLivePlayDomain
        {
            get
            {
                return AppSettingValue();
            }
        }

        private static string AppSettingValue([CallerMemberName] string key = null)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}

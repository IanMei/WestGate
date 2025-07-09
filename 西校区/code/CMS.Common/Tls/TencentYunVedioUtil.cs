using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Core.Common
{

    public class TexLiveUrl
    {

        public string pushUrl { get; set; }
        public string rmptUrl { get; set; }
        public string flvUrl { get; set; }
        public string hlsUrl { get; set; }
        public string webrtcUrl { get; set; }

    }
    public class TexLive
    {
        //推流防盗链的key
        private static String key = "e2d8a80a10627fc66b701ec1b8b17c87";


        public TexLiveUrl getUrl(string pushDomain, string playDomain, string streamId, DateTime end, string appName = "live")
        {
            //时间戳16进制
            String txTime = TimeToHex(end).ToUpper();

            //获取md5 txSecret
            String txSecret = getMD5String(key + streamId + txTime);
            return new TexLiveUrl
            {
                pushUrl = $"rtmp://{pushDomain}/{appName}/{streamId}?txSecret={txSecret}&txTime={txTime}",
                rmptUrl = $"rtmp://{playDomain}/{appName}/{streamId}",
                flvUrl = $"http://{playDomain}/{appName}/{streamId}.flv",
                hlsUrl = $"http://{playDomain}/{appName}/{streamId}.m3u8",
                webrtcUrl = $"webrtc://{playDomain}/{appName}/{streamId}",
            };
        }


        /// <summary>
        /// 用MD5加密字符串
        /// </summary>
        /// <param name="key">待加密的字符串</param>
        /// <returns></returns>
        private string getMD5String(string key)
        {
            var md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedDataBytes;
            hashedDataBytes = md5Hasher.ComputeHash(Encoding.Default.GetBytes(key));
            StringBuilder tmp = new StringBuilder();
            foreach (byte i in hashedDataBytes)
            {
                tmp.Append(i.ToString("x2"));
            }
            return tmp.ToString();
        }


        /// <summary>
        /// 把一个时间转化成四个字节的16进制字符串
        /// </summary>
        /// <param name="time">要转化的时间</param>
        /// <returns></returns>
        private String TimeToHex(DateTime time)
        {
            StringBuilder sb = new StringBuilder();
            DateTime timeStar = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 01, 01));
            TimeSpan timeSpan = time - timeStar;
            uint unitSpan = Convert.ToUInt32(timeSpan.TotalSeconds);
            if (unitSpan < 0)
            {
                return sb.ToString();
            }
            byte[] bytes = System.BitConverter.GetBytes(unitSpan);
            for (int i = bytes.Length - 1; i >= 0; i--)
            {
                sb.Append(bytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

    }
}

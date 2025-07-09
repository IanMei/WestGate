using System;
using System.Collections.Generic;
using System.Text;
using LTP.Common.DEncrypt;
using System.Security.Cryptography;

namespace CMS.Core.Common {
    public class DEncryptHelper
    {
        private static string _keys = "www.ZebraSoft.com.cnCopyRight2005-2008";
        private const string symmProvider = "RijndaelManaged";

        /// <summary>
        /// 加密数据源
        /// </summary>
        /// <param name="source">加密前的字符串数据</param>
        /// <returns>密文数据</returns>
        public static string Encrypt(string source)
        {
            return DESEncrypt.Encrypt(source, _keys);
            //return Cryptographer.EncryptSymmetric(symmProvider, source);
        }

        /// <summary>
        /// 解密数据
        /// </summary>
        /// <param name="source">密文数据</param>
        /// <returns>解密后数据</returns>
        public static string Decrypt(string source)
        {
            return DESEncrypt.Decrypt(source, _keys);
            //return Cryptographer.DecryptSymmetric(symmProvider, source);
        }

        private static int rep = 0;
        public static string GeneratePassWord(int CodeCount)
        {
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < CodeCount; i++)
            {

                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }

        public static string GenerateSerialNo()
        {
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < 5; i++)
            {

                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }
        public static char RandomChar()
        {
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            int num = random.Next();
            if ((num % 2) == 0)
            {
                return (char)(0x30 + ((ushort)(num % 10)));
            }
            else
            {
                return (char)(0x41 + ((ushort)(num % 0x1a)));
            }
        }
        public static string GenerateCheckCodeNum(int codeCount)
        {
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));

            for (int i = 0; i < codeCount; i++)
            {
                int num = random.Next();
                str = str + ((char)(0x30 + ((ushort)(num % 10)))).ToString();
            }
            return str;
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string MD5(string value)
        {
            byte[] data = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(value));
            StringBuilder hashedString = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                hashedString.Append(data[i].ToString("x2"));
            }
            return hashedString.ToString();
        }
    }
}

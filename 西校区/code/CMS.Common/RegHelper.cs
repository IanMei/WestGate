using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CMS.Core.Common {
    /// <summary>
    /// �ṩ��ͨ�����ݵĸ�ʽ��ȷ����֤
    /// </summary>
    public class RegHelper
    {
        public const string DATE_MM_DD_YY = @"^(1[0-2]|0[1-9])/(([1-2][0-9]|3[0-1]|0[1-9])/\d\d)$"; 
        private static Regex RegNumber0 = new Regex("^[0-9]+$");//�Ǹ�����
        private static Regex RegNumber = new Regex("^[1-9]+$");//������
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");//��������
        private static Regex RegFloat = new Regex("^[0-9]+[.]?[0-9]+$");//@"^[1-9]\d*\.\d*|0\.\d*[1-9]\d*$");//^[0-9]+[.]?[0-9]+$
        private static Regex RegDecimalSign = new Regex(@"^-?([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$"); //"^[+-]?[0-9]+[.]?[0-9]+$"
        private static Regex RegEmail = new Regex("^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$");//w Ӣ����ĸ�����ֵ��ַ������� [a-zA-Z0-9] �﷨һ�� 
        private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");
        //private static string RegPhone = @"((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)";
        private static string RegPhone = @"^1[3456789]\d{9}$";
        private static string RegTel = @"^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$";
        private static string RegIdCard = @"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$";
        private static string RegURL = @"^((https|http|ftp|rtsp|mms)?://)?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-zA-Z_!~*'().&=+$%-]+@)?(([0-9]{1,3}\.){3}[0-9]{1,3}|([0-9a-zA-Z_!~*'()-]+\.)*([0-9a-zA-Z][0-9a-zA-Z-]{0,61})?[0-9a-z]\.[a-zA-Z]{2,6})(:[0-9]{1,4})?((/?)|(/[0-9a-zA-Z_!~*'().;?:@&=+$,%#-]+)+/?)$";
        private static string RegZIP = @"[1-9]\d{5}(?!\d)";
        private static Regex RegMobile = new Regex(@"^1[3|4|5|6|7|8|9]\d{9}$");
        private static Regex RegUserName = new Regex(@"^[a-zA-Z]\w{4,20}$");
        private static string RegPosition = "(-|\\+)?(180.000000|(\\d{1,2}|1([0-7]\\d))\\.\\d{6}),(-|\\+)?(180.000000|(\\d{1,2}|1([0-7]\\d))\\.\\d{6})";
        /// <summary>
        /// 4-20λ��ĸ��ͷ����ĸ�����ֺ��»���
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool IsValidUserName(string UserName)
        {
            Match m = RegUserName.Match(UserName);
            return m.Success;
        } 

        /// <summary>
        /// �ֻ�������֤
        /// </summary>
        /// <param name="MobileNo"></param>
        /// <returns></returns>
        public static bool IsValidMobileNo(string MobileNo)
        {
            Match m = RegMobile.Match(MobileNo);
            return m.Success;
        } 
        
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsNumber(string inputData)
        {
            Match m = RegNumber0.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// �Ǹ�������֤
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsNumber0(string inputData)
        {
            Match m = RegNumber0.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// ����������֤
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsNumberSign(string inputData)
        {
            Match m = RegNumberSign.Match(inputData);
            return m.Success;
        }

        
        /// <summary>
        /// �Ƿ񸡵�����������������С��λ��ֵ
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsDecimal(string inputData)
        {
            Match m = RegNumber0.Match(inputData);
            if (!m.Success)
            {
                m = RegFloat.Match(inputData);
            }
            return m.Success;
        }

        /// <summary>
        /// �������ŵĸ�����
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsDecimalSign(string inputData)
        {
            Match m = RegDecimalSign.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// �Ƿ��������ַ�
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsHasCHZN(string inputData)
        {
            Match m = RegCHZN.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// �ʼ���ַ���
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsEmail(string inputData)
        {
            Match m = RegEmail.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// ��֤����ʱ��������
        /// </summary>
        /// <param name="dateStr"></param>
        /// <returns></returns>
        public static bool IsDateTime(string dateStr)
        {
            try
            {
                DateTime dt = DateTime.Parse(dateStr);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// �ֻ����
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsPhone(string inputPhone)
        {
            Match m = Regex.Match(inputPhone, RegPhone);//
            return m.Success;
        }
        /// <summary>
        /// �绰���
        /// </summary>
        /// <param name="inputPhone"></param>
        /// <returns></returns>
        public static bool IsPhoneTEL(string inputPhone)
        {
            Match m = Regex.Match(inputPhone, RegTel);//
            return m.Success;
        }

        /// <summary>
        /// ��֤URL
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsURL(string inputurl)
        {
            Match m = Regex.Match(inputurl, RegURL);//
            return m.Success;
        }
        /// <summary>
        /// ��֤ZIP
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsZIP(string inputzip)
        {
            Match m = Regex.Match(inputzip, RegZIP);//
            return m.Success;
        }

        /// <summary>
        /// ���֤���
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsIdCard(string inputData)
        {
            Match m = Regex.Match(inputData, RegIdCard);//
            return m.Success;
        }
        /// <summary>
        /// ��γ����֤
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsPosition(string input)
        {
            Match m = Regex.Match(input, RegPosition);
            return m.Success;
        }

        /// <summary>
        /// ���֤��֤����(��׼18λ��֤)
        /// </summary>
        /// <param name="idNumber"></param>
        /// <returns></returns>
        public static bool CheckIDCard18(string idNumber)
        {
            long n = 0;
            if (long.TryParse(idNumber.Remove(17), out n) == false
                || n < Math.Pow(10, 16) || long.TryParse(idNumber.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//������֤  
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(idNumber.Remove(2)) == -1)
            {
                return false;//ʡ����֤  
            }
            string birth = idNumber.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//������֤  
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = idNumber.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != idNumber.Substring(17, 1).ToLower())
            {
                return false;//У������֤  
            }
            return true;//����GB11643-1999��׼  
        }

        /// <summary>
        /// ���֤��֤����(��׼15λ��֤)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool CheckIDCard15(string Id)
        {
            long n = 0; if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//������֤  
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//ʡ����֤  
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime(); if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//������֤  
            }
            return true;//����15λ���֤��׼  
        }
    }
}

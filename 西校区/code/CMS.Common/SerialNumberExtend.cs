using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Core.Common
{
    public class SerialNumberExtend
    {
        private static readonly object Locker = new object();
        private static int _sn = 0;
        private static System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();

        /// <summary>
        /// 生成单号
        /// </summary>
        /// <param name="pre">单号前缀</param>
        /// <returns></returns>
        public static string GenerateNo(string pre = "")
        {
            lock (Locker)   //lock 关键字可确保当一个线程位于代码的临界区时，另一个线程不会进入该临界区。
            {
                if (_sn == 1000)
                {
                    _sn = 0;
                }
                else
                {
                    _sn++;
                }
                Thread.Sleep(100);
                return pre + DateTime.Now.ToString("yyyyMMddHHmmssfff") + _sn.ToString().PadLeft(3, '0');
            }
        }

        /// <summary>
        /// 唯一单号生成
        /// </summary>
        /// <returns></returns>
        public static string GenerateNumber()
        {
            string strDateTimeNumber = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string strRandomResult = NextRandom(1000, 1).ToString().PadLeft(4, '0');
            return strDateTimeNumber + strRandomResult;
        }
        /// <summary>
        /// 参考：msdn上的RNGCryptoServiceProvider例子
        /// </summary>
        /// <param name="numSeeds"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static int NextRandom(int numSeeds, int length)
        {
            // Create a byte array to hold the random value.  
            byte[] randomNumber = new byte[length];
            // Create a new instance of the RNGCryptoServiceProvider.  

            // Fill the array with a random value.  
            rng.GetBytes(randomNumber);
            // Convert the byte to an uint value to make the modulus operation easier.  
            uint randomResult = 0x0;
            for (int i = 0; i < length; i++)
            {
                randomResult |= ((uint)randomNumber[i] << ((length - 1 - i) * 8));
            }
            return (int)(randomResult % numSeeds) + 1;
        }
    }
}

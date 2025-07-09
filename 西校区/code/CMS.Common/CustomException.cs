using System;

namespace CMS.Core.Common
{
    /// <summary>
    /// 自定义异常类
    /// </summary>
    public class CustomException : ApplicationException
    {
        private int errCode;
        private Exception innerException;
        /// <summary>
        /// 无参数构造函数
        /// </summary>
        public CustomException()
        {

        }
        //带一个字符串参数的构造函数，作用：当程序员用Exception类获取异常信息而非 MyException时把自定义异常信息传递过去
        /// <summary>
        /// 自定义异常
        /// </summary>
        /// <param name="msg">异常消息</param>
        /// <param name="code">异常编码（自定义）</param>
        public CustomException(string msg, int code = -1)
            : base(msg)
        {
            this.errCode = code;
        }
        /// <summary>
        /// 带有一个字符串参数和一个内部异常信息参数的构造函数
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="innerException"></param>
        /// <param name="code"></param>
        public CustomException(string msg, Exception innerException, int code = -1)
            : base(msg)
        {
            this.innerException = innerException;
            this.errCode = code;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetErrorCode()
        {
            return errCode;
        }
    }
}

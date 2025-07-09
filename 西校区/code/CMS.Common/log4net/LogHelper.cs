using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace CMS.Core.Common {
    /// <summary>
    /// 通用日志处理器
    /// </summary>
    public class LogHelper
    {
        #region Logger
        private static log4net.ILog logInfo = null;
        private static log4net.ILog logError = null;
        private static log4net.ILog logDB = null;

        /// <summary>
        /// 返回记录日志到文件的Logger
        /// </summary>
        /// <returns>logInfo</returns>
        private static log4net.ILog InfoLogger()
        {
            if (logInfo == null)
            {
                log4net.Config.XmlConfigurator.Configure();
                logInfo = log4net.LogManager.GetLogger("logInfo");
            }
            return logInfo;
        }

        /// <summary>
        /// 返回记录日志到文件的Logger
        /// </summary>
        /// <returns>logError</returns>
        private static log4net.ILog ErrorLogger()
        {
            if (logError == null)
            {
                log4net.Config.XmlConfigurator.Configure();
                logError = log4net.LogManager.GetLogger("logError");
            }
            return logError;
        }

        /// <summary>
        /// 返回记录日志到数据库的Logger
        /// </summary>
        /// <returns>logDB</returns>
        private static log4net.ILog DBLogger()
        {
            if (logDB == null)
            {
                log4net.Config.XmlConfigurator.Configure();
                logDB = log4net.LogManager.GetLogger("logSQLite");
            }
            return logDB;
        }

        #endregion

        #region 记录日志到文本文件中
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="msg"></param>
        public static void Log(string msg)
        {
            InfoLogger();
            if (logInfo.IsInfoEnabled)
            {
                logInfo.Info(msg);
            }
        }

        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="ex"></param>
        public static void Log(Exception ex)
        {
            ErrorLogger();
            if (logError.IsErrorEnabled)
            {
                StringBuilder msgBuilder = new StringBuilder();
                msgBuilder.Append(ex.Message + "\r\n");
                msgBuilder.Append(ex.StackTrace + "\r\n");
                //msgBuilder.Append("USER CODE=" + CacheHelper.getServerLoginUser().USER_CODE + "\r\n");
                logError.Error(msgBuilder.ToString());
            }
        }

        /// <summary>
        /// 异常信息，并加附加的信息
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="formatInfo"></param>
        public static void Log(string msg, Exception ex)
        {
            ErrorLogger();
            if (logError.IsErrorEnabled)
            {
                StringBuilder msgBuilder = new StringBuilder();
                msgBuilder.Append(ex.Message + "\r\n");
                msgBuilder.Append(ex.StackTrace + "\r\n");
                msgBuilder.Append(msg + "\r\n");
                logError.Error(msgBuilder.ToString());
            }
        }

        /// <summary>
        /// 将SQL语句及其参数写入日志信息中
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="msg"></param>
        /// <param name="cmdParms"></param>
        public static void Log(Exception ex, string msg, params SqlParameter[] cmdParms)
        {
            ErrorLogger();
            DBLogger();
            if (logError.IsErrorEnabled)
            {
                StringBuilder msgBuilder = new StringBuilder();
                msgBuilder.Append(ex.Message);
                msgBuilder.Append(ex.StackTrace);
                msgBuilder.Append(msg);
                msgBuilder.Append(ParseParms(cmdParms));
                logError.Error(msgBuilder.ToString());
            }
        }

        /// <summary>
        /// 将参数转换成指定格式的字符串
        /// </summary>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        private static string ParseParms(params SqlParameter[] cmdParms)
        {
            StringBuilder parmsBuilder = new StringBuilder();
            parmsBuilder.Append("PARAMETERS:\r\n");
            if (cmdParms != null && cmdParms.Length > 0)
            {
                for (int i = 0; i < cmdParms.Length; i++)
                {
                    parmsBuilder.Append("(" + cmdParms[i].DbType.ToString() + ")" + cmdParms[i].ParameterName + "=" + cmdParms[i].Value + "\r\n");
                }
            }
            return parmsBuilder.ToString();
        }

        #endregion

        #region 记录日志到数据库中
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="msg"></param>
        public static void LogDB(string msg)
        {
            DBLogger();
            if (logDB.IsInfoEnabled)
            {
                logDB.Info(msg);
            }
        }

        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="ex"></param>
        public static void LogDB(Exception ex)
        {
            DBLogger();
            if (logDB.IsInfoEnabled)
            {
                StringBuilder msgBuilder = new StringBuilder();
                msgBuilder.Append(ex.Message + "\r\n");
                msgBuilder.Append(ex.StackTrace + "\r\n");
                logDB.Error(msgBuilder.ToString());
            }
        }

        /// <summary>
        /// 异常信息，并加附加的信息
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="formatInfo"></param>
        public static void LogDB(string msg, Exception ex)
        {
            DBLogger();
            if (logDB.IsInfoEnabled)
            {
                StringBuilder msgBuilder = new StringBuilder();
                msgBuilder.Append(ex.Message + "\r\n");
                msgBuilder.Append(ex.StackTrace + "\r\n");
                msgBuilder.Append(msg + "\r\n");
                logDB.Error(msgBuilder.ToString());
            }
        }

        /// <summary>
        /// 将SQL语句及其参数写入日志信息中
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="msg"></param>
        /// <param name="cmdParms"></param>
        public static void LogDB(Exception ex, string msg, params SqlParameter[] cmdParms)
        {
            DBLogger();
            if (logDB.IsInfoEnabled)
            {
                StringBuilder msgBuilder = new StringBuilder();
                msgBuilder.Append(ex.Message + "\r\n");
                msgBuilder.Append(ex.StackTrace + "\r\n");
                msgBuilder.Append(msg + "\r\n");
                msgBuilder.Append(ParseParms(cmdParms) + "\r\n");
                logDB.Error(msgBuilder.ToString());
            }
        }

        /// <summary>
        /// 记录操作信息
        /// </summary>
        /// <param name="deal"></param>
        /// <param name="sql"></param>
        public static void LogDB(string deal, string msg)
        {
            DBLogger();
            if (logDB.IsInfoEnabled)
            {
                StringBuilder msgBuilder = new StringBuilder();
                msgBuilder.Append(msg + "\r\n");
                msgBuilder.Append(deal + "\r\n");
                logDB.Info(msgBuilder.ToString());
            }
        }

        /// <summary>
        /// 记录带参数的操作信息
        /// </summary>
        /// <param name="deal"></param>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        public static void LogDB(string deal, string msg, params SqlParameter[] cmdParms)
        {
            DBLogger();
            if (logDB.IsInfoEnabled)
            {
                StringBuilder msgBuilder = new StringBuilder();
                msgBuilder.Append(msg + "\r\n");
                msgBuilder.Append(deal + "\r\n");
                msgBuilder.Append(ParseParms(cmdParms));
                logDB.Info(msgBuilder.ToString());
            }
        }

        #endregion
    }
}

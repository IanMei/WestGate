using CMS.Core.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CMS.Core.DAL {

    /// <summary>
    /// �����������ݴ����
    /// </summary>
    public class SqlCommondItem {
        public SqlCommondItem()
        {
            Params = new SqlParameter[] { };
        }

        public string Cmd { get; set; }

        public SqlParameter[] Params { get; set; }

    }
    /// <summary>
    /// ���ݷ��ʳ��������
    /// Copyright (C) 2004-2008
    /// All rights reserved
    /// </summary>
    public abstract class DbHelperSQL {
        #region Member
        public static string connectionString = "SQLConnectionstring";

        public DbHelperSQL()
        {
        }

        #endregion

        #region ���÷���


        /// <summary>
        /// ��ȡ��ĳ���ֶε����ֵ
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static int GetMaxID(string FieldName, string TableName)
        {
            string strSql = "select max(" + FieldName + ")+1 from " + TableName;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);

                object obj = db.ExecuteScalar(dbCommand);

                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return 1;
                }
                else
                {
                    return int.Parse(obj.ToString());
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        /// <summary>
        /// �������ݿ������ʱ��
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDBSystemDatetime()
        {
            string strSql = "select getdate() ";
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                object obj = db.ExecuteScalar(dbCommand);

                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return DateTime.Now;
                }
                else
                {
                    return (DateTime)obj;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }


        /// <summary>
        /// ���һ����¼�Ƿ����(SQL��䷽ʽ)
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static bool Exists(string strSql)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                object obj = db.ExecuteScalar(dbCommand);
                int cmdresult;
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    cmdresult = 0;
                }
                else
                {
                    cmdresult = int.Parse(obj.ToString());
                }
                if (cmdresult == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        /// <summary>
        /// ���һ����¼�Ƿ����(SqlParameter��䷽ʽ)
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                BuildDBParameter(db, dbCommand, cmdParms);
                object obj = db.ExecuteScalar(dbCommand);
                int cmdresult;
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    cmdresult = 0;
                }
                else
                {
                    cmdresult = int.Parse(obj.ToString());
                }
                if (cmdresult == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql, cmdParms);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }


        #endregion

        #region Create SqlParameter

        /// <summary>
        /// ����һ��SqlParameter
        /// </summary>
        /// <returns></returns>
        public static SqlParameter CreateDataParameter()
        {
            return new SqlParameter();
        }

        /// <summary>
        /// ����һ��SqlParameter
        /// </summary>
        /// <param name="name">������</param>
        /// <param name="dataType">��������</param>
        /// <returns></returns>
        public static SqlParameter CreateDataParameter(string name, DbType dataType)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = name;
            parameter.DbType = dataType;
            return parameter;
        }

        /// <summary>
        /// ����һ��SqlParameter
        /// </summary>
        /// <param name="name">������</param>
        /// <param name="value">����ֵ</param>
        /// <returns></returns>
        public static SqlParameter CreateDataParameter(string name, object value)
        {
            return new SqlParameter(name, value);
        }

        /// <summary>
        /// ����һ��SqlParameter
        /// </summary>
        /// <param name="name">������</param>
        /// <param name="dataType">��������</param>
        /// <param name="value">����ֵ</param>
        /// <returns></returns>
        public static SqlParameter CreateDataParameter(string name, DbType dataType, object value)
        {
            SqlParameter parameter = new SqlParameter();

            parameter.ParameterName = name;
            parameter.DbType = dataType;
            parameter.Value = value;
            return parameter;
        }

        public static SqlParameter CreateDataParameter(string name, DbType dataType, object value, bool isNullable)
        {
            SqlParameter parameter = new SqlParameter();

            parameter.ParameterName = name;
            parameter.DbType = dataType;
            parameter.IsNullable = isNullable;
            parameter.Value = value;
            return parameter;
        }

        /// <summary>
        /// ����һ��SqlParameter
        /// </summary>
        /// <param name="name">������</param>
        /// <param name="dataType">��������</param>
        /// <param name="size">��������ĳ���</param>
        /// <returns></returns>
        public static SqlParameter CreateDataParameter(string name, DbType dataType, int size)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = name;
            parameter.DbType = dataType;
            parameter.Size = size;
            return parameter;
        }

        public static SqlParameter CreateDataParameter(string name, DbType dataType, bool isNullable)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = name;
            parameter.DbType = dataType;
            parameter.IsNullable = isNullable;
            return parameter;
        }

        /// <summary>
        /// ����һ��SqlParameter
        /// </summary>
        /// <param name="name">������</param>
        /// <param name="dataType">��������</param>
        /// <param name="size">��������</param>
        /// <param name="srcColumn">������Ӧ��DataSet����</param>
        /// <returns></returns>
        public static SqlParameter CreateDataParameter(string name, DbType dataType, int size, string srcColumn)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = name;
            parameter.DbType = dataType;
            parameter.Size = size;
            parameter.SourceColumn = srcColumn;
            return parameter;
        }

        /// <summary>
        /// ����һ��SqlParameter
        /// </summary>
        /// <param name="name">������</param>
        /// <param name="dataType">��������</param>
        /// <param name="size">��������</param>
        /// <param name="direction"></param>
        /// <param name="isNullable"></param>
        /// <param name="precision"></param>
        /// <param name="scale"></param>
        /// <param name="srcColumn"></param>
        /// <param name="srcVersion"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SqlParameter CreateDataParameter(string name, DbType dataType, int size, ParameterDirection direction, bool isNullable, Byte precision, Byte scale, string srcColumn, DataRowVersion srcVersion, object value)
        {
            SqlParameter parameter = new SqlParameter();

            parameter.ParameterName = name;
            parameter.DbType = dataType;
            parameter.Size = size;
            parameter.Direction = direction;
            parameter.IsNullable = isNullable;
            parameter.Precision = precision;
            parameter.Scale = scale;
            parameter.SourceColumn = srcColumn;
            parameter.SourceVersion = srcVersion;
            parameter.Value = value;
            return parameter;
        }


        /// <summary>
        /// ���ز���
        /// </summary>
        /// <param name="db"></param>
        /// <param name="dbCommand"></param>
        /// <param name="cmdParms"></param>
        public static void BuildDBParameter(Database db, DbCommand dbCommand, params SqlParameter[] cmdParms)
        {
            foreach (SqlParameter sp in cmdParms)
            {
                db.AddInParameter(dbCommand, sp.ParameterName, sp.DbType, sp.Value);
            }
        }

        #endregion

        #region  ִ�м�SQL���

        public static int GetCount(string strSql, params SqlParameter[] cmdParms)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                BuildDBParameter(db, dbCommand, cmdParms);
                object obj = db.ExecuteScalar(dbCommand);
                int cmdresult;
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    cmdresult = 0;
                }
                else
                {
                    cmdresult = int.Parse(obj.ToString());
                }
                return cmdresult;
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql, cmdParms);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        /// <summary>
        /// ִ��SQL��䣬����Ӱ��ļ�¼��(���ڳ�ʱ���ѯ����䣬���õȴ�ʱ������ѯ��ʱ)
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="Times"></param>
        /// <returns></returns>
        public static int ExecuteSqlByTime(string strSql, int Times)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                dbCommand.CommandTimeout = Times;
                return db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }

        }


        /// <summary>
        /// ִ�в�ѯ��䣬����SqlDataReader ( ע�⣺ʹ�ú�һ��Ҫ��SqlDataReader����Close )
        /// </summary>
        /// <param name="strSql">��ѯ���</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string strSql)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                SqlDataReader dr = (SqlDataReader)db.ExecuteReader(dbCommand);
                return dr;
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        public static IDataReader getReader(string strSql, params SqlParameter[] cmdParms)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                BuildDBParameter(db, dbCommand, cmdParms);
                IDataReader dr = db.ExecuteReader(dbCommand);
                return dr;
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql, cmdParms);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        /// <summary>
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="strSql">��ѯ���</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string strSql)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        /// <summary>
        /// (���ڳ�ʱ���ѯ����䣬���õȴ�ʱ������ѯ��ʱ)
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="Times"></param>
        /// <returns></returns>
        public static DataSet Query(string strSql, int Times)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                dbCommand.CommandTimeout = Times;
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        #endregion

        #region Fill Data
        /// <summary>
        /// ����SQL���������ݵ�ָ����DataSet��
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableName"></param>
        public static void Fill(string strSql, DataSet dataSet, string tableName)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                if (dataSet.Tables.Contains(tableName))
                    dataSet.Tables[tableName].Clear();
                db.LoadDataSet(dbCommand, dataSet, tableName);
                LogHelper.LogDB("Select", strSql);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        /// <summary>
        /// ʹ��ָ��SQL��䡢ָ������������ݵ�ָ��DataSet��
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableName"></param>
        /// <param name="cmdParms"></param>
        public static void Fill(string strSql, DataSet dataSet, string tableName, params SqlParameter[] cmdParms)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                BuildDBParameter(db, dbCommand, cmdParms);
                if (dataSet.Tables.Contains(tableName))
                    dataSet.Tables[tableName].Clear();
                db.LoadDataSet(dbCommand, dataSet, tableName);
                LogHelper.LogDB("Select", strSql, cmdParms);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql, cmdParms);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }

        }

        #endregion

        #region ִ�д�������SQL���

        /// <summary>
        /// ִ��SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSql(string strSql)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                LogHelper.LogDB("Normal", strSql);
                return db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }


        /// <summary>
        /// ִ��SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static int ExecuteSql(string strSql, params SqlParameter[] cmdParms)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                BuildDBParameter(db, dbCommand, cmdParms);
                LogHelper.LogDB("Execute", strSql, cmdParms);
                return db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql, cmdParms);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }




        /// <summary>
        /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
        /// </summary>
        /// <param name="strSql">�����ѯ������</param>
        /// <returns>��ѯ�����object��</returns>
        public static object GetSingle(string strSql)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                object obj = db.ExecuteScalar(dbCommand);
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }
        public static object GetSingle(string strSql, ref string strError)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                object obj = db.ExecuteScalar(dbCommand);
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                strError = ex.Message;
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }


        /// <summary>
        /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
        /// </summary>
        /// <param name="strSql">�����ѯ������</param>
        /// <returns>��ѯ�����object��</returns>
        public static object GetSingle(string strSql, params SqlParameter[] cmdParms)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                BuildDBParameter(db, dbCommand, cmdParms);
                object obj = db.ExecuteScalar(dbCommand);
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql, cmdParms);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }

        }

        /// <summary>
        /// ���ؼ�¼ID
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static decimal GetID(string strSql, params SqlParameter[] cmdParms)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                BuildDBParameter(db, dbCommand, cmdParms);
                object obj = db.ExecuteScalar(dbCommand);
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return -1;
                }
                else
                {
                    return (decimal)obj;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql, cmdParms);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        /// <summary>
        /// ִ��һ��������䣬�﷨���£���������ID
        /// Insert Into Customers (Name, Address, City, Country, PostalCode) values ([Name], [Address],[City],[Country],[PostalCode]); Select @@IDENTITY;";
        /// </summary>
        /// <param name="strSql">�����ѯ������</param>
        /// <returns>��ѯ�����object��</returns>
        public static decimal ExecuteInsert(string strSql)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                object obj = db.ExecuteScalar(dbCommand);
                LogHelper.LogDB("Insert", strSql);
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return -1;
                }
                else
                {
                    return Convert.ToDecimal(obj);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        /// <summary>
        /// ִ��һ��������䣬�﷨���£���������ID
        /// Insert Into Customers (Name, Address, City, Country, PostalCode) values (@Name, @Address, @City, @Country, @PostalCode); Select @@IDENTITY;";
        /// </summary>
        /// <param name="strSql">�����ѯ������</param>
        /// <returns>��ѯ�����object��</returns>
        public static decimal ExecuteInsert(string strSql, params SqlParameter[] cmdParms)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                BuildDBParameter(db, dbCommand, cmdParms);
                object obj = db.ExecuteScalar(dbCommand);
                LogHelper.LogDB("Insert", strSql, cmdParms);
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return -1;
                }
                else
                {
                    return Convert.ToDecimal(obj);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql, cmdParms);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        /// <summary>
        /// ִ�в�ѯ��䣬����SqlDataReader ( ע�⣺ʹ�ú�һ��Ҫ��SqlDataReader����Close )
        /// </summary>
        /// <param name="strSql">��ѯ���</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string strSql, params SqlParameter[] cmdParms)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                BuildDBParameter(db, dbCommand, cmdParms);
                SqlDataReader dr = (SqlDataReader)db.ExecuteReader(dbCommand);
                return dr;
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql, cmdParms);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        /// <summary>
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="strSql">��ѯ���</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string strSql, params SqlParameter[] cmdParms)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                BuildDBParameter(db, dbCommand, cmdParms);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql, cmdParms);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }



        #endregion

        #region �洢���̲���

        /// <summary>
        /// ִ�д洢���̣�����Ӱ�������       
        /// </summary>       
        public static int RunProcedure(string storedProcName)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcName);
                return db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, storedProcName);
                throw new Exception(ex.Message + ",SQL=" + storedProcName, ex);
            }
        }

        /// <summary>
        /// ִ�д洢���̣��������������ֵ��Ӱ�������       
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <param name="OutParameter">�����������</param>
        /// <param name="rowsAffected">Ӱ�������</param>
        /// <returns></returns>
        public static object RunProcedure(string storedProcName, IDataParameter[] InParameters, SqlParameter OutParameter, int rowsAffected)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcName);
                BuildDBParameter(db, dbCommand, (SqlParameter[])InParameters);
                db.AddOutParameter(dbCommand, OutParameter.ParameterName, OutParameter.DbType, OutParameter.Size);
                rowsAffected = db.ExecuteNonQuery(dbCommand);
                return db.GetParameterValue(dbCommand, "@" + OutParameter.ParameterName);  //�õ����������ֵ
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, storedProcName);
                throw new Exception(ex.Message + ",SQL=" + storedProcName, ex);
            }
        }

        /// <summary>
        /// ִ�д洢���̣�����SqlDataReader ( ע�⣺ʹ�ú�һ��Ҫ��SqlDataReader����Close )
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcName, parameters);
                //BuildDBParameter(db, dbCommand, parameters);
                return (SqlDataReader)db.ExecuteReader(dbCommand);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, storedProcName);
                throw new Exception(ex.Message + ",SQL=" + storedProcName, ex);
            }
        }

       
        /// <summary>
        /// ִ�д洢���̣�����DataSet
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <param name="tableName">DataSet����еı���</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storedProcName, SqlParameter[] parameters, string tableName)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcName);
                BuildDBParameter(db, dbCommand, parameters);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, storedProcName);
                throw new Exception(ex.Message + ",SQL=" + storedProcName, ex);
            }
        }

        /// <summary>
        /// ִ�д洢���̣�����DataSet(�趨�ȴ�ʱ��)
        /// </summary>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcName, parameters);
                dbCommand.CommandTimeout = Times;
                //BuildDBParameter(db, dbCommand, parameters);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, storedProcName);
                throw new Exception(ex.Message + ",SQL=" + storedProcName, ex);
            }
        }

        /// <summary>
        /// ����SqlCommand ����(��������һ���������������һ������ֵ)
        /// </summary>
        /// <param name="connection">���ݿ�����</param>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            try
            {
                SqlCommand command = new SqlCommand(storedProcName, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                {
                    if (parameter != null)
                    {
                        // ���δ����ֵ���������,���������DBNull.Value.
                        if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) && (parameter.Value == null))
                        {
                            parameter.Value = DBNull.Value;
                        }
                        command.Parameters.Add(parameter);
                    }
                }
                return command;
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, storedProcName);
                throw new Exception(ex.Message + ",SQL=" + storedProcName, ex);
            }
        }

        #endregion

        #region ��������/����
        /// <summary>
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="SQLStringList"></param>
        public static bool ExecuteSqlTran(ArrayList SQLStringList)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionString);
            string strsql = "";
            bool commit = false;
            using (var connection = db.CreateConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            DbCommand dbCommand = db.GetSqlStringCommand(strsql);
                            db.ExecuteNonQuery(dbCommand, transaction);
                            LogHelper.LogDB("Normal", strsql);
                        }
                    }
                    commit = true;
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    commit = false;
                    transaction.Rollback();
                    LogHelper.Log(ex, strsql);
                    throw new Exception(ex.Message + ",SQL=" + strsql, ex);
                }
                connection.Close();
            }
            return commit;
        }


        /// <summary>
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="SQLStringList">SQL���Ĺ�ϣ��keyΪsql��䣬value�Ǹ�����SqlParameter[]��</param>
        public static bool ExecuteSqlTran(List<SqlCommondItem> SQLStringList)
        {

            Database db = DatabaseFactory.CreateDatabase(connectionString);
            string strsql = "";
            bool commit = false;
            using (var connection = db.CreateConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    foreach (var myDE in SQLStringList)
                    {
                        strsql = myDE.Cmd;
                        SqlParameter[] cmdParms = myDE.Params;
                        if (strsql.Trim().Length > 1)
                        {
                            DbCommand dbCommand = db.GetSqlStringCommand(strsql);
                            BuildDBParameter(db, dbCommand, cmdParms);
                            db.ExecuteNonQuery(dbCommand, transaction);
                            LogHelper.LogDB("Normal", strsql, cmdParms);
                        }
                    }
                    transaction.Commit();
                    commit = true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    commit = false;
                    LogHelper.Log(ex, strsql);
                    throw new Exception(ex.Message + ",SQL=" + strsql, ex);
                }
                connection.Close();
            }
            return commit;
        }

        #endregion

        #region �ۺϺ���

        public static decimal GetSum(string strSql, params SqlParameter[] cmdParms)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                BuildDBParameter(db, dbCommand, cmdParms);
                object obj = db.ExecuteScalar(dbCommand);
                decimal cmdresult;
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    cmdresult = 0;
                }
                else
                {
                    cmdresult = decimal.Parse(obj.ToString());
                }
                return cmdresult;
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql, cmdParms);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }
        #endregion
    }
}

using CMS.Core.Common;
using CMS.Core.DAL;
using CMS.Core.Responsity.BLL;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CMS.Core.Responsity
{
    public class BaseRepository<T> : IBaseRepository<T> where T : DataBasecfg, new()
    {
        /// <summary>
        /// 删除行
        /// </summary>
        /// <typeparam name="T">BaseObject基类的实体类</typeparam>
        /// <param name="instanceData">行</param>
        /// <returns></returns>
        public decimal Delete(BaseObject instanceData)
        {
            if (instanceData == null)
                return -1;
            return DALObject.Get(instanceData.GetType()).DeleteInstance(instanceData);
        }

        /// <summary>
        /// 删除集合
        /// </summary>
        /// <param name="masterData">集合</param>
        public void Delete(BaseList masterData)
        {
            if (masterData.Count > 0)
            {
                DALObject.Get(masterData[0].GetType()).Delete(masterData);
            }
        }
        /// <summary>
        /// 根据主键删除数据
        /// </summary>
        /// <typeparam name="T">BaseObject基类的实体类</typeparam>
        /// <param name="recordID">主键</param>
        /// <returns></returns>
        public int Delete<T>(decimal recordID) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).Delete(recordID);
        }

        public int Delete<T>(object keyCode) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).Delete(keyCode);
        }

        public int Delete<T>(ParamCollection _paramCollection) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).Delete(_paramCollection);
        }

        public bool Find<T>(decimal recordID) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).Find(recordID);
        }

        public bool Find<T>(object code) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).Find(code);
        }

        public bool Find<T>(object[] codes) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).Find(codes);
        }

        public bool Find<T>(decimal recordID, object code) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).Find(recordID, code);
        }

        public bool Find<T>(decimal recordID, object[] codes) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).Find(recordID, codes);
        }

        public bool Find<T>(decimal recordID, string field, object codes) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).Find(recordID, field, codes);
        }

        public T Get<T>(decimal recordID) where T : BaseObject, new()
        {
            var data = DALObject.Get(typeof(T)).Select(recordID);
            if (data.Count > 0)
            {
                return data[0] as T;
            }
            return null;
        }


        public T Get<T>(object keycode) where T : BaseObject, new()
        {
            var data = DALObject.Get(typeof(T)).Select(keycode);
            if (data.Count > 0)
            {
                return data[0] as T;
            }
            return null;
        }


        public T Get<T>(object[] keycodes) where T : BaseObject, new()
        {
            var data = DALObject.Get(typeof(T)).Select(keycodes);
            if (data.Count > 0)
            {
                return data[0] as T;
            }
            return null;
        }


        public object GetCode<T>(decimal recordID) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).GetCode(recordID);
        }

        public object[] GetCodes<T>(decimal recordID) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).GetCodes(recordID);
        }

        public int GetCount<T>(ParamCollection _paramCollection) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).GetCount(_paramCollection);
        }

        public object GetFieldValue<T>(object keyCode, string fieldName) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).GetFieldValue(keyCode, fieldName);
        }

        public object GetFieldValue<T>(object[] keyCodes, string fieldName) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).GetFieldValue(keyCodes, fieldName);
        }

        public object GetFieldValue<T>(ParamCollection _paramCollection, string fieldName) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).GetFieldValue(_paramCollection, fieldName);
        }

        public object GetFieldValue<T>(ParamCollection _paramCollection, string fieldName, string sort) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).GetFieldValue(_paramCollection, fieldName, sort);
        }

        public decimal GetID<T>(object code) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).GetID(code);
        }

        public decimal GetID<T>(object[] keyCodes) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).GetID(keyCodes);
        }

        public decimal GetSum<T>(ParamCollection _paramCollection, string sumField) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).GetSum(_paramCollection, sumField);
        }

        public List<T> Select<T>() where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).Select().OfType<T>().ToList();
        }

        public List<T> Select<T>(ParamCollection _paramCollection) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).Select(_paramCollection).OfType<T>().ToList();
        }

        public List<T> Select<T>(ParamCollection _paramCollection, string orderby) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).Select(_paramCollection, orderby).OfType<T>().ToList();
        }

        public List<T> Select<T>(ParamCollection _paramCollection, string orderby, short topcount) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).Select(_paramCollection, orderby, topcount).OfType<T>().ToList();
        }

        public List<T> SelectByPageIndex<T>(ParamCollection _paramCollection, string orderby, int pageIndex, int pageSize, out int pageCount) where T : BaseObject, new()
        {
            pageCount = DALObject.Get(typeof(T)).GetCount(_paramCollection);
            return DALObject.Get(typeof(T)).Select(_paramCollection, orderby, (pageIndex - 1) * pageSize + 1, pageIndex * pageSize).OfType<T>().ToList();
        }


        public List<T> SelectGroup<T>(ParamCollection _paramCollection, string groupby, string sort) where T : BaseObject, new()
        {
            return DALObject.Get(typeof(T)).SelectGroup(_paramCollection, groupby, sort).OfType<T>().ToList();
        }


        public decimal Update(BaseObject instanceData)
        {
            if (instanceData == null)
                return -1;
            if (instanceData.CurModel == DealModel.New)
            {
                return DALObject.Get(instanceData.GetType()).AddInstanceByParam(instanceData);
            }
            else
            {
                return (decimal)DALObject.Get(instanceData.GetType()).UpdateInstanceByParam(instanceData);
            }
        }

        public bool UpdateAllByParams(BaseList masterData)
        {
            if (masterData.Count > 0)
            {
                return DALObject.Get(masterData[0].GetType()).UpdateAllByParams(masterData);
            }
            return false;
        }

        public decimal UpdateMasterDetail(BaseObject masterData, params BaseList[] datas)
        {
            if (datas == null)
                return -1;
            if (datas.Length <= 0)
                return -1;
            var rs = DALObject.Get(masterData.GetType()).UpdateMasterDetail(masterData, datas);

            return 1;

        }

        public void UpdateMultiData(BaseList[] datas)
        {
            if (datas == null)
                return;
            if (datas.Length <= 0)
                return;
            DALObject.UpdateMultiData(datas);
        }

        /// <summary>
        /// 返回指定类型的序列号
        /// </summary>
        /// <param name="noType"></param>
        /// <returns></returns>
        public string GetSeqNo(string noType)
        {
            string yymm = DbHelperSQL.GetDBSystemDatetime().ToString("yyMM");
            string sql = "select SERIALS from SYS_NO where YYMM='" + yymm + "' AND NO_TYPE='" + noType + "'";
            object seq_no = DbHelperSQL.GetSingle(sql);
            decimal seq = 0;
            if (seq_no == null)
            {
                sql = "Insert into SYS_NO(NO_TYPE,YYMM,SERIALS) values('" + noType + "','" + yymm + "',1)";
                seq = 1;
            }
            else
            {
                seq = (decimal)seq_no + 1;
                sql = "Update SYS_NO set SERIALS=" + seq + " WHERE NO_TYPE='" + noType + "' AND YYMM='" + yymm + "'";
            }
            DbHelperSQL.ExecuteSql(sql);
            string seqNo = "" + seq;
            while (seqNo.Length < 5)
            {
                seqNo = "0" + seqNo;
            }
            return noType + yymm + seqNo;
        }

        /// <summary>
        /// 返回某一类的代码编码
        /// </summary>
        /// <param name="noType"></param>
        /// <param name="yymm"></param>
        /// <param name="CodeLen"></param>
        /// <returns></returns>
        public string GetSeqNo(string noType, int CodeLen)
        {
            string sql = "select SERIALS from SYS_NO where YYMM='" + noType + "' AND NO_TYPE='" + noType + "'";
            object seq_no = DbHelperSQL.GetSingle(sql);
            decimal seq = 0;
            if (seq_no == null)
            {
                sql = "Insert into SYS_NO(NO_TYPE,YYMM,SERIALS) values('" + noType + "','" + noType + "',1)";
                seq = 1;
            }
            else
            {
                seq = (decimal)seq_no + 1;
                sql = "Update SYS_NO set SERIALS=" + seq + " WHERE NO_TYPE='" + noType + "' AND YYMM='" + noType + "'";
            }
            DbHelperSQL.ExecuteSql(sql);
            string seqNo = "" + seq;
            while (seqNo.Length < CodeLen)
            {
                seqNo = "0" + seqNo;
            }
            return noType + seqNo;
        }

        /// <summary>
        /// 返回指定类型的唯一编号
        /// </summary>
        /// <param name="noType"></param>
        /// <returns></returns>
        public string GetSerialNo(string noType)
        {
            string yymm = DbHelperSQL.GetDBSystemDatetime().ToString("yyMMdd");
            string sql = "select SERIALS from SYS_NO where YYMM='" + yymm + "' AND NO_TYPE='" + noType + "'";
            object seq_no = DbHelperSQL.GetSingle(sql);
            decimal seq = 0;
            if (seq_no == null)
            {
                sql = "Insert into SYS_NO(NO_TYPE,YYMM,SERIALS) values('" + noType + "','" + yymm + "',1)";
                seq = 1;
            }
            else
            {
                seq = (decimal)seq_no + 1;
                sql = "Update SYS_NO set SERIALS=" + seq + " WHERE NO_TYPE='" + noType + "' AND YYMM='" + yymm + "'";
            }
            DbHelperSQL.ExecuteSql(sql);
            string seqNo = "" + seq;
            while (seqNo.Length < 5)
            {
                seqNo = "0" + seqNo;
            }
            return noType + yymm + seqNo;
        }

        /// <summary>
        /// 用户操作权限
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="operationCode">功能代号</param>
        /// <returns></returns>
        public bool GetUserOperationPermission(decimal userId, string operationCode)
        {
            object UOP = 0;
            StringBuilder buider = new StringBuilder();
            buider.Append(string.Format("SELECT [dbo].[FN_OperationalRights] ({0},'{1}')", userId, operationCode));
            UOP = DbHelperSQL.GetSingle(buider.ToString());
            return Convert.ToBoolean(UOP);
        }

        /// <summary>
        /// 用户权限验证
        /// </summary>
        /// <param name="token">TOKEN</param>
        /// <param name="funid">功能代码</param>
        /// <returns></returns>
        public bool GetUserRight(string token, string funid)
        {
            object UOP = 0;
            StringBuilder buider = new StringBuilder();
            buider.Append(string.Format("SELECT [dbo].[FN_UserRights] ('{0}','{1}')", token, funid));
            UOP = DbHelperSQL.GetSingle(buider.ToString());
            return Convert.ToBoolean(UOP);
        }

        /// <summary>
        /// 用户权限数组
        /// </summary>
        /// <param name="token"></param>
        /// <param name="funid"></param>
        /// <returns></returns>
        public string GetPermissionArray(decimal userId, string userType)
        {
            object arrs = "";
            StringBuilder buider = new StringBuilder();
            buider.Append(string.Format("SELECT [dbo].[FN_PermissionArray] ('{0}','{1}')", userId, userType));
            arrs = DbHelperSQL.GetSingle(buider.ToString());
            return arrs.ToString();
        }

      

        #region 数据反射

        /// <summary>
        /// 将dataReader转化成 List T
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="dataReader"></param>
        /// <returns>记录集</returns>
        private static List<T> ConvertTo<T>(SqlDataReader dataReader) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();
                var dataType = typeof(T);
                var Propertys = dataType.GetProperties();
                while (dataReader.Read())
                {
                    T data = new T();
                    int index = dataReader.FieldCount;
                    for (var i = 0; i < index; i++)
                    {
                        string fieldName = dataReader.GetName(i);
                        var property = GetPropertyInfo(Propertys, fieldName);
                        if (property != null && dataReader[i] != DBNull.Value)
                        {
                            property.SetValue(data, dataReader[i], null);
                        }
                    }
                    list.Add(data);
                }
                return list;
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                    dataReader.Dispose();
                }
            }
        }

        private static PropertyInfo GetPropertyInfo(PropertyInfo[] Propertys, string fieldName)
        {
            foreach (var Property in Propertys)
            {
                BaseFieldAttribute[] baseFieldAttributes = (BaseFieldAttribute[])Property.GetCustomAttributes(typeof(BaseFieldAttribute), true);
                if (baseFieldAttributes.Length > 0)
                {
                    foreach (BaseFieldAttribute baseField in baseFieldAttributes)
                    {
                        if (baseField.AliasName.Equals(fieldName, StringComparison.OrdinalIgnoreCase))
                            return Property;
                    }
                }
            }
            return null;
        }

        #endregion

      


        /// <summary>
        /// 用户是否购买本课程
        /// </summary>
        /// <param name="userCode">用户编号</param>
        /// <param name="courseNo">课程编号</param>
        /// <returns></returns>
        public int GetPayCourse(string userCode, string courseNo)
        {
            object arrs = "";
            StringBuilder buider = new StringBuilder();
            buider.Append(string.Format("SELECT [dbo].[MB_GetPayCourse] ('{0}','{1}')", userCode, courseNo));
            arrs = DbHelperSQL.GetSingle(buider.ToString());
            return (int)arrs;
        }
        /// <summary>
        /// 用户是否购买本资料
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="downloadNo"></param>
        /// <returns></returns>
        public int GetPayDownload(string userCode, string downloadNo)
        {
            object arrs = "";
            StringBuilder buider = new StringBuilder();
            buider.Append(string.Format("SELECT [dbo].[MB_GetPayDownload] ('{0}','{1}')", userCode, downloadNo));
            arrs = DbHelperSQL.GetSingle(buider.ToString());
            return (int)arrs;
        }
        /// <summary>
        /// 获取直播状态
        /// </summary>
        /// <param name="courseNo">直播课程编号</param>
        /// <returns></returns>
        public int GetLiveState(string courseNo)
        {
            object arrs = "";
            StringBuilder buider = new StringBuilder();
            buider.Append(string.Format("SELECT [dbo].[MB_GetLiveState] ('{0}')", courseNo));
            arrs = DbHelperSQL.GetSingle(buider.ToString());
            return (int)arrs;
        }
    }
}

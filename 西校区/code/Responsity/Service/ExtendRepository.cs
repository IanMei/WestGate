using CMS.Core.Common;
using CMS.Core.DAL;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace CMS.Core.Responsity.BLL {

    public class ExtendRepository<C> : IExtendRepository<C> where C : DataBasecfg {

        public List<T> SelectProcedure<T>(string ProcName, ParamCollection param) where T : class, new()
        {
            var list = new List<T>();
            var parameters = new List<SqlParameter>();
            foreach (var item in param)
            {

                var para = DbHelperSQL.CreateDataParameter(item.ParamName, item.DataType, item.Value);
                parameters.Add(para);
            }
            using (var dataReader = DbHelperSQL.RunProcedure(ProcName, parameters.ToArray()))
            {
                while (dataReader.Read())
                {
                    var _dataType = typeof(T);
                    T data = new T();
                    var propertyInfos = _dataType.GetProperties();
                    for (int i = 0; i < propertyInfos.Length; i++)
                    {
                        var fieldName = propertyInfos[i].Name;
                        PropertyInfo propertyInfo = _dataType.GetProperty(fieldName);
                        if (dataReader[fieldName] != System.DBNull.Value)
                        {
                            try
                            {
                                propertyInfo.SetValue(data, dataReader[fieldName], null);
                            }
                            catch (Exception e) { LogHelper.Log("ERROR  getDataList(DAL) : " + fieldName + "  " + e.Message); }
                        }
                    }
                    list.Add(data);
                }
            }

            return list;
        }

        public List<T> SelectBySql<T>(string sql) where T : class, new()
        {
            var list = new List<T>();
            using (var dataReader = DbHelperSQL.ExecuteReader(sql))
            {
                while (dataReader.Read())
                {
                    var _dataType = typeof(T);
                    T data = new T();
                    for (int i = 0; i < dataReader.FieldCount; i++) {
                        if (dataReader[i] != System.DBNull.Value)
                        {
                            PropertyInfo propertyInfo = _dataType.GetProperty(dataReader.GetName(i));
                            if (propertyInfo != null) {
                                try
                                {
                                    propertyInfo.SetValue(data, dataReader[i], null);
                                }
                                catch (Exception e) { LogHelper.Log("ERROR  getDataList(DAL) : " + propertyInfo.Name + "  " + e.Message); }
                            }
                        }
                    }
                    list.Add(data);
                }
            }

            return list;
        }
    }
}

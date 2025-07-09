using System;
using System.Collections.Generic;

namespace CMS.Core.Common.TableExtend
{
    public static class BaseObjectConvert
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="dataReader"></param>
        /// <returns>记录集</returns>
        public static T ConvertTo<T>(this object data) where T : class, new()
        {
            try
            {
                var dataType = typeof(T);
                var Propertys = dataType.GetProperties();

                T res = new T();

                foreach (var property in Propertys)
                {
                    var valType = data.GetType();

                    var valP = valType.GetProperty(property.Name);
                    if (valP != null)
                    {
                        var val = valP.GetValue(data, null);
                        property.SetValue(res, val, null);
                    }
                }
                return res;
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace ElementUI.Admin.Filters
{
    /// <summary>
    /// Json.NET 利用ContractResolver解决命名不一致问题
    /// 解决问题：通过无论是序列化还是反序列化都达到了效果，即：ProjectName -> project_name 和 project_name -> ProjectName
    /// </summary>
    public class UnderlineSplitContractResolver : DefaultContractResolver
    {
        /// <summary>
        /// 解析属性名称
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected override string ResolvePropertyName(string propertyName)
        {
            //return CamelCaseToUnderlineSplit(propertyName);//下划线分割命名法
            return propertyName.ToLower();//小写命名法
        }
        /// <summary>
        /// 下划线分割命名法
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string CamelCaseToUnderlineSplit(string name)
        {
            //return name.ToLower();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < name.Length; i++)
            {
                var ch = name[i];
                if (char.IsUpper(ch) && i > 0)
                {
                    var prev = name[i - 1];
                    if (prev != '_')
                    {
                        if (char.IsUpper(prev))
                        {
                            if (i < name.Length - 1)
                            {
                                var next = name[i + 1];
                                if (char.IsLower(next))
                                {
                                    builder.Append('_');
                                }
                            }
                        }
                        else
                        {
                            builder.Append('_');
                        }
                    }
                }

                builder.Append(char.ToLower(ch));
            }

            return builder.ToString();
        }
        /// <summary>
        /// 解决API NULL 和时间格式问题
        /// </summary>
        /// <param name="type"></param>
        /// <param name="memberSerialization"></param>
        /// <returns></returns>
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return type.GetProperties()
                   .Select(p => {
                       var jp = base.CreateProperty(p, memberSerialization);
                       //if (jp.PropertyType == typeof(System.String))
                       jp.ValueProvider = new NullToEmptyStringValueProvider(p);
                       //if (jp.PropertyType.ToString().Contains("System.DateTime"))
                       //    jp.Converter = new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd HH:mm:ss" };
                       return jp;
                   }).ToList();
        }
    }

    /// <summary>
    /// 解决返回json数据null问题
    /// </summary>
    public class NullToEmptyStringValueProvider : IValueProvider
    {
        PropertyInfo _MemberInfo;
        /// <summary>
        /// 空到空字符串值属性
        /// </summary>
        /// <param name="memberInfo">属性信息</param>
        public NullToEmptyStringValueProvider(PropertyInfo memberInfo)
        {
            _MemberInfo = memberInfo;
        }
        /// <summary>
        /// 方法
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public object GetValue(object target)
        {
            object result = _MemberInfo.GetValue(target, null);
            if (_MemberInfo.PropertyType == typeof(string) && result == null) result = "";
            return result;
        }
        /// <summary>
        /// 赋值
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public void SetValue(object target, object value)
        {
            _MemberInfo.SetValue(target, value, null);
        }
    }
}
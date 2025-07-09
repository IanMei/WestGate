using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Http.Description
{
    /// <summary>
    /// API描述器扩展
    /// </summary>
    public static class ApiDescriptionExtension
    {
        /// <summary>
        /// 获取区域名称
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        //public static string GetAreaName(this ApiDescription description)
        //{
        //    string controllerFullName = description.ActionDescriptor.ControllerDescriptor.ControllerType.FullName;
        //    //匹配areaName
        //    string areaName = Text.RegularExpressions.Regex.Match(controllerFullName, @"Area.([^,]+)\.C").Groups[1].ToString().Replace(".", "");
        //    if (string.IsNullOrEmpty(areaName))
        //    {
        //        //若不是areas下的controller,将路由格式中的{area}去掉
        //        description.RelativePath = description.RelativePath.Replace("{area}/", "");
        //    }
        //    else
        //    {
        //        //若是areas下的controller,将路由格式中的{area}替换为真实areaname
        //        description.RelativePath = description.RelativePath.Replace("{area}", areaName);
        //        var findResult = description.ParameterDescriptions.Where(t => t.Name == "area");
        //        if (findResult != null && findResult.Count() > 0)
        //        {
        //            description.ParameterDescriptions.Remove(findResult.First());
        //        }
        //    }
        //    return areaName;
        //}
        public static string GetAreaName(this ApiDescription description)
        {
            string controllerFullName = description.ActionDescriptor.ControllerDescriptor.ControllerType.FullName;

            //获取控制器名称
            string controllerName = "";
            int index = controllerFullName.LastIndexOf('.');
            if (index != -1)
            {
                controllerName = controllerFullName.Substring(index + 1);
                controllerName = controllerName.Replace("Controller", "");
            }

            //匹配areaName
            //如果不包含area,则根据控制器名称进行分组
            string areaName = "";
            if (controllerFullName.Contains(".Areas."))
            {
                //获取area索引位置
                index = controllerFullName.IndexOf(".Areas.");
                areaName = controllerFullName.Substring(index + 7);

                //获取area名称,解决多级目录下area名称不正确的问题
                try
                {
                    index = areaName.IndexOf('.');
                    areaName = areaName.Substring(0, index);
                }
                catch (System.Exception)
                {
                }
            }

            if (string.IsNullOrEmpty(areaName))
            {
                //若不是areas下的controller,将路由格式中的{area}去掉
                description.RelativePath = description.RelativePath.Replace("{area}/", "");
                return areaName;
            }
            //根据area分组
            else
            {
                //string relativePath = $"{areaName}.{controllerName}";
                //若是areas下的controller,将路由格式中的{area}替换为真实areaname
                description.RelativePath = description.RelativePath.Replace("{area}", areaName);
                //description.RelativePath = relativePath;

                var findResult = description.ParameterDescriptions.Where(t => t.Name == "area");
                if (findResult != null && findResult.Count() > 0)
                {
                    description.ParameterDescriptions.Remove(findResult.First());
                }
                return areaName;
            }
        }
        /// <summary>
        /// 获取控制器名称
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public static string GetControllerName(this ApiDescription description)
        {
            //string controllerFullName = description.ActionDescriptor.ControllerDescriptor.ControllerType.FullName;
            //string controllerName = controllerFullName;

            //if (!string.IsNullOrEmpty(controllerFullName))
            //{
            //    int index = controllerFullName.LastIndexOf('.');
            //    if (index != -1)
            //    {
            //        controllerName = controllerFullName.Substring(index + 1);
            //        controllerName = controllerName.Replace("Controller", "");
            //    }
            //}
            //return controllerName;

            string controllerFullName = description.ActionDescriptor.ControllerDescriptor.ControllerType.FullName;
            //获取控制器名称
            string controllerName = "";
            int index = controllerFullName.LastIndexOf('.');
            if (index != -1)
            {
                controllerName = controllerFullName.Substring(index + 1);
                controllerName = controllerName.Replace("Controller", "");
            }

            //匹配areaName
            //如果不包含area,则根据控制器名称进行分组
            string areaName = "";
            if (controllerFullName.Contains(".Areas."))
            {
                //获取area索引位置
                index = controllerFullName.IndexOf(".Areas.");
                areaName = controllerFullName.Substring(index + 7);

                //获取area名称,解决多级目录下area名称不正确的问题
                index = areaName.IndexOf('.');
                areaName = areaName.Substring(0, index);
            }
            //= Regex.Match(controllerFullName, @"Area.([^,]+)\.C").Groups[1].ToString().Replace(".", "");
            if (string.IsNullOrEmpty(areaName))
            {
                //若不是areas下的controller,将路由格式中的{area}去掉
                description.RelativePath = description.RelativePath.Replace("{area}/", "");
                return controllerName;
            }
            //根据area分组
            else
            {
                //string relativePath = $"{areaName}.{controllerName}";
                //若是areas下的controller,将路由格式中的{area}替换为真实areaname
                description.RelativePath = description.RelativePath.Replace("{area}", areaName);
                //description.RelativePath = relativePath;

                var findResult = description.ParameterDescriptions.Where(t => t.Name == "area");
                if (findResult != null && findResult.Count() > 0)
                {
                    description.ParameterDescriptions.Remove(findResult.First());
                }
                return controllerName;
                //return areaName;
            }
        }
    }
}
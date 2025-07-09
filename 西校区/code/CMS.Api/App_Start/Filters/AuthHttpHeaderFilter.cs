using ElementUI.Admin.Filters;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace ElementUI.Admin.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthHttpHeaderFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();
            //var filterPipeline = apiDescription.ActionDescriptor.GetFilterPipeline(); //判断是否添加权限过滤器
            //var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Instance).Any(filter => filter is IAuthorizationFilter); //判断是否允许匿名方法 

            var isNeedLogin = apiDescription.ActionDescriptor.GetCustomAttributes<ApiAuthorizeAttribute>().Any();//是否有验证用户标记
            if (isNeedLogin == false)//如果有验证标记 多输出1个文本框(swagger form提交是会将这两个值放到header中)
            {
                isNeedLogin = apiDescription.GetControllerAndActionAttributes<ApiAuthorizeAttribute>().Any();
            }
            var isAllowAnonymous = apiDescription.GetControllerAndActionAttributes<AllowAnonymousAttribute>().Any();
            if (isNeedLogin && isAllowAnonymous == false)
            {
                operation.parameters.Add(new Parameter
                {
                    name = "token",
                    @in = "header",
                    description = "令牌(登陆后可以获取)",
                    required = false,
                    type = "string"
                });
            }
        }
    }
}
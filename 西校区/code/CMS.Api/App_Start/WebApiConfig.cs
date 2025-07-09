using Newtonsoft.Json;
using System.Configuration;
using System.Web.Http;

namespace ElementUI.Admin {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            var allowOrigins = ConfigurationManager.AppSettings["cors_allowOrigins"];
            var allowHeaders = ConfigurationManager.AppSettings["cors_allowHeaders"];
            var allowMethods = ConfigurationManager.AppSettings["cors_allowMethods"];
            var globalCors = new System.Web.Http.Cors.EnableCorsAttribute(allowOrigins, allowHeaders, allowMethods)
            {
                SupportsCredentials = true
            };
            config.EnableCors(globalCors);
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{area}/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //config.Formatters.JsonFormatter.SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings()
            //{
            //    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore //设置忽略值为 null 的属性  
            //};

            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            config.Formatters.JsonFormatter.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            config.Formatters.JsonFormatter.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";   //解决json时间带T的问题
            //config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;   //解决json格式化缩进问题
            //config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;   //解决json序列化时的循环引用问题
            //config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new UnderlineSplitContractResolver();
        }
    }
}

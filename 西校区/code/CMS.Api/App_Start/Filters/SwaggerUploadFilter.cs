using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace ElementUI.Admin.Filters
{
    /// <summary>
    /// swagger file upload parameter filter
    /// </summary>
    public class SwaggerUploadFilter : IOperationFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="schemaRegistry"></param>
        /// <param name="apiDescription"></param>
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            //string su = operation.summary;
            //if (!string.IsNullOrWhiteSpace(su) && su.Contains("upload"))
            //{
            //    operation.consumes.Add("multipart/form-data");
            //    operation.parameters.Add(new Parameter
            //    {
            //        name = "file",
            //        @in = "formData",
            //        description = "file to upload",
            //        required = true,
            //        type = "file"
            //    });
            //}
            string relativePath = apiDescription.RelativePath;
            if (relativePath == "api/UpLoad/FileUpLoad" || relativePath == "api/UpLoad/ImageUpload")
            {
                operation.consumes.Add("multipart/form-data");
                if (operation.parameters == null)
                {
                    operation.parameters = new List<Parameter>();
                }
                operation.parameters.Add(new Parameter
                {
                    name = "file",
                    @in = "formData",
                    description = "file to upload",
                    required = true,
                    type = "file"
                });
            }
        }
    }
}
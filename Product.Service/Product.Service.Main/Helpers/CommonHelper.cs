using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Service.Main.Helpers
{
    /// <summary>
    /// Static class for common helpers
    /// </summary>
    public static class CommonHelper
    {
        /// <summary>
        /// Extension for IOperationFilter class
        /// </summary>
        public class RemoveVersionParameterFilter : IOperationFilter
        {
            /// <summary>
            /// Remove parameter version from list of parameters
            /// </summary>
            /// <param name="operation"></param>
            /// <param name="context"></param>
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                var versionParameter = operation.Parameters.Single(p => p.Name == "version");
                operation.Parameters.Remove(versionParameter);
            }
        }

        /// <summary>
        /// Extension for IDocumentFilter class
        /// </summary>
        public class ReplaceVersionWithExactValueInPathFilter : IDocumentFilter
        {
            /// <summary>
            /// Replace version macro for real version text
            /// </summary>
            /// <param name="swaggerDoc"></param>
            /// <param name="context"></param>
            public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
            {
                var paths = new OpenApiPaths();
                foreach (var path in swaggerDoc.Paths)
                {
                    paths.Add(path.Key.Replace("v{version}", swaggerDoc.Info.Version), path.Value);
                }
                swaggerDoc.Paths = paths;
            }
        }
        }
}

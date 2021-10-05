using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace MyProject.WebFramework.ServiceConfiguration.Swagger
{
    internal class RemoveDefaultInputs : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Remove version parameter from all Operations
            var versionParameter = operation.Parameters.SingleOrDefault(p => p.Name == "version");
            if (versionParameter != null)
                operation.Parameters.Remove(versionParameter);
            var CultureParameter = operation.Parameters.SingleOrDefault(p => p.Name == "Culture");
            if (CultureParameter != null)
            {
                operation.Parameters.Remove(CultureParameter);
            }
        }
    }
}

using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MyProject.WebFramework.ServiceConfiguration.Swagger
{
    internal class SetVersionAndCultureInPaths : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var updatedPaths = new OpenApiPaths();
            string newUri = null;
            foreach (var entry in swaggerDoc.Paths)
            {
                newUri = entry.Key.Replace("v{version}", swaggerDoc.Info.Version);
                newUri = newUri.Replace("{Culture}", "en-US");
                updatedPaths.Add(newUri, entry.Value);
            }
            swaggerDoc.Paths = updatedPaths;
        }
    }
}

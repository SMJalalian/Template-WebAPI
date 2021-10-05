using Microsoft.Extensions.DependencyInjection;
using MyProject.Configuration;
using MyProject.WebFramework.ServiceConfiguration.Localization;
using MyProject.WebFramework.ServiceConfiguration.Swagger;

namespace MyProject.WebFramework
{
    public static class ServicesExtentions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, string environment,
            GlobalSettings globalSettings)
        {

            #region Custom Services

            services.AddApiVersioning();
            services.AddCustomSwagger(environment, globalSettings);
            services.AddCustomLocalization();

            #endregion

            return services;
        }
    }
}

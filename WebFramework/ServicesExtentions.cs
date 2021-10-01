using Microsoft.Extensions.DependencyInjection;
using MyProject.WebFramework.ServiceConfiguration.Swagger;
using MyProject.WebFramework.ServiceConfiguration.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Configuration;
using Microsoft.Extensions.Options;

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

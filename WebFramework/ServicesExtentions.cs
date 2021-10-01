using Microsoft.Extensions.DependencyInjection;
using MyProject.WebFramework.ServiceConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.WebFramework
{
    public static class ServicesExtentions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, string environment )
        {




            #region Custom Services

            services.AddCustomSwagger(environment);
            services.AddCustomLocalization();

            #endregion

            return services;
        }
    }
}

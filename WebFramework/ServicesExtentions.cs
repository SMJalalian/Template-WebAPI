using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyProject.Configuration;
using MyProject.Data;
using MyProject.Services.DomainServices.Messaging;
using MyProject.WebFramework.ServiceConfiguration.Identity;
using MyProject.WebFramework.ServiceConfiguration.Localization;
using MyProject.WebFramework.ServiceConfiguration.Swagger;
using MyProject.WebFramework.ServiceConfiguration.WebToken;

namespace MyProject.WebFramework
{
    public static class ServicesExtentions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, string environment,
            GlobalSettings globalSettings)
        {

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IApplicationBuilder, ApplicationBuilder>();

            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(globalSettings.SQLSettings.ConnectionString));


            services.AddCustomWebTokenAuthentication(globalSettings.JwtSettings);

            services.AddScoped<EmailManager>();

            #region Custom Services

            services.AddApiVersioning();
            services.AddCustomIdentity();
            services.AddCustomSwagger(environment, globalSettings);
            services.AddCustomLocalization();

            #endregion

            return services;
        }
    }
}

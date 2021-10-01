using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using MyProject.Services.ExternalServices;
using System.Globalization;

namespace MyProject.WebFramework.ServiceConfiguration
{
    public static class LocalizationConfigurationExtensions
    {
        public static void AddCustomLocalization(this IServiceCollection services)
        {

            services.AddLocalization(opts => opts.ResourcesPath = "Resources");
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.SubFolder);
            services.AddScoped<LocalizationManager>();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]{
                    new CultureInfo("en-US"),
                    new CultureInfo("fa-IR"),
                    // ... others
                };
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders.Insert(0, new RouteDataRequestCultureProvider());
            });
        }
    }
}

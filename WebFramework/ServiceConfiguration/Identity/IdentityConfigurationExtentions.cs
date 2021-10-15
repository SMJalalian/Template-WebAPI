using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MyProject.Data;
using MyProject.Domain.Identity;
using MyProject.Services.DomainServices.Identity;

namespace MyProject.WebFramework.ServiceConfiguration.Identity
{
    public static class IdentityConfigurationExtentions
    {
        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDBContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<CustomSignInManager>();
            services.AddScoped<CustomUserManager>();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MyProject.Shared.Utilities;
using System;
using System.Linq;
using System.Reflection;

namespace MyProject.WebFramework.ServiceConfiguration
{
    public static class SwaggerConfigurationExtensions
    {
        public static void AddCustomSwagger(this IServiceCollection services, string environment)
        {
            Assert.NotNull(services, nameof(services));

            //Add services and configuration to use swagger
            services.AddSwaggerGen(options =>
            {

                options.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "API V1 (en-US)" });
                options.SwaggerDoc("v2", new OpenApiInfo { Version = "v2", Title = "API V2 (en-US)" });

                #region Authentication

                if (environment.Equals("Production"))
                {
                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Scheme = "Bearer",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.OAuth2,
                        Flows = new OpenApiOAuthFlows
                        {
                            Password = new OpenApiOAuthFlow
                            {
                                TokenUrl = new Uri("https://WebApiProduction.MySite.Local/api/v1/en-US/Token"),                                
                            }
                        }
                    });
                }
                else if (environment.Equals("Staging"))
                {
                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Scheme = "Bearer",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.OAuth2,
                        Flows = new OpenApiOAuthFlows
                        {
                            Password = new OpenApiOAuthFlow
                            {
                                TokenUrl = new Uri("https://WebApiStaging.MySite.Local/api/v1/en-US/Token"),
                            }
                        }
                    });
                }
                else if (environment.Equals("Development"))
                {
                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Scheme = "Bearer",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.OAuth2,
                        Flows = new OpenApiOAuthFlows
                        {
                            Password = new OpenApiOAuthFlow
                            {
                                TokenUrl = new Uri("https://localhost:44342/api/v1/en-US/Token"),
                            }
                        }
                    });
                }
                #endregion
            });
        }
    }
}

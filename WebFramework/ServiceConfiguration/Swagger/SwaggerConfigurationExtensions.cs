using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MyProject.Configuration;
using System;

namespace MyProject.WebFramework.ServiceConfiguration.Swagger
{
    public static class SwaggerConfigurationExtensions
    {
        public static void AddCustomSwagger(this IServiceCollection services, string environment, GlobalSettings globalSettings)
        {
            string swaggerTokenUri = null;
            string swaggerSecurityScheme = globalSettings.SwaggerSettings.SecurityScheme;


            //Set token Uri based on apllication environment
            if (environment.Equals("Production"))
                swaggerTokenUri = globalSettings.SwaggerSettings.ProductionTokenUrl;
            else if (environment.Equals("Staging"))
                swaggerTokenUri = globalSettings.SwaggerSettings.StagingTokenUrl;
            else
                swaggerTokenUri = globalSettings.SwaggerSettings.DevelopmentTokenUrl;


            //Add services and configuration to use swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "API V1 (en-US)" });
                options.SwaggerDoc("v2", new OpenApiInfo { Version = "v2", Title = "API V2 (en-US)" });

                // Remove version and culture parameter from all Operations
                options.OperationFilter<RemoveDefaultInputs>();

                //set version "api/v{version}/{culture}/[controller]" from current swagger doc verion
                options.DocumentFilter<SetVersionAndCultureInPaths>();

                //set authentication protocol and security options
                options.AddSecurityDefinition(swaggerSecurityScheme, new OpenApiSecurityScheme
                {
                    Scheme = swaggerSecurityScheme,
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Password = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri(swaggerTokenUri),
                        }
                    }
                });
            });
        }
    }
}

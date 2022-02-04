using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Weelo.App.Api.Config
{
    public static class SwaggerConfiguration
    {
        private const string KEYApiName = "Swagger:ApiName";
        private const string KEYApiVersion = "Swagger:ApiVersion";
        private const string KEYApiDescription = "Weelo.App.Api is a attitude test in .NET Core tecnologia, for its use, please use the method 'authenticate' and log in with this user 'Admin' and Password 'PassWorD'";

        public static void AddSwagger(this IServiceCollection services)
            => AddSwagger(services, string.Empty, string.Empty);

        public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            string ApiName = "Weelo.App.Api";
            var SectionApiName = configuration.GetSection(KEYApiName);
            if (SectionApiName.Exists())
                ApiName = SectionApiName.Value;

            string ApiVersion = "V.0.1";
            var SectionApiVersion = configuration.GetSection(KEYApiVersion);
            if (SectionApiVersion.Exists())
                ApiVersion = SectionApiVersion.Value;

            AddSwagger(services, ApiName, ApiVersion);
        }

        private static void AddSwagger(this IServiceCollection services, string APIName, string APIVersion)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = APIName, Version = APIVersion, Description = KEYApiDescription });
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name.Replace(".Config", "")}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                c.OperationFilter<SecurityRequirementsOperationFilter>();
                c.OperationFilter<FileOperationFilter>();
            });
        }
    }
    public class FileOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var fileParams = context.MethodInfo.GetParameters()
                .Where(p => p.ParameterType.FullName.Equals(typeof(Microsoft.AspNetCore.Http.IFormFile).FullName));

            if (fileParams.Any() && fileParams.Count() == 1)
            {
                operation.Parameters.Clear();
                operation.Parameters = new List<OpenApiParameter>
                {
                    new OpenApiParameter
                    {
                        Name = fileParams.First().Name,
                        Required = true,
                        Schema = new OpenApiSchema(){ Type = "file" },
                        In = ParameterLocation.Header
                    }
                };
            }
        }
    }
}

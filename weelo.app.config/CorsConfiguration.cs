using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Weelo.App.Api.Config
{
    public static class CorsConfiguration
    {
        private const string KeyAvaliableHosts = "Settings:AvailableOrigins";
        public const string DevelopPolicyName = "AllowAllOrigin";

        public static void AddCorsValidation(this IServiceCollection services, IConfiguration configuration)
        {
            var HostsSection = configuration.GetSection(KeyAvaliableHosts);
            if (!HostsSection.Exists())
                throw new System.Exception("No se encontró la sección '{KeyAvaliableHosts}'.");

            var HostsArray = HostsSection.Value.Split(';');
            services.AddCors(options =>
            {                
                options.AddPolicy(DevelopPolicyName, builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }
    }
}

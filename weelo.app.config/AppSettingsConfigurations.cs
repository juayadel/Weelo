using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.App.Api.Config
{
    public static class AppSettingsConfigurations
    {
        public static IConfiguration DefaultBuild()
        {
            string EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}

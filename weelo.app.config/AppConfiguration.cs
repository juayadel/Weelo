using Microsoft.Extensions.Configuration;
using System;
namespace Weelo.App.Api.Config
{
    public class AppConfiguration 
    {
        public static AppConfiguration Instance
        {
            get { return obj; }
        }
        private static readonly AppConfiguration obj = new AppConfiguration();

        readonly IConfiguration ConfigRoot = AppSettingsConfigurations.DefaultBuild();

        public string Read(string KeyItem)
            => ConfigRoot.GetSection("Settings").GetSection(KeyItem.ToString()).Value;
        public string Read(String KeyName, String SectionName)
           => ConfigRoot.GetSection(SectionName).GetSection(KeyName).Value;
        public string GetConnectionString(String DataBase)
            => Read(DataBase, "ConnectionStrings");
    }
}

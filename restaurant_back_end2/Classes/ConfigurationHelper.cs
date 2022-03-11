using Microsoft.Extensions.Configuration;
using System;

namespace restaurant_back_end2.Classes
{
    public class ConfigurationHelper
    {
        public static string GetByName(string configKeyName)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();


            IConfigurationSection section = config.GetSection("test");
            return section.Value;
        }
    }
}

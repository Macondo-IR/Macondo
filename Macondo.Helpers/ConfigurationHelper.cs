using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Macondo.Helpers
{
    public static class ConfigurationHelper
    {
        public static string GetConnectionString(string name)
        {
            var config = new ConfigurationBuilder()
                // .SetBasePath(Directory.GetCurrentDirectory())
                .SetBasePath(@"G:\Prj\Macondo\Macondo.Helpers") // مسیر دقیق لایبرری

                .AddJsonFile("appsettings.json")
                .Build();
            return config.GetConnectionString(name);
        }
    }
}
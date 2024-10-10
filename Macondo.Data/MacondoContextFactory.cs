using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Macondo.Data
{
    public class MacondoContextFactory : IDesignTimeDbContextFactory<MacondoContext>
    {
        public MacondoContext CreateDbContext(string[] args)
        {
            // Load configuration from the current project (Macondo.Data)
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // مسیر جاری پروژه
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // بارگذاری فایل تنظیمات
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MacondoContext>();
            var connectionString = configuration.GetConnectionString("MacondoDatabase");

            optionsBuilder.UseSqlServer(connectionString);

            return new MacondoContext(optionsBuilder.Options);
        }
    }
}

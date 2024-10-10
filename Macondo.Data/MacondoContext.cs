using Microsoft.EntityFrameworkCore;
using Macondo.Model;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Macondo.Data
{
    public class MacondoContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<List> Lists { get; set; }

        // Constructor for allowing the DbContextOptions to be passed in (needed for Dependency Injection and design-time tools)
        public MacondoContext(DbContextOptions<MacondoContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Load configuration from the Helpers project
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Macondo.Helpers")) // مسیر پروژه Helpers
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("MacondoDatabase");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .ToTable("Items");

            modelBuilder.Entity<List>()
                .ToTable("Lists");

            modelBuilder.Entity<List>()
                .HasMany(l => l.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade); // تنظیم رابطه حذف
        }
    }
}

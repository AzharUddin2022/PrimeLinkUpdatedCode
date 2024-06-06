using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Entity;
using System;

namespace Repository.DatabaseUtil
{
    public class DbContextFactory
    {
        public static DbContext GetFrontDbContext()
        {
            return new FrontDbContext();
        }

        public static DbContext GetBackDbContext()
        {
            return new BackDbContext();
        }

        public class BackDbContext : PrimLinkDBContext
        {
            public BackDbContext()
            {

            }
            public BackDbContext(DbContextOptions<PrimLinkDBContext> options) : base(options)
            {

            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }
            public IConfigurationRoot Configuration { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var ASPNETCORE_ENVIRONMENT = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                var configuration = new ConfigurationBuilder()
                      .AddJsonFile("appsettings.json")
                      .AddJsonFile($"appsettings.{ASPNETCORE_ENVIRONMENT}.json");
                Configuration = configuration.Build();
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("PrimLinkDB"));
            }

        }
        public class FrontDbContext : DbContext
        {
            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
            }
        }

    }
}

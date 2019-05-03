using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TT.SoMall.EntityFrameworkCore
{
    public class SoMallMigrationsDbContextFactory : IDesignTimeDbContextFactory<SoMallMigrationsDbContext>
    {
        public SoMallMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<SoMallMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new SoMallMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, true);

            return builder.Build();
        }
    }
}

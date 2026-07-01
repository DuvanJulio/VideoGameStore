using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using VideoGameStore.Infrastructure.Utils;

namespace VideoGameStore.Infrastructure.Database
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var appEnvironment = new AppEnvironment();
            configuration.GetSection("AppEnvironment").Bind(appEnvironment);

            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            optionsBuilder.UseMySql(
                appEnvironment.DATABASE_STRING_BUILDER.ConnectionString,
                new MariaDbServerVersion(new Version(10, 11, 0)));

            return new DatabaseContext(optionsBuilder.Options, appEnvironment);
        }
    }
}

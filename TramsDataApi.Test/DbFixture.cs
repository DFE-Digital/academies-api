using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using TramsDataApi.DatabaseModels;
using Xunit;

namespace TramsDataApi.Test
{
    public class DbFixture
    {
        public readonly string ConnString;

        public DbFixture()
        {
            var projectDir = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(projectDir, "integration_settings.json");

            var config = new ConfigurationBuilder()
                .AddJsonFile(configPath)
                .AddUserSecrets(typeof(DbFixture).Assembly)
                .AddEnvironmentVariables()
                .Build();

            ConnString = config.GetConnectionString("DefaultConnection");

            var tramsContextBuilder = new DbContextOptionsBuilder<TramsDbContext>();
            tramsContextBuilder.UseSqlServer(ConnString);
            var tramsDbContext = new TramsDbContext(tramsContextBuilder.Options);

            tramsDbContext.Database.EnsureCreated();
            tramsDbContext.Database.Migrate();
        }
    }

    [CollectionDefinition("Database", DisableParallelization = true)]
    public class DatabaseCollection : ICollectionFixture<DbFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}

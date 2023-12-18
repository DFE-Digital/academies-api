using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using TramsDataApi.DatabaseModels;
using Xunit;

namespace TramsDataApi.Test
{
    public class DbFixture : IDisposable
    {
        private readonly LegacyTramsDbContext _legacyTramsDbContext;
        private readonly TramsDbContext _tramsDbContext;
        private readonly IDbContextTransaction _legacyTransaction;
        private readonly IDbContextTransaction _tramsTransaction;
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

            var legacyContextBuilder = new DbContextOptionsBuilder<LegacyTramsDbContext>();
            var tramsContextBuilder = new DbContextOptionsBuilder<TramsDbContext>();

            legacyContextBuilder.UseSqlServer(ConnString);
            _legacyTramsDbContext = new LegacyTramsDbContext(legacyContextBuilder.Options);

            tramsContextBuilder.UseSqlServer(ConnString);
            _tramsDbContext = new TramsDbContext(tramsContextBuilder.Options);

            _tramsDbContext.Database.EnsureCreated();
            _tramsDbContext.Database.Migrate();

            _legacyTransaction = _legacyTramsDbContext.Database.BeginTransaction();
            _tramsTransaction = _tramsDbContext.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _legacyTransaction.Rollback();
            _legacyTransaction.Dispose();
            _tramsTransaction.Rollback();
            _tramsTransaction.Dispose();
            GC.SuppressFinalize(this);
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
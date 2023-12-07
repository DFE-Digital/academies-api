using System;
using System.IO;
using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Domain.Trust;
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
        private readonly MstrContext _mstrDbContext;
        private readonly IDbContextTransaction _legacyTransaction;
        private readonly IDbContextTransaction _tramsTransaction;
        private readonly IDbContextTransaction _mstrTransaction;
        public readonly string ConnString;
        public DbContextOptions<MstrContext> MstrContextOptions { get; }
        
        
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
            var mstrContextBuilder = new DbContextOptionsBuilder<MstrContext>();

            legacyContextBuilder.UseSqlServer(ConnString);
            _legacyTramsDbContext = new LegacyTramsDbContext(legacyContextBuilder.Options);

            tramsContextBuilder.UseSqlServer(ConnString);
            _tramsDbContext = new TramsDbContext(tramsContextBuilder.Options);

            mstrContextBuilder.UseSqlServer(ConnString);
            _mstrDbContext = new MstrContext(mstrContextBuilder.Options);
            MstrContextOptions = mstrContextBuilder.Options;

            _tramsDbContext.Database.EnsureCreated();
            _tramsDbContext.Database.Migrate();
            
            _legacyTransaction = _legacyTramsDbContext.Database.BeginTransaction();
            _tramsTransaction = _tramsDbContext.Database.BeginTransaction();
            _mstrTransaction = _mstrDbContext.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _legacyTransaction.Rollback();
            _legacyTransaction.Dispose();
            _tramsTransaction.Rollback();
            _tramsTransaction.Dispose();
            _mstrTransaction.Rollback();
            _mstrTransaction.Dispose();
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

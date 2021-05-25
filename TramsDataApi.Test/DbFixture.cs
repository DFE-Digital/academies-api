using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
            ConnString = $"Server=localhost,1433;Database=sip;User=sa;Password=StrongPassword905";

            var legacyContextBuilder = new DbContextOptionsBuilder<LegacyTramsDbContext>();
            var tramsContextBuilder = new DbContextOptionsBuilder<TramsDbContext>();

            legacyContextBuilder.UseSqlServer(ConnString);
            _legacyTramsDbContext = new LegacyTramsDbContext(legacyContextBuilder.Options);

            tramsContextBuilder.UseSqlServer(ConnString);
            _tramsDbContext = new TramsDbContext(tramsContextBuilder.Options);
            
            
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

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
        private readonly string _tramsDbName = $"Trams-{Guid.NewGuid()}";
        private readonly IDbContextTransaction _legacyTransaction;
        private readonly IDbContextTransaction _tramsTransaction;
        public readonly string ConnString;
        
        private bool _disposed;
        
        public DbFixture()
        {
            ConnString = $"Server=localhost,1433;Database={_tramsDbName};User=sa;Password=StrongPassword905";

            var legacyContextBuilder = new DbContextOptionsBuilder<LegacyTramsDbContext>();
            var tramsContextBuilder = new DbContextOptionsBuilder<TramsDbContext>();

            legacyContextBuilder.UseSqlServer(ConnString);
            _legacyTramsDbContext = new LegacyTramsDbContext(legacyContextBuilder.Options);

            tramsContextBuilder.UseSqlServer(ConnString);
            _tramsDbContext = new TramsDbContext(tramsContextBuilder.Options);
            

            _legacyTramsDbContext.Database.Migrate();
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
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // remove the temp db from the server once all tests are done
                    _legacyTramsDbContext.Database.EnsureDeleted();
                    _tramsDbContext.Database.EnsureDeleted();
                }

                _disposed = true;
            }
        }
    }
    
    [CollectionDefinition("Database")]
    public class DatabaseCollection : ICollectionFixture<DbFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}

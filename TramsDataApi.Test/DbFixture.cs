using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TramsDataApi.DatabaseModels;
using Xunit;

namespace TramsDataApi.Test
{
    public class DbFixture : IDisposable
    {
        private readonly TramsDbContext _dbContext;
        private readonly string _tramsDbName = $"Trams-{Guid.NewGuid()}";
        private readonly IDbContextTransaction _transaction;
        public readonly string ConnString;
        
        private bool _disposed;
        
        public DbFixture()
        {
            ConnString = $"Server=localhost,1433;Database={_tramsDbName};User=sa;Password=StrongPassword905";

            var builder = new DbContextOptionsBuilder<TramsDbContext>();

            builder.UseSqlServer(ConnString);
            _dbContext = new TramsDbContext(builder.Options);

            _dbContext.Database.Migrate();
            _transaction = _dbContext.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _transaction.Rollback();
            _transaction.Dispose();
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
                    //_dbContext.Database.EnsureDeleted();
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

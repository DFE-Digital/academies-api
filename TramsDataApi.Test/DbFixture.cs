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
        public readonly DbContextOptions<MstrContext> MstrContextOptions;

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

            var mstrContextBuilder = new DbContextOptionsBuilder<MstrContext>();
            mstrContextBuilder.UseSqlServer(ConnString);
            MstrContextOptions = mstrContextBuilder.Options;
            var mstrDbContext = new MstrContext(MstrContextOptions);

            tramsDbContext.Database.EnsureCreated();
            tramsDbContext.Database.Migrate();

            ClearDatabase(mstrDbContext);
            SeedDatabase(mstrDbContext);
        }

        private static void ClearDatabase(MstrContext context)
        {
            context.TrustTypes.RemoveRange(context.TrustTypes);
            context.Trusts.RemoveRange(context.Trusts);
            context.LocalAuthorities.RemoveRange(context.LocalAuthorities);
            context.Establishments.RemoveRange(context.Establishments);
            context.SaveChanges();
        }

        private static void SeedDatabase(MstrContext context)
        {
            SeedTrustTypes(context);
            SeedLocalAuthorities(context);
        }

        private static void SeedTrustTypes(MstrContext context)
        {
            context.TrustTypes.Add(new TrustType() { SK = 30, Code = "06", Name = "Multi-academy trust" });
            context.TrustTypes.Add(new TrustType() { SK = 32, Code = "10", Name = "Single-academy trust" });
            context.SaveChanges();
        }

        private static void SeedLocalAuthorities(MstrContext context)
        {
            context.LocalAuthorities.Add(new LocalAuthority() { SK = 1, Code = "202", Name = "Barnsley" });
            context.LocalAuthorities.Add(new LocalAuthority() { SK = 2, Code = "203", Name = "Birmingham" });
            context.LocalAuthorities.Add(new LocalAuthority() { SK = 3, Code = "204", Name = "Bradford" });
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

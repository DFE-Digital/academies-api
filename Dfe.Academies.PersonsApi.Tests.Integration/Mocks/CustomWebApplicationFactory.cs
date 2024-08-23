using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Domain.Constituencies;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using System.Drawing;

namespace Dfe.Academies.PersonsApi.Tests.Integration.Mocks
{
    public class CustomWebApplicationFactory<TProgram, TDbContext>
      : WebApplicationFactory<TProgram> where TProgram : class where TDbContext : DbContext
    {
        private SqliteConnection? _connection;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContextDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<TDbContext>));
                services.Remove(dbContextDescriptor!);

                var dbConnectionDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbConnection));
                services.Remove(dbConnectionDescriptor!);

                services.AddSingleton<DbConnection>(container =>
                {
                    if (_connection == null)
                    {
                        _connection = new SqliteConnection("DataSource=:memory:");
                        _connection.Open();
                    }

                    return _connection;
                });

                services.AddDbContext<TDbContext>((container, options) =>
                {
                    var connection = container.GetRequiredService<DbConnection>();
                    options.UseSqlite(connection);
                });

                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<TDbContext>();
                    db.Database.EnsureCreated();

                    SeedTestData(db);
                }
            });

            builder.UseEnvironment("Development");
        }

        public TDbContext GetDbContext()
        {
            var scopeFactory = Services.GetRequiredService<IServiceScopeFactory>();
            var scope = scopeFactory.CreateScope();
            return scope.ServiceProvider.GetRequiredService<TDbContext>();
        }

        private static void SeedTestData(TDbContext context)
        {
            if (context is MstrContext mstrContext)
            {

                    // Populate Trust
                    var trust1 = new Trust { SK = 1, Name = "Trust A", TrustTypeId = mstrContext.TrustTypes.FirstOrDefault().SK, GroupUID = "G1", Modified = DateTime.UtcNow, ModifiedBy = "System" };
                    var trust2 = new Trust { SK = 2, Name = "Trust B", TrustTypeId = mstrContext.TrustTypes.FirstOrDefault().SK, GroupUID = "G2", Modified = DateTime.UtcNow, ModifiedBy = "System" };
                    mstrContext.Trusts.AddRange(trust1, trust2);

                    // Populate Establishment
                    var establishment1 = new Establishment
                    {
                        SK = 1,
                        EstablishmentName = "School A",
                        LocalAuthorityId = mstrContext.LocalAuthorities.FirstOrDefault().SK,
                        EstablishmentTypeId = mstrContext.EstablishmentTypes.FirstOrDefault().SK,
                        Latitude = 54.9784,
                        Longitude = -1.6174,
                        MainPhone = "01234567890",
                        Email = "schoolA@example.com",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = "System"
                    };
                    var establishment2 = new Establishment
                    {
                        SK = 2,
                        EstablishmentName = "School B",
                        LocalAuthorityId = mstrContext.LocalAuthorities.FirstOrDefault().SK,
                        EstablishmentTypeId = mstrContext.EstablishmentTypes.FirstOrDefault().SK,
                        Latitude = 50.3763,
                        Longitude = -4.1427,
                        MainPhone = "09876543210",
                        Email = "schoolB@example.com",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = "System"
                    };
                    mstrContext.Establishments.AddRange(establishment1, establishment2);

                    // Populate EducationEstablishmentTrust
                    var educationEstablishmentTrust1 = new EducationEstablishmentTrust
                    {
                        SK = 1,
                        EducationEstablishmentId = (int)establishment1.SK,
                        TrustId = (int)trust1.SK,
                    };
                    var educationEstablishmentTrust2 = new EducationEstablishmentTrust
                    {
                        SK = 2,
                        EducationEstablishmentId = (int)establishment2.SK,
                        TrustId = (int)trust2.SK,

                    };
                    mstrContext.EducationEstablishmentTrusts.AddRange(educationEstablishmentTrust1, educationEstablishmentTrust2);

                    // Populate GovernanceRoleType
                    var governanceRoleType1 = new GovernanceRoleType { SK = 1, Name = "Chair of Governors", Modified = DateTime.UtcNow, ModifiedBy = "System" };
                    var governanceRoleType2 = new GovernanceRoleType { SK = 2, Name = "Vice Chair of Governors", Modified = DateTime.UtcNow, ModifiedBy = "System" };
                    mstrContext.GovernanceRoleTypes.AddRange(governanceRoleType1, governanceRoleType2);

                    // Populate EducationEstablishmentGovernance
                    var governance1 = new EducationEstablishmentGovernance
                    {
                        SK = 1,
                        EducationEstablishmentId = establishment1.SK,
                        GovernanceRoleTypeId = governanceRoleType1.SK,
                        GID = "GID1",
                        Title = "Mr.",
                        Forename1 = "John",
                        Surname = "Doe",
                        Email = "johndoe@example.com",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = "System"
                    };
                    var governance3 = new EducationEstablishmentGovernance
                    {
                        SK = 3,
                        EducationEstablishmentId = establishment1.SK,
                        GovernanceRoleTypeId = governanceRoleType2.SK,
                        GID = "GID2",
                        Title = "Ms.",
                        Forename1 = "Anna",
                        Surname = "Smith",
                        Email = "annasmith@example.com",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = "System"
                    };
                mstrContext.EducationEstablishmentGovernances.AddRange(governance1, governance3);

                    // Save changes
                    mstrContext.SaveChanges();
            }

            if (context is MopContext mopContext)
            {
                mopContext.MemberContactDetails.Add(new MemberContactDetails
                {
                    MemberID = 1,
                    Email = "test1@example.com",
                    TypeId = 1
                });
                mopContext.MemberContactDetails.Add(new MemberContactDetails
                {
                    MemberID = 2,
                    Email = "test2@example.com",
                    TypeId = 2
                });

                mopContext.Constituencies.Add(new Constituency
                {
                    ConstituencyId = 1,
                    ConstituencyName = "Test Constituency 1",
                    NameList = "Wood, John",
                    NameDisplayAs = "John Wood",
                    NameFullTitle = "John Wood MP",
                    LastRefresh = DateTime.UtcNow,
                    MemberID = 1
                });
                mopContext.Constituencies.Add(new Constituency
                {
                    ConstituencyId = 2,
                    ConstituencyName = "Test Constituency 2",
                    NameList = "Wood, Joe",
                    NameDisplayAs = "Joe Wood",
                    NameFullTitle = "Joe Wood MP",
                    LastRefresh = DateTime.UtcNow,
                    MemberID = 2
                });

                mopContext.SaveChanges();
            }
        }

        protected override void ConfigureClient(HttpClient client)
        {
            client.DefaultRequestHeaders.Add("ApiKey", "app-key");

            base.ConfigureClient(client);
        }
    }
}

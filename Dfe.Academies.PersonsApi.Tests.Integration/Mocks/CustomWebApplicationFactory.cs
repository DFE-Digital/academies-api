using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Domain.Persons;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

namespace Dfe.Academies.PersonsApi.Tests.Integration.Mocks
{
    public class CustomWebApplicationFactory<TProgram>
        : WebApplicationFactory<TProgram> where TProgram : class
    {
        private SqliteConnection _connection;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContextDescriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<MopContext>));

                services.Remove(dbContextDescriptor!);

                var dbConnectionDescriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbConnection));

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

                services.AddDbContext<MopContext>((container, options) =>
                {
                    var connection = container.GetRequiredService<DbConnection>();
                    options.UseSqlite(connection);
                });

                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<MopContext>();

                    db.Database.EnsureCreated();

                    SeedTestData(db);
                }
            });

            builder.UseEnvironment("Development");
        }

        public MopContext GetDbContext()
        {
            var scopeFactory = Services.GetRequiredService<IServiceScopeFactory>();
            var scope = scopeFactory.CreateScope();
            return scope.ServiceProvider.GetRequiredService<MopContext>();
        }

        private void SeedTestData(MopContext context)
        {
            context.MemberContactDetails.Add(new MemberContactDetails
            {
                MemberID = 1,
                Email = "test1@example.com",
                TypeId = 1
            });
            context.MemberContactDetails.Add(new MemberContactDetails
            {
                MemberID = 2,
                Email = "test2@example.com",
                TypeId = 2
            });

            context.Constituencies.Add(new Constituency
            {
                ConstituencyId = 1,
                ConstituencyName = "Test Constituency 1",
                NameList = "Wood, John",
                NameDisplayAs = "John Wood",
                NameFullTitle = "John Wood MP",
                LastRefresh = DateTime.UtcNow,
                MemberID = 1
            });
            context.Constituencies.Add(new Constituency
            {
                ConstituencyId = 2,
                ConstituencyName = "Test Constituency 2",
                NameList = "Wood, Joe",
                NameDisplayAs = "Joe Wood",
                NameFullTitle = "Joe Wood MP",
                LastRefresh = DateTime.UtcNow,
                MemberID= 2
            });

            context.SaveChanges();
        }

        protected override void ConfigureClient(HttpClient client)
        {
            client.DefaultRequestHeaders.Add("ApiKey", "app-key");

            base.ConfigureClient(client);
        }
    }
}

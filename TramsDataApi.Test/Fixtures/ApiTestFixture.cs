using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Mime;
using Xunit;

namespace TramsDataApi.Test.Fixtures
{
    public class ApiTestFixture : IDisposable
    {
        private readonly WebApplicationFactory<Startup> _application;

        public HttpClient Client { get; init; }

        private DbContextOptions<MstrContext> _dbContextOptions { get; init; }

        private static readonly object _lock = new();
        private static bool _isInitialised = false;

        private const string ConnectionStringKey = "ConnectionStrings:DefaultConnection";

        public ApiTestFixture()
        {
            lock (_lock)
            {
                if (!_isInitialised)
                {
                    string connectionString = null;

                    _application = new WebApplicationFactory<Startup>()
                        .WithWebHostBuilder(builder =>
                        {
                            var configPath = Path.Combine(Directory.GetCurrentDirectory(), "integration_settings.json");

                            builder.ConfigureAppConfiguration((context, config) =>
                            {
                                config.AddJsonFile(configPath)
                                    .AddEnvironmentVariables();

                                connectionString = BuildDatabaseConnectionString(config);

                                config.AddInMemoryCollection(new Dictionary<string, string>
                                {
                                    [ConnectionStringKey] = connectionString
                                });
                            });
                        });

                    Client = CreateHttpClient();

                    _dbContextOptions = new DbContextOptionsBuilder<MstrContext>()
                        .UseSqlServer(connectionString)
                        .Options;

                    using var context = GetMstrContext();
                    context.Database.EnsureDeleted();
                    context.Database.Migrate();
                    _isInitialised = true;
                }
            }
        }

        public void Dispose()
        {
            _application.Dispose();
            Client.Dispose();
        }

        public MstrContext GetMstrContext() => new MstrContext(_dbContextOptions);

        private HttpClient CreateHttpClient()
        {
            var client = _application.CreateClient();
            client.DefaultRequestHeaders.Add("ApiKey", "testing-api-key");
            client.DefaultRequestHeaders.Add("ContentType", MediaTypeNames.Application.Json);

            client.BaseAddress = new Uri("https://trams-api.com");

            return client;
        }

        private static string BuildDatabaseConnectionString(IConfigurationBuilder config)
        {
            var currentConfig = config.Build();
            var connection = currentConfig[ConnectionStringKey];
            var sqlBuilder = new SqlConnectionStringBuilder(connection);
            sqlBuilder.InitialCatalog = "ApiTests";

            var result = sqlBuilder.ToString();

            return result;
        }
    }

    [CollectionDefinition(ApiTestCollectionName, DisableParallelization = true)]
    public class ApiTestCollection : ICollectionFixture<ApiTestFixture>
    {
        public const string ApiTestCollectionName = "ApiTestCollection";

        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}

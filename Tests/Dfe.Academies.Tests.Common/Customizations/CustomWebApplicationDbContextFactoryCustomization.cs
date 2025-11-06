using AutoFixture;
using Dfe.Academies.Infrastructure;
using Dfe.Academies.Tests.Common.Seeders;
using Dfe.AcademiesApi.Client;
using Dfe.AcademiesApi.Client.Contracts;
using Dfe.TramsDataApi.Client.Extensions;
using GovUK.Dfe.CoreLibs.Testing.Mocks.Authentication;
using GovUK.Dfe.CoreLibs.Testing.Mocks.WebApplicationFactory;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Security.Claims;
using TramsDataApi.DatabaseModels;

namespace Dfe.Academies.Tests.Common.Customizations
{
    public class CustomWebApplicationDbContextFactoryCustomization<T> : ICustomization where T : class
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<CustomWebApplicationDbContextFactory<T>>(composer => composer.FromFactory(() =>
            {

                var factory = new CustomWebApplicationDbContextFactory<T>()
                {
                    SeedData = new Dictionary<Type, Action<DbContext>>
                    {
                        { typeof(MstrContext), context => MstrContextSeeder.Seed((MstrContext)context) },
                        { typeof(MisMstrContext), context => MisMstrContextSeeder.Seed((MisMstrContext)context) },
                        { typeof(LegacyTramsDbContext), context => LegacyTramsDbContextSeeder.Seed((LegacyTramsDbContext)context) }
                    },
                    ExternalServicesConfiguration = services =>
                    {
                        services.PostConfigure<AuthenticationOptions>(options =>
                        {
                            options.DefaultAuthenticateScheme = "TestScheme";
                            options.DefaultChallengeScheme = "TestScheme";
                        });

                        services.AddAuthentication("TestScheme")
                            .AddScheme<AuthenticationSchemeOptions, MockJwtBearerHandler>("TestScheme", options => { });
                    },
                    ExternalHttpClientConfiguration = client =>
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "external-mock-token");
                        client.DefaultRequestHeaders.Add("apiKey", "app-key");
                    }
                };
                var client = factory.CreateClient();

                var config = new ConfigurationBuilder()
                    .AddInMemoryCollection(new Dictionary<string, string?>
                    {
                        { "PersonsApiClient:BaseUrl", client.BaseAddress!.ToString() },
                        { "AcademiesApiClient:BaseUrl", client.BaseAddress!.ToString() }
                    })
                    .Build();

                var services = new ServiceCollection();
                services.AddSingleton<IConfiguration>(config);
                services.AddAcademiesApiClient<IEstablishmentsV1Client, EstablishmentsV1Client>(config, client);
                services.AddAcademiesApiClient<IEstablishmentsV4Client, EstablishmentsV4Client>(config, client);
                services.AddAcademiesApiClient<IEstablishmentsV5Client, EstablishmentsV5Client>(config, client);
                services.AddAcademiesApiClient<ITrustsV1Client, TrustsV1Client>(config, client);
                services.AddAcademiesApiClient<ITrustsV4Client, TrustsV4Client>(config, client);

                services.AddDbContext<LegacyTramsDbContext>(options =>
                    options.UseSqlServer("DataSource=:memory:"));
                var serviceProvider = services.BuildServiceProvider();

                fixture.Inject(factory);
                fixture.Inject(serviceProvider);
                fixture.Inject(client);
                fixture.Inject(serviceProvider.GetRequiredService<IEstablishmentsV1Client>());
                fixture.Inject(serviceProvider.GetRequiredService<IEstablishmentsV4Client>());
                fixture.Inject(serviceProvider.GetRequiredService<IEstablishmentsV5Client>());
                fixture.Inject(serviceProvider.GetRequiredService<ITrustsV1Client>());
                fixture.Inject(serviceProvider.GetRequiredService<ITrustsV4Client>());

                fixture.Inject(new List<Claim>());

                return factory;
            }));
        }
    }
}

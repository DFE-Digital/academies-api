﻿using AutoFixture;
using Dfe.Academies.Infrastructure;
using Dfe.Academies.Tests.Common.Seeders;
using Dfe.PersonsApi.Client;
using Dfe.PersonsApi.Client.Contracts;
using Dfe.PersonsApi.Client.Extensions;
using DfE.CoreLibs.Testing.Mocks.Authentication;
using DfE.CoreLibs.Testing.Mocks.WebApplicationFactory;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Security.Claims;
using Dfe.TramsDataApi.Client.Extensions;
using PersonsApi;
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
                        { typeof(MopContext), context => MopContextSeeder.Seed((MopContext)context) },
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
                        { "TramsDataApiClient:BaseUrl", client.BaseAddress!.ToString() }
                    })
                    .Build();

                var services = new ServiceCollection();
                services.AddSingleton<IConfiguration>(config);
                services.AddPersonsApiClient<IConstituenciesClient, ConstituenciesClient>(config, client);
                services.AddPersonsApiClient<IEstablishmentsClient, EstablishmentsClient>(config, client);
                services.AddPersonsApiClient<ITrustsClient, TrustsClient>(config, client);
                services.AddTramsDataApiClient<TramsDataApi.Client.Contracts.IEstablishmentsClient, TramsDataApi.Client.EstablishmentsClient>(config, client);
                services.AddTramsDataApiClient<TramsDataApi.Client.Contracts.ITrustsClient, TramsDataApi.Client.TrustsClient>(config, client);
                
                services.AddDbContext<LegacyTramsDbContext>(options =>
                    options.UseSqlServer("DataSource=:memory:"));
                var serviceProvider = services.BuildServiceProvider();

                fixture.Inject(factory);
                fixture.Inject(serviceProvider);
                fixture.Inject(client);
                fixture.Inject(serviceProvider.GetRequiredService<IConstituenciesClient>());
                fixture.Inject(serviceProvider.GetRequiredService<IEstablishmentsClient>());
                fixture.Inject(serviceProvider.GetRequiredService<ITrustsClient>());
                fixture.Inject(serviceProvider.GetRequiredService<TramsDataApi.Client.Contracts.IEstablishmentsClient>());
                fixture.Inject(serviceProvider.GetRequiredService<TramsDataApi.Client.Contracts.ITrustsClient>());

                fixture.Inject(new List<Claim>());

                return factory;
            }));
        }
    }
}

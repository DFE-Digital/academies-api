using AutoFixture;
using Dfe.Academies.Testing.Common.Mocks;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Dfe.PersonsApi.Client;
using Dfe.PersonsApi.Client.Contracts;
using Dfe.PersonsApi.Client.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dfe.Academies.Testing.Common.Customizations
{
    public class WebAppFactoryCustomization<TProgram, TDbContext> : ICustomization
        where TProgram : class
        where TDbContext : DbContext
    {
        private readonly List<Claim> _testClaims;
        private CustomWebApplicationFactory<TProgram, TDbContext>? _factoryInstance;

        public WebAppFactoryCustomization(List<Claim> testClaims)
        {
            _testClaims = testClaims;
        }

        public void Customize(IFixture fixture)
        {
            fixture.Customize<CustomWebApplicationFactory<TProgram, TDbContext>>(composer => composer.FromFactory(() =>
            {
                if (_factoryInstance != null) return _factoryInstance;

                var factory = new CustomWebApplicationFactory<TProgram, TDbContext>
                {
                    TestClaims = _testClaims
                };

                var client = factory.CreateClient();

                var config = new ConfigurationBuilder()
                    .AddInMemoryCollection(new Dictionary<string, string?>
                    {
                        { "PersonsApiClient:BaseUrl", client.BaseAddress!.ToString() }
                    })
                    .Build();

                var services = new ServiceCollection();
                services.AddSingleton<IConfiguration>(config);
                services.AddPersonsApiClient<IConstituenciesClient, ConstituenciesClient>(config, client);
                services.AddPersonsApiClient<IEstablishmentsClient, EstablishmentsClient>(config, client);
                
                var serviceProvider = services.BuildServiceProvider();

                fixture.Inject(factory);
                fixture.Inject(serviceProvider);
                fixture.Inject(client);
                fixture.Inject(serviceProvider.GetRequiredService<IConstituenciesClient>());
                fixture.Inject(serviceProvider.GetRequiredService<IEstablishmentsClient>());

                return factory;
            }));

            fixture.Inject(_testClaims);
        }
    }
}

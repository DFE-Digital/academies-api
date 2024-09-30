using System.Security.Claims;
using AutoFixture;
using Dfe.Academies.Tests.Common.Mocks;
using Dfe.PersonsApi.Client;
using Dfe.PersonsApi.Client.Contracts;
using Dfe.PersonsApi.Client.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dfe.Academies.Tests.Common.Customizations
{
    public class CustomWebApplicationFactoryCustomization<TProgram> : ICustomization
        where TProgram : class {

        public void Customize(IFixture fixture)
        {
            fixture.Customize<CustomWebApplicationFactory<TProgram>>(composer => composer.FromFactory(() =>
            {

                var factory = new CustomWebApplicationFactory<TProgram>(); 

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
                fixture.Inject(new List<Claim>());

                return factory;
            }));

        }
    }
}

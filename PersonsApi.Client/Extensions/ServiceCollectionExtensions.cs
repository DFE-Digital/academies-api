using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonsApi.Client.Settings;
using System.Diagnostics.CodeAnalysis;

namespace PersonsApi.Client.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersonsApiClient<TClientInterface, TClientImplementation>(this IServiceCollection services, IConfiguration configuration)
            where TClientInterface : class
            where TClientImplementation : class, TClientInterface
        {
            var apiSettings = new PersonsApiClientSettings();
            configuration.GetSection("PersonsApiClient").Bind(apiSettings);

            services.AddHttpClient<TClientInterface, TClientImplementation>((httpClient, serviceProvider) =>
            {
                httpClient.BaseAddress = new Uri(apiSettings.BaseUrl!);
                httpClient.DefaultRequestHeaders.Add("ApiKey", apiSettings.ApiKey);

                return ActivatorUtilities.CreateInstance<TClientImplementation>(serviceProvider, httpClient, apiSettings.BaseUrl!);
            });

            return services;
        }
    }

}

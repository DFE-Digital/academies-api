using Dfe.PersonsApi.Client.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Dfe.PersonsApi.Client.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersonsApiClient<TClientInterface, TClientImplementation>(
            this IServiceCollection services,
            IConfiguration configuration,
            HttpClient? existingHttpClient = null)
            where TClientInterface : class
            where TClientImplementation : class, TClientInterface
        {
            var apiSettings = new PersonsApiClientSettings();
            configuration.GetSection("PersonsApiClient").Bind(apiSettings);

            if (existingHttpClient != null)
            {
                // Use the provided HttpClient
                services.AddSingleton(existingHttpClient);
                services.AddTransient<TClientInterface, TClientImplementation>(serviceProvider =>
                {
                    return ActivatorUtilities.CreateInstance<TClientImplementation>(
                        serviceProvider, existingHttpClient, apiSettings.BaseUrl!);
                });
            }
            else
            {
                // Default logic if HttpClient is not provided
                services.AddHttpClient<TClientInterface, TClientImplementation>((httpClient, serviceProvider) =>
                {
                    httpClient.BaseAddress = new Uri(apiSettings.BaseUrl!);
                    httpClient.DefaultRequestHeaders.Add("ApiKey", apiSettings.ApiKey);

                    return ActivatorUtilities.CreateInstance<TClientImplementation>(
                        serviceProvider, httpClient, apiSettings.BaseUrl!);
                });
            }

            return services;
        }
    }
}

using System.Diagnostics.CodeAnalysis;
using Dfe.AcademiesApi.Client.Security;
using Dfe.AcademiesApi.Client.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dfe.TramsDataApi.Client.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAcademiesApiClient<TClientInterface, TClientImplementation>(
            this IServiceCollection services,
            IConfiguration configuration,
            HttpClient? existingHttpClient = null)
            where TClientInterface : class
            where TClientImplementation : class, TClientInterface
        {
            var apiSettings = new AcademiesApiClientSettings();
            configuration.GetSection("AcademiesApiClient").Bind(apiSettings);

            services.AddSingleton(apiSettings);

            if (existingHttpClient != null)
            {
                services.AddSingleton(existingHttpClient);
                services.AddTransient<TClientInterface, TClientImplementation>(serviceProvider =>
                {
                    return ActivatorUtilities.CreateInstance<TClientImplementation>(
                        serviceProvider, existingHttpClient, apiSettings.BaseUrl!);
                });
            }
            else
            {
                services.AddHttpClient<TClientInterface, TClientImplementation>((httpClient, serviceProvider) =>
                {
                    httpClient.BaseAddress = new Uri(apiSettings.BaseUrl!);

                    return ActivatorUtilities.CreateInstance<TClientImplementation>(
                        serviceProvider, httpClient, apiSettings.BaseUrl!);
                })
                .AddHttpMessageHandler(serviceProvider =>
                {
                    var apiSettings = serviceProvider.GetRequiredService<AcademiesApiClientSettings>();
                    return new ApiKeyHandler(apiSettings);
                });
            }
            return services;
        }
    }
}

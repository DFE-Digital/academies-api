using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Dfe.Academies.DataLakePoc;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds Databricks SQL query client and configured HttpClient to the service collection.
    /// Use either <see cref="DatabricksSqlOptions.AccessToken"/> (static token) or
    /// <see cref="DatabricksSqlOptions.AzureAdTenantId"/> + <see cref="DatabricksSqlOptions.AzureAdClientId"/> +
    /// <see cref="DatabricksSqlOptions.AzureAdClientSecret"/> (service principal) for authentication.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configureOptions">Optional action to configure DatabricksSqlOptions (e.g. from configuration).</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddDatabricksSqlQueryClient(
        this IServiceCollection services,
        Action<DatabricksSqlOptions>? configureOptions = null)
    {
        if (configureOptions != null)
            services.Configure(configureOptions);

        services.AddHttpClient<DatabricksSqlQueryClient>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<DatabricksSqlOptions>>().Value;
            var baseUrl = options.WorkspaceUrl.TrimEnd('/');
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        })
        .AddHttpMessageHandler(sp =>
        {
            var options = sp.GetRequiredService<IOptions<DatabricksSqlOptions>>().Value;
            IDatabricksTokenProvider? tokenProvider = options.UseServicePrincipal
                ? sp.GetService<IDatabricksTokenProvider>()
                : null;
            return new DatabricksAuthHandler(sp.GetRequiredService<IOptions<DatabricksSqlOptions>>(), tokenProvider);
        });

        return services;
    }

    /// <summary>
    /// Registers Azure AD service principal token provider and adds the Databricks SQL query client.
    /// Call this when using service principal auth; options should include AzureAdTenantId, AzureAdClientId, AzureAdClientSecret.
    /// </summary>
    public static IServiceCollection AddDatabricksSqlQueryClientWithServicePrincipal(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<DatabricksSqlOptions>(
            configuration.GetSection(DatabricksSqlOptions.SectionName));
        services.TryAddSingleton<IDatabricksTokenProvider>(sp => new AzureAdDatabricksTokenProvider(
            sp.GetRequiredService<IOptions<DatabricksSqlOptions>>(),
            sp.GetRequiredService<IOptions<DatabricksOdbcOptions>>()));
        return AddDatabricksSqlQueryClient(services, (Action<DatabricksSqlOptions>?)null);
    }

    /// <summary>
    /// Adds Databricks SQL query client bound to configuration section "DatabricksSql".
    /// Uses static <see cref="DatabricksSqlOptions.AccessToken"/> if set; if instead
    /// AzureAdTenantId, AzureAdClientId, and AzureAdClientSecret are set, call
    /// <see cref="AddDatabricksSqlQueryClientWithServicePrincipal"/> so the token provider is registered.
    /// </summary>
    public static IServiceCollection AddDatabricksSqlQueryClient(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<DatabricksSqlOptions>(
            configuration.GetSection(DatabricksSqlOptions.SectionName));

        // If config has service principal settings, register the token provider so the handler can use it.
        var options = new DatabricksSqlOptions();
        configuration.GetSection(DatabricksSqlOptions.SectionName).Bind(options);
        if (options.UseServicePrincipal)
        {
            services.TryAddSingleton<IDatabricksTokenProvider>(sp => new AzureAdDatabricksTokenProvider(
                sp.GetRequiredService<IOptions<DatabricksSqlOptions>>(),
                sp.GetRequiredService<IOptions<DatabricksOdbcOptions>>()));
        }

        return AddDatabricksSqlQueryClient(services, (Action<DatabricksSqlOptions>?)null);
    }

    /// <summary>
    /// Registers <see cref="DatabricksOdbcQueryClient"/> for Databricks SQL via the ODBC driver (Simba).
    /// Install the Databricks ODBC driver on the machine; see <see cref="DatabricksOdbcOptions"/>.
    /// When <see cref="DatabricksOdbcOptions.UseAzureAdTokenProvider"/> or ODBC Entra credentials
    /// (<see cref="DatabricksOdbcOptions.UseOdbcServicePrincipal"/>) are set, registers
    /// <see cref="IDatabricksTokenProvider"/> via <see cref="TryAddSingleton"/> so ODBC can use the same
    /// service principal flow as the REST client.
    /// </summary>
    public static IServiceCollection AddDatabricksOdbcQueryClient(
        this IServiceCollection services,
        Action<DatabricksOdbcOptions>? configureOptions = null)
    {
        if (configureOptions != null)
            services.Configure(configureOptions);

        services.AddSingleton(sp =>
        {
            var odbcOptions = sp.GetRequiredService<IOptions<DatabricksOdbcOptions>>().Value;
            IDatabricksTokenProvider? tokenProvider = odbcOptions.UseEntraTokenForOdbc
                ? sp.GetService<IDatabricksTokenProvider>()
                : null;
            return new DatabricksOdbcQueryClient(
                sp.GetRequiredService<IOptions<DatabricksOdbcOptions>>(),
                tokenProvider);
        });

        return services;
    }

    /// <summary>
    /// Binds <see cref="DatabricksOdbcOptions"/> from configuration section "DatabricksOdbc" and registers the ODBC client.
    /// </summary>
    public static IServiceCollection AddDatabricksOdbcQueryClient(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<DatabricksOdbcOptions>(
            configuration.GetSection(DatabricksOdbcOptions.SectionName));

        var odbcProbe = new DatabricksOdbcOptions();
        configuration.GetSection(DatabricksOdbcOptions.SectionName).Bind(odbcProbe);
        if (odbcProbe.UseOdbcServicePrincipal)
        {
            services.TryAddSingleton<IDatabricksTokenProvider>(sp => new AzureAdDatabricksTokenProvider(
                sp.GetRequiredService<IOptions<DatabricksSqlOptions>>(),
                sp.GetRequiredService<IOptions<DatabricksOdbcOptions>>()));
        }

        return AddDatabricksOdbcQueryClient(services, (Action<DatabricksOdbcOptions>?)null);
    }
}

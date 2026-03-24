using System.Data.Odbc;

namespace Dfe.Academies.DataLakePoc;

/// <summary>
/// Builds DSN-less ODBC connection strings for the Databricks ODBC driver.
/// </summary>
/// <remarks>
/// See Databricks docs: DSN-less connection strings, ThriftTransport=2, SSL=1.
/// </remarks>
public static class DatabricksOdbcConnectionStringBuilder
{
    /// <summary>
    /// Builds a connection string from options, unless <see cref="DatabricksOdbcOptions.RawConnectionString"/> is set.
    /// </summary>
    /// <param name="authMechanismOverride">When set, overrides <see cref="DatabricksOdbcOptions.AuthMechanism"/> (e.g. force Entra layout when using a token provider).</param>
    public static string Build(
        DatabricksOdbcOptions options,
        string? accessTokenOverride = null,
        DatabricksOdbcAuthMechanism? authMechanismOverride = null)
    {
        ArgumentNullException.ThrowIfNull(options);

        if (!string.IsNullOrWhiteSpace(options.RawConnectionString))
            return options.RawConnectionString.Trim();

        var host = ResolveHost(options);
        if (string.IsNullOrWhiteSpace(host))
            throw new InvalidOperationException(
                "Databricks ODBC: Host or WorkspaceUrl must be configured.");

        var httpPath = ResolveHttpPath(options);
        if (string.IsNullOrWhiteSpace(httpPath))
            throw new InvalidOperationException(
                "Databricks ODBC: HttpPath or WarehouseId must be configured.");

        var token = accessTokenOverride ?? options.AccessToken;
        if (string.IsNullOrWhiteSpace(token))
            throw new InvalidOperationException(
                "Databricks ODBC: AccessToken is required unless RawConnectionString is set or a token provider supplies the token.");

        var builder = new OdbcConnectionStringBuilder
        {
            Driver = options.Driver
        };

        var authMech = authMechanismOverride ?? options.AuthMechanism;

        // Databricks ODBC driver keywords (see Azure Databricks ODBC authentication / DSN-less docs)
        builder["Host"] = host;
        builder["Port"] = options.Port.ToString();
        builder["HTTPPath"] = NormalizeHttpPath(httpPath);
        builder["SSL"] = "1";
        builder["ThriftTransport"] = "2";

        if (authMech == DatabricksOdbcAuthMechanism.MicrosoftEntraOrOAuthAccessToken)
        {
            builder["AuthMech"] = "11";
            builder["Auth_Flow"] = "0";
            builder["Auth_AccessToken"] = token;
        }
        else
        {
            builder["AuthMech"] = ((int)authMech).ToString();
            builder["UID"] = "token";
            builder["PWD"] = token;
        }

        if (options.ConnectionTimeoutSeconds > 0)
            builder["ConnTimeout"] = options.ConnectionTimeoutSeconds.ToString();

        if (!string.IsNullOrWhiteSpace(options.Catalog))
            builder["Catalog"] = options.Catalog!;

        if (!string.IsNullOrWhiteSpace(options.Schema))
            builder["Schema"] = options.Schema!;

        var cs = builder.ConnectionString;
        if (!string.IsNullOrWhiteSpace(options.AdditionalProperties))
            cs = AppendAdditional(cs, options.AdditionalProperties);

        return cs;
    }

    private static string AppendAdditional(string connectionString, string additional)
    {
        var extra = additional.Trim().TrimStart(';').TrimEnd(';');
        if (string.IsNullOrEmpty(extra))
            return connectionString;
        return connectionString.EndsWith(";", StringComparison.Ordinal) ? connectionString + extra : connectionString + ";" + extra;
    }

    private static string ResolveHost(DatabricksOdbcOptions options)
    {
        if (!string.IsNullOrWhiteSpace(options.Host))
            return options.Host.Trim();

        if (string.IsNullOrWhiteSpace(options.WorkspaceUrl))
            return string.Empty;

        var url = options.WorkspaceUrl.Trim();
        if (!url.Contains("://", StringComparison.Ordinal))
            url = "https://" + url;

        return new Uri(url).Host;
    }

    private static string ResolveHttpPath(DatabricksOdbcOptions options)
    {
        if (!string.IsNullOrWhiteSpace(options.HttpPath))
            return options.HttpPath.Trim();

        if (!string.IsNullOrWhiteSpace(options.WarehouseId))
            return $"/sql/1.0/warehouses/{options.WarehouseId.Trim()}";

        return string.Empty;
    }

    /// <summary>
    /// Ensures HTTP path starts with / per Databricks ODBC driver expectations.
    /// </summary>
    private static string NormalizeHttpPath(string path)
    {
        path = path.Trim();
        return path.StartsWith("/", StringComparison.Ordinal) ? path : "/" + path;
    }
}

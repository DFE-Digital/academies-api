using System.Net.Http.Headers;
using Microsoft.Extensions.Options;

namespace Dfe.Academies.DataLakePoc;

/// <summary>
/// Sets the Authorization Bearer header on each request, using either a static token from options
/// or a token from <see cref="IDatabricksTokenProvider"/> when using service principal auth.
/// </summary>
internal sealed class DatabricksAuthHandler : DelegatingHandler
{
    private readonly IOptions<DatabricksSqlOptions> _options;
    private readonly IDatabricksTokenProvider? _tokenProvider;

    public DatabricksAuthHandler(
        IOptions<DatabricksSqlOptions> options,
        IDatabricksTokenProvider? tokenProvider = null)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));
        _tokenProvider = tokenProvider;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        string token;
        if (_tokenProvider != null)
            token = await _tokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false);
        else
            token = _options.Value.AccessToken ?? string.Empty;

        if (!string.IsNullOrEmpty(token))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }
}

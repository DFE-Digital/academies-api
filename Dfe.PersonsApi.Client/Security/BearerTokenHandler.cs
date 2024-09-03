using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;

namespace Dfe.PersonsApi.Client.Security
{
    [ExcludeFromCodeCoverage]
    public class BearerTokenHandler : DelegatingHandler
    {
        private readonly ITokenAcquisitionService _tokenAcquisitionService;

        public BearerTokenHandler(ITokenAcquisitionService tokenAcquisitionService)
        {
            _tokenAcquisitionService = tokenAcquisitionService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var token = await _tokenAcquisitionService.GetTokenAsync();

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}

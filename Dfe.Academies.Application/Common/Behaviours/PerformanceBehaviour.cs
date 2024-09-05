using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Dfe.Academies.Application.Common.Behaviours
{
    [ExcludeFromCodeCoverage]
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PerformanceBehaviour(
            ILogger<TRequest> logger,
            IHttpContextAccessor httpContextAccessor)
        {
            _timer = new Stopwatch();
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMilliseconds > 500)
            {
                var user = _httpContextAccessor.HttpContext?.User;

                var requestName = typeof(TRequest).Name;
                var identityName = user?.Identity?.Name;

                _logger.LogWarning("PersonsAPI Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@IdentityName} {@Request}",
                    requestName, elapsedMilliseconds, identityName, request);
            }

            return response;
        }
    }

}

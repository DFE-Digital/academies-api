using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace Dfe.Academies.Application.Common.Behaviours
{
    [ExcludeFromCodeCoverage]
    public class UnhandledExceptionBehaviour<TRequest, TResponse>(ILogger<TRequest> logger)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
#pragma warning disable S2139
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;

                logger.LogError(ex, "PersonsAPI Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);

                throw;
            }
#pragma warning restore S2139
        }
    }

}

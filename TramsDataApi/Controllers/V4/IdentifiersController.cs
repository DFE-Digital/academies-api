using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Dfe.Academies.Application.Trust;
using Dfe.Academies.Contracts.V4;
using Dfe.Academies.Contracts.V4.Trusts;
using Dfe.Academies.Domain.Trust;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Controllers.V4
{
    /// <summary>
    /// Handles operations related to Identifiers.
    /// </summary>
    [ApiController]
    [ApiVersion("4.0")]
    [Route("v{version:apiVersion}/")]
    [SwaggerTag("TrustIdentifiers Endpoints")]
    public class IdentifiersController : ControllerBase
    {
        private readonly ITrustQueries _trustQueries;
        private readonly ILogger<TrustsController> _logger;

        public IdentifiersController(ITrustQueries trustQueries, ILogger<TrustsController> logger)
        {
            _trustQueries = trustQueries;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves a Trust's other identifiers based on one of its identifiers. Currently supports UKPRN, UID and Trust Reference
        /// </summary>
        /// <param name="identifier">The identifier (UKPRN, UID or Trust Reference).</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A Trust or NotFound if not available.</returns>
        [HttpGet]
        [Route("identifier/{identifier}")]        
        [SwaggerOperation(Summary = "Retrieves a Trust's Identifiers based on one of its identifiers.", Description = "Returns a Trust identifiers found in the database.")]
        [SwaggerResponse(200, "Successfully found and returned the Trusts identifiers.")]
        [SwaggerResponse(404, "Trust with specified identifier not found.")]
        public async Task<ActionResult<TrustIdentifiers[]>> GetTrustIdentifiers(string identifier, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Attempting to get trust identifiers by identifier {identifier}");
            var trusts = await _trustQueries.GetTrustIdentifiers(identifier, cancellationToken).ConfigureAwait(false);
            
            if (trusts == null)
            {
                _logger.LogInformation($"No trust with identifier {identifier}");
                return NotFound();
            }
            
            _logger.LogInformation($"Returning trusts found by identifier {identifier}");
            _logger.LogDebug(JsonSerializer.Serialize(trusts));
            return Ok(trusts.ToArray());
        }
    }
}

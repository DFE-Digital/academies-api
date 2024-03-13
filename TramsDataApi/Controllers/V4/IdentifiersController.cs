using System;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Dfe.Academies.Application.Trust;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace TramsDataApi.Controllers.V4;

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
        var loggableIdentifier = Regex.Replace(identifier, "[^a-zA-Z0-9-]", "", RegexOptions.None, TimeSpan.FromSeconds(2));
        _logger.LogInformation("Attempting to get trust identifiers by identifier {identifier}", loggableIdentifier);
        var trusts = await _trustQueries.GetTrustIdentifiers(identifier, cancellationToken).ConfigureAwait(false);
            
        if (trusts.Count <= 0)
        {
            _logger.LogInformation("No trust with identifier {identifier}", loggableIdentifier);
            return NotFound();
        }
            
        _logger.LogInformation("Returning trusts found by identifier {identifier}", loggableIdentifier);
        _logger.LogDebug("{output}",JsonSerializer.Serialize(trusts));
        return Ok(trusts.ToArray());
    }
}
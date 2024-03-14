using System;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Dfe.Academies.Application.Establishment;
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
[SwaggerTag("Identifiers Endpoints")]
public class IdentifiersController : ControllerBase
{
    private readonly ITrustQueries _trustQueries;
    private readonly IEstablishmentQueries _establishmentQueries;
    private readonly ILogger<TrustsController> _logger;

    public IdentifiersController(ITrustQueries trustQueries, ILogger<TrustsController> logger, IEstablishmentQueries establishmentQueries)
    {
        _trustQueries = trustQueries;
        _logger = logger;
        _establishmentQueries = establishmentQueries;
    }

    /// <summary>
    /// Retrieves an object's other identifiers based on one of its identifiers. Currently supports UKPRN, UID and Trust Reference for trusts and UKPRN, URN and LAESTAB for establishments
    /// </summary>
    /// <param name="identifier">The identifier (UKPRN, UID, URN, LAESTAB or Trust Reference).</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A list of matching objects or empty lists if not found.</returns>
    [HttpGet]
    [Route("identifier/{identifier}")]        
    [SwaggerOperation(Summary = "Retrieves an object's Identifiers based on one of its identifiers.", Description = "Returns an objects identifiers found in the database.")]
    [SwaggerResponse(200, "Successfully found and returned the objects identifiers.")]
    public async Task<ActionResult<Identifiers>> GetIdentifiers(string identifier, CancellationToken cancellationToken)
    {
        var loggableIdentifier = Regex.Replace(identifier, "[^a-zA-Z0-9-]", "", RegexOptions.None, TimeSpan.FromSeconds(2));
        _logger.LogInformation("Attempting to get object identifiers by identifier {identifier}", loggableIdentifier);
        var trusts = await _trustQueries.GetTrustIdentifiers(identifier, cancellationToken).ConfigureAwait(false);
        var establishments = await _establishmentQueries.GetEstablishmentIdentifiers(identifier, cancellationToken).ConfigureAwait(false);
        var results = new Identifiers(trusts.ToArray(), establishments.ToArray());
        _logger.LogInformation("Returning objects found by identifier {identifier}", loggableIdentifier);
        _logger.LogDebug("{output}",JsonSerializer.Serialize(results));
        return Ok(results);
    }
}

public record Identifiers(TrustIdentifiers[] Trusts, EstablishmentIdentifiers[] Establishments);
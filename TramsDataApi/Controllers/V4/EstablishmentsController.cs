using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Dfe.Academies.Application.Queries.Establishment;
using Dfe.Academies.Contracts.Establishments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Controllers.V4
{
    /// <summary>
    /// Handles operations related to Establishments.
    /// </summary>
    [ApiController]
    [ApiVersion("4.0")]
    [Route("v{version:apiVersion}/")]
    [SwaggerTag("Establishment Endpoints")]
    public class EstablishmentsController : ControllerBase
    {
        private readonly IEstablishmentQueries _establishmentQueries;
        private readonly ILogger<EstablishmentsController> _logger;

        public EstablishmentsController(IEstablishmentQueries establishmentQueries, ILogger<EstablishmentsController> logger)
        {
            _establishmentQueries = establishmentQueries;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves a Establishment by its UK Provider Reference Number (UKPRN).
        /// </summary>
        /// <param name="ukprn">The UK Provider Reference Number (UKPRN) identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A Establishment or NotFound if not available.</returns>
        [HttpGet]
        [Route("establishment/{ukprn}")]
        [SwaggerOperation(Summary = "Retrieve Establishment by UK Provider Reference Number (UKPRN)", Description = "Returns a Establishment identified by UK Provider Reference Number (UKPRN).")]
        [SwaggerResponse(200, "Successfully found and returned the Establishment.")]
        [SwaggerResponse(404, "Establishment with specified UK Provider Reference Number (UKPRN) not found.")]
        public async Task<ActionResult<EstablishmentDto>> GetEstablishmentByUkprn(string ukprn, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Attempting to get establishment by UK Provider Reference Number (UKPRN) {ukprn}");
            var establishment = await _establishmentQueries.GetByUkprn(ukprn, cancellationToken).ConfigureAwait(false);

            if (establishment == null)
            {
                _logger.LogInformation($"No establishment found for UK Provider Reference Number (UKPRN) {ukprn}");
                return NotFound();
            }

            _logger.LogInformation($"Returning establishment found by UK Provider Reference Number (UKPRN) {ukprn}");
            _logger.LogDebug(JsonSerializer.Serialize(establishment));
            return Ok(establishment);
        }

        /// <summary>
        /// Retrieves an establishment by its Unique Reference Number (URN).
        /// </summary>
        /// <param name="urn">The Unique Reference Number (URN) of the establishment.</param>
        /// <returns>An establishment or NotFound if not available.</returns>
        [HttpGet]
        [Route("establishment/urn/{urn}")]
        [SwaggerOperation(Summary = "Get Establishment by Unique Reference Number (URN)", Description = "Returns an establishment specified by Unique Reference Number (URN).")]
        [SwaggerResponse(200, "Successfully found and returned the establishment.")]
        [SwaggerResponse(404, "Establishment with specified Unique Reference Number (URN) not found.")]
        public async Task<ActionResult<EstablishmentDto>> GetEstablishmentByUrn(string urn, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Attempting to get establishment by Unique Reference Numbers (URN) {urn}");
            var establishment = await _establishmentQueries.GetByUrn(urn, cancellationToken).ConfigureAwait(false);

            if (establishment == null)
            {
                _logger.LogInformation($"No establishment found for Unique Reference Numbers (URN) {urn}");
                return NotFound();
            }

            _logger.LogInformation($"Returning establishment found by Unique Reference Numbers (URN) {urn}");
            _logger.LogDebug(JsonSerializer.Serialize(establishment));
            return Ok(establishment);
        }

        /// <summary>
        /// Searches for Establishments based on query parameters.
        /// </summary>
        /// <param name="name">Name of the establishment.</param>
        /// <param name="ukPrn">UK Provider Reference Number (UKPRN) identifier.</param>
        /// <param name="urn">Unique Reference Numbers (URN).</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of Establishments that meet the search criteria.</returns>
        [HttpGet]
        [Route("establishments")]
        [SwaggerOperation(Summary = "Search Establishments", Description = "Returns a list of Establishments based on search criteria.")]
        [SwaggerResponse(200, "Successfully executed the search and returned Establishments.")]
        public async Task<ActionResult<List<EstablishmentDto>>> SearchEstablishments(string name, string ukPrn, string urn, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Searching for establishments by name \"{name}\", UKPRN \"{prn}\", urn \"{number}\"}",
                name, ukPrn, urn);

            var (establishments, recordCount) = await _establishmentQueries
                .Search(name, ukPrn, urn, cancellationToken).ConfigureAwait(false);

            _logger.LogInformation(
                "Found {count} establishments for name \"{name}\", UKPRN \"{prn}\", urn \"{number}\"",
                recordCount, name, ukPrn, urn);

            _logger.LogDebug(JsonSerializer.Serialize(establishments));

            var response = new List<EstablishmentDto>(establishments);

            return Ok(response);
        }

        /// <summary>
        /// Retrieves a list of establishment Unique Reference Numbers (URNs) by region.
        /// </summary>
        /// <param name="regions">Array of regions.</param>
        /// <returns>List of establishment Unique Reference Numbers (URNs) or NotFound if none are available.</returns>
        [HttpGet]
        [Route("establishment/regions")]
        [SwaggerOperation(Summary = "Get Establishment Unique Reference Numbers (URNs) by Region", Description = "Returns a list of establishment Unique Reference Numbers (URNs) by specified regions.")]
        [SwaggerResponse(200, "Successfully found and returned the establishment Unique Reference Numbers (URNs).")]
        [SwaggerResponse(404, "No establishments found for specified regions.")]
        public async Task<ActionResult<IEnumerable<int>>> GetURNsByRegion(ICollection<string> regions,  CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Searching for establishment URNs by regions\"{regions}\"}",
                regions);

            var establishmentURNs = await _establishmentQueries
                .GetURNsByRegion(regions, cancellationToken).ConfigureAwait(false);          

            _logger.LogDebug(JsonSerializer.Serialize(establishmentURNs));

            var response = new List<int>(establishmentURNs);

            return Ok(response);
        }

        /// <summary>
        /// Retrieves a list of establishments by their Unique Reference Numbers (URNs).
        /// </summary>
        /// <param name="request">Contains Unique Reference Number (URNs) of the establishments.</param>
        /// <returns>List of establishments or NotFound if none are available.</returns>
        [HttpGet]
        [Route("establishments/bulk")]
        [SwaggerOperation(Summary = "Get Establishments by Unique Reference Number (URNs)", Description = "Returns a list of establishments specified by Unique Reference Numbers (URNs).")]
        [SwaggerResponse(200, "Successfully found and returned the establishments.")]
        [SwaggerResponse(404, "Establishments with specified Unique Reference Numbers (URNs) not found.")]
        public ActionResult<List<EstablishmentResponse>> GetByUrns([FromQuery] int[] request)
        {
            var commaSeparatedRequestUrns = string.Join(",", request);
            _logger.LogInformation($"Attemping to get establishments by Unique Reference Numbers (URNs): {commaSeparatedRequestUrns}");

            var establishments = _establishmentQueries.GetByUrns(request);         

            if (establishments == null)
            {
                _logger.LogInformation($"No establishment was found any of the requested Unique Reference Numbers (URNs): {commaSeparatedRequestUrns}");
                return NotFound();
            }

            _logger.LogInformation($"Returning Establishments for Unique Reference Numbers (URNs): {commaSeparatedRequestUrns}");
            _logger.LogDebug(JsonSerializer.Serialize(establishments));
            return Ok(establishments);
        }
    }
}
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Dfe.Academies.Application.Queries.Establishment;
using Dfe.Academies.Contracts.Establishments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
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
        public async Task<ActionResult<ApiResponseV2<EstablishmentDto>>> SearchEstablishments(string name, string ukPrn, string urn, CancellationToken cancellationToken)
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

            var response = new ApiResponseV2<List<EstablishmentDto>>(establishments);

            return Ok(response);
        }
    }
}
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers
{
    /// <summary>
    /// Manages establishment-related operations.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [SwaggerTag("Establishment Endpoints")]
    public class EstablishmentsController : ControllerBase
    {
        private readonly IGetEstablishmentByUkprn _getEstablishmentByUkprn;
        private readonly IGetEstablishmentURNsByRegion _getEstablishmentURNsByRegion;
        private readonly IUseCase<GetEstablishmentByUrnRequest, EstablishmentResponse> _getEstablishmentByUrn;
        private readonly IUseCase<SearchEstablishmentsRequest, IList<EstablishmentSummaryResponse>> _searchEstablishments;
        private readonly IGetEstablishments _getEstablishments;
        private readonly ILogger<EstablishmentsController> _logger;

        public EstablishmentsController(
            IGetEstablishmentByUkprn getEstablishmentByUkprn,
            IUseCase<GetEstablishmentByUrnRequest, EstablishmentResponse> getEstablishmentByUrn,
            IUseCase<SearchEstablishmentsRequest, IList<EstablishmentSummaryResponse>> searchEstablishments,
            IGetEstablishmentURNsByRegion getEstablishmentURNsByRegion,
            IGetEstablishments getEstablishments,
            ILogger<EstablishmentsController> logger)
        {
            _getEstablishmentByUkprn = getEstablishmentByUkprn;
            _getEstablishmentByUrn = getEstablishmentByUrn;
            _searchEstablishments = searchEstablishments;
            _getEstablishmentURNsByRegion = getEstablishmentURNsByRegion;
            _getEstablishments = getEstablishments;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves an establishment by its UK Provider Reference Number (UKPRN).
        /// </summary>
        /// <param name="ukprn">The UK Provider Reference Number (UKPRN) of the establishment.</param>
        /// <returns>An establishment or NotFound if not available.</returns>
        [HttpGet]
        [Route("establishment/{ukprn}")]
        [SwaggerOperation(Summary = "Get Establishment by UK Provider Reference Number (UKPRN)", Description = "Returns an establishment specified by UK Provider Reference Number (UKPRN).")]
        [SwaggerResponse(200, "Successfully found and returned the establishment.")]
        [SwaggerResponse(404, "Establishment with specified UK Provider Reference Number (UKPRN) not found.")]
        public ActionResult<EstablishmentResponse> GetByUkprn(string ukprn)
        {
            _logger.LogInformation($"Attempting to get Establishment by UK Provider Reference Number (UKPRN) {ukprn}");
            var establishment = _getEstablishmentByUkprn.Execute(ukprn);

            if (establishment == null)
            {
                _logger.LogInformation($"No Establishment found for UK Provider Reference Number (UKPRN) {ukprn}");
                return NotFound();
            }
            _logger.LogInformation($"Returning Establishment with UK Provider Reference Number (UKPRN) {ukprn}");
            _logger.LogDebug(JsonSerializer.Serialize<EstablishmentResponse>(establishment));
            return Ok(establishment);
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
        public ActionResult<IEnumerable<int>> GetURNsByRegion([FromQuery] string[] regions)
        {
            _logger.LogInformation($"Attempting to get Establishment Unique Reference Numbers (URNs) by Region {regions}");
            var establishment = _getEstablishmentURNsByRegion.Execute(regions);

            if (establishment == null)
            {
                _logger.LogInformation($"No Establishments found for Region {regions}");
                return NotFound();
            }
            _logger.LogInformation($"Returning Establishment Unique Reference Numbers (URNs) with Region {regions}");
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
        public ActionResult<EstablishmentResponse> GetByUrn(int urn)
        {
            var establishment = _getEstablishmentByUrn.Execute(new GetEstablishmentByUrnRequest { URN = urn });
            _logger.LogInformation($"Attempting to get Establishment by Unique Reference Number (URN) {urn}");

            if (establishment == null)
            {
                _logger.LogInformation($"No Establishment found for Unique Reference Number (URN) {urn}");
                return NotFound();
            }
            _logger.LogInformation($"Returning Establishment with Unique Reference Number (URN) {urn}");
            _logger.LogDebug(JsonSerializer.Serialize<EstablishmentResponse>(establishment));
            return Ok(establishment);
        }

        /// <summary>
        /// Searches for establishments based on a query.
        /// </summary>
        /// <param name="request">Search criteria.</param>
        /// <returns>List of establishments that meet the search criteria.</returns>
        [HttpGet]
        [Route("establishments")]
        [SwaggerOperation(Summary = "Search for Establishments", Description = "Returns a list of establishments based on search criteria.")]
        [SwaggerResponse(200, "Successfully executed the search and returned establishments.")]
        public ActionResult<List<EstablishmentSummaryResponse>> SearchEstablishments([FromQuery] SearchEstablishmentsRequest request)
        {
            _logger.LogInformation($"Searching for Establishments");
            var establishments = _searchEstablishments.Execute(request);
            _logger.LogDebug(JsonSerializer.Serialize<IList<EstablishmentSummaryResponse>>(establishments));
            return Ok(establishments);
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
        public ActionResult<List<EstablishmentResponse>> GetByUrns([FromQuery] GetEstablishmentsByUrnsRequest request)
        {
            var commaSeparatedRequestUrns = string.Join(",", request.Urns);
            _logger.LogInformation($"Attemping to get establishments by Unique Reference Numbers (URNs): {commaSeparatedRequestUrns}");

            var establishments = _getEstablishments.Execute(request);

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
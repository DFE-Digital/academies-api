using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    public class EstablishmentsController : ControllerBase
    {
        private readonly IGetEstablishmentURNsByRegion _getEstablishmentURNsByRegion;
        private readonly IUseCase<SearchEstablishmentsRequest, IList<EstablishmentSummaryResponse>> _searchEstablishments;
        private readonly IGetEstablishments _getEstablishments;
        private readonly ILogger<EstablishmentsController> _logger;

        public EstablishmentsController(
            IUseCase<SearchEstablishmentsRequest, IList<EstablishmentSummaryResponse>> searchEstablishments,
            IGetEstablishmentURNsByRegion getEstablishmentURNsByRegion,
            IGetEstablishments getEstablishments,
            ILogger<EstablishmentsController> logger)
        {
            _searchEstablishments = searchEstablishments;
            _getEstablishmentURNsByRegion = getEstablishmentURNsByRegion;
            _getEstablishments = getEstablishments;
            _logger = logger;
        }

        [HttpGet]
        [Route("establishment/{ukprn}")]
        public ActionResult<EstablishmentResponse> GetByUkprn(string ukprn)
        {
            _logger.LogInformation($"Attempting to get Establishment by UKPRN {ukprn}");
            var request = new GetEstablishmentsByUkprnsRequest { Ukprns = new string[] { ukprn } };
            var establishment = _getEstablishments.Execute(request)?.First();

            if (establishment == null)
            {
                _logger.LogInformation($"No Establishment found for UKPRN {ukprn}");
                return NotFound();
            }
            _logger.LogInformation($"Returning Establishment with UKPRN {ukprn}");
            _logger.LogDebug(JsonSerializer.Serialize(establishment));
            return Ok(establishment);
        }

        [HttpGet]
        [Route("establishment/regions")]
        public ActionResult<IEnumerable<int>> GetURNsByRegion([FromQuery] string[] regions)
        {
            _logger.LogInformation($"Attempting to get Establishment URNs by Region {regions}");
            var establishment = _getEstablishmentURNsByRegion.Execute(regions);

            if (establishment == null)
            {
                _logger.LogInformation($"No Establishments found for Region {regions}");
                return NotFound();
            }
            _logger.LogInformation($"Returning Establishment URNs with Region {regions}");
            _logger.LogDebug(JsonSerializer.Serialize(establishment));
            return Ok(establishment);
        }

        [HttpGet]
        [Route("establishment/urn/{urn}")]
        public ActionResult<EstablishmentResponse> GetByUrn(int urn)
        {
            var request = new GetEstablishmentsByUrnsRequest { Urns = new int[] { urn } };
            var establishment = _getEstablishments.Execute(request)?.First();
            _logger.LogInformation($"Attempting to get Establishment by URN {urn}");

            if (establishment == null)
            {
                _logger.LogInformation($"No Establishment found for URN {urn}");
                return NotFound();
            }
            _logger.LogInformation($"Returning Establishment with URN {urn}");
            _logger.LogDebug(JsonSerializer.Serialize<EstablishmentResponse>(establishment));
            return Ok(establishment);
        }

        [HttpGet]
        [Route("establishments")]
        public ActionResult<List<EstablishmentSummaryResponse>> SearchEstablishments([FromQuery] SearchEstablishmentsRequest request)
        {
            _logger.LogInformation($"Searching for Establishments");
            var establishments = _searchEstablishments.Execute(request);
            _logger.LogDebug(JsonSerializer.Serialize<IList<EstablishmentSummaryResponse>>(establishments));
            return Ok(establishments);
        }

        [HttpGet]
        [Route("establishments/bulk")]
        public ActionResult<List<EstablishmentResponse>> GetByUrns([FromQuery] GetEstablishmentsByUrnsRequest request)
        {
            var commaSeparatedRequestUrns = string.Join(",", request.Urns);
            _logger.LogInformation($"Attemping to get establishments by URNs: {commaSeparatedRequestUrns}");

            var establishments = _getEstablishments.Execute(request);

            if (establishments == null)
            {
                _logger.LogInformation($"No establishment was found any of the requested URNs: {commaSeparatedRequestUrns}");
                return NotFound();
            }

            _logger.LogInformation($"Returning Establishments for URNs: {commaSeparatedRequestUrns}");
            _logger.LogDebug(JsonSerializer.Serialize(establishments));
            return Ok(establishments);
        }
    }
}
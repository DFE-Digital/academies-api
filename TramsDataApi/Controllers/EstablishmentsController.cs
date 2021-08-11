using System.Collections;
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
        private readonly IGetEstablishmentByUkprn _getEstablishmentByUkprn;
        private readonly IUseCase<GetEstablishmentByUrnRequest, EstablishmentResponse> _getEstablishmentByUrn;
        private readonly IUseCase<SearchEstablishmentsRequest, IList<EstablishmentSummaryResponse>> _searchEstablishments;
        private readonly ILogger<EstablishmentsController> _logger;

        public EstablishmentsController(
            IGetEstablishmentByUkprn getEstablishmentByUkprn, 
            IUseCase<GetEstablishmentByUrnRequest, EstablishmentResponse> getEstablishmentByUrn,
            IUseCase<SearchEstablishmentsRequest, IList<EstablishmentSummaryResponse>> searchEstablishments,
            ILogger<EstablishmentsController> logger)
        {
            _getEstablishmentByUkprn = getEstablishmentByUkprn;
            _getEstablishmentByUrn = getEstablishmentByUrn;
            _searchEstablishments = searchEstablishments;
            _logger = logger;
        }

        [HttpGet]
        [Route("establishment/{ukprn}")]
        public ActionResult<EstablishmentResponse> GetByUkprn(string ukprn)
        {
            _logger.LogInformation($"Attempting to get Establishment by UKPRN {ukprn}");
            var establishment = _getEstablishmentByUkprn.Execute(ukprn);

            if (establishment == null)
            {
                _logger.LogInformation($"No Establishment found for UKPRN {ukprn}");
                return NotFound();
            }
            _logger.LogInformation($"Returning Establishment with UKPRN {ukprn}");
            _logger.LogDebug(JsonSerializer.Serialize<EstablishmentResponse>(establishment));
            return Ok(establishment);
        }

        [HttpGet]
        [Route("establishment/urn/{urn}")]
        public ActionResult<EstablishmentResponse> GetByUrn(int urn)
        {
            var establishment = _getEstablishmentByUrn.Execute(new GetEstablishmentByUrnRequest { URN = urn });
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
    }
}
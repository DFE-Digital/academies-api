using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    public class TrustsController : ControllerBase
    {
        private readonly IGetTrustByUkprn _getTrustByUkprn;
        private readonly ISearchTrusts _searchTrusts;
        private readonly ILogger<TrustsController> _logger;

        public TrustsController(IGetTrustByUkprn getTrustByUkprn, ISearchTrusts searchTrusts, ILogger<TrustsController> logger)
        {
            _getTrustByUkprn = getTrustByUkprn;
            _searchTrusts = searchTrusts;
            _logger = logger;
        }
        
        [HttpGet]
        [Route("trust/{ukprn}")]
        public ActionResult<TrustResponse> GetTrustByUkprn(string ukprn)
        {
            _logger.LogInformation($"Attempting to get trust by UKPRN {ukprn}");
            var trust = _getTrustByUkprn.Execute(ukprn);

            if (trust == null)
            {
                _logger.LogInformation($"No trust found for UKPRN {ukprn}");
                return NotFound();
            }

            _logger.LogInformation($"Returning trust found by UKPRN {ukprn}");
            _logger.LogDebug(JsonSerializer.Serialize(trust));
            return Ok(trust);
        }

        [HttpGet]
        [Route("trusts")]
        public ActionResult<List<TrustSummaryResponse>> SearchTrusts(string groupName, string ukprn, string companiesHouseNumber, int page = 1)
        {
            _logger.LogInformation($"Searching for trusts by groupName \"{groupName}\", UKPRN \"{ukprn}\", companiesHouseNumber \"{companiesHouseNumber}\", page {page}");
            var trusts = _searchTrusts.Execute(groupName, ukprn, companiesHouseNumber, page);
            _logger.LogInformation($"Found {trusts.Count} trusts for groupName \"{groupName}\", UKPRN \"{ukprn}\", companiesHouseNumber \"{companiesHouseNumber}\", page {page}");
            _logger.LogDebug(JsonSerializer.Serialize(trusts));
            return Ok(trusts);
        }
    }
}
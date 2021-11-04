using System.Collections.Generic;
using System.Linq;
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
        public ActionResult<List<TrustSummaryResponse>> SearchTrusts(string groupName, string ukPrn, string companiesHouseNumber, int page = 1, int count = 10)
        {
            _logger.LogInformation(
                "Searching for trusts by groupName \"{name}\", UKPRN \"{prn}\", companiesHouseNumber \"{number}\", page {page}, count {count}",
                groupName, ukPrn, companiesHouseNumber, page, count);

            var trusts = _searchTrusts
                .Execute(page, count, groupName, ukPrn, companiesHouseNumber)
                .ToList();
            
            _logger.LogInformation(
                "Found {count} trusts for groupName \"{name}\", UKPRN \"{prn}\", companiesHouseNumber \"{number}\", page {page}, count {count}",
                trusts.Count, groupName, ukPrn, companiesHouseNumber, page, count);
            
            _logger.LogDebug(JsonSerializer.Serialize(trusts));
            return Ok(trusts);
        }
    }
}
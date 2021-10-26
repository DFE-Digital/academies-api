using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("v{version:apiVersion}/trusts")]
    public class TrustsController
    {
        private readonly IGetTrustByUkprn _getTrustByUkPrn;
        private readonly ISearchTrusts _searchTrusts;
        private readonly ILogger<TrustsController> _logger;

        public TrustsController(IGetTrustByUkprn getTrustByUkPrn, ISearchTrusts searchTrusts, ILogger<TrustsController> logger)
        {
            _getTrustByUkPrn = getTrustByUkPrn;
            _searchTrusts = searchTrusts;
            _logger = logger;
        }
        
        [HttpGet]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiResponseV2<TrustSummaryResponse>> SearchTrusts(string groupName, string ukprn, string companiesHouseNumber, int page = 1)
        {
            _logger.LogInformation(
                "Searching for trusts by groupName \"{name}\", UKPRN \"{prn}\", companiesHouseNumber \"{number}\", page {page}",
                groupName, ukprn, companiesHouseNumber, page);
            
            var trusts = _searchTrusts.Execute(groupName, ukprn, companiesHouseNumber, page);
            _logger.LogInformation(
                "Found {count} trusts for groupName \"{name}\", UKPRN \"{prn}\", companiesHouseNumber \"{number}\", page {page}",
                trusts.Count, groupName, ukprn, companiesHouseNumber, page);
            
            _logger.LogDebug(JsonSerializer.Serialize(trusts));
            
            var response = new ApiResponseV2<TrustSummaryResponse>(trusts, null);
            return new OkObjectResult(response);
        }
        
        [HttpGet("{ukPrn}")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiResponseV2<TrustResponse>> GetTrustByUkPrn(string ukPrn)
        {
            _logger.LogInformation("Attempting to get trust by UKPRN {prn}", ukPrn);
            var trust = _getTrustByUkPrn.Execute(ukPrn);

            if (trust == null)
            {
                _logger.LogInformation("No trust found for UKPRN {prn}", ukPrn);
                return new NotFoundResult();
            }

            _logger.LogInformation("Returning trust found by UKPRN {prn}", ukPrn);
            _logger.LogDebug(JsonSerializer.Serialize(trust));

            var response = new ApiResponseV2<TrustResponse>(trust);
            return new OkObjectResult(response);
        }
    }
}
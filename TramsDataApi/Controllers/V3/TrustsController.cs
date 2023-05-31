using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers.V3
{
    [ApiVersion("3.0")]
    [ApiController]
    [Route("v{version:apiVersion}/")]
    public class TrustsController : ControllerBase
    {
        private readonly IGetMstrTrustByUkprn _getMstrTrustByUkPrn;
        private readonly ISearchTrusts _searchTrusts;
        private readonly IGetMstrTrustsByUkprns _getMstrTrustsByUkprns;
        private readonly ILogger<TrustsController> _logger;

        public TrustsController(IGetMstrTrustByUkprn getMstrTrustByUkPrn, ISearchTrusts searchTrusts, IGetMstrTrustsByUkprns getMstrTrustsByUkprns, ILogger<TrustsController> logger)
        {
            _getMstrTrustByUkPrn = getMstrTrustByUkPrn;
            _searchTrusts = searchTrusts;
            _getMstrTrustsByUkprns = getMstrTrustsByUkprns;
            _logger = logger;
        }

        [HttpGet("trusts")]
        [MapToApiVersion("3.0")]
        public ActionResult<ApiResponseV2<TrustSummaryResponse>> SearchTrusts(string groupName, string ukPrn, string companiesHouseNumber, 
            int page = 1, int count = 50, bool includeEstablishments = true)
        {
            _logger.LogInformation(
                "Searching for trusts by groupName \"{name}\", UKPRN \"{prn}\", companiesHouseNumber \"{number}\", page {page}, count {count}",
                groupName, ukPrn, companiesHouseNumber, page, count);

            var (trusts, recordCount) = _searchTrusts
                .Execute(page, count, groupName, ukPrn, companiesHouseNumber, includeEstablishments);
            trusts = trusts.ToList();
            
            _logger.LogInformation(
                "Found {count} trusts for groupName \"{name}\", UKPRN \"{prn}\", companiesHouseNumber \"{number}\", page {page}, count {count}",
                trusts.Count(), groupName, ukPrn, companiesHouseNumber, page, count);

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug(JsonSerializer.Serialize(trusts));
            }

            var pagingResponse = PagingResponseFactory.Create(page, count, recordCount, Request);
            var response = new ApiResponseV2<TrustSummaryResponse>(trusts, pagingResponse);
            return new OkObjectResult(response);
        }

        [HttpGet]
        [Route("trust/{ukprn}")]
        [MapToApiVersion("3.0")]
        public ActionResult<ApiSingleResponseV2<MasterTrustResponse>> GetTrustByUkPrn(string ukprn)
        {
            _logger.LogInformation("Attempting to get trust by UKPRN {prn}", ukprn);
            var trust = _getMstrTrustByUkPrn.Execute(ukprn);

            if (trust == null)
            {
                _logger.LogInformation("No trust found for UKPRN {prn}", ukprn);
                return new NotFoundResult();
            }

            _logger.LogInformation("Returning trust found by UKPRN {prn}", ukprn);
            _logger.LogDebug(JsonSerializer.Serialize(trust));

            var response = new ApiSingleResponseV2<MasterTrustResponse>(trust);
            return new OkObjectResult(response);
        }

        [HttpGet]
        [Route("trusts/bulk")]
        [MapToApiVersion("3.0")]
        public ActionResult<ApiResponseV2<MasterTrustResponse>> GetByUkprns([FromQuery] GetTrustsByUkprnsRequest request)
        {
            var commaSeparatedRequestUkprns = string.Join(",", request.Ukprns);
            _logger.LogInformation($"Attemping to get Trusts by UKPRNs: {commaSeparatedRequestUkprns}");

            var trusts = _getMstrTrustsByUkprns.Execute(request);

            if (trusts == null)
            {
                _logger.LogInformation($"No Trust was found for any of the requested UKPRNs: {commaSeparatedRequestUkprns}");
                return NotFound();
            }

            _logger.LogInformation($"Returning Trusts for UKPRNs: {commaSeparatedRequestUkprns}");
            _logger.LogDebug(JsonSerializer.Serialize(trusts));

            var response = new ApiResponseV2<MasterTrustResponse>(trusts, null);
            return Ok(response);
        }
    }
}
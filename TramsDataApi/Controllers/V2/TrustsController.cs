using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers.V2
{
    /// <summary>
    /// Manages trusts operations.
    /// </summary>
    [ApiVersion("2.0")]
    [ApiController]
    [Route("v{version:apiVersion}/")]
    public class TrustsController : ControllerBase
    {
        private readonly IGetTrustByUkprn _getTrustByUkPrn;
        private readonly ISearchTrusts _searchTrusts;
        private readonly IGetTrustsByUkprns _getTrustsByUkprns;
        private readonly ILogger<TrustsController> _logger;

        public TrustsController(IGetTrustByUkprn getTrustByUkPrn, ISearchTrusts searchTrusts, IGetTrustsByUkprns getTrustsByUkprns, ILogger<TrustsController> logger)
        {
            _getTrustByUkPrn = getTrustByUkPrn;
            _searchTrusts = searchTrusts;
            _getTrustsByUkprns = getTrustsByUkprns;
            _logger = logger;
        }

        /// <summary>
        /// Searches for trusts based on given criteria.
        /// </summary>
        /// <remarks>
        /// Search can be performed using the groupName, UK Provider Reference Number (UKPRN), and companiesHouseNumber parameters.
        /// </remarks>
        [HttpGet("trusts")]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Search Trusts", Description = "Search for trusts using the specified parameters.")]
        [SwaggerResponse(200, "Successfully found and returned the list of trusts.", typeof(ApiResponseV2<TrustSummaryResponse>))]
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

        /// <summary>
        /// Retrieves a specific trust by UK Provider Reference Number (UKPRN).
        /// </summary>
        [HttpGet]
        [Route("trust/{ukprn}")]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Get Trust By UK Provider Reference Number (UKPRN)", Description = "Retrieve a single trust by its UK Provider Reference Number (UKPRN).")]
        [SwaggerResponse(200, "Successfully retrieved the trust.", typeof(ApiSingleResponseV2<TrustResponse>))]
        [SwaggerResponse(404, "The trust was not found.")]
        public ActionResult<ApiSingleResponseV2<TrustResponse>> GetTrustByUkPrn(string ukprn)
        {
            _logger.LogInformation("Attempting to get trust by UKPRN {prn}", ukprn);
            var trust = _getTrustByUkPrn.Execute(ukprn);

            if (trust == null)
            {
                _logger.LogInformation("No trust found for UKPRN {prn}", ukprn);
                return new NotFoundResult();
            }

            _logger.LogInformation("Returning trust found by UKPRN {prn}", ukprn);
            _logger.LogDebug(JsonSerializer.Serialize(trust));

            var response = new ApiSingleResponseV2<TrustResponse>(trust);
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Retrieves multiple trusts by their UK Provider Reference Numbers (UKPRNs).
        /// </summary>
        [HttpGet]
        [Route("trusts/bulk")]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Get Trusts By UK Provider Reference Numbers (UKPRNs)", Description = "Retrieve multiple trusts by their UK Provider Reference Numbers (UKPRNs).")]
        [SwaggerResponse(200, "Successfully retrieved the trusts.", typeof(ApiResponseV2<TrustResponse>))]
        [SwaggerResponse(404, "The trusts were not found.")]
        public ActionResult<ApiResponseV2<TrustResponse>> GetByUkprns([FromQuery] GetTrustsByUkprnsRequest request)
        {
            var commaSeparatedRequestUkprns = string.Join(",", request.Ukprns);
            _logger.LogInformation($"Attempting to get Trusts by UKPRNs: {commaSeparatedRequestUkprns}");

            var trusts = _getTrustsByUkprns.Execute(request);

            if (trusts == null)
            {
                _logger.LogInformation($"No Trust was found for any of the requested UKPRNs: {commaSeparatedRequestUkprns}");
                return NotFound();
            }

            _logger.LogInformation($"Returning Trusts for UKPRNs: {commaSeparatedRequestUkprns}");
            _logger.LogDebug(JsonSerializer.Serialize(trusts));

            var response = new ApiResponseV2<TrustResponse>(trusts, null);
            return Ok(response);
        }
    }
}
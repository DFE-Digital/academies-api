using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Dfe.Academies.Application.Queries.Trust;
using Dfe.Academies.Contracts.Trusts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Controllers.V4
{
    /// <summary>
    /// Handles operations related to Trusts.
    /// </summary>
    [ApiController]
    [ApiVersion("4.0")]
    [Route("v{version:apiVersion}/")]
    [SwaggerTag("Trust Endpoints")]
    public class TrustsController : ControllerBase
    {
        private readonly ITrustQueries _trustQueries;
        private readonly ILogger<TrustsController> _logger;

        public TrustsController(ITrustQueries trustQueries, ILogger<TrustsController> logger)
        {
            _trustQueries = trustQueries;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves a Trust by its UK Provider Reference Number (UKPRN).
        /// </summary>
        /// <param name="ukprn">The UK Provider Reference Number (UKPRN) identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A Trust or NotFound if not available.</returns>
        [HttpGet]
        [Route("trust/{ukprn}")]
        [SwaggerOperation(Summary = "Retrieve Trust by UK Provider Reference Number (UKPRN)", Description = "Returns a Trust identified by UK Provider Reference Number (UKPRN).")]
        [SwaggerResponse(200, "Successfully found and returned the Trust.")]
        [SwaggerResponse(404, "Trust with specified UK Provider Reference Number (UKPRN) not found.")]
        public async Task<ActionResult<TrustDto>> GetTrustByUkprn(string ukprn, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Attempting to get trust by UK Provider Reference Number (UKPRN) {ukprn}");
            var trust = await _trustQueries.GetByUkprn(ukprn, cancellationToken).ConfigureAwait(false);

            if (trust == null)
            {
                _logger.LogInformation($"No trust found for UK Provider Reference Number (UKPRN) {ukprn}");
                return NotFound();
            }

            _logger.LogInformation($"Returning trust found by UK Provider Reference Number (UKPRN) {ukprn}");
            _logger.LogDebug(JsonSerializer.Serialize(trust));
            return Ok(trust);
        }

        /// <summary>
        /// Searches for Trusts based on query parameters.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="ukPrn">UK Provider Reference Number (UKPRN) identifier.</param>
        /// <param name="companiesHouseNumber">Companies House Number.</param>
        /// <param name="cancellationToken"></param>
        /// <param name="page">Pagination page.</param>
        /// <param name="count">Number of results per page.</param>
        /// <returns>A list of Trusts that meet the search criteria.</returns>
        [HttpGet]
        [Route("trusts")]
        [SwaggerOperation(Summary = "Search Trusts", Description = "Returns a list of Trusts based on search criteria.")]
        [SwaggerResponse(200, "Successfully executed the search and returned Trusts.")]
        public async Task<ActionResult<ApiResponseV2<TrustDto>>> SearchTrusts(string groupName, string ukPrn, string companiesHouseNumber, CancellationToken cancellationToken, int page = 1, int count = 10)
        {
            _logger.LogInformation(
                "Searching for trusts by groupName \"{name}\", UKPRN \"{prn}\", companiesHouseNumber \"{number}\", page {page}, count {count}",
                groupName, ukPrn, companiesHouseNumber, page, count);

            var (trusts, recordCount) = await _trustQueries
                .Search(page, count, groupName, ukPrn, companiesHouseNumber, cancellationToken).ConfigureAwait(false);

            _logger.LogInformation(
                "Found {count} trusts for groupName \"{name}\", UKPRN \"{prn}\", companiesHouseNumber \"{number}\", page {page}, count {count}",
                recordCount, groupName, ukPrn, companiesHouseNumber, page, count);

            _logger.LogDebug(JsonSerializer.Serialize(trusts));

            var pagingResponse = PagingResponseFactory.Create(page, count, recordCount, Request);
            var response = new ApiResponseV2<TrustDto>(trusts, pagingResponse);

            return Ok(response);
        }

        /// <summary>
        /// Returns Trusts based on supplied list of Ukprns query parameter.
        /// </summary>
        /// <param name="ukprns">List of ukprns to search for.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of Trusts that match the ukprns.</returns>
        [HttpGet]
        [Route("trusts/bulk")]
        [MapToApiVersion("4.0")]
        [SwaggerOperation(Summary = "Get Trusts By UK Provider Reference Numbers (UKPRNs)", Description = "Retrieve multiple trusts by their UK Provider Reference Numbers (UKPRNs).")]
        [SwaggerResponse(200, "Successfully retrieved the trusts.")]
        [SwaggerResponse(404, "The trusts were not found.")]
        public async Task<ActionResult<List<TrustDto>>> GetByUkprns([FromQuery] string[] ukprns, CancellationToken cancellationToken)
        {
            var commaSeparatedRequestUkprns = string.Join(",", ukprns);
            _logger.LogInformation($"Attempting to get Trusts by UKPRNs: {commaSeparatedRequestUkprns}");

            var trusts = await _trustQueries.GetByUkprns(ukprns, cancellationToken);

            if (trusts == null)
            {
                _logger.LogInformation($"No Trust was found for any of the requested UKPRNs: {commaSeparatedRequestUkprns}");
                return NotFound();
            }

            _logger.LogInformation($"Returning Trusts for UKPRNs: {commaSeparatedRequestUkprns}");
            _logger.LogDebug(JsonSerializer.Serialize(trusts));

            return Ok(trusts);
        }
    }
}
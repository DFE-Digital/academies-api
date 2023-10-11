using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers
{
    /// <summary>
    /// Handles operations related to Trusts.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [SwaggerTag("Trust Endpoints")]
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

        /// <summary>
        /// Retrieves a Trust by its UKPRN.
        /// </summary>
        /// <param name="ukprn">The UKPRN identifier.</param>
        /// <returns>A Trust or NotFound if not available.</returns>
        [HttpGet]
        [Route("trust/{ukprn}")]
        [SwaggerOperation(Summary = "Retrieve Trust by UKPRN", Description = "Returns a Trust identified by UKPRN.")]
        [SwaggerResponse(200, "Successfully found and returned the Trust.")]
        [SwaggerResponse(404, "Trust with specified UKPRN not found.")]
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

        /// <summary>
        /// Searches for Trusts based on query parameters.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="ukPrn">UKPRN identifier.</param>
        /// <param name="companiesHouseNumber">Companies House Number.</param>
        /// <param name="page">Pagination page.</param>
        /// <param name="count">Number of results per page.</param>
        /// <returns>A list of Trusts that meet the search criteria.</returns>
        [HttpGet]
        [Route("trusts")]
        [SwaggerOperation(Summary = "Search Trusts", Description = "Returns a list of Trusts based on search criteria.")]
        [SwaggerResponse(200, "Successfully executed the search and returned Trusts.")]
        public ActionResult<List<TrustSummaryResponse>> SearchTrusts(string groupName, string ukPrn, string companiesHouseNumber, int page = 1, int count = 10)
        {
            _logger.LogInformation(
                "Searching for trusts by groupName \"{name}\", UKPRN \"{prn}\", companiesHouseNumber \"{number}\", page {page}, count {count}",
                groupName, ukPrn, companiesHouseNumber, page, count);

            var trusts = _searchTrusts
                .Execute(page, count, groupName, ukPrn, companiesHouseNumber, true)
                .Item1.ToList();
            
            _logger.LogInformation(
                "Found {count} trusts for groupName \"{name}\", UKPRN \"{prn}\", companiesHouseNumber \"{number}\", page {page}, count {count}",
                trusts.Count, groupName, ukPrn, companiesHouseNumber, page, count);
            
            _logger.LogDebug(JsonSerializer.Serialize(trusts));
            return Ok(trusts);
        }
    }
}
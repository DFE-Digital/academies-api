using Dfe.Academies.Application.Trust;
using Dfe.Academies.Domain.Trust;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DfE.CoreLibs.Contracts.Academies.V4;
using DfE.CoreLibs.Contracts.Academies.V4.Trusts;
using TramsDataApi.ResponseModels;
using TramsDataApi.RequestModels;

namespace TramsDataApi.Controllers.V4
{
    /// <summary>
    /// Handles operations related to Trusts.
    /// </summary>
    [ApiController]
    [ApiVersion("4.0")]
    [Route("v{version:apiVersion}/")]
    public class TrustsController(ITrustQueries trustQueries, ILogger<TrustsController> logger) : ControllerBase
    {
        private readonly ILogger<TrustsController> _logger = logger;

        /// <summary>
        /// Retrieves a Trust by its UK Provider Reference Number (UKPRN).
        /// </summary>
        /// <param name="ukprn">The UK Provider Reference Number (UKPRN) identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A Trust or NotFound if not available.</returns>
        [HttpGet]
        [Route("trust/{ukprn}")]
        [SwaggerOperation(Summary = "Retrieve Trust by UK Provider Reference Number (UKPRN)", Description = "Returns a Trust identified by UK Provider Reference Number (UKPRN).")]
        [SwaggerResponse(200, "Successfully found and returned the Trust.", typeof(TrustDto))]
        [SwaggerResponse(404, "Trust with specified UK Provider Reference Number (UKPRN) not found.")]
        public async Task<ActionResult<TrustDto>> GetTrustByUkprn(string ukprn, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Attempting to get trust by UK Provider Reference Number (UKPRN) {ukprn}");
            var trust = await trustQueries.GetByUkprn(ukprn, cancellationToken).ConfigureAwait(false);

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
        /// Retrieves a Trust by its Companies House Number.
        /// </summary>
        /// <param name="companiesHouseNumber">The Companies House Number identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A Trust or NotFound if not available.</returns>
        [HttpGet]
        [Route("trust/companiesHouseNumber/{companiesHouseNumber}")]
        [SwaggerOperation(Summary = "Retrieve Trust by Companies House Number", Description = "Returns a Trust identified by Companies House Number.")]
        [SwaggerResponse(200, "Successfully found and returned the Trust.", typeof(TrustDto))]
        [SwaggerResponse(404, "Trust with specified Companies House Number not found.")]
        public async Task<ActionResult<TrustDto>> GetTrustByCompaniesHouseNumber(string companiesHouseNumber, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Attempting to get trust by Companies House Number {companiesHouseNumber}");
            var trust = await trustQueries.GetByCompaniesHouseNumber(companiesHouseNumber, cancellationToken).ConfigureAwait(false);

            if (trust == null)
            {
                _logger.LogInformation($"No trust found for Companies House Number {companiesHouseNumber}");
                return NotFound();
            }

            _logger.LogInformation($"Returning trust found by Companies House Number {companiesHouseNumber}");
            _logger.LogDebug(JsonSerializer.Serialize(trust));
            return Ok(trust);
        }

        /// <summary>
        /// Retrieves a Trust by its Trust Reference Number.
        /// </summary>
        /// <param name="trustReferenceNumber">The Trust Number identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A Trust or NotFound if not available.</returns>
        [HttpGet]
        [Route("trust/trustReferenceNumber/{trustReferenceNumber}")]
        [SwaggerOperation(Summary = "Retrieve Trust by Trust Reference Number also know as the GIAS Group ID", Description = "Retrieve Trust by Trust Reference Number also know as the GIAS Group ID.")]
        [SwaggerResponse(200, "Successfully found and returned the Trust.", typeof(TrustDto))]
        [SwaggerResponse(404, "Trust with specified Trust Reference Number not found.")]
        public async Task<ActionResult<TrustDto>> GetTrustByTrustReferenceNumber(string trustReferenceNumber, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Attempting to get trust by Trust Reference Number {trustReferenceNumber}");
            var trust = await trustQueries.GetByTrustReferenceNumber(trustReferenceNumber, cancellationToken).ConfigureAwait(false);

            if (trust == null)
            {
                _logger.LogInformation($"No trust found for Trust Reference Number {trustReferenceNumber}");
                return NotFound();
            }

            _logger.LogInformation($"Returning trust found by Trust Reference Number {trustReferenceNumber}");
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
        /// <param name="status">The status of the trust, defaults to "Open"</param>
        /// <returns>A list of Trusts that meet the search criteria.</returns>
        [HttpGet]
        [Route("trusts")]
        [SwaggerOperation(Summary = "Search Trusts", Description = "Returns a list of Trusts based on search criteria.")]
        [SwaggerResponse(200, "Successfully executed the search and returned Trusts.", typeof(PagedDataResponse<TrustDto>))]
        public async Task<ActionResult<PagedDataResponse<TrustDto>>> SearchTrusts(string groupName, string ukPrn, string companiesHouseNumber, CancellationToken cancellationToken, int page = 1, int count = 10, TrustStatus status = TrustStatus.Open)
        {
            _logger.LogInformation(
                "Searching for trusts by groupName \"{name}\", UKPRN \"{prn}\", companiesHouseNumber \"{number}\", page {page}, count {count}",
                groupName, ukPrn, companiesHouseNumber, page, count);

            var (trusts, recordCount) = await trustQueries
                .Search(page, count, groupName, ukPrn, companiesHouseNumber, status, cancellationToken).ConfigureAwait(false);

            _logger.LogInformation(
                "Found {count} trusts for groupName \"{name}\", UKPRN \"{prn}\", companiesHouseNumber \"{number}\", page {page}, count {count}",
                recordCount, groupName, ukPrn, companiesHouseNumber, page, count);

            _logger.LogDebug(JsonSerializer.Serialize(trusts));

            var pagingResponse = PagingResponseFactory.CreateV4PagingResponse(page, count, recordCount, Request);
            var response = new PagedDataResponse<TrustDto>(trusts, pagingResponse);

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
        [SwaggerOperation(Summary = "Get Trusts By UK Provider Reference Numbers (UKPRNs)", Description = "Retrieve multiple trusts by their UK Provider Reference Numbers (UKPRNs).")]
        [SwaggerResponse(200, "Successfully retrieved the trusts.", typeof(List<TrustDto>))]
        [SwaggerResponse(404, "The trusts were not found.")]
        public async Task<ActionResult<List<TrustDto>>> GetByUkprns([FromQuery] string[] ukprns, CancellationToken cancellationToken)
        {
            var commaSeparatedRequestUkprns = string.Join(",", ukprns);
            _logger.LogInformation($"Attempting to get Trusts by UKPRNs: {commaSeparatedRequestUkprns}");

            List<TrustDto> trusts = await trustQueries.GetByUkprns(ukprns, cancellationToken);

            if (trusts == null || !trusts.Any())
            {
                _logger.LogInformation($"No Trust was found for any of the requested UKPRNs: {commaSeparatedRequestUkprns}");
                return NotFound();
            }

            _logger.LogInformation($"Returning Trusts for UKPRNs: {commaSeparatedRequestUkprns}");
            _logger.LogDebug(JsonSerializer.Serialize(trusts));

            return Ok(trusts);
        }

        /// <summary>
        /// Returns Trusts based on supplied list of establishments URNs in the request body.
        /// </summary>
        /// <param name="model">Contains Unique Reference Number (URNs) of the establishments.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A dictionary of URNs and their associated Trusts.</returns>
        [HttpPost]
        [Route("trusts/establishments/urns")]
        [SwaggerOperation(Summary = "Get Trusts By Unique Numbers (URNs)", Description = "Retrieve multiple trusts by establishments Unique Reference Numbers (URNs).")]
        [SwaggerResponse(200, "Successfully retrieved the trusts.", typeof(Dictionary<int, List<TrustDto>>))]
        [SwaggerResponse(404, "The trusts were not found.")]
        public async Task<ActionResult<Dictionary<int, TrustDto>>> GetTrustsByEstablishmentUrnsAsync(
            [FromBody] UrnRequestModel model,
            CancellationToken cancellationToken)
        {
            if (model?.Urns?.Count == 0)
            {
                return BadRequest("Establishments URN list cannot be empty.");
            }

            var commaSeparatedRequestUrns = string.Join(",", model.Urns);
            _logger.LogInformation("Attempting to get Trusts by establishments URNs: {CommaSeparatedRequestUrns}", commaSeparatedRequestUrns);

            var trusts = await trustQueries.GetTrustsByEstablishmentUrns(model.Urns, cancellationToken); 

            _logger.LogInformation("Returning Trusts for establishmentsURNs: {CommaSeparatedRequestUrns}", commaSeparatedRequestUrns);
            _logger.LogDebug("Trust details: {Trust}", JsonSerializer.Serialize(trusts));

            return Ok(trusts);
        }

    }
}
using Dfe.Academies.Application.SignificantChange;
using GovUK.Dfe.CoreLibs.Contracts.Academies.V4;
using GovUK.Dfe.CoreLibs.Contracts.Academies.V4.SignificantChange;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Controllers.V4
{
    /// <summary>
    /// Handles operations related to Significant change.
    /// </summary>
    [ApiController]
    [ApiVersion("4.0")]
    [Route("v{version:apiVersion}/")]
    public class SignificantChangesController(ISignificantChangeQueries significantChangeQueries, ILogger<SignificantChangesController> logger) : ControllerBase
    {
        /// <summary>
        /// Searches for significant changes based on query parameters.
        /// </summary>
        /// <param name="deliveryOfficer">Delivery officer.</param>
        /// <param name="orderByChangeEditDate">Order by significant change edit date.</param>
        /// <param name="page">Pagination page.</param>
        /// <param name="count">Number of results per page.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A list of significant changes that meet the search criteria.</returns>
        [HttpGet]
        [Route("significantchanges")]
        [SwaggerOperation(Summary = "Search significant changes", Description = "Returns a list of significant changes based on search criteria.")]
        [SwaggerResponse(200, "Successfully executed the search and returned significant changes.", typeof(PagedDataResponse<SignificantChangeDto>))]
        public async Task<ActionResult<IEnumerable<SignificantChangeDto>>> SearchSignificantChanges(string deliveryOfficer, bool orderByChangeEditDate = false, int page = 1, int count = 10, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("Searching for significant changes by deliveryOfficer \"{DeliveryOfficer}\" , orderByChangeEditDate {OrderByChangeEditDate}, page {Page}, count {Count}", deliveryOfficer, orderByChangeEditDate, page, count);
            
            var(significantChanges, recordCount) = await significantChangeQueries.SearchSignificantChanges(deliveryOfficer, orderByChangeEditDate, page, count, cancellationToken);
             

            logger.LogInformation("Found {RecordCount} significant changes for deliveryOfficer \"{DeliveryOfficer}\" , orderByChangeEditDate {OrderByChangeEditDate}, page {Page}, count {Count}", recordCount, deliveryOfficer, orderByChangeEditDate, page, count);
            logger.LogDebug("Significant changes details: {@SignificantChanges}", significantChanges);

            var pagingResponse = PagingResponseFactory.CreateV4PagingResponse(page, count, recordCount, Request);
            var response = new PagedDataResponse<SignificantChangeDto>(significantChanges, pagingResponse);

            return Ok(response);
        }
    }
}

using Dfe.Academies.Application.Establishment.V5; 
using GovUK.Dfe.CoreLibs.Contracts.Academies.V5.Establishments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks; 

namespace TramsDataApi.Controllers.V5
{
    /// <summary>
    /// Handles operations related to Establishments.
    /// </summary>
    [ApiController]
    [ApiVersion("5.0")]
    [Route("v{version:apiVersion}/")]
    public class EstablishmentsController(IEstablishmentQueries establishmentQueries, ILogger<EstablishmentsController> logger) : ControllerBase
    {

        /// <summary>
        /// Searches for Establishments with mock report cards based on query parameters.
        /// </summary>
        /// <param name="name">Name of the establishment.</param>
        /// <param name="ukPrn">UK Provider Reference Number (UKPRN) identifier.</param>
        /// <param name="urn">Unique Reference Numbers (URN).</param>
        /// <param name="excludeClosed">When true, exclude closed establishments.</param>
        /// <param name="matchAny">When true, return results where either of name, ukPrn or urn match.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of Establishments that meet the search criteria.</returns>
        [HttpGet]
        [Route("establishments")]
        [SwaggerOperation(Summary = "Search Establishments with mock report cards", Description = "Returns a list of Establishments with mock report cards based on search criteria.")]
        [SwaggerResponse(200, "Successfully executed the search and returned Establishments.", typeof(List<EstablishmentDto>))]
        public async Task<ActionResult<List<EstablishmentDto>>> SearchEstablishmentsWithMockReportCards(string name, string ukPrn, string urn, bool? excludeClosed, bool? matchAny, CancellationToken cancellationToken)
        {
            logger.LogInformation(
                "Searching for establishments with mock report cards by name \"{Name}\", UKPRN \"{UkPrn}\", urn \"{Number}\"", name, ukPrn, urn);

            var (establishments, recordCount) = await establishmentQueries
                .Search(name, ukPrn, urn, excludeClosed, matchAny, cancellationToken).ConfigureAwait(false);

            logger.LogInformation("Found {Count} establishments for name \"{Name}\", UKPRN \"{UkPrn}\", urn \"{Number}\"",
                recordCount, name, ukPrn, urn);

            logger.LogDebug("Establishments: {@Establishments}", establishments);

            var response = new List<EstablishmentDto>(establishments);

            return Ok(response);
        }
    }
}
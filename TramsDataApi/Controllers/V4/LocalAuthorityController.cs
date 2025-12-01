using Dfe.Academies.Application.LocalAuthority;
using GovUK.Dfe.CoreLibs.Contracts.Academies.V4.Establishments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace TramsDataApi.Controllers.V4
{
    /// <summary>
    /// Handles operations related to local authorities.
    /// </summary>
    [ApiController]
    [ApiVersion("4.0")]
    [Route("v{version:apiVersion}/")]
    public class LocalAuthorityController : ControllerBase
    {
        private readonly ILocalAuthorityQueries _localAuthorityQueries;
        private readonly ILogger<EstablishmentsController> _logger;

        public LocalAuthorityController(ILocalAuthorityQueries localAuthorityQueries, ILogger<EstablishmentsController> logger)
        {
            _localAuthorityQueries = localAuthorityQueries;
            _logger = logger;
        }

        /// <summary>
        /// Searches for Establishments based on query parameters.
        /// </summary>
        /// <param name="name">Name of the establishment.</param>
        /// <param name="code">name code identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of local authorities that meet the search criteria.</returns>
        [HttpGet]
        [Route("local-auththorities")]
        [SwaggerOperation(Summary = "Search Local authorities", Description = "Returns a list of local authorities based on search criteria.")]
        [SwaggerResponse(200, "Successfully executed the search and returned local Authorities.", typeof(List<NameAndCodeDto>))]
        public async Task<ActionResult<List<NameAndCodeDto>>> SearchLocalAuthorities(string name, string code, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Searching for local authorities by name \"{name}\", code \"{code}\"",
                name, code);

            var (localAuthorities, recordCount) = await _localAuthorityQueries
                .Search(name, code, cancellationToken).ConfigureAwait(false);

            _logger.LogInformation(
                "Found {count} local authorities for name \"{name}\", code \"{code}\"",
                recordCount, name, code);

            _logger.LogDebug(JsonSerializer.Serialize(localAuthorities));

            var response = new List<NameAndCodeDto>(localAuthorities);

            return Ok(response);
        }
    }
}
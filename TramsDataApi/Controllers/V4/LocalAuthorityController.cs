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
        private readonly ILogger<LocalAuthorityController> _logger;

        public LocalAuthorityController(ILocalAuthorityQueries localAuthorityQueries, ILogger<LocalAuthorityController> logger)
        {
            _localAuthorityQueries = localAuthorityQueries;
            _logger = logger;
        }


        /// <summary>
        /// Retrieves a local authority by its name code.
        /// </summary>
        /// <param name="code">Name code.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A local authority or NotFound if not available.</returns>
        [HttpGet]
        [Route("local-authorities/{code}")]
        [SwaggerOperation(Summary = "Retrieve local authority by name code", Description = "Returns a local authority identified by the name code.")]
        [SwaggerResponse(200, "Successfully found and returned the local authority.", typeof(NameAndCodeDto))]
        [SwaggerResponse(404, "local authority with specified name code not found.")]
        public async Task<ActionResult<NameAndCodeDto>> GetLocalAuthorityByCode(string code, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
            "Attempting to get local authority by name code \"{Code}\"",
            code);

            var localAuthority = await _localAuthorityQueries.GetByCode(code, cancellationToken).ConfigureAwait(false);

            if (localAuthority == null)
            {
                _logger.LogInformation(
                    "No local authority found for name code \"{Code}\"",
                    code);
                return NotFound();
            }

            _logger.LogInformation(
                "Returning local authority found by name code \"{Code}\"",
                code);
            _logger.LogDebug("Local authority get by name code result: {LocalAuthority}", JsonSerializer.Serialize(localAuthority));
            return Ok(localAuthority);
        }

        /// <summary>
        /// Searches for Establishments based on query parameters.
        /// </summary>
        /// <param name="name">Name of the establishment.</param>
        /// <param name="code">name code identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of local authorities that meet the search criteria.</returns>
        [HttpGet]
        [Route("local-authorities")]
        [SwaggerOperation(Summary = "Search Local authorities", Description = "Returns a list of local authorities based on search criteria.")]
        [SwaggerResponse(200, "Successfully executed the search and returned local Authorities.", typeof(List<NameAndCodeDto>))]
        public async Task<ActionResult<List<NameAndCodeDto>>> SearchLocalAuthorities(string name, string code, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Searching for local authorities by name \"{Name}\", code \"{Code}\"",
                name, code);

            var (localAuthorities, recordCount) = await _localAuthorityQueries
                .Search(name, code, cancellationToken).ConfigureAwait(false);

            _logger.LogInformation(
                "Found {Count} local authorities for name \"{Name}\", code \"{Code}\"",
                recordCount, name, code);

            _logger.LogDebug("Local authorities search results: {LocalAuthorities}", JsonSerializer.Serialize(localAuthorities));

            var response = new List<NameAndCodeDto>(localAuthorities);

            return Ok(response);
        }
    }
}
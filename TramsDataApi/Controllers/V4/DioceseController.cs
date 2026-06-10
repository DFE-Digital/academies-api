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
    /// Handles operations related to dioceses.
    /// </summary>
    [ApiController]
    [ApiVersion("4.0")]
    [Route("v{version:apiVersion}/")]
    public class DioceseController : ControllerBase
    {
        private readonly IDioceseQueries _dioceseQueries;
        private readonly ILogger<DioceseController> _logger;

        public DioceseController(IDioceseQueries dioceseQueries, ILogger<DioceseController> logger)
        {
            _dioceseQueries = dioceseQueries;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves a diocese by its name code.
        /// </summary>
        /// <param name="code">Name code.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A diocese or NotFound if not available.</returns>
        [HttpGet]
        [Route("diocese/{code}")]
        [SwaggerOperation(Summary = "Retrieve Diocese by name code", Description = "Returns a diocese identified by the name code.")]
        [SwaggerResponse(200, "Successfully found and returned the diocese.", typeof(NameAndCodeDto))]
        [SwaggerResponse(404, "Diocese with specified name code not found.")]
        public async Task<ActionResult<NameAndCodeDto>> GetDioceseByCode(string code, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Attempting to get diocese by name code {Code}", code);

            var diocese = await _dioceseQueries.GetByCode(code, cancellationToken).ConfigureAwait(false);

            if (diocese == null)
            {
                _logger.LogInformation("No diocese found for name code {Code}", code);
                return NotFound();
            }

            _logger.LogInformation("Returning diocese found by name code {Code}", code);

            if (_logger.IsEnabled(LogLevel.Debug))
            {
            _logger.LogDebug("Diocese get by name code result: {Diocese}", JsonSerializer.Serialize(diocese));
            }
            return Ok(diocese);
        }

        /// <summary>
        /// Searches for dioceses based on query parameters.
        /// </summary>
        /// <param name="name">Name of the diocese.</param>
        /// <param name="code">Name code identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of dioceses that meet the search criteria.</returns>
        [HttpGet]
        [Route("diocese")]
        [SwaggerOperation(Summary = "Search Dioceses", Description = "Returns a list of dioceses based on search criteria.")]
        [SwaggerResponse(200, "Successfully executed the search and returned dioceses.", typeof(List<NameAndCodeDto>))]
        public async Task<ActionResult<List<NameAndCodeDto>>> SearchDioceses(string name, string code, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Searching for dioceses by name {Name}, code {Code}", name, code);

            var (dioceses, recordCount) = await _dioceseQueries
                .Search(name, code, cancellationToken).ConfigureAwait(false);

            _logger.LogInformation("Found {Count} dioceses for name {Name}, code {Code}", recordCount, name, code);

            if (_logger.IsEnabled(LogLevel.Debug))
            {
            _logger.LogDebug("Dioceses search results: {Dioceses}", JsonSerializer.Serialize(dioceses));
            }

            return Ok(new List<NameAndCodeDto>(dioceses));
        }
    }
}
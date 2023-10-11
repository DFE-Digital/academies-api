using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.EducationalPerformance;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers
{
    /// <summary>
    /// Manages operations related to Key Stage Educational Performance.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [SwaggerTag("Key Stage Performance Data Endpoints")]
    public class KeyStagePerformanceController : ControllerBase
    {
        private readonly IGetKeyStagePerformanceByUrn _getKeyStagePerformanceByUrn;
        private readonly ILogger<KeyStagePerformanceController> _logger;

        public KeyStagePerformanceController(
            IGetKeyStagePerformanceByUrn getKeyStagePerformanceByUrn,
            ILogger<KeyStagePerformanceController> logger)
        {
            _getKeyStagePerformanceByUrn = getKeyStagePerformanceByUrn;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves educational performance data for an establishment by its Unique reference number (URN).
        /// </summary>
        /// <param name="urn">The Unique reference number (URN) identifier of the establishment.</param>
        /// <returns>An EducationalPerformanceResponse object or NotFound if unavailable.</returns>
        [HttpGet]
        [Route("educationPerformance/{urn}")]
        [SwaggerOperation(
            Summary = "Retrieve Educational Performance by Unique reference number (URN)",
            Description = "Returns educational performance data identified by Unique reference number (URN)."
        )]
        [SwaggerResponse(200, "Successfully found and returned the educational performance data.")]
        [SwaggerResponse(404, "Educational performance data with the specified Unique reference number (URN) not found.")]
        public ActionResult<EducationalPerformanceResponse> GetEducationPerformanceByUrn(string urn)
        {
            _logger.LogInformation($"Attempting to get Performance Data for Unique reference number (URN) {urn}");
            var performanceData = _getKeyStagePerformanceByUrn.Execute(urn);
            if (performanceData == null)
            {
                _logger.LogInformation($"No Performance Data found for Unique reference number (URN) {urn}");
                return NotFound();
            }
            _logger.LogInformation($"Returning Performance Data for Unique reference number (URN) {urn}");
            _logger.LogDebug(JsonSerializer.Serialize<EducationalPerformanceResponse>(performanceData));
            return Ok(performanceData);
        }
    }
}
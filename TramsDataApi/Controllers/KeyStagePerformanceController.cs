using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramsDataApi.DatabaseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers
{
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
        
        [HttpGet]
        [Route("educationPerformance/{urn}")]
        public ActionResult<List<SipEducationalperformancedata>> GetEducationPerformanceByUrn(string urn)
        {
            _logger.LogInformation($"Attempting to get Performance Data for URN {urn}");
            var performanceData = _getKeyStagePerformanceByUrn.Execute(urn);
            if (performanceData == null)
            {
                _logger.LogInformation($"No Performance Data found for URN {urn}");
                return NotFound();
            }
            _logger.LogInformation($"Returning Performance Data for URN {urn}");
            return Ok(performanceData);
        }
    }
}
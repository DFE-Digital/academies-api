using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TramsDataApi.DatabaseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers
{
    public class KeyStagePerformanceController : ControllerBase
    {
        private readonly IGetKeyStagePerformanceByUrn _getKeyStagePerformanceByUrn;

        public KeyStagePerformanceController(IGetKeyStagePerformanceByUrn getKeyStagePerformanceByUrn)
        {
            _getKeyStagePerformanceByUrn = getKeyStagePerformanceByUrn;
        }
        
        [HttpGet]
        [Route("educationPerformance/{urn}")]
        public ActionResult<List<SipEducationalperformancedata>> GetEducationPerformanceByUrn(string urn)
        {
            var performanceData = _getKeyStagePerformanceByUrn.Execute(urn);
            if (performanceData == null)
            {
                return NotFound();
            }

            return Ok(performanceData);
        }
    }
}
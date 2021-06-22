using Microsoft.AspNetCore.Mvc;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers
{
    [ApiController]
    public class KeyStagePerformanceDataController : ControllerBase
    {
        private readonly IUseCase<GetKeyPerformanceDataRequest, KeyPerformanceDataResponse> _getKeyPerformanceDataByUrn;
        public KeyStagePerformanceDataController(IUseCase<GetKeyPerformanceDataRequest, KeyPerformanceDataResponse> getKeyPerformanceDataByUrn)
        {
            _getKeyPerformanceDataByUrn = getKeyPerformanceDataByUrn;
        }
        public IActionResult GetKeyPerformanceDataByUrn(int urn)
        {
            var keyPerformanceData = _getKeyPerformanceDataByUrn.Execute(new GetKeyPerformanceDataRequest { URN = urn });
            
              if (keyPerformanceData == null)
            {
                return NotFound();
            }  

            return Ok(keyPerformanceData);
        }
    }
}

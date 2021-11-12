using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("v{version:apiVersion}/concerns-record")]
    
    public class ConcernsRecordController : ControllerBase
    {
        private readonly ILogger<ConcernsRecordController> _logger;
        private ICreateConcernsRecord _createConcernsRecord;

        public ConcernsRecordController(
            ILogger<ConcernsRecordController> logger, 
            ICreateConcernsRecord createConcernsRecord)
        {
            _logger = logger;
            _createConcernsRecord = createConcernsRecord;
        }
        
        [HttpPost]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiResponseV2<ConcernsRecordResponse>> Create(ConcernsRecordRequest request)
        {
            var createdConcernsRecord = _createConcernsRecord.Execute(request);
            var response = new ApiSingleResponseV2<ConcernsRecordResponse>(createdConcernsRecord);
            
            return new ObjectResult(response) {StatusCode = StatusCodes.Status201Created};
        }
    }
}
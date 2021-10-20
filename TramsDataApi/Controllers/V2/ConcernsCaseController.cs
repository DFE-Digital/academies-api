using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("v{version:apiVersion}/concerns-cases")]
    public class ConcernsCaseController: ControllerBase
    { 
        private readonly ILogger<ConcernsCaseController> _logger;
        private readonly ICreateConcernsCase _createConcernsCase;

        public ConcernsCaseController(
            ILogger<ConcernsCaseController> logger, 
            ICreateConcernsCase createConcernsCase)
        {
            _logger = logger;
            _createConcernsCase = createConcernsCase;
        }

        public ActionResult<ConcernsCaseResponse> Create(ConcernCaseRequest request)
        {
            var createdConcernsCase = _createConcernsCase.Execute(request);
            return CreatedAtAction("Create", createdConcernsCase);
        }
    }
    
    
}
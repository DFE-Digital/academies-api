using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.ApplyToBecome;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("v{version:apiVersion}/apply-to-become/application")]
    public class A2BApplicationController: ControllerBase
    { 
        private readonly ILogger<A2BApplicationController> _logger;
        private readonly IGetA2BApplication _getA2BApplicationById;
        private readonly ICreateA2BApplication _createA2BApplication;
        
        public A2BApplicationController(
            ILogger<A2BApplicationController> logger, 
            IGetA2BApplication getA2BApplicationById, 
            ICreateA2BApplication createA2BApplication)
        {
            _logger = logger;
            _getA2BApplicationById = getA2BApplicationById;
            _createA2BApplication = createA2BApplication;
        }
        
        [HttpGet]
        [Route("{applicationId}")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<A2BApplicationResponse>> GetApplicationByApplicationId(string applicationId)
        {
            _logger.LogInformation("Attempting to get ApplyToBecome Application by ApplicationId {applicationId}", applicationId);
            var application = _getA2BApplicationById.Execute(applicationId);
            
            if (application == null)
            {
                _logger.LogInformation($"No ApplyToBecome Application found for ApplicationId {applicationId}", applicationId);
                return NotFound($"Application with Id {applicationId} not found");
            }
            
            _logger.LogInformation($"Returning ApplyToBecome Application by ApplicationId {applicationId}", applicationId);
            _logger.LogDebug(JsonSerializer.Serialize(application));
            var response = new ApiSingleResponseV2<A2BApplicationResponse>(application);
            
            return Ok(response);
        }

        [HttpPost]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<A2BApplicationResponse>> Create(A2BApplicationCreateRequest request)
        {
            var createdA2BApplication = _createA2BApplication.Execute(request);
            var response = new ApiSingleResponseV2<A2BApplicationResponse>(createdA2BApplication);
            
            return new ObjectResult(response) {StatusCode = StatusCodes.Status201Created};
        }
    }
}
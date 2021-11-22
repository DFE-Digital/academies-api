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
        private readonly IUseCase<A2BApplicationByIdRequest, A2BApplicationResponse> _getApplyToBecomeApplicationById;

        public A2BApplicationController(
            ILogger<A2BApplicationController> logger, 
            IUseCase<A2BApplicationByIdRequest, A2BApplicationResponse> getApplyToBecomeApplicationById)
        {
            _logger = logger;
            _getApplyToBecomeApplicationById = getApplyToBecomeApplicationById;
        }
        
        [HttpGet]
        [Route("{applicationId}")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<A2BApplicationResponse>> GetApplicationByApplicationId(string applicationId)
        {
            _logger.LogInformation("Attempting to get ApplyToBecome Application by ApplicationId {applicationId}", applicationId);
            var request = new A2BApplicationByIdRequest {ApplicationId = applicationId};
            var application = _getApplyToBecomeApplicationById.Execute(request);
            
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
    }
}
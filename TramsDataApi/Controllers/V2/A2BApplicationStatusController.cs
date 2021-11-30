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
    [Route("v{version:apiVersion}/apply-to-become/status")]
    public class A2BApplicationStatusController: ControllerBase
    { 
        private readonly ILogger<A2BApplicationStatusController> _logger;
        private readonly IGetA2BApplicationStatus _getA2BApplicationStatus;
        private readonly ICreateA2BApplicationStatus _createA2BApplicationStatus;
        
        public A2BApplicationStatusController(
            ILogger<A2BApplicationStatusController> logger, 
            IGetA2BApplicationStatus getA2BApplicationStatus ,
            ICreateA2BApplicationStatus createA2BApplicationStatus)
        {
            _logger = logger;
            _getA2BApplicationStatus = getA2BApplicationStatus;
            _createA2BApplicationStatus = createA2BApplicationStatus;
        }
        
        [HttpGet]
        [Route("{statusId}")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<A2BApplicationStatusResponse>> GetApplicationStatusByStatusId(int statusId)
        {
            _logger.LogInformation("Attempting to get ApplyToBecome ApplicationStatus by statusId {statusId}", statusId);
             
            var status = _getA2BApplicationStatus.Execute(statusId);
            
            if (status == null)
            {
                _logger.LogInformation($"No ApplyToBecome Applicationstatus found for statusId {statusId}", statusId);
                return NotFound($"ApplicationStatus with Id {statusId} not found");
            }
            
            _logger.LogInformation($"Returning ApplyToBecome ApplicationStatus by statusId {statusId}", statusId);
            _logger.LogDebug(JsonSerializer.Serialize(status));
            var response = new ApiSingleResponseV2<A2BApplicationStatusResponse>(status);
            
            return Ok(response);
        }

        [HttpPost]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<A2BApplicationResponse>> Create(A2BApplicationStatusCreateRequest request)
        {
            var createdstatus = _createA2BApplicationStatus.Execute(request);
            var response = new ApiSingleResponseV2<A2BApplicationStatusResponse>(createdstatus);
            
            return new ObjectResult(response) {StatusCode = StatusCodes.Status201Created};
        }
    }
}
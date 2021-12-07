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
    [Route("v{version:apiVersion}/apply-to-become/applyingSchool")]
    public class A2BApplyingSchoolController: ControllerBase
    { 
        private readonly ILogger<A2BApplyingSchoolController> _logger;
        private readonly IGetA2BApplyingSchool _getA2BApplyingSchool;
        private readonly ICreateA2BApplyingSchool _createA2BApplyingSchool;
        
        public A2BApplyingSchoolController(
            ILogger<A2BApplyingSchoolController> logger, 
            IGetA2BApplyingSchool getA2BApplyingSchool ,
            ICreateA2BApplyingSchool createA2BApplyingSchool)
        {
            _logger = logger;
            _getA2BApplyingSchool = getA2BApplyingSchool;
            _createA2BApplyingSchool = createA2BApplyingSchool;
        }
        
        [HttpGet]
        [Route("{applyingSchoolId}")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<A2BApplyingSchoolResponse>> GetApplyingSchoolByApplyingSchoolId(string applyingSchoolId)
        {
            _logger.LogInformation("Attempting to get ApplyToBecome ApplyingSchool by ApplyingSchoolId {applyingSchoolId}", applyingSchoolId);
             
            var applyingSchool = _getA2BApplyingSchool.Execute(applyingSchoolId);
            if (applyingSchool == null)
            {
                _logger.LogInformation($"No ApplyToBecome ApplyingSchool found for applyingSchoolId {applyingSchoolId}", applyingSchoolId);
                return NotFound($"ApplyingSchool with Id {applyingSchoolId} not found");
            }
            
            _logger.LogInformation($"Returning ApplyToBecome ApplyingSchool by applyingSchoolId {applyingSchoolId}", applyingSchoolId);
            _logger.LogDebug(JsonSerializer.Serialize(applyingSchool));
            var response = new ApiSingleResponseV2<A2BApplyingSchoolResponse>(applyingSchool);
            
            return Ok(response);
        }

        [HttpPost]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<A2BApplicationResponse>> Create(A2BApplyingSchoolCreateRequest request)
        {
            var createdApplyingSchool = _createA2BApplyingSchool.Execute(request);
            var response = new ApiSingleResponseV2<A2BApplyingSchoolResponse>(createdApplyingSchool);
            
            return new ObjectResult(response) {StatusCode = StatusCodes.Status201Created};
        }
    }
}

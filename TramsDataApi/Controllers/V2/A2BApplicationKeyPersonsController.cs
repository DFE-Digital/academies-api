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
    [Route("v{version:apiVersion}/apply-to-become/keyPersons")]
    public class A2BApplicationKeyPersonsController: ControllerBase
    { 
        private readonly ILogger<A2BApplicationKeyPersonsController> _logger;
        private readonly IGetA2BApplicationKeyPersons _getA2BApplicationKeyPersons;
        private readonly ICreateA2BApplicationKeyPersons _createA2BApplicationKeyPersons;
        
        public A2BApplicationKeyPersonsController(
            ILogger<A2BApplicationKeyPersonsController> logger, 
            IGetA2BApplicationKeyPersons getA2BApplicationKeyPersons ,
            ICreateA2BApplicationKeyPersons createA2BApplicationKeyPersons)
        {
            _logger = logger;
            _getA2BApplicationKeyPersons = getA2BApplicationKeyPersons;
            _createA2BApplicationKeyPersons = createA2BApplicationKeyPersons;
        }
        
        [HttpGet]
        [Route("{keyPersonId}")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<A2BApplicationKeyPersonsResponse>> GetApplicationKeyPersonByKeyPersonId(int keyPersonId)
        {
            _logger.LogInformation("Attempting to get ApplyToBecome ApplicationKeyPerson by KeyPersonId {keyPersonId}", keyPersonId);
            var request = new A2BApplicationKeyPersonsByIdRequest() {KeyPersonId = keyPersonId};
            
            var keyPerson = _getA2BApplicationKeyPersons.Execute(request);
            
            if (keyPerson == null)
            {
                _logger.LogInformation($"No ApplyToBecome ApplicationKeyPersons found for KeyPersonId {keyPersonId}", keyPersonId);
                return NotFound($"ApplicationKeyPerson with Id {keyPersonId} not found");
            }
            
            _logger.LogInformation($"Returning ApplyToBecome ApplicationKeyPerson by KeyPersonId {keyPersonId}", keyPersonId);
            _logger.LogDebug(JsonSerializer.Serialize(keyPerson));
            var response = new ApiSingleResponseV2<A2BApplicationKeyPersonsResponse>(keyPerson);
            
            return Ok(response);
        }

        [HttpPost]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<A2BApplicationResponse>> Create(A2BApplicationKeyPersonsCreateRequest request)
        {
            var createdKeyPersons = _createA2BApplicationKeyPersons.Execute(request);
            var response = new ApiSingleResponseV2<A2BApplicationKeyPersonsResponse>(createdKeyPersons);
            
            return new ObjectResult(response) {StatusCode = StatusCodes.Status201Created};
        }
    }
}
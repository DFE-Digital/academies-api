using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.ApplyToBecome;
using TramsDataApi.UseCases;
using System.Text.Json;

namespace TramsDataApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("v{version:apiVersion}/apply-to-become/school-leases")]
    public class A2BSchoolLeaseController : ControllerBase
    {
        private readonly ILogger<A2BSchoolLeaseController> _logger;
        private readonly ICreateA2BSchoolLease _createA2BSchoolLease;
        private readonly IGetA2BSchoolLease _getA2BSchoolLease;

        public A2BSchoolLeaseController(
            ILogger<A2BSchoolLeaseController> logger,
            ICreateA2BSchoolLease createA2BSchoolLease,
            IGetA2BSchoolLease getA2BSchoolLease)
        {
            _logger = logger;
            _createA2BSchoolLease = createA2BSchoolLease;
            _getA2BSchoolLease = getA2BSchoolLease;
        }
        
        [HttpPost]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<A2BSchoolLeaseResponse>> Create(A2BSchoolLeaseCreateRequest request)
        {
            var createdSchoolLease = _createA2BSchoolLease.Execute(request);
            var response = new ApiSingleResponseV2<A2BSchoolLeaseResponse>(createdSchoolLease);
            
            return new ObjectResult(response) {StatusCode = StatusCodes.Status201Created};
        }
        
        [HttpGet]
        [Route("{leaseId}")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<A2BSchoolLeaseResponse>> GetLeaseByLeaseId(string leaseId)
        {
            _logger.LogInformation($"Attempting to get ApplyToBecome School Lease by LeaseId {leaseId}", leaseId);
             
            var lease = _getA2BSchoolLease.Execute(leaseId);
            
            if (lease == null)
            {
                _logger.LogInformation($"No ApplyToBecome School lease found for leaseId {leaseId}", leaseId);
                return NotFound($"Lease with Id {leaseId} not found");
            }
            
            _logger.LogInformation($"Returning ApplyToBecome Lease by leaseId {leaseId}", leaseId);
            _logger.LogDebug(JsonSerializer.Serialize(lease));
            var response = new ApiSingleResponseV2<A2BSchoolLeaseResponse>(lease);
            
            return Ok(response);
        }
    }
}
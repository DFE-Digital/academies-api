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
    [Route("v{version:apiVersion}/apply-to-become/contributor")]
    public class A2BContributorController: ControllerBase
    { 
        private readonly ILogger<A2BContributorController> _logger;
        private readonly IGetA2BContributor _getA2BContributor;
        private readonly ICreateA2BContributor _createA2BContributor;
        
        public A2BContributorController(
            ILogger<A2BContributorController> logger, 
            IGetA2BContributor getA2BContributor ,
            ICreateA2BContributor createA2BContributor)
        {
            _logger = logger;
            _getA2BContributor = getA2BContributor;
            _createA2BContributor = createA2BContributor;
        }
        
        [HttpGet]
        [Route("{contributorId}")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<A2BContributorResponse>> GetContributorByContributorId(string contributorId)
        {
            _logger.LogInformation("Attempting to get ApplyToBecome Contributor by ContributorId {contributorId}", contributorId);
             
            var contributor = _getA2BContributor.Execute(contributorId);
            
            if (contributor == null)
            {
                _logger.LogInformation($"No ApplyToBecome Contributor found for contributorId {contributorId}", contributorId);
                return NotFound($"Contributor with Id {contributorId} not found");
            }
            
            _logger.LogInformation($"Returning ApplyToBecome Contributor by contributorId {contributorId}", contributorId);
            _logger.LogDebug(JsonSerializer.Serialize(contributor));
            var response = new ApiSingleResponseV2<A2BContributorResponse>(contributor);
            
            return Ok(response);
        }

        [HttpPost]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<A2BApplicationResponse>> Create(A2BContributorCreateRequest request)
        {
            var createdContributor = _createA2BContributor.Execute(request);
            var response = new ApiSingleResponseV2<A2BContributorResponse>(createdContributor);
            
            return new ObjectResult(response) {StatusCode = StatusCodes.Status201Created};
        }
    }
}
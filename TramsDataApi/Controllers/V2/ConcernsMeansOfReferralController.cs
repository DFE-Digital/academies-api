using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers.V2
{
    [ApiVersion("2.0", Deprecated = true)]
    [ApiController]
    [Route("v{version:apiVersion}/concerns-meansofreferral")]
    [Obsolete("This endpoint is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class ConcernsMeansOfReferralController: ControllerBase
    {
        
        private readonly ILogger<ConcernsMeansOfReferralController> _logger;
        private readonly IIndexConcernsMeansOfReferrals _indexConcernsMeansOfReferrals;

        public ConcernsMeansOfReferralController(
            ILogger<ConcernsMeansOfReferralController> logger, 
            IIndexConcernsMeansOfReferrals indexConcernsMeansOfReferrals)
        {
            _logger = logger;
            _indexConcernsMeansOfReferrals = indexConcernsMeansOfReferrals;
        }
        
        [HttpGet]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiResponseV2<ConcernsMeansOfReferralResponse>> Index()
        {
            _logger.LogInformation("Attempting to get Concerns Means of Referrals");
            var meansOfReferrals = _indexConcernsMeansOfReferrals.Execute();
            
            _logger.LogInformation("Returning Concerns Means of Referrals");
            var pagingResponse = PagingResponseFactory.Create(1, 50, meansOfReferrals.Count, Request);
            var response = new ApiResponseV2<ConcernsMeansOfReferralResponse>(meansOfReferrals, pagingResponse);
            return Ok(response);
        }
    }
}
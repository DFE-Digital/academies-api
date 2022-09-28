using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("v{version:apiVersion}/concerns-ratings")]
    [Obsolete("This endpoint is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class ConcernsRatingController: ControllerBase
    {
        private readonly ILogger<ConcernsRatingController> _logger;
        private readonly IIndexConcernsRatings _indexConcernsRatings;

        public ConcernsRatingController(
            ILogger<ConcernsRatingController> logger,
            IIndexConcernsRatings indexConcernsRatings)
        {
            _logger = logger;
            _indexConcernsRatings = indexConcernsRatings;
        }
        
        [HttpGet]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiResponseV2<ConcernsRatingResponse>> Index()
        {
            _logger.LogInformation($"Attempting to get Concerns Ratings");
            var ratings = _indexConcernsRatings.Execute();
            
            _logger.LogInformation($"Returning Concerns ratings");
            var pagingResponse = PagingResponseFactory.Create(1, 50, ratings.Count, Request);
            var response = new ApiResponseV2<ConcernsRatingResponse>(ratings, pagingResponse);
            return Ok(response);
        }
    }
}
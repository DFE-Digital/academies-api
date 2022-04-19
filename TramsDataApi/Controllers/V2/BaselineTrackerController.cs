using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramsDataApi.RequestModels;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("v{version:apiVersion}/basline-tracker")]
    public class BaselineTrackerController : ControllerBase
    {
        private readonly ILogger<BaselineTrackerController> _logger;
        private readonly IUseCase<GetAllBaselineTrackerRequest, IEnumerable<BaselineTrackerResponse>> _getAllBBaselineTrackerRequest;

        public BaselineTrackerController(ILogger<BaselineTrackerController> logger, 
            IUseCase<GetAllBaselineTrackerRequest, IEnumerable<BaselineTrackerResponse>> getAllBBaselineTrackerRequest)
        {
            _logger = logger;
            _getAllBBaselineTrackerRequest = getAllBBaselineTrackerRequest;
        }

		[HttpGet]
		[MapToApiVersion("2.0")]
		public ActionResult<ApiResponseV2<BaselineTrackerResponse>> Get([FromQuery] int page = 1, [FromQuery] int count = 50)
		{
            _logger.LogInformation($"Attempting to retrieve {count} Baseline Tracker List.");

            var list = _getAllBBaselineTrackerRequest.Execute(new GetAllBaselineTrackerRequest { Page = page, Count = count }).ToList();

			_logger.LogInformation($"Returning {list.Count} Baseline Tracker List");
			_logger.LogDebug(JsonSerializer.Serialize<IEnumerable<BaselineTrackerResponse>>(list));

			var pagingResponse = PagingResponseFactory.Create(page, count, list.Count, Request);

			var response = new ApiResponseV2<BaselineTrackerResponse>(list, pagingResponse);
			return Ok(response);
		}
	}
}

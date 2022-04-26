using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramsDataApi.RequestModels;
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
        private readonly IUseCase<GetAllBaselineTrackerRequestByStatusesRequest, IEnumerable<BaselineTrackerResponse>> _getAllBBaselineTrackerRequestByStatus;


        public BaselineTrackerController(ILogger<BaselineTrackerController> logger, 
            IUseCase<GetAllBaselineTrackerRequest, IEnumerable<BaselineTrackerResponse>> getAllBBaselineTrackerRequest,
            IUseCase<GetAllBaselineTrackerRequestByStatusesRequest, IEnumerable<BaselineTrackerResponse>> getAllBBaselineTrackerRequestByStatus)
        {
            _logger = logger;
            _getAllBBaselineTrackerRequest = getAllBBaselineTrackerRequest;
            _getAllBBaselineTrackerRequestByStatus = getAllBBaselineTrackerRequestByStatus;
        }

		[HttpGet]
		[MapToApiVersion("2.0")]
		public ActionResult<ApiResponseV2<BaselineTrackerResponse>> Get(
            [FromQuery] string states = null,
            [FromQuery] int page = 1, 
            [FromQuery] int count = 50)
		{
            var statusList = string.IsNullOrWhiteSpace(states) ? null : states.Split(',').ToList();

            _logger.LogInformation(statusList == null || !statusList.Any()
                ? $"Attempting to retrieve {count} Baseline Tracker List."
                : $"Attempting to retrieve {count} Baseline Tracker List filtered by {states}");

            var list = statusList == null || !statusList.Any()
                    ? _getAllBBaselineTrackerRequest
                        .Execute(new GetAllBaselineTrackerRequest { Page = page, Count = count })
                        .ToList()
                    : _getAllBBaselineTrackerRequestByStatus
                        .Execute(new GetAllBaselineTrackerRequestByStatusesRequest { Page = page, Count = count, Statuses = statusList })
                        .ToList();


            _logger.LogInformation($"Returning {list.Count} Baseline Tracker List");
			_logger.LogDebug(JsonSerializer.Serialize<IEnumerable<BaselineTrackerResponse>>(list));

			var pagingResponse = PagingResponseFactory.Create(page, count, list.Count, Request);

			var response = new ApiResponseV2<BaselineTrackerResponse>(list, pagingResponse);
			return Ok(response);
		}
	}
}

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers.V2
{
    /// <summary>
    /// Manages baseline tracker-related operations.
    /// </summary>
    [ApiVersion("2.0")]
    [ApiController]
    [Route("v{version:apiVersion}/basline-tracker")]
    [SwaggerTag("Operations related to Baseline Tracking")]   
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

        /// <summary>
        /// Retrieves a paginated list of baseline trackers.
        /// </summary>
        /// <param name="states">Comma-separated list of states to filter by.</param>
        /// <param name="page">The page number to return.</param>
        /// <param name="count">The number of items per page.</param>
        /// <returns>A paginated ApiResponse containing BaselineTrackerResponse objects.</returns>
        [HttpGet]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(
            Summary = "Retrieve Baseline Trackers",
            Description = "Returns a paginated list of baseline trackers, optionally filtered by states."
        )]
        [SwaggerResponse(200, "Successfully found and returned the list of baseline trackers.")]
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

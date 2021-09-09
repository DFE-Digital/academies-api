using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.AcademyConversionProject;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
	[Route("v{version:apiVersion}/conversion-projects")]
    public class AcademyConversionProjectController : ControllerBase
	{
		private readonly ILogger<AcademyConversionProjectController> _logger;
		private readonly IUseCase<GetAcademyConversionProjectsByStatusesRequest, IEnumerable<AcademyConversionProjectResponse>>
			_getConversionProjectsByStatus;

		public AcademyConversionProjectController(
			IUseCase<GetAcademyConversionProjectsByStatusesRequest, IEnumerable<AcademyConversionProjectResponse>> getConversionProjectsByStatus,
			ILogger<AcademyConversionProjectController> logger)
		{
			_logger = logger;
			_getConversionProjectsByStatus = getConversionProjectsByStatus;
		}

		[HttpGet]
		[MapToApiVersion("2.0")]
		public ActionResult<ApiResponseV2<AcademyConversionProjectResponse>> GetConversionProjectsByStatuses([FromQuery] string states, [FromQuery] int count = 50)
		{
			if (string.IsNullOrWhiteSpace(states))
			{
				_logger.LogInformation($"Received Request did not provide any values for {nameof(states)} ");
				return new OkObjectResult(new ApiResponseV2<AcademyConversionProjectResponse>());
			}

			var statusList = states.Split(',').ToList();
			
			_logger.LogInformation($"Attempting to retrieve {count} Academy Conversion Projects filtered by {states}");
			
			// temporarily limiting count until we know rules around which to return as there's hundreds in db
			var projects = _getConversionProjectsByStatus
				.Execute(new GetAcademyConversionProjectsByStatusesRequest { Count = count, Statuses = statusList })
				.ToList();

			_logger.LogInformation($"Returning {projects.Count} Academy Conversion Projects");
			_logger.LogDebug(JsonSerializer.Serialize<IEnumerable<AcademyConversionProjectResponse>>(projects));

			var response = new ApiResponseV2<AcademyConversionProjectResponse>(projects);
			return Ok(response);
		}
	}
}

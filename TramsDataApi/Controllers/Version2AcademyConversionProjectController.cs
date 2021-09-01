using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.AcademyConversionProject;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers
{
    [ApiController]
	[Route("v2/conversion-projects")]
	[ApiVersion("2.0")]
	public class Version2AcademyConversionProjectController : ControllerBase
	{
		private readonly IUseCase<GetAcademyConversionProjectByIdRequest, AcademyConversionProjectResponse> _getAcademyConversionProjectById;
		private readonly IUseCase<GetAllAcademyConversionProjectsRequest, IEnumerable<AcademyConversionProjectResponse>> _getAllAcademyConversionProjects;
		private readonly IUpdateAcademyConversionProject _updateAcademyConversionProject;
		private readonly ILogger<Version2AcademyConversionProjectController> _logger;

		public Version2AcademyConversionProjectController(
			IUseCase<GetAcademyConversionProjectByIdRequest, AcademyConversionProjectResponse> getAcademyConversionProjectById,
			IUseCase<GetAllAcademyConversionProjectsRequest, IEnumerable<AcademyConversionProjectResponse>> getAllAcademyConversionProjects,
			IUpdateAcademyConversionProject updateAcademyConversionProject,
			ILogger<Version2AcademyConversionProjectController> logger)
		{
			_getAcademyConversionProjectById = getAcademyConversionProjectById;
			_getAllAcademyConversionProjects = getAllAcademyConversionProjects;
			_updateAcademyConversionProject = updateAcademyConversionProject;
			_logger = logger;
		}

		[HttpGet]
		public ActionResult<Version2AApiResponse<IEnumerable<AcademyConversionProjectResponse>>> GetConversionProjects( [FromBody] List<string> states, [FromQuery] int count = 50)
		{
			_logger.LogInformation($"Attempting to retrieve {count} Academy Conversion Projects filtered by {states}");
			
			// temporarily limiting count until we know rules around which to return as there's hundreds in db
			var projects = _getAllAcademyConversionProjects
				.Execute(new GetAllAcademyConversionProjectsRequest { Count = count, State = states});
			
			_logger.LogInformation($"Returning {projects.Count()} Academy Conversion Projects");
			_logger.LogDebug(JsonSerializer.Serialize<IEnumerable<AcademyConversionProjectResponse>>(projects));
			
			var response = new Version2AApiResponse<IEnumerable<AcademyConversionProjectResponse>>(projects);
			return Ok(response);
		}
	}
}

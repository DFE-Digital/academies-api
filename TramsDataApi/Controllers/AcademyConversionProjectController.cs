using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers
{
    [ApiController]
	[Route("conversion-projects")]
	public class AcademyConversionProjectController : ControllerBase
	{
		private readonly IUseCase<GetAcademyConversionProjectByIdRequest, AcademyConversionProjectResponse> _getAcademyConversionProjectById;
		private readonly IUseCase<GetAllAcademyConversionProjectsRequest, IEnumerable<AcademyConversionProjectResponse>> _getAllAcademyConversionProjects;
		private readonly IUpdateAcademyConversionProject _updateAcademyConversionProject;
		private readonly ILogger<AcademyConversionProjectController> _logger;

		public AcademyConversionProjectController(
			IUseCase<GetAcademyConversionProjectByIdRequest, AcademyConversionProjectResponse> getAcademyConversionProjectById,
			IUseCase<GetAllAcademyConversionProjectsRequest, IEnumerable<AcademyConversionProjectResponse>> getAllAcademyConversionProjects,
			IUpdateAcademyConversionProject updateAcademyConversionProject,
			ILogger<AcademyConversionProjectController> logger)
		{
			_getAcademyConversionProjectById = getAcademyConversionProjectById;
			_getAllAcademyConversionProjects = getAllAcademyConversionProjects;
			_updateAcademyConversionProject = updateAcademyConversionProject;
			_logger = logger;
		}

		[HttpGet]
		public IActionResult GetConversionProjects([FromQuery] int count = 50)
		{
			_logger.LogInformation($"Attempting to retrieve {count} Academy Conversion Projects");
			// temporarily limiting count until we know rules around which to return as there's hundreds in db
			var projects = _getAllAcademyConversionProjects.Execute(new GetAllAcademyConversionProjectsRequest { Count = count });
			_logger.LogInformation($"Returning {projects.Count()} Academy Conversion Projects");

			return Ok(projects);
		}

		[HttpGet("{id}")]
		public IActionResult GetConversionProjectById(int id)
		{
			_logger.LogInformation($"Attempting to get Academy Conversion Project by ID {id}");
			var project = _getAcademyConversionProjectById.Execute(new GetAcademyConversionProjectByIdRequest { Id = id });
			if (project == null)
			{
				_logger.LogInformation($"No Academy Conversion Project found for ID {id}");
				return NotFound();
			}

			_logger.LogInformation($"Returning Academy Conversion Project with ID {id}");
			return Ok(project);
		}

		[HttpPatch("{id}")]
		public IActionResult UpdateConversionProject(int id, UpdateAcademyConversionProjectRequest request)
		{
			_logger.LogInformation($"Attempting to update Academy Conversion Project {id}");
			var updatedAcademyConversionProject = _updateAcademyConversionProject.Execute(id, request);
			if (updatedAcademyConversionProject == null)
			{
				_logger.LogInformation($"Updating Academy Conversion Project failed: No Academy Conversion Project matching ID {id} was found");
				return NotFound();
			}
			_logger.LogInformation($"Successfully Updated Academy Conversion Project {id}");
			return Ok(updatedAcademyConversionProject);
		}
	}
}

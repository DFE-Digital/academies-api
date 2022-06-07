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
		private readonly IGetAcademyConversionProject _getAcademyConversionProjectById;
		private readonly IGetAcademyConversionProjects _getAllAcademyConversionProjects;
		private readonly IUpdateAcademyConversionProject _updateAcademyConversionProject;
		private readonly IGetAcademyConversionProjectsByStatuses
			_getConversionProjectsByStatus;

		public AcademyConversionProjectController(
			IGetAcademyConversionProjectsByStatuses getConversionProjectsByStatus,
			IGetAcademyConversionProjects getAllAcademyConversionProjects,
			IGetAcademyConversionProject getAcademyConversionProjectById,
			IUpdateAcademyConversionProject updateAcademyConversionProject,
			ILogger<AcademyConversionProjectController> logger)
		{
			_logger = logger;
			_getAcademyConversionProjectById = getAcademyConversionProjectById;
			_getAllAcademyConversionProjects = getAllAcademyConversionProjects;
			_updateAcademyConversionProject = updateAcademyConversionProject;
			_getConversionProjectsByStatus = getConversionProjectsByStatus;
		}
		
		[HttpGet]
		[MapToApiVersion("2.0")]
		public ActionResult<ApiResponseV2<AcademyConversionProjectResponse>> GetConversionProjects(
			[FromQuery] string states,
			[FromQuery] int page = 1,
			[FromQuery] int count = 50)
		{
			var areStatesProvided = string.IsNullOrWhiteSpace(states);
			var statusList = areStatesProvided 
				? null 
				: states.Split(',').ToList();

			if (areStatesProvided)
			{
				_logger.LogInformation("Attempting to retrieve {Count} Academy Conversion Projects",count);
			}
			else
			{
				_logger.LogInformation("Attempting to retrieve {Count} Academy Conversion Projects filtered by {States}", count, states);
			}

			var projects = areStatesProvided
				? _getAllAcademyConversionProjects
					.Execute(page, count)
					.ToList()
				: _getConversionProjectsByStatus
					.Execute(page, count, statusList)
					.ToList();
			
			_logger.LogInformation($"Returning {projects.Count} Academy Conversion Projects");

			var pagingResponse = PagingResponseFactory.Create(page, count, projects.Count, Request);
			
			var response = new ApiResponseV2<AcademyConversionProjectResponse>(projects, pagingResponse);
			return Ok(response);
		}
		
		[HttpGet("{id:int}")]
		[MapToApiVersion("2.0")]
		public ActionResult<AcademyConversionProjectResponse> GetConversionProjectById(int id)
		{
			_logger.LogInformation($"Attempting to get Academy Conversion Project by ID {id}");
			var project = _getAcademyConversionProjectById.Execute(id);
			if (project == null)
			{
				_logger.LogInformation($"No Academy Conversion Project found for ID {id}");
				return NotFound();
			}

			_logger.LogInformation($"Returning Academy Conversion Project with ID {id}");
			_logger.LogDebug(JsonSerializer.Serialize(project));
			
			var response = new ApiResponseV2<AcademyConversionProjectResponse>(project);
			return Ok(response);
		}

		[HttpPatch("{id:int}")]
		[MapToApiVersion("2.0")]
		public ActionResult<AcademyConversionProjectResponse> UpdateConversionProject(int id, UpdateAcademyConversionProjectRequest request)
		{
			_logger.LogInformation($"Attempting to update Academy Conversion Project {id}");
			var updatedAcademyConversionProject = _updateAcademyConversionProject.Execute(id, request);
			if (updatedAcademyConversionProject == null)
			{
				_logger.LogInformation($"Updating Academy Conversion Project failed: No Academy Conversion Project matching ID {id} was found");
				return NotFound();
			}

			_logger.LogInformation($"Successfully Updated Academy Conversion Project {id}");
			_logger.LogDebug(JsonSerializer.Serialize(updatedAcademyConversionProject));
			
			var response = new ApiResponseV2<AcademyConversionProjectResponse>(updatedAcademyConversionProject);
			return Ok(response);
		}
	}
}

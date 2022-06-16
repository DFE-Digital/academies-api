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
    [ApiVersion("1.0", Deprecated = true)]
    [Route("conversion-projects")]
    public class AcademyConversionProjectController : ControllerBase
	{
		private readonly IGetAcademyConversionProject _getAcademyConversionProjectById;
		private readonly IGetAcademyConversionProjects _getAllAcademyConversionProjects;
		private readonly IUpdateAcademyConversionProject _updateAcademyConversionProject;
		private readonly ILogger<AcademyConversionProjectController> _logger;

		private const string RetrieveProjectsLog = "Attempting to retrieve {count} Academy Conversion Projects";
		private const string RetrieveProjectsByIdLog = "Attempting to get Academy Conversion Project with Id: {id}";
		private const string ProjectByIdNotFound = "No Academy Conversion Project found with Id: {id}";
		private const string ReturnProjectsLog = "Returning {count} Academy Conversion Projects with Id(s): {ids}";
		private const string UpdateProjectById = "Attempting to update Academy Conversion Project with Id: {id}";
		private const string UpdatedProjectById = "Successfully Updated Academy Conversion Project with Id: {id}";
		
		public AcademyConversionProjectController(
			IGetAcademyConversionProject getAcademyConversionProjectById,
			IGetAcademyConversionProjects getAllAcademyConversionProjects,
			IUpdateAcademyConversionProject updateAcademyConversionProject,
			ILogger<AcademyConversionProjectController> logger)
		{
			_getAcademyConversionProjectById = getAcademyConversionProjectById;
			_getAllAcademyConversionProjects = getAllAcademyConversionProjects;
			_updateAcademyConversionProject = updateAcademyConversionProject;
			_logger = logger;
		}

		[HttpGet]
		public ActionResult<IEnumerable<AcademyConversionProjectResponse>> GetConversionProjects([FromQuery] int count = 50)
		{
			_logger.LogInformation(RetrieveProjectsLog, count);
			
			var projects = _getAllAcademyConversionProjects.Execute(1, count).ToList();

			var projectIds = projects.Select(p => p.Id);
			_logger.LogInformation(ReturnProjectsLog, projects.Count, string.Join(',', projectIds));

			return Ok(projects);
		}

		[HttpGet("{id:int}")]
		public ActionResult<AcademyConversionProjectResponse> GetConversionProjectById(int id)
		{
			_logger.LogInformation(RetrieveProjectsByIdLog, id);
			var project = _getAcademyConversionProjectById.Execute(id);
			if (project == null)
			{
				_logger.LogInformation(ProjectByIdNotFound, id);
				return NotFound();
			}

			_logger.LogInformation(ReturnProjectsLog, 1, id);

			return Ok(project);
		}

		[HttpPatch("{id:int}")]
		public ActionResult<AcademyConversionProjectResponse> UpdateConversionProject(int id, UpdateAcademyConversionProjectRequest request)
		{
			_logger.LogInformation(UpdateProjectById, id);
			var updatedAcademyConversionProject = _updateAcademyConversionProject.Execute(id, request);
			if (updatedAcademyConversionProject == null)
			{
				_logger.LogInformation(ProjectByIdNotFound, id);
				return NotFound();
			}

			_logger.LogInformation(UpdatedProjectById, id);
			
			return Ok(updatedAcademyConversionProject);
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

		public AcademyConversionProjectController(
			IUseCase<GetAcademyConversionProjectByIdRequest, AcademyConversionProjectResponse> getAcademyConversionProjectById,
			IUseCase<GetAllAcademyConversionProjectsRequest, IEnumerable<AcademyConversionProjectResponse>> getAllAcademyConversionProjects,
			IUpdateAcademyConversionProject updateAcademyConversionProject)
		{
			_getAcademyConversionProjectById = getAcademyConversionProjectById;
			_getAllAcademyConversionProjects = getAllAcademyConversionProjects;
			_updateAcademyConversionProject = updateAcademyConversionProject;
		}

		[HttpGet]
		public IActionResult GetConversionProjects([FromQuery] int count = 50)
		{
			// temporarily limiting count until we know rules around which to return as there's hundreds in db
			var projects = _getAllAcademyConversionProjects.Execute(new GetAllAcademyConversionProjectsRequest { Count = count });

			return Ok(projects);
		}

		[HttpGet("{id}")]
		public IActionResult GetConversionProjectById(int id)
		{
			var project = _getAcademyConversionProjectById.Execute(new GetAcademyConversionProjectByIdRequest { Id = id });
			if (project == null)
			{
				return NotFound();
			}

			return Ok(project);
		}

		[HttpPatch("{id}")]
		public IActionResult UpdateConversionProject(int id, UpdateAcademyConversionProjectRequest request)
		{
			var updatedAcademyConversionProject = _updateAcademyConversionProject.Execute(id, request);
			if (updatedAcademyConversionProject == null)
			{
				return NotFound();
			}
			return Ok(updatedAcademyConversionProject);
		}
	}
}

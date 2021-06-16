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

		public static Dictionary<int, bool?> _rationaleMarkAsComplete = new Dictionary<int, bool?>();

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

			// foreach (var project in projects)
   //          {
			// 	UpdateMarkAsComplete(project);
			// }

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

			//UpdateMarkAsComplete(project);

			return Ok(project);
		}

		[HttpPatch("{id}")]
		public IActionResult UpdateConversionProject(int id, UpdateAcademyConversionProjectRequest request)
		{
			// if (!_rationaleMarkAsComplete.ContainsKey(id))
   //          {
			// 	_rationaleMarkAsComplete.Add(id, false);
   //          }
			// _rationaleMarkAsComplete[id] = request.RationaleSectionComplete;

			var updatedAcademyConversionProject = _updateAcademyConversionProject.Execute(id, request);
			if (updatedAcademyConversionProject == null)
			{
				return NotFound();
			}
			//UpdateMarkAsComplete(updatedAcademyConversionProject);
			return Ok(updatedAcademyConversionProject);
		}

		private void UpdateMarkAsComplete(AcademyConversionProjectResponse response)
        {
			_rationaleMarkAsComplete.TryGetValue(response.Id, out var complete);
			response.RationaleSectionComplete = complete ?? false;
		}
	}
}

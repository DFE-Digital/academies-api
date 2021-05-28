using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels.AcademyConversionProject;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers
{
    [ApiController]
    public class AcademyConversionProjectController : ControllerBase
	{
        private readonly IUseCase<GetAcademyConversionProjectByIdRequest, AcademyConversionProjectResponse> _getAcademyConversionProjectById;
        private readonly IUseCase<GetAllAcademyConversionProjectsRequest, IEnumerable<AcademyConversionProjectResponse>> _getAllAcademyConversionProjects;

        public AcademyConversionProjectController(
			IUseCase<GetAcademyConversionProjectByIdRequest, AcademyConversionProjectResponse> getAcademyConversionProjectById,
			IUseCase<GetAllAcademyConversionProjectsRequest, IEnumerable<AcademyConversionProjectResponse>> getAllAcademyConversionProjects)
        {
            _getAcademyConversionProjectById = getAcademyConversionProjectById;
            _getAllAcademyConversionProjects = getAllAcademyConversionProjects;
        }

        [HttpGet]
		[Route("conversion-projects")]
        public IActionResult GetConversionProjects([FromQuery]int count = 50)
        {
			// temporarily limiting count until we know rules around which to return as there's hundreds in db
			var projects = _getAllAcademyConversionProjects.Execute(new GetAllAcademyConversionProjectsRequest { Count = count });

			return Ok(projects);
		}

		[HttpGet]
		[Route("conversion-projects/{id}")]
		public IActionResult GetConversionProjectById(int id)
		{
			var project = _getAcademyConversionProjectById.Execute(new GetAcademyConversionProjectByIdRequest { Id = id });
			if (project == null)
            {
				return NotFound();
            }

			return Ok(project);
		}
	}
}

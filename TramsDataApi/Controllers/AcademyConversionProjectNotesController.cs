using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers
{
    [ApiController]
    [Route("project-notes")]
    public class AcademyConversionProjectNotesController : ControllerBase
    {
        private readonly
            IUseCase<GetAcademyConversionProjectNotesByIdRequest, IEnumerable<AcademyConversionProjectNoteResponse>>
            _getAcademyConversionProjectNotesById;

        public AcademyConversionProjectNotesController(IUseCase<GetAcademyConversionProjectNotesByIdRequest,
            IEnumerable<AcademyConversionProjectNoteResponse>> getAcademyConversionProjectNotesById)
        {
            _getAcademyConversionProjectNotesById = getAcademyConversionProjectNotesById;
        }

        [HttpGet("{id}")]
        public IActionResult GetConversionProjectNotesById(int id)
        {
            var projectNotes = _getAcademyConversionProjectNotesById.Execute(new GetAcademyConversionProjectNotesByIdRequest { Id = id });

            return Ok(projectNotes);
        }
    }
}

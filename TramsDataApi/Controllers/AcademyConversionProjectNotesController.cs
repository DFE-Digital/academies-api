using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers
{
    [ApiController]
    [Route("project-notes")]
    [ApiVersion("1.0")]
    public class AcademyConversionProjectNotesController : ControllerBase
    {
        private readonly
            IUseCase<GetAcademyConversionProjectNotesByIdRequest, IEnumerable<AcademyConversionProjectNoteResponse>>
            _getAcademyConversionProjectNotesById;
        private readonly IAddAcademyConversionProjectNote _addAcademyConversionProjectNote;

        public AcademyConversionProjectNotesController(IUseCase<GetAcademyConversionProjectNotesByIdRequest,
            IEnumerable<AcademyConversionProjectNoteResponse>> getAcademyConversionProjectNotesById, IAddAcademyConversionProjectNote addAcademyConversionProjectNote)
        {
            _getAcademyConversionProjectNotesById = getAcademyConversionProjectNotesById;
            _addAcademyConversionProjectNote = addAcademyConversionProjectNote;
        }

        [HttpGet("{id}")]
        public IActionResult GetConversionProjectNotesById(int id)
        {
            var projectNotes = _getAcademyConversionProjectNotesById.Execute(new GetAcademyConversionProjectNotesByIdRequest { Id = id });

            return Ok(projectNotes);
        }

        [HttpPost("{id}")]
        public IActionResult AddProjectNote(int id, AddAcademyConversionProjectNoteRequest request)
        {
            var projectNote = _addAcademyConversionProjectNote.Execute(id, request);
            if (projectNote == null)
            {
                return BadRequest();
            }

            return Ok(projectNote);
        }
    }
}

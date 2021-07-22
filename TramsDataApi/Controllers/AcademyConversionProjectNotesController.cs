using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly IAddAcademyConversionProjectNote _addAcademyConversionProjectNote;
        private readonly ILogger<AcademyConversionProjectNotesController> _logger;

        public AcademyConversionProjectNotesController(IUseCase<GetAcademyConversionProjectNotesByIdRequest,
            IEnumerable<AcademyConversionProjectNoteResponse>> getAcademyConversionProjectNotesById, IAddAcademyConversionProjectNote addAcademyConversionProjectNote)
        {
            _getAcademyConversionProjectNotesById = getAcademyConversionProjectNotesById;
            _addAcademyConversionProjectNote = addAcademyConversionProjectNote;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<AcademyConversionProjectNoteResponse>> GetConversionProjectNotesById(int id)
        {
            _logger.LogInformation($"Attempting to get Academy Conversion Project Notes by ID {id}");
            var projectNotes = _getAcademyConversionProjectNotesById.Execute(new GetAcademyConversionProjectNotesByIdRequest { Id = id });

            _logger.LogInformation($"Returning Academy Conversion Project Notes for ID {id}");
            _logger.LogDebug(JsonSerializer.Serialize<IEnumerable<AcademyConversionProjectNoteResponse>>(projectNotes));

            return Ok(projectNotes);
        }

        [HttpPost("{id}")]
        public IActionResult AddProjectNote(int id, AddAcademyConversionProjectNoteRequest request)
        {
            _logger.LogInformation($"Attempting to add Academy Conversion Project Note for ID {id}");

            var projectNote = _addAcademyConversionProjectNote.Execute(id, request);
            if (projectNote == null)
            {
                _logger.LogInformation($"Bad request when attempting to add Academy Conversion Project Note for ID {id}");
                _logger.LogDebug(JsonSerializer.Serialize<AddAcademyConversionProjectNoteRequest>(request));

                return BadRequest();
            }

            _logger.LogInformation($"Successfully added Academy Conversion Project Note for ID {id}");
            _logger.LogDebug(JsonSerializer.Serialize<AcademyConversionProjectNoteResponse>(projectNote));
            
            return Ok(projectNote);
        }
    }
}

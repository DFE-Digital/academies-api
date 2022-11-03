using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.AcademyTransferProject;
using TramsDataApi.ResponseModels.AcademyTransferProject;
using TramsDataApi.UseCases;
using TramsDataApi.Validators;

namespace TramsDataApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]

    public class AcademyTransferProjectController : ControllerBase
    {
        private const string SearchProjectsLog =
            "Attempting to retrieve {Count} Academy Transfer Projects filtered by: urn: {Urn} title: {Title}";
        private const string ReturnProjectsLog = "Returning {count} Academy Transfer Projects with Id(s): {ids}";
        private readonly ICreateAcademyTransferProject _createAcademyTransferProject;
        private readonly ISearchAcademyTransferProjects _searchAcademyTransferProject;
        private readonly IGetAcademyTransferProject _getAcademyTransferProject;
        private readonly IUpdateAcademyTransferProject _updateAcademyTransferProject;
        private readonly IIndexAcademyTransferProjects _indexAcademyTransferProject;
        private readonly ILogger<AcademyTransferProjectController> _logger;
        

        public AcademyTransferProjectController(
            ICreateAcademyTransferProject createAcademyTransferProject,
            ISearchAcademyTransferProjects searchAcademyTransferProject,
            IGetAcademyTransferProject getAcademyTransferProject,
            IUpdateAcademyTransferProject updateAcademyTransferProject,
            IIndexAcademyTransferProjects indexAcademyTransferProjects,
            ILogger<AcademyTransferProjectController> logger)
        {
            _createAcademyTransferProject = createAcademyTransferProject;
            _searchAcademyTransferProject = searchAcademyTransferProject;
            _getAcademyTransferProject = getAcademyTransferProject;
            _updateAcademyTransferProject = updateAcademyTransferProject;
            _indexAcademyTransferProject = indexAcademyTransferProjects;
            _logger = logger;
        }
        
        [HttpPost]
        [Route("academyTransferProject")]
        public ActionResult<AcademyTransferProjectResponse> Create(AcademyTransferProjectRequest request)
        {
            _logger.LogInformation($"Attempting to create Academy Transfer Project");
            var validator = new AcademyTransferProjectRequestValidator();
            if (validator.Validate(request).IsValid)
            {
                var createdAcademyTransferProject = _createAcademyTransferProject.Execute(request);
                _logger.LogInformation($"Successfully created new Academy Transfer Project with URN {createdAcademyTransferProject.ProjectUrn}");
                _logger.LogDebug(JsonSerializer.Serialize(createdAcademyTransferProject));
                return CreatedAtAction("Create", createdAcademyTransferProject);
            }
            _logger.LogInformation($"Failed to create Academy Transfer Project due to bad request");
            return BadRequest();
        }

        [HttpPatch]
        [Route("academyTransferProject/{urn}")]
        public ActionResult<AcademyTransferProjectResponse> Update(int urn, AcademyTransferProjectRequest request)
        {
            _logger.LogInformation($"Attempting to update Academy Transfer Project {urn}");
            if (_getAcademyTransferProject.Execute(urn) == null)
            {
                _logger.LogInformation($"Failed to update: No Academy Transfer Project found for URN {urn}");
                return NotFound();
            }

            var validator = new AcademyTransferProjectRequestValidator();
            if (validator.Validate(request).IsValid)
            {
                var updatedAcademyTransferProject = _updateAcademyTransferProject.Execute(urn, request);
                _logger.LogInformation($"Successfully updated Academy Transfer Project {urn}");
                _logger.LogDebug(JsonSerializer.Serialize(updatedAcademyTransferProject));
                return Ok(updatedAcademyTransferProject);
            }
            _logger.LogInformation($"Failed to update Academy Transfer Project due to bad request");
            return BadRequest();
        }

        [HttpGet]
        [Route("academyTransferProject/{urn}")]
        public ActionResult<AcademyTransferProjectResponse> GetByUrn(int urn)
        {
            _logger.LogInformation($"Attempting to get Academy Transfer Project by URN {urn}");
            var academyTransferProject = _getAcademyTransferProject.Execute(urn);
            if (academyTransferProject == null)
            {
                _logger.LogInformation($"No Academy Transfer Project found for urn {urn}");
                return NotFound();
            }

            _logger.LogInformation($"Returning Academy Transfer Project with URN {urn}");
            _logger.LogDebug(JsonSerializer.Serialize(academyTransferProject));
            return Ok(academyTransferProject);
        }
        
        [HttpGet]
        [Route("academyTransferProject")]
        public ActionResult<PagedResult<AcademyTransferProjectSummaryResponse>> Index([FromQuery(Name="page")]int page = 1)
        {
            _logger.LogInformation($"Indexing Academy Transfer Projects from page {page}");
            Tuple<IList<AcademyTransferProjectSummaryResponse>, int> projects = _indexAcademyTransferProject.Execute(page);
            _logger.LogDebug(JsonSerializer.Serialize(projects));
            return Ok(new PagedResult<AcademyTransferProjectSummaryResponse>(projects.Item1, projects.Item2));
        }

        [HttpGet]
        [Route("academyTransferProjects")]
        public async Task<ActionResult<AcademyTransferProjectResponse>> GetTransferProjects(
           [FromQuery] string title,
           [FromQuery] int page = 1,
           [FromQuery] int count = 50,
           [FromQuery] int? urn = null)
        {
           _logger.LogInformation(SearchProjectsLog, count, urn, title);

           PagedResult<AcademyTransferProjectSummaryResponse> result =
              await _searchAcademyTransferProject.Execute(page, count, urn, title);

           if (result.Results.Any())
           {
              IEnumerable<string> projectIds = result.Results.Select(p => p.ProjectUrn);
              _logger.LogInformation(ReturnProjectsLog, result.Results.Count(), string.Join(',', projectIds));
           }

           return Ok(result);
        }
    }
}
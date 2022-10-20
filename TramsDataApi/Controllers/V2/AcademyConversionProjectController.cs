using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramsDataApi.DatabaseModels;
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
        private readonly IUpdateAcademyConversionProject _updateAcademyConversionProject;
        private readonly IGetAcademyConversionProjectStatuses _getAcademyConversionProjectStatuses;
        private readonly ISearchAcademyConversionProjects _searchAcademyConversionProjects;

        private const string RetrieveProjectsLog = "Attempting to retrieve {Count} Academy Conversion Projects";

        private const string SearchProjectsLog =
            "Attempting to retrieve {Count} Academy Conversion Projects filtered by: states: {States} urn: {Urn} title: {Title}";

        private const string ProjectByIdNotFound = "No Academy Conversion Project found with Id: {id}";
        private const string ReturnProjectsLog = "Returning {count} Academy Conversion Projects with Id(s): {ids}";
        private const string UpdateProjectById = "Attempting to update Academy Conversion Project with Id: {id}";
        private const string UpdatedProjectById = "Successfully Updated Academy Conversion Project with Id: {id}";

        public AcademyConversionProjectController(
            ISearchAcademyConversionProjects searchAcademyConversionProjects,
            IGetAcademyConversionProject getAcademyConversionProjectById,
            IUpdateAcademyConversionProject updateAcademyConversionProject,
            IGetAcademyConversionProjectStatuses getAcademyConversionProjectStatuses,
            ILogger<AcademyConversionProjectController> logger)
        {
            _logger = logger;
            _getAcademyConversionProjectById = getAcademyConversionProjectById;
            _updateAcademyConversionProject = updateAcademyConversionProject;
            _getAcademyConversionProjectStatuses = getAcademyConversionProjectStatuses;
            _searchAcademyConversionProjects = searchAcademyConversionProjects;
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<ApiResponseV2<AcademyConversionProjectResponse>>> GetConversionProjects(
            [FromQuery] string states,
            [FromQuery] string title,
            [FromQuery] string deliveryOfficer,
            [FromQuery] int page = 1,
            [FromQuery] int count = 50,
            [FromQuery] int? urn = null)
        {
            var statusList = !string.IsNullOrWhiteSpace(states)
                ? states.Split(',').ToList()
                : null;
            
            _logger.LogInformation(SearchProjectsLog, count, states, urn, title);
            var result = await _searchAcademyConversionProjects.Execute(page, count, statusList, urn, title, deliveryOfficer);

            if (!result.Results.Any())
            {
                var projectIds = result.Results.Select(p => p.Id);
                _logger.LogInformation(ReturnProjectsLog, result.Results.Count(), string.Join(',', projectIds));
            }

            var pagingResponse = PagingResponseFactory.Create(page, count, result.TotalCount, Request);

            var response = new ApiResponseV2<AcademyConversionProjectResponse>(result.Results, pagingResponse);
            return Ok(response);
        }

        [HttpGet("statuses")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<List<string>>> GetAvailableStatuses()
        {
            var result = await _getAcademyConversionProjectStatuses.Execute();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<AcademyConversionProjectResponse>> GetConversionProjectById(int id)
        {
            _logger.LogInformation(RetrieveProjectsLog, 1);
            var project = await _getAcademyConversionProjectById.Execute(id);
            if (project == null)
            {
                _logger.LogInformation(ProjectByIdNotFound, id);
                return NotFound();
            }

            _logger.LogInformation(ReturnProjectsLog, 1, id);

            var response = new ApiResponseV2<AcademyConversionProjectResponse>(project);
            return Ok(response);
        }

        [HttpPatch("{id:int}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<AcademyConversionProjectResponse>> UpdateConversionProject(int id,
            UpdateAcademyConversionProjectRequest request)
        {
            _logger.LogInformation(UpdateProjectById, id);
            var updatedAcademyConversionProject = await _updateAcademyConversionProject.Execute(id, request);
            if (updatedAcademyConversionProject == null)
            {
                _logger.LogInformation(ProjectByIdNotFound, id);
                return NotFound();
            }

            _logger.LogInformation(UpdatedProjectById, id);

            var response = new ApiResponseV2<AcademyConversionProjectResponse>(updatedAcademyConversionProject);
            return Ok(response);
        }
    }
}
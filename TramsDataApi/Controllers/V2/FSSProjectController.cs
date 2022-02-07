using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text.Json;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("v{version:apiVersion}/")]
    public class FssProjectController : Controller
    {
        private readonly ILogger<FssProjectController> _logger;
        private readonly IGetAllFssProject _getAllFssProject;

        public FssProjectController(ILogger<FssProjectController> logger, IGetAllFssProject getAllFssProject)
        {
            _logger = logger;
            _getAllFssProject = getAllFssProject;
        }

        [HttpGet("projects")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiResponseV2<FssProjectResponse>> GetAll(int page = 1, int count = 50)
        {
            _logger.LogInformation($"Retreiving FSS Projects , page {page}, count {count}");

            var projects = _getAllFssProject.Execute(page, count).ToList();

            _logger.LogInformation( $"Found {count} projects, page {page}");

            _logger.LogDebug(JsonSerializer.Serialize(projects));

            var pagingResponse = PagingResponseFactory.Create(page, count, projects.Count, Request);
            var response = new ApiResponseV2<FssProjectResponse>(projects.ToList(), pagingResponse);
            return new OkObjectResult(response);
        }
    }
}

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
    [Route("v{version:apiVersion}/fss/")]
    public class FssProjectController : Controller
    {
        private readonly ILogger<FssProjectController> _logger;
        private readonly IGetAllFssProjects _getAllFssProjects;

        public FssProjectController(ILogger<FssProjectController> logger, IGetAllFssProjects getAllFssProjects)
        {
            _logger = logger;
            _getAllFssProjects = getAllFssProjects;
        }

        [HttpGet("projects")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiResponseV2<FssProjectResponse>> GetAll()
        {
            _logger.LogInformation($"Retreiving all FSS Projects ");

            var projects = _getAllFssProjects.Execute().ToList();

            _logger.LogInformation($"Found {0} projects, " , projects.Count);

            _logger.LogDebug(JsonSerializer.Serialize(projects));

            // Since the dat sent s not being paginated passing null in the pagingResponse parameter
            var response = new ApiResponseV2<FssProjectResponse>(projects.ToList(), null);
            return new OkObjectResult(response);
        }
    }
}

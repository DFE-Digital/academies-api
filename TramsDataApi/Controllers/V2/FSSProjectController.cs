using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerResponse(200, "Successfully found and returned the list of Fss Projects.", typeof(ApiResponseV2<FssProjectResponse>))]

        public async Task<ActionResult<ApiResponseV2<FssProjectResponse>>> GetAll()
        {
            _logger.LogInformation($"Retreiving all FSS Projects ");

            var projects = await _getAllFssProjects.Execute();

            _logger.LogInformation("Found {0} projects, ", projects.Count);

            var response = new ApiResponseV2<FssProjectResponse>(projects, null);
            return new OkObjectResult(response);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TramsDataApi.RequestModels.CaseActions.SRMA;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.CaseActions.SRMA;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("v{version:apiVersion}/case-actions/srma")]
    public class SRMAController : Controller
    {
        private readonly ILogger<SRMAController> _logger;
        private readonly IUseCase<CreateSRMARequest, CreateSRMAResponse> _createSRMAUseCase;

        public SRMAController(
            ILogger<SRMAController> logger,
            IUseCase<CreateSRMARequest, CreateSRMAResponse> createSRMAUseCase)
        {
            _logger = logger;
            _createSRMAUseCase = createSRMAUseCase;
        }

        [HttpPost]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<CreateSRMAResponse>> Create(CreateSRMARequest request)
        {
            var createdSRMA = _createSRMAUseCase.Execute(request);
            var response = new ApiSingleResponseV2<CreateSRMAResponse>(createdSRMA);

            return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
        }
    }
}
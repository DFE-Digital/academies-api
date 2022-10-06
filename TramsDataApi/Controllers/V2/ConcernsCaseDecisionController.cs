using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.RequestModels.Concerns.Decisions;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.Concerns.Decisions;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("v{version:apiVersion}/concerns-cases/{urn:int}/decisions/")]
    [Obsolete("This endpoint is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class ConcernsCaseDecisionController : ControllerBase
    {
        private readonly ILogger<ConcernsCaseDecisionController> _logger;
        private readonly IUseCaseAsync<CreateDecisionRequest, CreateDecisionResponse> _createDecisionUseCase;

        public ConcernsCaseDecisionController(
            ILogger<ConcernsCaseDecisionController> logger,
            IUseCaseAsync<CreateDecisionRequest, CreateDecisionResponse> createDecisionUseCase
        )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _createDecisionUseCase =
                createDecisionUseCase ?? throw new ArgumentNullException(nameof(createDecisionUseCase));
        }

        [HttpPost]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<ApiSingleResponseV2<ConcernsCaseResponse>>> Create(int urn, CreateDecisionRequest request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            if (!request.IsValid())
            {
                _logger.LogInformation($"Failed to create Concerns Case Decision due to bad request");
                return BadRequest();
            }

            request.ConcernsCaseUrn = urn;
            var createdDecision = await _createDecisionUseCase.Execute(request, cancellationToken);
            var response = new ApiSingleResponseV2<CreateDecisionResponse>(createdDecision);

            return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
        }
    }
}
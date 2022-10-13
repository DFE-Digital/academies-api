using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.CompilerServices;
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
        private readonly IUseCaseAsync<GetDecisionRequest, DecisionResponse> _getDecisionUserCase;

        public ConcernsCaseDecisionController(
            ILogger<ConcernsCaseDecisionController> logger,
            IUseCaseAsync<CreateDecisionRequest, CreateDecisionResponse> createDecisionUseCase,
            IUseCaseAsync<GetDecisionRequest, DecisionResponse> getDecisionUserCase
        )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _createDecisionUseCase = createDecisionUseCase ?? throw new ArgumentNullException(nameof(createDecisionUseCase));
            _getDecisionUserCase = getDecisionUserCase ?? throw new ArgumentNullException(nameof(getDecisionUserCase));
        }

        [HttpPost]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<ApiSingleResponseV2<CreateDecisionResponse>>> Create(int urn, CreateDecisionRequest request, CancellationToken cancellationToken)
        {
            LogInfo($"Executing Create. Urn {urn}");

            _ = request ?? throw new ArgumentNullException(nameof(request));

            if (urn <= 0)
            {
                LogInfo($"Failed to create Concerns Case Decision - invalid urn value");
                return BadRequest();
            }
            request.ConcernsCaseUrn = urn;

            if(!request.IsValid())
            {
                LogInfo($"Failed to create Concerns Case Decision due to bad request");
                return BadRequest();
            }

            var createdDecision = await _createDecisionUseCase.Execute(request, cancellationToken);
            var response = new ApiSingleResponseV2<CreateDecisionResponse>(createdDecision);
            
            LogInfo($"Returning created response. Concerns Case Urn {response.Data.ConcernsCaseUrn}, DecisionId {response.Data.DecisionId}");
            return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpGet("{decisionId:int}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<ApiSingleResponseV2<DecisionResponse>>> GetById(int urn, int decisionId, CancellationToken cancellationToken)
        {
            LogInfo($"Attempting to get Concerns Decision by Urn {urn}, DecisionId {decisionId}");

            if (urn <= 0)
            {
                LogInfo($"Failed to GET Concerns Case Decision - invalid urn value");
                return BadRequest();
            }
            if (decisionId <= 0)
            {
                LogInfo($"Failed to GET Concerns Case Decision - invalid urn value");
                return BadRequest();
            }

            var decisionResponse = await _getDecisionUserCase.Execute(new GetDecisionRequest(urn, decisionId), cancellationToken);
            if (decisionResponse == null)
            {
                LogInfo($" returning NotFound");
                return NotFound();
            }
            else
            {
                LogInfo($" returning OK Response");
                var actionResponse = new ApiSingleResponseV2<DecisionResponse>(decisionResponse);
                return Ok(actionResponse);
            }
        }

        private void LogInfo(string msg, [CallerMemberName] string caller = "")
        {
            _logger.LogInformation($"{caller} {msg}");
        }
    }
}
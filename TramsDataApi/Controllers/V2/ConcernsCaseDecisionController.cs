using System;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramsDataApi.RequestModels;
using TramsDataApi.RequestModels.Concerns.Decisions;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.Concerns.Decisions;
using TramsDataApi.UseCases;
using TramsDataApi.UseCases.CaseActions.Decisions;
using TramsDataApi.Validators;

namespace TramsDataApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("v{version:apiVersion}/concerns-cases/{urn:int}/decisions/")]
    [Obsolete(
        "This endpoint is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class ConcernsCaseDecisionController : ControllerBase
    {
        private readonly ILogger<ConcernsCaseDecisionController> _logger;
        private readonly IUseCase<CreateDecisionRequest, CreateDecisionResponse> _createDecisionUseCase;

        public ConcernsCaseDecisionController(
            ILogger<ConcernsCaseDecisionController> logger,
            IUseCase<CreateDecisionRequest, CreateDecisionResponse> createDecisionUseCase
        )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _createDecisionUseCase =
                createDecisionUseCase ?? throw new ArgumentNullException(nameof(createDecisionUseCase));
        }

        [HttpPost]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<ConcernsCaseResponse>> Create(int urn, CreateDecisionRequest request)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            if (! request.IsValid())
            {
                _logger.LogInformation($"Failed to create Concerns Case due to bad request");
                return BadRequest();
            }

            request.ConcernsCaseUrn = urn;
            var createdDecision = _createDecisionUseCase.Execute(request);
            var response = new ApiSingleResponseV2<CreateDecisionResponse>(createdDecision);

            return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
            
        }

        //[HttpPut("{decisionId:int}")]
        //[MapToApiVersion("2.0")]
        //public ActionResult<ApiSingleResponseV2<ConcernsCaseResponse>> Create(int urn, int decisionId, CreateDecisionRequest request)
        //{
        //    _ = request ?? throw new ArgumentNullException(nameof(request));

        //    // var validator = new ConcernsCaseRequestValidator();
        //    //if (validator.Validate(request).IsValid)
        //    //{

        //    request.ConcernsCaseUrn = urn;
        //    var createdDecision = _createDecisionUseCase.Execute(request);
        //    var response = new ApiSingleResponseV2<CreateDecisionResponse>(createdDecision);

        //    return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
        //    //}
        //    //_logger.LogInformation($"Failed to create Concerns Case due to bad request");
        //    //return BadRequest();
        //}

        //[HttpGet]
        //[Route("{int:int}")]
        //[MapToApiVersion("2.0")]
        //public ActionResult<ApiSingleResponseV2<ConcernsCaseResponse>> GetByUrn(int id)
        //{
        //    _logger.LogInformation($"Attempting to get Concerns Case by Urn {urn}");
        //    var concernsCase = _getConcernsCaseByUrn.Execute(urn);

        //    if (concernsCase == null)
        //    {
        //        _logger.LogInformation($"No Concerns case found for URN {urn}");
        //        return NotFound();
        //    }

        //    _logger.LogInformation($"Returning Concerns case with Urn {urn}");
        //    _logger.LogDebug(JsonSerializer.Serialize(concernsCase));
        //    var response = new ApiSingleResponseV2<ConcernsCaseResponse>(concernsCase);

        //    return Ok(response);
        //}
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using TramsDataApi.Enums;
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
        private readonly IUseCase<CreateSRMARequest, SRMAResponse> _createSRMAUseCase;
        private readonly IUseCase<int, ICollection<SRMAResponse>> _getSRMAsByCaseIdUseCase;
        private readonly IUseCase<int, SRMAResponse> _getSRMAByIdUseCase;
        private readonly IUseCase<PatchSRMARequest, SRMAResponse> _patchSRMAUseCase;

        public SRMAController(
            ILogger<SRMAController> logger,
            IUseCase<CreateSRMARequest, SRMAResponse> createSRMAUseCase,
            IUseCase<int, ICollection<SRMAResponse>> getSRMAsByCaseIdUseCase,
            IUseCase<int, SRMAResponse> getSRMAByIdUseCase,
            IUseCase<PatchSRMARequest, SRMAResponse> patchSRMAUseCase)
        {
            _logger = logger;
            _createSRMAUseCase = createSRMAUseCase;
            _getSRMAsByCaseIdUseCase = getSRMAsByCaseIdUseCase;
            _getSRMAByIdUseCase = getSRMAByIdUseCase;
            _patchSRMAUseCase = patchSRMAUseCase;
        }

        [HttpPost]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<SRMAResponse>> Create(CreateSRMARequest request)
        {
            var createdSRMA = _createSRMAUseCase.Execute(request);
            var response = new ApiSingleResponseV2<SRMAResponse>(createdSRMA);

            return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<SRMAResponse>> GetSRMAById(int srmaId)
        {
            var srma = _getSRMAByIdUseCase.Execute(srmaId);
            var response = new ApiSingleResponseV2<SRMAResponse>(srma);

            return Ok(response);
        }

        [HttpGet]
        [Route("case/{caseId}")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<ICollection<SRMAResponse>>> GetSRMAsByCaseId(int caseId)
        { 

            var srmas = _getSRMAsByCaseIdUseCase.Execute(caseId);
            var response = new ApiSingleResponseV2<ICollection<SRMAResponse>>(srmas);

            return Ok(response);
        }

        [HttpPatch]
        [Route("{id}/update-status")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<SRMAResponse>> UpdateStatus(int srmaId, SRMAStatus status)
        {
            var patched = _patchSRMAUseCase.Execute(new PatchSRMARequest
            {
                SRMAId = srmaId,
                Delegate = (srma) =>
                {
                    srma.StatusId = (int)status;
                    return srma;
                }
            });

            var response = new ApiSingleResponseV2<SRMAResponse>(patched);

            return Ok(response);
        }

        [HttpPatch]
        [Route("{id}/update-reason")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<SRMAResponse>> UpdateReason(int srmaId, SRMAReasonOffered reason)
        {
            var patched = _patchSRMAUseCase.Execute(new PatchSRMARequest
            {
                SRMAId = srmaId,
                Delegate = (srma) =>
                {
                    srma.ReasonId = (int)reason;
                    return srma;
                }
            });

            var response = new ApiSingleResponseV2<SRMAResponse>(patched);

            return Ok(response);
        }
    }
}
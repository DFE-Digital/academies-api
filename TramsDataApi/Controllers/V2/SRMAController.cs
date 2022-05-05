using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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

        [HttpPatch]
        [Route("{id}/update-offered-date")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<SRMAResponse>> UpdateOfferedDate(int srmaId, DateTime offeredDate)
        {
            var patched = _patchSRMAUseCase.Execute(new PatchSRMARequest
            {
                SRMAId = srmaId,
                Delegate = (srma) =>
                {
                    srma.DateOffered = offeredDate;
                    return srma;
                }
            });

            var response = new ApiSingleResponseV2<SRMAResponse>(patched);

            return Ok(response);
        }

        [HttpPatch]
        [Route("{id}/update-notes")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<SRMAResponse>> UpdateNotes(int srmaId, string notes)
        {
            var patched = _patchSRMAUseCase.Execute(new PatchSRMARequest
            {
                SRMAId = srmaId,
                Delegate = (srma) =>
                {
                    srma.Notes = notes;
                    return srma;
                }
            });

            var response = new ApiSingleResponseV2<SRMAResponse>(patched);

            return Ok(response);
        }

        [HttpPatch]
        [Route("{id}/update-visit-dates")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<SRMAResponse>> UpdateVisitDates(int srmaId, DateTime startDate, DateTime? endDate)
        {
            var patched = _patchSRMAUseCase.Execute(new PatchSRMARequest
            {
                SRMAId = srmaId,
                Delegate = (srma) =>
                {
                    srma.StartDateOfVisit = startDate;
                    srma.EndDateOfVisit = endDate;
                    return srma;
                }
            });

            var response = new ApiSingleResponseV2<SRMAResponse>(patched);

            return Ok(response);
        }

        [HttpPatch]
        [Route("{id}/update-date-accepted")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<SRMAResponse>> UpdateDateAccepted(int srmaId, DateTime? acceptedDate)
        {
            var patched = _patchSRMAUseCase.Execute(new PatchSRMARequest
            {
                SRMAId = srmaId,
                Delegate = (srma) =>
                {
                    srma.DateAccepted = acceptedDate;
                    return srma;
                }
            });

            var response = new ApiSingleResponseV2<SRMAResponse>(patched);

            return Ok(response);
        }

        [HttpPatch]
        [Route("{id}/update-date-report-sent")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<SRMAResponse>> UpdateDateReportSent(int srmaId, DateTime? dateReportSent)
        {
            var patched = _patchSRMAUseCase.Execute(new PatchSRMARequest
            {
                SRMAId = srmaId,
                Delegate = (srma) =>
                {
                    srma.DateReportSentToTrust = dateReportSent;
                    return srma;
                }
            });

            var response = new ApiSingleResponseV2<SRMAResponse>(patched);

            return Ok(response);
        }


        [HttpPatch]
        [Route("{id}/update-closed-date")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<SRMAResponse>> UpdateDateClosed(int srmaId, DateTime? dateClosed)
        {
            var patched = _patchSRMAUseCase.Execute(new PatchSRMARequest
            {
                SRMAId = srmaId,
                Delegate = (srma) =>
                {
                    srma.ClosedAt = dateClosed;
                    return srma;
                }
            });

            var response = new ApiSingleResponseV2<SRMAResponse>(patched);

            return Ok(response);
        }
    }
}
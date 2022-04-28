﻿using Microsoft.AspNetCore.Http;
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

        public SRMAController(
            ILogger<SRMAController> logger,
            IUseCase<CreateSRMARequest, SRMAResponse> createSRMAUseCase,
            IUseCase<int, ICollection<SRMAResponse>> getSRMAsByCaseIdUseCase,
            IUseCase<int, SRMAResponse> getSRMAByIdUseCase)
        {
            _logger = logger;
            _createSRMAUseCase = createSRMAUseCase;
            _getSRMAsByCaseIdUseCase = getSRMAsByCaseIdUseCase;
            _getSRMAByIdUseCase = getSRMAByIdUseCase;
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
        public ActionResult<ApiSingleResponseV2<ICollection<SRMAResponse>>> GetSRMAsByCaseId(int caseId)
        {
            var srmas = _getSRMAsByCaseIdUseCase.Execute(caseId);
            var response = new ApiSingleResponseV2<ICollection<SRMAResponse>>(srmas);

            return Ok(response);
        }

        //[HttpGet]
        //[MapToApiVersion("2.0")]
        //public ActionResult<ApiSingleResponseV2<SRMAResponse>> GetSRMAById(int srmaId)
        //{
        //    var srma = _getSRMAByIdUseCase.Execute(srmaId);
        //    var response = new ApiSingleResponseV2<SRMAResponse>(srma);

        //    return Ok(response);
        //}

        [HttpPatch]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<SRMAResponse>> UpdateStatus(int srmaId, SRMAStatus status)
        {
            var srma = _getSRMAByIdUseCase.Execute(srmaId);
            var response = new ApiSingleResponseV2<SRMAResponse>(srma);

            return Ok(response);
        }

        [HttpPatch]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<SRMAResponse>> UpdateReason(int srmaId, SRMAReasonOffered reason)
        {
            var srma = _getSRMAByIdUseCase.Execute(srmaId);
            var response = new ApiSingleResponseV2<SRMAResponse>(srma);

            return Ok(response);
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.CaseActions.FinancialPlan;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.CaseActions.FinancialPlan;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/case-actions/financial-plan")]
    [ApiController]
    public class FinancialPlanController : Controller
    {
        private readonly ILogger<FinancialPlanController> _logger;
        private readonly IUseCase<FinancialPlanRequest, FinancialPlanResponse> _createFinancialPlanUseCase;
        private readonly IUseCase<long, FinancialPlanResponse> _getFinancialPlanByIdUseCase;
        private readonly IUseCase<int, List<FinancialPlanResponse>> _getFinancialPlansByCaseUseCase;
        private readonly IUseCase<FinancialPlanRequest, FinancialPlanResponse> _patchFinancialPlanUseCase;
        private readonly IUseCase<object, List<FinancialPlanStatus>> _getAllStatuses;

        public FinancialPlanController(ILogger<FinancialPlanController> logger,
            IUseCase<FinancialPlanRequest, FinancialPlanResponse> createSRMAUseCase,
            IUseCase<long, FinancialPlanResponse> getFinancialPlanByIdUseCase,
            IUseCase<int, List<FinancialPlanResponse>> getFinancialPlansByCase,
            IUseCase<FinancialPlanRequest, FinancialPlanResponse> patchFinancialPlan,
            IUseCase<Object, List<FinancialPlanStatus>> getAllStatuses)
        {
            _logger = logger;
            _createFinancialPlanUseCase = createSRMAUseCase;
            _getFinancialPlanByIdUseCase = getFinancialPlanByIdUseCase;
            _getFinancialPlansByCaseUseCase = getFinancialPlansByCase;
            _patchFinancialPlanUseCase = patchFinancialPlan;
            _getAllStatuses = getAllStatuses;
        }

        [HttpPost]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<FinancialPlanResponse>> Create(FinancialPlanRequest request)
        {
            var createdFP = _createFinancialPlanUseCase.Execute(request);
            var response = new ApiSingleResponseV2<FinancialPlanResponse>(createdFP);

            return CreatedAtAction(nameof(GetFinancialPlanById), new { financialPlanId = createdFP.Id}, response);
        }

        [HttpGet]
        [Route("{financialPlanId}")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<FinancialPlanResponse>> GetFinancialPlanById(long financialPlanId)
        {
            var fp = _getFinancialPlanByIdUseCase.Execute(financialPlanId);
            var response = new ApiSingleResponseV2<FinancialPlanResponse>(fp);

            return Ok(response);
        }

        [HttpGet]
        [Route("case/{caseUrn}")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<List<FinancialPlanResponse>>> GetFinancialPlansByCaseId(int caseUrn)
        {
            var fps = _getFinancialPlansByCaseUseCase.Execute(caseUrn);
            var response = new ApiSingleResponseV2<List<FinancialPlanResponse>>(fps);

            return Ok(response);
        }

        [HttpGet]
        [Route("all-statuses")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<List<FinancialPlanStatus>>> GetAllStatuses()
        {
            var statuses = _getAllStatuses.Execute(null);
            var response = new ApiSingleResponseV2<List<FinancialPlanStatus>>(statuses);

            return Ok(response);
        }

        [HttpPatch]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<FinancialPlanResponse>> Patch(FinancialPlanRequest request)
        {
            var createdFP = _patchFinancialPlanUseCase.Execute(request);
            var response = new ApiSingleResponseV2<FinancialPlanResponse>(createdFP);

            return CreatedAtAction(nameof(GetFinancialPlanById), new { financialPlanId = createdFP.Id}, response);
        }
    }
}

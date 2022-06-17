using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories.CaseActionFactories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.CaseActions.FinancialPlan;
using TramsDataApi.RequestModels.CaseActions.SRMA;
using TramsDataApi.ResponseModels.CaseActions.FinancialPlan;

namespace TramsDataApi.UseCases.CaseActions
{
    public class PatchFinancialPlan : IUseCase<PatchFinancialPlanRequest, FinancialPlanResponse>
    {
        private readonly IFinancialPlanGateway _gateway;

        public PatchFinancialPlan(IFinancialPlanGateway gateway)
        {
            _gateway = gateway;
        }

        public FinancialPlanResponse Execute(PatchFinancialPlanRequest request)
        {
            return ExecuteAsync(request).Result;
        }

        public async Task<FinancialPlanResponse> ExecuteAsync(PatchFinancialPlanRequest request)
        {
            var patchedSRMA = await _gateway.PatchFinancialPlan(FinancialPlanFactory.CreateDBModel(request));
            return FinancialPlanFactory.CreateResponse(patchedSRMA);
        }
    }
}

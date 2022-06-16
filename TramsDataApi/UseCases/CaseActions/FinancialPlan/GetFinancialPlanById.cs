using System.Collections.Generic;
using System.Threading.Tasks;
using TramsDataApi.Factories.CaseActionFactories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.CaseActions.FinancialPlan;

namespace TramsDataApi.UseCases.CaseActions
{
    public class GetFinancialPlanById : IUseCase<long, FinancialPlanResponse>
    {
        private readonly IFinancialPlanGateway _gateway;

        public GetFinancialPlanById(IFinancialPlanGateway gateway)
        {
            _gateway = gateway;
        }

        public FinancialPlanResponse Execute(long financialPlanId)
        {
            return ExecuteAsync(financialPlanId).Result;
        }

        public async Task<FinancialPlanResponse> ExecuteAsync(long financialPlanId)
        {
            var fp = await _gateway.GetFinancialPlanById(financialPlanId);
            return FinancialPlanFactory.CreateResponse(fp);
        }
    }
}

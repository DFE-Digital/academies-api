using System.Threading.Tasks;
using TramsDataApi.Factories.CaseActionFactories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.CaseActions.FinancialPlan;
using TramsDataApi.ResponseModels.CaseActions.FinancialPlan;

namespace TramsDataApi.UseCases.CaseActions
{
    public class CreateFinancialPlan : IUseCase<FinancialPlanRequest, FinancialPlanResponse>
    {
        private readonly IFinancialPlanGateway _gateway;

        public CreateFinancialPlan(IFinancialPlanGateway financialPlanGateway)
        {
            _gateway = financialPlanGateway;
        }

        public FinancialPlanResponse Execute(FinancialPlanRequest request)
        {
            return ExecuteAsync(request).Result;
        }

        public async Task<FinancialPlanResponse> ExecuteAsync(FinancialPlanRequest request)
        {
            var dbModel = FinancialPlanFactory.CreateDBModel(request);
            var createdSRMA = await _gateway.CreateFinancialPlan(dbModel);

            return FinancialPlanFactory.CreateResponse(createdSRMA);
        }
    }
}

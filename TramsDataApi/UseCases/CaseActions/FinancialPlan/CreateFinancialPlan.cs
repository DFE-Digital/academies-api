using System.Threading.Tasks;
using TramsDataApi.Factories.CaseActionFactories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.CaseActions.FinancialPlan;
using TramsDataApi.ResponseModels.CaseActions.FinancialPlan;

namespace TramsDataApi.UseCases.CaseActions
{
    public class CreateFinancialPlan : IUseCase<CreateFinancialPlanRequest, FinancialPlanResponse>
    {
        private readonly IFinancialPlanGateway _gateway;

        public CreateFinancialPlan(IFinancialPlanGateway financialPlanGateway)
        {
            _gateway = financialPlanGateway;
        }

        public FinancialPlanResponse Execute(CreateFinancialPlanRequest request)
        {
            return ExecuteAsync(request).Result;
        }

        public async Task<FinancialPlanResponse> ExecuteAsync(CreateFinancialPlanRequest request)
        {
            var dbModel = FinancialPlanFactory.CreateDBModel(request);
            var createdSRMA = await _gateway.CreateFinancialPlan(dbModel);

            return FinancialPlanFactory.CreateResponse(createdSRMA);
        }
    }
}

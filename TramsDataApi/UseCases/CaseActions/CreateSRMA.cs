using System.Threading.Tasks;
using TramsDataApi.Factories.CaseActionFactories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.CaseActions.SRMA;
using TramsDataApi.ResponseModels.CaseActions.SRMA;

namespace TramsDataApi.UseCases.CaseActions
{
    public class CreateSRMA : IUseCase<CreateSRMARequest, CreateSRMAResponse>
    {
        private readonly ISRMAGateway _gateway;

        public CreateSRMA(ISRMAGateway gateway)
        {
            _gateway = gateway;
        }

        public CreateSRMAResponse Execute(CreateSRMARequest request)
        {
            return ExecuteAsync(request).Result;
        }

        public async Task<CreateSRMAResponse> ExecuteAsync(CreateSRMARequest request)
        {
            var dbModel = SRMAFactory.CreateDBModel(request);
            var createdSRMA = await _gateway.CreateSRMA(dbModel);

            return SRMAFactory.CreateResponse(createdSRMA);
        }
    }
}

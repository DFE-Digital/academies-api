using System.Threading.Tasks;
using TramsDataApi.Factories.CaseActionFactories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.CaseActions.NTI.UnderConsideration;
using TramsDataApi.ResponseModels.CaseActions.NTI.UnderConsideration;

namespace TramsDataApi.UseCases.CaseActions
{
    public class CreateNTIUnderConsideration : IUseCase<CreateNTIUnderConsiderationRequest, NTIUnderConsiderationResponse>
    {
        private readonly INTIUnderConsiderationGateway _gateway;

        public CreateNTIUnderConsideration(INTIUnderConsiderationGateway gateway)
        {
            _gateway = gateway;
        }

        public NTIUnderConsiderationResponse Execute(CreateNTIUnderConsiderationRequest request)
        {
            return ExecuteAsync(request).Result;
        }

        public async Task<NTIUnderConsiderationResponse> ExecuteAsync(CreateNTIUnderConsiderationRequest request)
        {
            var dbModel = NTIUnderConsiderationFactory.CreateDBModel(request);

            var createdNTIUnderConsideration = await _gateway.CreateNTIUnderConsideration(dbModel);

            return NTIUnderConsiderationFactory.CreateResponse(createdNTIUnderConsideration);
        }

    }
}

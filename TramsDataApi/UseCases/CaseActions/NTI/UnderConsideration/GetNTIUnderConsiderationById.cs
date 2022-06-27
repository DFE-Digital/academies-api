using System.Threading.Tasks;
using TramsDataApi.Factories.CaseActionFactories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.CaseActions.NTI.UnderConsideration;

namespace TramsDataApi.UseCases.CaseActions
{
    public class GetNTIUnderConsiderationById : IUseCase<long, NTIUnderConsiderationResponse>
    {
        private readonly INTIUnderConsiderationGateway _gateway;

        public GetNTIUnderConsiderationById(INTIUnderConsiderationGateway gateway)
        {
            _gateway = gateway;
        }

        public NTIUnderConsiderationResponse Execute(long underConsiderationId)
        {
            return ExecuteAsync(underConsiderationId).Result;
        }

        public async Task<NTIUnderConsiderationResponse> ExecuteAsync(long underConsiderationId)
        {
            var consideration = await _gateway.GetNTIUnderConsiderationById(underConsiderationId);
            return NTIUnderConsiderationFactory.CreateResponse(consideration);
        }
    }
}

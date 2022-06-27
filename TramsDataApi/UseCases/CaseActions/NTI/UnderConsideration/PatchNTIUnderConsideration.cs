using System.Threading.Tasks;
using TramsDataApi.Factories.CaseActionFactories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.CaseActions.NTI.UnderConsideration;
using TramsDataApi.ResponseModels.CaseActions.NTI.UnderConsideration;

namespace TramsDataApi.UseCases.CaseActions
{
    public class PatchNTIUnderConsideration : IUseCase<PatchNTIUnderConsiderationRequest, NTIUnderConsiderationResponse>
    {
        private readonly INTIUnderConsiderationGateway _gateway;

        public PatchNTIUnderConsideration(INTIUnderConsiderationGateway gateway)
        {
            _gateway = gateway;
        }

        public NTIUnderConsiderationResponse Execute(PatchNTIUnderConsiderationRequest request)
        {
            return ExecuteAsync(request).Result;
        }

        public async Task<NTIUnderConsiderationResponse> ExecuteAsync(PatchNTIUnderConsiderationRequest request)
        {
            var patchedSRMA = await _gateway.PatchNTIUnderConsideration(NTIUnderConsiderationFactory.CreateDBModel(request));
            return NTIUnderConsiderationFactory.CreateResponse(patchedSRMA);
        }
    }
}

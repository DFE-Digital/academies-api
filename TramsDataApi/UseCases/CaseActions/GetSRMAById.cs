using System.Collections.Generic;
using System.Threading.Tasks;
using TramsDataApi.Factories.CaseActionFactories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.CaseActions.SRMA;

namespace TramsDataApi.UseCases.CaseActions
{
    public class GetSRMAById : IUseCase<int, SRMAResponse>
    {
        private readonly ISRMAGateway _gateway;

        public GetSRMAById(ISRMAGateway gateway)
        {
            _gateway = gateway;
        }

        public SRMAResponse Execute(int srmaId)
        {
            return ExecuteAsync(srmaId).Result;
        }
        public async Task<SRMAResponse> ExecuteAsync(int srmaId)
        {
            var srma = await _gateway.GetSRMAById(srmaId);
            return SRMAFactory.CreateResponse(srma);
        }
    }
}

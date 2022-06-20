using System.Collections.Generic;
using System.Threading.Tasks;
using TramsDataApi.Factories.CaseActionFactories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.CaseActions.SRMA;
using System.Linq;

namespace TramsDataApi.UseCases.CaseActions
{
    public class GetSRMAsByCaseId : IUseCase<int, ICollection<SRMAResponse>>
    {
        private readonly ISRMAGateway _gateway;

        public GetSRMAsByCaseId(ISRMAGateway gateway)
        {
            _gateway = gateway;
        }

        public ICollection<SRMAResponse> Execute(int caseId)
        {
            return ExecuteAsync(caseId).Result;
        }

        public async Task<ICollection<SRMAResponse>> ExecuteAsync(int caseId)
        {
            var dbModels = await _gateway.GetSRMAsByCaseId(caseId);
            return dbModels.Select(dbm => SRMAFactory.CreateResponse(dbm)).ToList();
        }

    }
}

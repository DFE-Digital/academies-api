using System.Collections.Generic;
using System.Linq;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class GetConcernsCaseByTrustUkprn : IGetConcernsCaseByTrustUkprn
    {
        private readonly IConcernsCaseGateway _concernsCaseGateway;

        public GetConcernsCaseByTrustUkprn(IConcernsCaseGateway concernsCaseGateway)
        {
            _concernsCaseGateway = concernsCaseGateway;
        }
        public IList<ConcernsCaseResponse> Execute(string trustUkprn)
        {
            var concernsCases = _concernsCaseGateway.GetConcernsCaseByTrustUkprn(trustUkprn);
            return concernsCases.Select(ConcernsCaseResponseFactory.Create).ToList();
        }
    }
}
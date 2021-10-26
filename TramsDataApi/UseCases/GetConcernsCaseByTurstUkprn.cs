using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class GetConcernsCaseByTurstUkprn : IGetConcernsCaseByTurstUkprn
    {
        private readonly IConcernsCaseGateway _concernsCaseGateway;

        public GetConcernsCaseByTurstUkprn(IConcernsCaseGateway concernsCaseGateway)
        {
            _concernsCaseGateway = concernsCaseGateway;
        }
        public ConcernsCaseResponse Execute(string trustUkprn)
        {
            var concernsCase = _concernsCaseGateway.GetConcernsCaseByTrustUkprn(trustUkprn);
            return concernsCase == null ? null : ConcernsCaseResponseFactory.Create(concernsCase);
        }
    }
}
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class GetConcernsCaseByUrn : IGetConcernsCaseByUrn
    {
        private readonly IConcernsCaseGateway _concernsCaseGateway;

        public GetConcernsCaseByUrn(IConcernsCaseGateway concernsCaseGateway)
        {
            _concernsCaseGateway = concernsCaseGateway;
        }

        public ConcernsCaseResponse Execute(int urn)
        {
           var concernsCase = _concernsCaseGateway.GetConcernsCaseByUrn(urn);
           return concernsCase == null ? null : ConcernsCaseResponseFactory.Create(concernsCase);
        }
    }
}
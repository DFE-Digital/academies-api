using System.Collections.Generic;
using System.Linq;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class IndexConcernsMeansOfReferrals : IIndexConcernsMeansOfReferrals
    {
        private IConcernsMeansOfReferralGateway _concernsMeansOfReferralGateway;

        public IndexConcernsMeansOfReferrals(IConcernsMeansOfReferralGateway concernsMeansOfReferralGateway)
        {
            _concernsMeansOfReferralGateway = concernsMeansOfReferralGateway;
        }
        public IList<ConcernsMeansOfReferralResponse> Execute()
        {
            var types = _concernsMeansOfReferralGateway.GetMeansOfReferrals();
            return types.Select(ConcernsMeansOfReferralResponseFactory.Create).ToList();
        }
    }
}
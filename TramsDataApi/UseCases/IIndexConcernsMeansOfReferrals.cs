using System.Collections.Generic;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IIndexConcernsMeansOfReferrals
    {
        public IList<ConcernsMeansOfReferralResponse> Execute();
    }
}
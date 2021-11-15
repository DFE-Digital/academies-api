using System.Collections.Generic;
using System.Linq;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class IndexConcernsRatings : IIndexConcernsRatings
    {
        private readonly IConcernsRatingGateway _concernsRatingGateway;

        public IndexConcernsRatings(IConcernsRatingGateway concernsRatingGateway)
        {
            _concernsRatingGateway = concernsRatingGateway;
        }

        public IList<ConcernsRatingResponse> Execute()
        {
            var ratings = _concernsRatingGateway.GetRatings();
            return ratings.Select(ConcernsRatingResponseFactory.Create).ToList();
        }
    }
}
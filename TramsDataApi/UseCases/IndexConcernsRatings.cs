using System;
using System.Collections.Generic;
using System.Linq;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
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
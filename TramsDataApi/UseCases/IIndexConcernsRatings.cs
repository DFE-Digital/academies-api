using System.Collections.Generic;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IIndexConcernsRatings
    {
        public IList<ConcernsRatingResponse> Execute();
    }
}
using System;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class ConcernsRatingResponseFactory
    {
        public static ConcernsRatingResponse Create(ConcernsRating concernsRating)
        {
            return new ConcernsRatingResponse
            {
                Name = concernsRating.Name,
                CreatedAt = concernsRating.CreatedAt,
                UpdatedAt = concernsRating.UpdatedAt,
                Urn = concernsRating.Urn
            };
        }
    }
}
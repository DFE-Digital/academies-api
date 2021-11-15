using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
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
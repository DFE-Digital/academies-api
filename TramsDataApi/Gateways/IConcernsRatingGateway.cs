using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IConcernsRatingGateway
    {
        IList<ConcernsRating> GetRatings();
        ConcernsRating GetRatingByUrn(int urn);
    }
}
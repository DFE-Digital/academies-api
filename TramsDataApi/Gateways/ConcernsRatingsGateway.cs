using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class ConcernsRatingsGateway : IConcernsRatingGateway
    {
        private readonly TramsDbContext _tramsDbContext;

        public ConcernsRatingsGateway(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext;
        }

        public IList<ConcernsRating> GetRatings()
        {
            return _tramsDbContext.ConcernsRatings.ToList();
        }

        public ConcernsRating GetRatingByUrn(int urn)
        {
            return _tramsDbContext.ConcernsRatings.FirstOrDefault(r => r.Urn == urn);
        }
    }
}
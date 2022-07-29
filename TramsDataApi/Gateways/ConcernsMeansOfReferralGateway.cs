using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class ConcernsMeansOfReferralGateway : IConcernsMeansOfReferralGateway
    {
        private readonly TramsDbContext _tramsDbContext;

        public ConcernsMeansOfReferralGateway(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext;
        }

        public IList<ConcernsMeansOfReferral> GetMeansOfReferrals()
        {
            return _tramsDbContext.ConcernsMeansOfReferrals.ToList();
        }

        public ConcernsMeansOfReferral GetMeansOfReferralByUrn(long urn)
        {
            return _tramsDbContext.ConcernsMeansOfReferrals.SingleOrDefault(m => m.Urn == urn);
        }
    }
}
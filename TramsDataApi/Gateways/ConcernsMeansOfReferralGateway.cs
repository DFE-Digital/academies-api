using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            return _tramsDbContext
                .ConcernsMeansOfReferrals
                .AsNoTracking()
                .ToList();
        }

        public ConcernsMeansOfReferral GetMeansOfReferralByUrn(int urn)
        {
            return _tramsDbContext
                .ConcernsMeansOfReferrals
                .AsNoTracking()
                .SingleOrDefault(m => m.Urn == urn);
        }
        
        public ConcernsMeansOfReferral GetMeansOfReferralById(int id)
        {
            return _tramsDbContext
                .ConcernsMeansOfReferrals
                .AsNoTracking()
                .SingleOrDefault(m => m.Id == id);
        }
    }
}
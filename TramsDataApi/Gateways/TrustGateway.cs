using System;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Gateways
{
    public class TrustGateway : ITrustGateway
    {
        private readonly TramsDbContext _dbContext;

        public TrustGateway(TramsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public TrustResponse GetByUkprn(string ukprn)
        {
            var trust = _dbContext.Group.FirstOrDefault(g => g.Ukprn == ukprn);
            if (trust == null)
            {
                return null;
            }
            var ifdTrustData = _dbContext.Trust.FirstOrDefault(t => t.TrustRef == trust.GroupId);
            Console.WriteLine(trust);
            var establishments = _dbContext.Establishment.Where(e => e.TrustsCode == trust.GroupUid).ToList();
            return TrustResponseFactory.Create(trust, ifdTrustData, establishments);
        }
    }
}
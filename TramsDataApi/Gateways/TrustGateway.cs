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
        private readonly IEstablishmentGateway _establishmentGateway;

        public TrustGateway(TramsDbContext dbContext, IEstablishmentGateway establishmentGateway)
        {
            _dbContext = dbContext;
            _establishmentGateway = establishmentGateway;
        }
        
        public TrustResponse GetByUkprn(string ukprn)
        {
            var trust = _dbContext.Group.FirstOrDefault(g => g.Ukprn == ukprn);
            if (trust == null)
            {
                return null;
            }
            var ifdTrustData = _dbContext.Trust.FirstOrDefault(t => t.TrustRef == trust.GroupId);
            var establishments = _establishmentGateway.GetByTrustUid(trust.GroupUid);
            return TrustResponseFactory.Create(trust, ifdTrustData, establishments);
        }
    }
}
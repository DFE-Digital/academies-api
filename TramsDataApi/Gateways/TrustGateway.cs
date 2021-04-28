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

            return trust == null ? null : TrustResponseFactory.Create(trust);
        }
    }
}
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
            var group = _dbContext.Group.First(g => g.Ukprn == ukprn);

            return group == null ? null : TrustResponseFactory.Create(group);
        }
    }
}
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Gateways
{
    public class AcademyGateway : IAcademyGateway
    {
        private readonly TramsDbContext _dbContext;

        public AcademyGateway(TramsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AcademyResponse GetByUkprn(string ukprn)
        {
            var establishment = _dbContext.Establishment.FirstOrDefault(e => e.Ukprn == ukprn);
            return AcademyResponseFactory.Create(establishment);
        }
    }
}
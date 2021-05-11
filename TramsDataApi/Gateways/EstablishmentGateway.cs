using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Gateways
{
    public class EstablishmentGateway : IEstablishmentGateway
    {
        private readonly TramsDbContext _dbContext;

        public EstablishmentGateway(TramsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EstablishmentResponse GetByUkprn(string ukprn)
        {
            var establishment = _dbContext.Establishment.FirstOrDefault(e => e.Ukprn == ukprn);
            return AcademyResponseFactory.Create(establishment);
        }

        public List<EstablishmentResponse> GetByTrustUid(string trustUid)
        {
            return _dbContext.Establishment.Where(e => e.TrustsCode == trustUid)
                .Select(e => AcademyResponseFactory.Create(e))
                .ToList();
        }
    }
}
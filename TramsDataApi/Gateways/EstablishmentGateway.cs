using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class EstablishmentGateway : IEstablishmentGateway
    {
        private readonly LegacyTramsDbContext _dbContext;

        public EstablishmentGateway(LegacyTramsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Establishment GetByUkprn(string ukprn)
        { 
            return _dbContext.Establishment.FirstOrDefault(e => e.Ukprn == ukprn);
        }

        public Establishment GetByUrn(int urn)
        {
            return _dbContext.Establishment.SingleOrDefault(e => e.Urn == urn);
        }

        public IList<Establishment> GetByTrustUid(string trustUid)
        {
            return _dbContext.Establishment.Where(e => e.TrustsCode == trustUid)
                .ToList();
        }

        public MisEstablishments GetMisEstablishmentByUrn(int establishmentUrn)
        {
            return _dbContext.MisEstablishments.FirstOrDefault(m => m.Urn == establishmentUrn);
        }

        public SmartData GetSmartDataByUrn(int establishmentUrn)
        {
            return _dbContext.SmartData.FirstOrDefault(s => s.Urn == establishmentUrn.ToString());
        }

        public IList<Establishment> SearchEstablishments(int? urn, string ukprn, string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
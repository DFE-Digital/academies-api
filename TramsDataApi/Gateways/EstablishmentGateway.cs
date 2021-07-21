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

        public FurtherEducationEstablishments GetFurtherEducationEstablishmentByUrn(int establishmentUrn)
        {
            return _dbContext.FurtherEducationEstablishments.FirstOrDefault(m => m.ProviderUrn == establishmentUrn);
        }

        public SmartData GetSmartDataByUrn(int establishmentUrn)
        {
            return _dbContext.SmartData.FirstOrDefault(s => s.Urn == establishmentUrn.ToString());
        }


         public ViewAcademyConversions GetViewAcademyConversionInfoByUrn(int establishmentUrn) 
        {
            var viewAcademyConversionInfo = _dbContext.ViewAcademyConversions.FirstOrDefault(x => x.GeneralDetailsUrn == establishmentUrn.ToString());
            return viewAcademyConversionInfo;
        }

        public IList<Establishment> SearchEstablishments(int? urn, string ukprn, string name)
        {
            return _dbContext.Establishment
                .Where(e =>
                    (name != null && e.EstablishmentName.Contains(name)) ||
                    (ukprn != null && e.Ukprn.Contains(ukprn)) ||
                    (urn != null && e.Urn.ToString().Contains(urn.ToString()))
                )
                .OrderBy(e => e.Urn)
                .ToList();
        }
    }
}
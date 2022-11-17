using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<int> GetURNsByRegion(IEnumerable<string> regions)
        {
            return
                _dbContext.Establishment
                    .AsNoTracking()
                    .Where(p => regions.Contains(p!.GorName.ToLower()))
                    .Select(e => e.Urn).ToList();
        }

        public Establishment GetByUrn(int urn)
        {
            return _dbContext.Establishment.SingleOrDefault(e => e.Urn == urn);
        }

        public IList<Establishment> GetByUrns(int[] urns)
        {
            return _dbContext.Establishment.AsNoTracking().Where(e => urns.Contains(e.Urn)).ToList();
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

        public IList<MisEstablishments> GetMisEstablishmentsByUrns(int[] establishmentUrns)
        {
            return _dbContext.MisEstablishments.AsNoTracking().Where(e => establishmentUrns.Contains((int)e.Urn)).ToList();
        }

        public FurtherEducationEstablishments GetFurtherEducationEstablishmentByUrn(int establishmentUrn)
        {
            return _dbContext.FurtherEducationEstablishments.FirstOrDefault(m => m.ProviderUrn == establishmentUrn);
        }

        public IList<FurtherEducationEstablishments> GetFurtherEducationEstablishmentsByUrns(int[] establishmentUrns)
        {
            return _dbContext.FurtherEducationEstablishments.AsNoTracking().Where(e => establishmentUrns.Contains(e.ProviderUrn)).ToList();
        }

        public SmartData GetSmartDataByUrn(int establishmentUrn)
        {
            return _dbContext.SmartData.FirstOrDefault(s => s.Urn == establishmentUrn.ToString());
        }

        public IList<SmartData> GetSmartDataByUrns(int[] establishmentUrns)
        {
            var stringUrns = Array.ConvertAll(establishmentUrns, urn => urn.ToString());

            return _dbContext.SmartData.AsNoTracking().Where(e => stringUrns.Contains(e.Urn)).ToList();
        }

        public ViewAcademyConversions GetViewAcademyConversionInfoByUrn(int establishmentUrn) 
        {
            return _dbContext.ViewAcademyConversions.FirstOrDefault(x => x.GeneralDetailsAcademyUrn == establishmentUrn.ToString());
        }

        public IList<ViewAcademyConversions> GetViewAcademyConversionInfoByUrns(int[] establishmentUrns)
        {
            var stringUrns = Array.ConvertAll(establishmentUrns, urn => urn.ToString());

            return _dbContext.ViewAcademyConversions.AsNoTracking().Where(e => stringUrns.Contains(e.GeneralDetailsAcademyUrn)).ToList();
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
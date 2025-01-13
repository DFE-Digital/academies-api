using System.Collections.Generic;
using Dfe.Academies.Domain.Establishment;
using TramsDataApi.DatabaseModels;
using Establishment = TramsDataApi.DatabaseModels.Establishment;

namespace TramsDataApi.Gateways
{
    public interface IEstablishmentGateway
    {
        Establishment GetByUkprn(string ukprn);
        Establishment GetByUrn(int urn);
        IList<Establishment> GetByTrustUid(string trustUid);
        MisEstablishment GetMisEstablishmentByUrn(int establishmentUrn);
        SmartData GetSmartDataByUrn(int establishmentUrn);
        public IEnumerable<int> GetURNsByRegion(IEnumerable<string> regions);
        IList<Establishment> SearchEstablishments(int? urn, string ukprn, string name);
        FurtherEducationEstablishment GetFurtherEducationEstablishmentByUrn(int establishmentUrn);
        ViewAcademyConversions GetViewAcademyConversionInfoByUrn(int urn);
        IList<Establishment> GetByUrns(int[] urns);
        IList<Establishment> GetByTrustUids(string[] trustUids);
        IList<MisEstablishment> GetMisEstablishmentsByUrns(int[] establishmentUrns);
        IList<FurtherEducationEstablishment> GetFurtherEducationEstablishmentsByUrns(int[] establishmentUrns);
        IList<SmartData> GetSmartDataByUrns(int[] establishmentUrns);
        IList<ViewAcademyConversions> GetViewAcademyConversionInfoByUrns(int[] establishmentUrns);
    }
}
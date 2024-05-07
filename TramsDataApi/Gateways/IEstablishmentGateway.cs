using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IEstablishmentGateway
    {
        Establishment GetByUkprn(string ukprn);
        Establishment GetByUrn(int urn);
        IList<Establishment> GetByTrustUid(string trustUid);
        MisEstablishments GetMisEstablishmentByUrn(int establishmentUrn);
        SmartData GetSmartDataByUrn(int establishmentUrn);
        public IEnumerable<int> GetURNsByRegion(IEnumerable<string> regions);
        IList<Establishment> SearchEstablishments(int? urn, string ukprn, string name);
        FurtherEducationEstablishments GetFurtherEducationEstablishmentByUrn(int establishmentUrn);
        ViewAcademyConversions GetViewAcademyConversionInfoByUrn(int urn);
        IList<Establishment> GetByUrns(int[] urns);
        IList<Establishment> GetByTrustUids(string[] trustUids);
        IList<MisEstablishments> GetMisEstablishmentsByUrns(int[] establishmentUrns);
        IList<FurtherEducationEstablishments> GetFurtherEducationEstablishmentsByUrns(int[] establishmentUrns);
        IList<SmartData> GetSmartDataByUrns(int[] establishmentUrns);
        IList<ViewAcademyConversions> GetViewAcademyConversionInfoByUrns(int[] establishmentUrns);
    }
}
using System.Collections;
using System.Collections.Generic;
using TramsDataApi.Controllers;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IEstablishmentGateway
    {
        public Establishment GetByUkprn(string ukprn);
        public IEnumerable<int?> GetURNsByRegion(IEnumerable<string> regions);
        public Establishment GetByUrn(int urn);
        public IList<Establishment> GetByTrustUid(string trustUid);
        public MisEstablishments GetMisEstablishmentByUrn(int establishmentUrn);
        public SmartData GetSmartDataByUrn(int establishmentUrn);

        public IList<Establishment> SearchEstablishments(int? urn, string ukprn, string name);
        public FurtherEducationEstablishments GetFurtherEducationEstablishmentByUrn(int establishmentUrn);
        public ViewAcademyConversions GetViewAcademyConversionInfoByUrn(int urn);
    }
}
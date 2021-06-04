using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IEstablishmentGateway
    {
        public Establishment GetByUkprn(string ukprn);
        public Establishment GetByUrn(int urn);
        public IList<Establishment> GetByTrustUid(string trustUid);
        public MisEstablishments GetMisEstablishmentByUrn(int establishmentUrn);
        public SmartData GetSmartDataByUrn(int establishmentUrn);
    }
}
using System.Collections.Generic;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Gateways
{
    public interface IEstablishmentGateway
    {
        public Establishment GetByUkprn(string ukprn);
        public IList<Establishment> GetByTrustUid(string trustUid);
        public MisEstablishments GetMisEstablishmentByUrn(int establishmentUrn);
    }
}
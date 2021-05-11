using System.Collections.Generic;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Gateways
{
    public interface IEstablishmentGateway
    {
        public Establishment GetByUkprn(string ukprn);
        public List<EstablishmentResponse> GetByTrustUid(string trustUid);
    }
}
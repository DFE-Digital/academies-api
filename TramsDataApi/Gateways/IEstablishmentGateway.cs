using System.Collections.Generic;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Gateways
{
    public interface IEstablishmentGateway
    {
        public EstablishmentResponse GetByUkprn(string ukprn);
        public List<EstablishmentResponse> GetByTrustUid(string trustUid);
    }
}
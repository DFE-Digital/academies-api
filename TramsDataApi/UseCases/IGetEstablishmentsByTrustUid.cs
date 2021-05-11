using System.Collections.Generic;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetEstablishmentsByTrustUid
    {
        public List<EstablishmentResponse> Execute(string trustUid);
    }
}
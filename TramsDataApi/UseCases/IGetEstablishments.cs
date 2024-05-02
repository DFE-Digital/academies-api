using System.Collections.Generic;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetEstablishments
    {
        IList<EstablishmentResponse> Execute(GetEstablishmentsByUrnsRequest request);
        IList<EstablishmentResponse> Execute(GetEstablishmentsByUkprnsRequest request);
        IList<EstablishmentResponse> Execute(string[] trustUids);
    }
}
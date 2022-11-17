using System.Collections.Generic;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetEstablishmentsByUrns
    {
        IList<EstablishmentResponse> Execute(GetEstablishmentsByUrnsRequest request);
    }
}
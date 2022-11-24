using System.Collections.Generic;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetTrustsByUkprns
    {
        IList<TrustResponse> Execute(GetTrustsByUkprnsRequest request);
    }
}
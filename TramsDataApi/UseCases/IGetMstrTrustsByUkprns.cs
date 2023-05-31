using System.Collections.Generic;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetMstrTrustsByUkprns
    {
        IList<MasterTrustResponse> Execute(GetTrustsByUkprnsRequest request);
    }
}
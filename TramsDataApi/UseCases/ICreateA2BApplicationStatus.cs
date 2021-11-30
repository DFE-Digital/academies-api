using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public interface ICreateA2BApplicationStatus
    {
        A2BApplicationStatusResponse Execute(A2BApplicationStatusCreateRequest request);
    }
}
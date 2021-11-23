using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public interface ICreateA2BApplication
    {
        A2BApplicationResponse Execute(A2BApplicationCreateRequest request);
    }
}
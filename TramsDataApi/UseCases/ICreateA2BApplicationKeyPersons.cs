using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public interface ICreateA2BApplicationKeyPersons
    {
        A2BApplicationKeyPersonsResponse Execute(A2BApplicationKeyPersonsCreateRequest request);
    }
}
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public interface IGetA2BApplicationKeyPersons
    {
        A2BApplicationKeyPersonsResponse Execute(A2BApplicationKeyPersonsByIdRequest request);
    }
}
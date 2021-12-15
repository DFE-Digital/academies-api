using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public interface ICreateA2BSchoolLease
    {
        A2BSchoolLeaseResponse Execute(A2BSchoolLeaseCreateRequest request);
    }
}
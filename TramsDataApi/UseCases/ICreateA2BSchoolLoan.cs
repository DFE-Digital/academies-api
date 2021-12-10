using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public interface ICreateA2BSchoolLoan
    {
        A2BSchoolLoanResponse Execute(A2BSchoolLoanCreateRequest request);
    }
}
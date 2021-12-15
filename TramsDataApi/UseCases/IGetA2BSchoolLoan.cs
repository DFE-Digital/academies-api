using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public interface IGetA2BSchoolLoan
    {
        A2BSchoolLoanResponse Execute(string loanId);
    }
}
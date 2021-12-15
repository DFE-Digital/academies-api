using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IA2BSchoolLoanGateway
    {
        A2BSchoolLoan CreateA2BSchoolLoan(A2BSchoolLoan schoolLoan);
        A2BSchoolLoan GetByLoanId(string loanId);
    }
}
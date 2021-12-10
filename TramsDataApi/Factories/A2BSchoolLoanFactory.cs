using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.ApplyToBecome;

namespace TramsDataApi.Factories
{
    public class A2BSchoolLoanFactory
    {
        public static A2BSchoolLoan Create(A2BSchoolLoanCreateRequest request)
        {
            return request == null
                ? null
                : new A2BSchoolLoan
                {
                    SchoolLoanId = request.SchoolLoanId,
                    SchoolLoanAmount = request.SchoolLoanAmount,
                    SchoolLoanPurpose = request.SchoolLoanPurpose,
                    SchoolLoanProvider = request.SchoolLoanProvider,
                    SchoolLoanInterestRate = request.SchoolLoanInterestRate,
                    SchoolLoanSchedule = request.SchoolLoanSchedule
                };
        }
    }
}
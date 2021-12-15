using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.Factories
{
    public class A2BSchoolLoanResponseFactory
    {
        public static A2BSchoolLoanResponse Create(A2BSchoolLoan schoolLoan)
        {
            return schoolLoan == null
                ? null
                : new A2BSchoolLoanResponse
                {
                    SchoolLoanId = schoolLoan.SchoolLoanId,
                    SchoolLoanAmount = schoolLoan.SchoolLoanAmount,
                    SchoolLoanPurpose = schoolLoan.SchoolLoanPurpose,
                    SchoolLoanProvider = schoolLoan.SchoolLoanProvider,
                    SchoolLoanInterestRate = schoolLoan.SchoolLoanInterestRate,
                    SchoolLoanSchedule = schoolLoan.SchoolLoanSchedule
                };
        }
    }
}
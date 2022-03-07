using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.ApplyToBecome;
using TramsDataApi.ServiceModels.ApplyToBecome;

namespace TramsDataApi.Factories
{
    public class A2BSchoolLoanServiceModelFactory
    {
        public static A2BSchoolLoanServiceModel Create(A2BSchoolLoan schoolLoan)
        {
            return schoolLoan == null
                ? null
                : new A2BSchoolLoanServiceModel
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
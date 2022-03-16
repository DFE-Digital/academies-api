using TramsDataApi.DatabaseModels;
using TramsDataApi.ServiceModels.ApplyToBecome;

namespace TramsDataApi.Factories.A2BApplicationFactories
{
    public class A2BSchoolLoanFactory
    {
        public static A2BSchoolLoan Create(A2BSchoolLoanServiceModel request)
        {
            return request == null
                ? null
                : new A2BSchoolLoan
                {
                    SchoolLoanAmount = request.SchoolLoanAmount,
                    SchoolLoanPurpose = request.SchoolLoanPurpose,
                    SchoolLoanProvider = request.SchoolLoanProvider,
                    SchoolLoanInterestRate = request.SchoolLoanInterestRate,
                    SchoolLoanSchedule = request.SchoolLoanSchedule
                };
        }
    }
}
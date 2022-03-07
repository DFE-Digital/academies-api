using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ServiceModels.ApplyToBecome;

namespace TramsDataApi.Factories
{
    public class A2BSchoolLeaseFactory
    {
        public static A2BSchoolLease Create(A2BSchoolLeaseServiceModel request)
        {
            return request == null
                ? null
                : new A2BSchoolLease
                {
                    SchoolLeaseId = request.SchoolLeaseId,
                    SchoolLeaseTerm = request.SchoolLeaseTerm,
                    SchoolLeaseRepaymentValue = request.SchoolLeaseRepaymentValue,
                    SchoolLeaseInterestRate = request.SchoolLeaseInterestRate,
                    SchoolLeasePaymentToDate = request.SchoolLeasePaymentToDate,
                    SchoolLeasePurpose = request.SchoolLeasePurpose,
                    SchoolLeaseValueOfAssets = request.SchoolLeaseValueOfAssets,
                    SchoolLeaseResponsibleForAssets = request.SchoolLeaseResponsibleForAssets
                };
        }
    }
}
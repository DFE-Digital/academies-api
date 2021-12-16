using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.Factories
{
    public class A2BSchoolLeaseResponseFactory
    {
        public static A2BSchoolLeaseResponse Create(A2BSchoolLease schoolLease)
        {
            return schoolLease == null
                ? null
                : new A2BSchoolLeaseResponse
                {
                    SchoolLeaseId = schoolLease.SchoolLeaseId,
                    SchoolLeaseTerm = schoolLease.SchoolLeaseTerm,
                    SchoolLeaseRepaymentValue = schoolLease.SchoolLeaseRepaymentValue,
                    SchoolLeaseInterestRate = schoolLease.SchoolLeaseInterestRate,
                    SchoolLeasePaymentToDate = schoolLease.SchoolLeasePaymentToDate,
                    SchoolLeasePurpose = schoolLease.SchoolLeasePurpose,
                    SchoolLeaseValueOfAssets = schoolLease.SchoolLeaseValueOfAssets,
                    SchoolLeaseResponsibleForAssets = schoolLease.SchoolLeaseResponsibleForAssets
                };
        }
    }
}
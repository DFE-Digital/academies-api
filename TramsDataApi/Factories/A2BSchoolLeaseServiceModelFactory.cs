using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.ApplyToBecome;
using TramsDataApi.ServiceModels.ApplyToBecome;

namespace TramsDataApi.Factories
{
    public class A2BSchoolLeaseServiceModelFactory
    {
        public static A2BSchoolLeaseServiceModel Create(A2BSchoolLease schoolLease)
        {
            return schoolLease == null
                ? null
                : new A2BSchoolLeaseServiceModel
                {
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
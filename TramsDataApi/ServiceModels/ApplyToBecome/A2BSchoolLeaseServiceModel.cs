namespace TramsDataApi.ServiceModels.ApplyToBecome
{
    public class A2BSchoolLeaseServiceModel
    {
        public int SchoolLeaseId {get; set;}
        public string SchoolLeaseTerm {get; set;}
        public decimal SchoolLeaseRepaymentValue {get; set;}
        public decimal SchoolLeaseInterestRate {get; set;}
        public decimal SchoolLeasePaymentToDate {get; set;}
        public string SchoolLeasePurpose {get; set;}
        public string SchoolLeaseValueOfAssets {get; set;}
        public string SchoolLeaseResponsibleForAssets {get; set;}
    }
}
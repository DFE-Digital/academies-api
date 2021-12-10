namespace TramsDataApi.RequestModels.ApplyToBecome
{
    public class A2BSchoolLoanCreateRequest
    {
        public string SchoolLoanId {get; set;}
        public string SchoolLoanAmount {get; set;}
        public string SchoolLoanPurpose {get; set;}
        public string SchoolLoanProvider {get; set;}
        public string SchoolLoanInterestRate {get; set;}
        public string SchoolLoanSchedule {get; set;}
    }
}
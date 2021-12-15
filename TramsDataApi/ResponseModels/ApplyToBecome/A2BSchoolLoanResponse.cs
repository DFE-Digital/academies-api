namespace TramsDataApi.ResponseModels.ApplyToBecome
{
    public class A2BSchoolLoanResponse
    {
        public string SchoolLoanId {get; set;}
        public decimal? SchoolLoanAmount {get; set;}
        public string SchoolLoanPurpose {get; set;}
        public string SchoolLoanProvider {get; set;}
        public string SchoolLoanInterestRate {get; set;}
        public string SchoolLoanSchedule {get; set;}
    }
}
using System;

namespace TramsDataApi.ServiceModels.ApplyToBecome
{
    public class A2BSchoolLoanServiceModel
    {
        public decimal? SchoolLoanAmount {get; set;}
        public string SchoolLoanPurpose {get; set;}
        public string SchoolLoanProvider {get; set;}
        public string SchoolLoanInterestRate {get; set;}
        public string SchoolLoanSchedule {get; set;}
        public Guid DynamicsSchoolLoanId { get; set; }
    }
}
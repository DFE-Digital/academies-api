using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Table("A2BSchoolLoan", Schema = "sdd")]
    public class A2BSchoolLoan
    {
        [Key]
        public string SchoolLoanId {get; set;}
        public string SchoolLoanAmount {get; set;}
        public string SchoolLoanPurpose {get; set;}
        public string SchoolLoanProvider {get; set;}
        public string SchoolLoanInterestRate {get; set;}
        public string SchoolLoanSchedule {get; set;}
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Table("A2BSchoolLease", Schema = "sdd")]
    public class A2BSchoolLease
    {
        [Key]
        public string SchoolLeaseId {get; set;}
        
        public string SchoolLeaseTerm {get; set;}
        public string SchoolLeaseRepaymentValue {get; set;}
        public string SchoolLeaseInterestRate {get; set;}
        public string SchoolLeasePaymentToDate {get; set;}
        public string SchoolLeasePurpose {get; set;}
        public string SchoolLeaseValueOfAssets {get; set;}
        public string SchoolLeaseResponsibleForAssets {get; set;}
        public int ApplyingSchoolId { get; set; }
    }
}
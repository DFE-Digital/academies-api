using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Table("A2BSchoolLease", Schema = "sdd")]
    public class A2BSchoolLease
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolLeaseId {get; set;}

        public string SchoolLeaseTerm {get; set;}

        [Column(TypeName = "decimal(18,2)")]
        public decimal SchoolLeaseRepaymentValue {get; set;}
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal SchoolLeaseInterestRate {get; set;}
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal SchoolLeasePaymentToDate {get; set;}
        public string SchoolLeasePurpose {get; set;}
        public string SchoolLeaseValueOfAssets {get; set;}
        public string SchoolLeaseResponsibleForAssets {get; set;}
        
        public int ApplyingSchoolId { get; set; }
        public virtual A2BApplicationApplyingSchool A2BApplicationApplyingSchool { get; set; }
    }
}
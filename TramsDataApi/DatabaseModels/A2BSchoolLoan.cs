using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Table("A2BSchoolLoan", Schema = "sdd")]
    public class A2BSchoolLoan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolLoanId {get; set;}

        [Column(TypeName = "decimal(18,2)")]
        public decimal? SchoolLoanAmount {get; set;}
        public string SchoolLoanPurpose {get; set;}
        public string SchoolLoanProvider {get; set;}
        public string SchoolLoanInterestRate {get; set;}
        public string SchoolLoanSchedule {get; set;}
        
        public int ApplyingSchoolId { get; set; }
        public virtual A2BApplicationApplyingSchool A2BApplicationApplyingSchool { get; set; }
    }
}
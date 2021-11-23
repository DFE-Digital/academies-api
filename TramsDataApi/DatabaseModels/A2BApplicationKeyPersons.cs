using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Table("A2BApplicationKeyPersons", Schema = "sdd")]
    public class A2BApplicationKeyPersons
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KeyPersonId {get; set;}
        
        public string Name {get; set;}
        public string KeyPersonDateOfBirth {get; set;}
        public string KeyPersonBiography {get; set;}
        public string KeyPersonCeoExecutive {get; set;}
        public string KeyPersonChairOfTrust {get; set;}
        public string KeyPersonFinancialDirector {get; set;}
        public string KeyPersonFinancialDirectorTime {get; set;}
        public string KeyPersonMember {get; set;}
        public string KeyPersonOther {get; set;}
        public string KeyPersonTrustee {get; set;}
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Table("A2BApplicationKeyPersons", Schema = "sdd")]
    public class A2BApplicationKeyPersons
    {
        public string Name {get; set;}
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KeyPersonId {get; set;}
        
        public DateTime? KeyPersonDateOfBirth {get; set;}
        public string KeyPersonBiography {get; set;}
        public bool? KeyPersonCeoExecutive {get; set;}
        public bool? KeyPersonChairOfTrust {get; set;}
        public bool? KeyPersonFinancialDirector {get; set;}
        public bool? KeyPersonMember {get; set;}
        public bool? KeyPersonOther {get; set;}
        public bool? KeyPersonTrustee {get; set;}
        
        public string ApplicationId { get; set; }
        public virtual A2BApplication A2BApplication { get; set; }

        public Guid DynamicsKeyPersonId { get; set; }
    }
}
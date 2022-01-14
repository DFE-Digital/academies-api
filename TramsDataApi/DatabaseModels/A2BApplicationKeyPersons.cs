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
        public string KeyPersonFinancialDirectorTime {get; set;}
        public string KeyPersonMember {get; set;}
        public string KeyPersonOther {get; set;}
        public string KeyPersonTrustee {get; set;}
        
        public string ApplicationId { get; set; }
        public A2BApplication Application { get; set; }
    }
}
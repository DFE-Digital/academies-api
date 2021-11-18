using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Table("A2BApplicationStatus", Schema = "sdd")]
    public class A2BApplicationStatus
    {
        [Key]
        public string ApplicationStatusId {get; set;}
        
        public string Name {get; set;}
    }
}
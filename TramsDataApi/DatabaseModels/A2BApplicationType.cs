
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Table("A2BApplicationType", Schema = "sdd")]
    public class A2BApplicationType
    {
        [Key]
        public int Id { get; set; }
        public string Name {get; set;}
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Table("A2BSelectOption", Schema = "sdd")]
    public class A2BSelectOption
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Table("A2BCreateSchoolRequest", Schema = "sdd")]
    public class A2BCreateSchoolRequest
    {
        [Key]
        public string SchoolId { get; set; }
        
        public string Name { get; set; }
        public string ApplicationId { get; set; }
    }
}
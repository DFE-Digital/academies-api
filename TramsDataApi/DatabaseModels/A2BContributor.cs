using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Table("A2BContributor", Schema = "sdd")]
    public class A2BContributor 
    {
        [Key]
        public string ContributorUserId { get; set; }
        
        public string ApplicationTypeId { get; set; }
        public string ContributorAppIdTest { get; set; }
        public string ContributorUserName { get; set; }
    }
}
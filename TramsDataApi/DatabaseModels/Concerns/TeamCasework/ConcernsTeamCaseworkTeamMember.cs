using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels.Concerns.TeamCasework
{
    [Table("ConcernsCaseworkTeamMember", Schema = "sdd")]
    public class ConcernsCaseworkTeamMember
    {
        [Key]
        public Guid TeamMemberId { get; set; }
        public string TeamMember { get; set; }
    }
}

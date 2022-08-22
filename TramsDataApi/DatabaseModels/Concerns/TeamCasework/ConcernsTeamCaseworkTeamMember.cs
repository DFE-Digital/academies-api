using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels.Concerns.TeamCasework
{
    [Table("ConcernsTeamCaseworkTeamMember", Schema = "sdd")]
    public class ConcernsTeamCaseworkTeamMember
    {
        [Key]
        public Guid TeamMemberId { get; set; }
        public string TeamMember { get; set; }
    }
}

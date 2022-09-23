using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels.Concerns.TeamCasework
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    [Table("ConcernsCaseworkTeamMember", Schema = "sdd")]
    public class ConcernsCaseworkTeamMember
    {
        [Key]
        public Guid TeamMemberId { get; set; }
        public string TeamMember { get; set; }
    }
}

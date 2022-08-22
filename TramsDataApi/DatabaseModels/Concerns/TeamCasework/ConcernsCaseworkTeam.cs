using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels.Concerns.TeamCasework
{
    [Table("ConcernsTeamCaseworkTeam", Schema = "sdd")]
    public class ConcernsCaseworkTeam
    {
        public string Id { get; set; }

        public virtual List<ConcernsTeamCaseworkTeamMember> TeamMembers { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels.Concerns.TeamCasework
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    [Table("ConcernsCaseworkTeam", Schema = "sdd")]
    public class ConcernsCaseworkTeam
    {
        public string Id { get; set; }

        public virtual List<ConcernsCaseworkTeamMember> TeamMembers { get; set; }
    }
}

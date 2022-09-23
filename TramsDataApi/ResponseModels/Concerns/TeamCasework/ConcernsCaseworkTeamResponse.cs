using System;

namespace TramsDataApi.ResponseModels.Concerns.TeamCasework
{
    [Obsolete("This class is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class ConcernsCaseworkTeamResponse
    {
        public string OwnerId { get; set; }

        public string[] TeamMembers { get; set; }
    }
}

using System;

namespace TramsDataApi.RequestModels.Concerns.TeamCasework
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class ConcernsCaseworkTeamUpdateRequest
    {
        public string OwnerId { get; set; }

        public string[] TeamMembers { get; set; }
    }
}

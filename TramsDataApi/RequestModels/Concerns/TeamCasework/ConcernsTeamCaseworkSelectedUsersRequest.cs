namespace TramsDataApi.RequestModels.Concerns.TeamCasework
{
    public class ConcernsTeamCaseworkSelectedUsersUpdateRequest
    {
        public string OwnerId { get; set; }

        public string[] SelectedTeamMembers { get; set; }
    }
}

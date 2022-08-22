using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Table("ConcernsTeamCaseworkSelectedUser", Schema = "sdd")]
    public class ConcernsTeamCaseworkSelectedUser
    {
        public string OwnerId { get; set; }

        public string SelectedTeamMember { get; set; }
    }
}

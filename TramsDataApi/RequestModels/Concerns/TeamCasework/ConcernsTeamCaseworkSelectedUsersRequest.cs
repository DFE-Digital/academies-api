using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramsDataApi.RequestModels.Concerns.TeamCasework
{
    public class ConcernsTeamCaseworkSelectedUsersRequest
    {
        public string OwnerId { get; set; }

        public string[] SelectedTeamMembers { get; set; }
    }
}

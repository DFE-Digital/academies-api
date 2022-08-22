using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels.Concerns.TeamCasework;

namespace TramsDataApi.Gateways
{
    public interface IConcernsTeamCaseworkGateway
    {
        Task<ConcernsCaseworkTeam> GetByOwnerId(string ownerId, CancellationToken cancellationToken);
        Task UpdateTeamCaseworkUserSelections(string ownerId, IList<ConcernsTeamCaseworkTeamMember> selectedUsers, CancellationToken cancellationToken);
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels.Concerns.TeamCasework;

namespace TramsDataApi.Gateways
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public interface IConcernsTeamCaseworkGateway
    {
        Task<ConcernsCaseworkTeam> GetByOwnerId(string ownerId, CancellationToken cancellationToken);
        Task UpdateCaseworkTeam(ConcernsCaseworkTeam team, CancellationToken cancellationToken);
        Task AddCaseworkTeam(ConcernsCaseworkTeam team, CancellationToken cancellationToken);
        Task<string[]> GetTeamOwners(CancellationToken cancellationToken);
    }
}

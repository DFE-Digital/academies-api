﻿using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels.Concerns.TeamCasework;

namespace TramsDataApi.Gateways
{
    public interface IConcernsTeamCaseworkGateway
    {
        Task<ConcernsCaseworkTeam> GetByOwnerId(string ownerId, CancellationToken cancellationToken);
        Task UpdateCaseworkTeam(ConcernsCaseworkTeam team, CancellationToken cancellationToken);
        Task AddCaseworkTeam(ConcernsCaseworkTeam team, CancellationToken cancellationToken);
        Task<string[]> GetTeamOwners(CancellationToken cancellationToken);
    }
}

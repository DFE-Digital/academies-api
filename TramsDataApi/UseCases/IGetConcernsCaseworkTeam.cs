using System;
using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.ResponseModels.Concerns.TeamCasework;

namespace TramsDataApi.UseCases
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public interface IGetConcernsCaseworkTeam
    {
        public Task<ConcernsCaseworkTeamResponse> Execute(string ownerId, CancellationToken cancellationToken);
    }
}

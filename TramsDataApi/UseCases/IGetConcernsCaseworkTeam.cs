using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.ResponseModels.Concerns.TeamCasework;

namespace TramsDataApi.UseCases
{
    public interface IGetConcernsCaseworkTeam
    {
        public Task<ConcernsCaseworkTeamResponse> Execute(string ownerId, CancellationToken cancellationToken);
    }
}

using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.RequestModels.Concerns.TeamCasework;
using TramsDataApi.ResponseModels.Concerns.TeamCasework;

namespace TramsDataApi.UseCases
{
    public interface IUpdateConcernsTeamCaseworkSelectedUsers
    {
        public Task<ConcernsCaseworkTeamResponse> Execute(ConcernsCaseworkTeamUpdateRequest updateRequest, CancellationToken cancellationToken);
    }
}

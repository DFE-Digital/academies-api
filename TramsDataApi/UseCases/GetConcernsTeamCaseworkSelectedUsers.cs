using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.ResponseModels.Concerns.TeamCasework;

namespace TramsDataApi.UseCases
{
    public class GetConcernsTeamCaseworkSelectedUsers : IGetConcernsTeamCaseworkSelectedUsers
    {
        public Task<ConcernsTeamCaseworkSelectedUsersResponse> Execute(string ownerId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}

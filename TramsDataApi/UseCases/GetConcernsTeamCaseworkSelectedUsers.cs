using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.Concerns.TeamCasework;

namespace TramsDataApi.UseCases
{
    public class GetConcernsTeamCaseworkSelectedUsers : IGetConcernsTeamCaseworkSelectedUsers
    {
        private readonly IConcernsTeamCaseworkGateway _gateway;

        public GetConcernsTeamCaseworkSelectedUsers(IConcernsTeamCaseworkGateway gateway)
        {
            _gateway = gateway ?? throw new ArgumentNullException(nameof(gateway));
        }

        public async Task<ConcernsTeamCaseworkSelectedUsersResponse> Execute(string ownerId, CancellationToken cancellationToken)
        {
            var record = await _gateway.GetByOwnerId(ownerId, cancellationToken);

            if (record is null)
            {
                return null;
            }
            return new ConcernsTeamCaseworkSelectedUsersResponse { OwnerId = ownerId, SelectedTeamMembers = record.TeamMembers.Select(x => x.TeamMember).ToArray() };
        }
    }
}

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels.Concerns.TeamCasework;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.Concerns.TeamCasework;
using TramsDataApi.ResponseModels.Concerns.TeamCasework;

namespace TramsDataApi.UseCases
{
    public class UpdateConcernsCaseworkTeam : IUpdateConcernsCaseworkTeam
    {
        private readonly IConcernsTeamCaseworkGateway _gateway;
        public UpdateConcernsCaseworkTeam(IConcernsTeamCaseworkGateway gateway)
        {
            _gateway = gateway ?? throw new ArgumentNullException(nameof(gateway));
        }

        public async Task<ConcernsCaseworkTeamResponse> Execute(ConcernsCaseworkTeamUpdateRequest updateRequest, CancellationToken cancellationToken)
        {
            _ = updateRequest ?? throw new ArgumentNullException(nameof(updateRequest));

            var ownerId = updateRequest.OwnerId;
            var newSelections = updateRequest.TeamMembers.Select(x => new ConcernsCaseworkTeamMember { TeamMember = x }).ToArray();

            var team = await _gateway.GetByOwnerId(updateRequest.OwnerId, cancellationToken);

            if (team == null)
            {
                team = new ConcernsCaseworkTeam { Id = updateRequest.OwnerId, TeamMembers = updateRequest.TeamMembers.Select(x => new ConcernsCaseworkTeamMember { TeamMember = x}).ToList() };
                await _gateway.AddCaseworkTeam(team, cancellationToken);
            }
            else
            {
                team.TeamMembers = updateRequest.TeamMembers.Select(x => new ConcernsCaseworkTeamMember { TeamMember = x }).ToList();

                await _gateway.UpdateCaseworkTeam(team, cancellationToken);
            }

            return new ConcernsCaseworkTeamResponse { OwnerId = updateRequest.OwnerId, TeamMembers = newSelections.Select(x => x.TeamMember).ToArray() };
        }
    }
}

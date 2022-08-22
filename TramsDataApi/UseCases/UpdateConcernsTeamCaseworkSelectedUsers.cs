using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.Concerns.TeamCasework;
using TramsDataApi.ResponseModels.Concerns.TeamCasework;

namespace TramsDataApi.UseCases
{
    public class UpdateConcernsTeamCaseworkSelectedUsers : IUpdateConcernsTeamCaseworkSelectedUsers
    {
        private readonly IConcernsTeamCaseworkGateway _gateway;
        public UpdateConcernsTeamCaseworkSelectedUsers(IConcernsTeamCaseworkGateway gateway)
        {
            _gateway = gateway ?? throw new ArgumentNullException(nameof(gateway));
        }

        public async Task<ConcernsTeamCaseworkSelectedUsersResponse> Execute(ConcernsTeamCaseworkSelectedUsersUpdateRequest updateRequest, CancellationToken cancellationToken)
        {
            _ = updateRequest ?? throw new ArgumentNullException(nameof(updateRequest));

            var ownerId = updateRequest.OwnerId;
            var newSelections = updateRequest.SelectedTeamMembers.Select(x => new ConcernsTeamCaseworkSelectedUser { OwnerId = updateRequest.OwnerId, SelectedTeamMember = x}).ToArray();
            await _gateway.UpdateTeamCaseworkUserSelections(updateRequest.OwnerId, newSelections, cancellationToken);

            return new ConcernsTeamCaseworkSelectedUsersResponse { OwnerId = updateRequest.OwnerId, SelectedTeamMembers = newSelections.Select(x => x.SelectedTeamMember).ToArray() };
        }
    }
}

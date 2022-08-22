using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using TramsDataApi.DatabaseModels.Concerns.TeamCasework;
using static Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;

namespace TramsDataApi.Gateways
{
    public interface IConcernsTeamCaseworkGateway
    {
        Task<IList<ConcernsTeamCaseworkTeamMember>> GetByOwnerId(string ownerId, CancellationToken cancellationToken);
        Task UpdateTeamCaseworkUserSelections(string ownerId, IList<ConcernsTeamCaseworkTeamMember> selectedUsers, CancellationToken cancellationToken);
    }

    public class ConcernsTeamCaseworkGateway : IConcernsTeamCaseworkGateway
    {
        private readonly TramsDbContext _tramsDbContext;

        public ConcernsTeamCaseworkGateway(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext ?? throw new ArgumentNullException(nameof(tramsDbContext));
        }

        public async Task<IList<ConcernsTeamCaseworkTeamMember>> GetByOwnerId(string ownerId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(ownerId))
            {
                throw new ArgumentNullException(nameof(ownerId));
            }

            var team = await _tramsDbContext.ConcernsTeamCaseworkTeam
                .Include(t => t.TeamMembers)
                .FirstOrDefaultAsync(x => x.Id == ownerId);

            return team == null ? new List<ConcernsTeamCaseworkTeamMember>() : team.TeamMembers.ToList();
        }

        public async Task UpdateTeamCaseworkUserSelections(string ownerId, IList<ConcernsTeamCaseworkTeamMember> selectedUsers, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(ownerId))
            {
                throw new ArgumentNullException(nameof(ownerId));
            }
            _ = selectedUsers ?? throw new ArgumentNullException(nameof(selectedUsers));

            var team = await _tramsDbContext.ConcernsTeamCaseworkTeam.FirstOrDefaultAsync(x => x.Id == ownerId);

            if (team == null)
            {
                team = new ConcernsCaseworkTeam { Id = ownerId, TeamMembers = selectedUsers.ToList() };
                _tramsDbContext.Add(team);
            }
            else
            {
                team.TeamMembers = selectedUsers.ToList();
            }

            await _tramsDbContext.SaveChangesAsync();
        }
    }
}

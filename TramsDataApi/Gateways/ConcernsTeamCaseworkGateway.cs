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
    public class ConcernsTeamCaseworkGateway : IConcernsTeamCaseworkGateway
    {
        private readonly TramsDbContext _tramsDbContext;

        public ConcernsTeamCaseworkGateway(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext ?? throw new ArgumentNullException(nameof(tramsDbContext));
        }

        public async Task<ConcernsCaseworkTeam> GetByOwnerId(string ownerId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(ownerId))
            {
                throw new ArgumentNullException(nameof(ownerId));
            }

            var team = await _tramsDbContext.ConcernsTeamCaseworkTeam
                .Include(t => t.TeamMembers)
                .FirstOrDefaultAsync(x => x.Id == ownerId);

            return team; 
        }

        public async Task UpdateTeamCaseworkUserSelections(string ownerId, IList<ConcernsTeamCaseworkTeamMember> selectedUsers, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(ownerId))
            {
                throw new ArgumentNullException(nameof(ownerId));
            }
            _ = selectedUsers ?? throw new ArgumentNullException(nameof(selectedUsers));

            var team = await this.GetByOwnerId(ownerId, cancellationToken);

            if (team == null)
            {
                team = new ConcernsCaseworkTeam { Id = ownerId, TeamMembers = selectedUsers.ToList() };
                _tramsDbContext.Add(team);
            }
            else
            {
                var membersToRemove = team.TeamMembers.Where(x => !selectedUsers.Any(s => s.TeamMember == x.TeamMember))
                    .ToArray();

                foreach (var member in membersToRemove)
                {
                    team.TeamMembers.Remove(member);
                }

                var newMembersModels = selectedUsers.Where(s => !team.TeamMembers.Any(x => s.TeamMember == x.TeamMember))
                    .Select(s => new ConcernsTeamCaseworkTeamMember { TeamMember = s.TeamMember })
                    .ToArray();

                team.TeamMembers.AddRange(newMembersModels);

                _tramsDbContext.ConcernsTeamCaseworkTeamMember.RemoveRange(membersToRemove);
            }

            await _tramsDbContext.SaveChangesAsync();
        }
    }
}

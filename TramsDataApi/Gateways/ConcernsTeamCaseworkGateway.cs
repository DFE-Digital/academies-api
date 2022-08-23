using System;
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

        public async Task UpdateCaseworkTeam(ConcernsCaseworkTeam team, CancellationToken cancellationToken)
        {
            _ = team ?? throw new ArgumentNullException(nameof(team));
            if (string.IsNullOrWhiteSpace(team.Id))
            {
                throw new ArgumentNullException(nameof(team.Id));
            }
            _ = team.TeamMembers ?? throw new ArgumentNullException(nameof(team.TeamMembers));

            var existingTeam = await this.GetByOwnerId(team.Id, cancellationToken);

            if (existingTeam == null)
            {
                _tramsDbContext.Add(team);
            }
            else
            {
                var membersToRemove = existingTeam.TeamMembers.Where(x => !team.TeamMembers.Any(s => s.TeamMember == x.TeamMember))
                    .ToArray();

                foreach (var member in membersToRemove)
                {
                    existingTeam.TeamMembers.Remove(member);
                }

                var newTeamMembers = team.TeamMembers.Where(s => !existingTeam.TeamMembers.Any(x => s.TeamMember == x.TeamMember))
                    .Select(s => new ConcernsCaseworkTeamMember { TeamMember = s.TeamMember })
                    .ToArray();

                existingTeam.TeamMembers.AddRange(newTeamMembers);

                _tramsDbContext.ConcernsTeamCaseworkTeamMember.RemoveRange(membersToRemove);
            }

            await _tramsDbContext.SaveChangesAsync();
        }
    }
}

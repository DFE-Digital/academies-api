using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public async Task AddCaseworkTeam(ConcernsCaseworkTeam team, CancellationToken cancellationToken)
        {
            _ = team ?? throw new ArgumentNullException(nameof(team));            
            _ = team.TeamMembers ?? throw new ArgumentNullException(nameof(team.TeamMembers));
            
            _tramsDbContext.ConcernsTeamCaseworkTeam.Add(team);
            await _tramsDbContext.SaveChangesAsync(cancellationToken);
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
            
            _tramsDbContext.ConcernsTeamCaseworkTeam.Update(team);
            await _tramsDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

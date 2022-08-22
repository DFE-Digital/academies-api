using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using static Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;

namespace TramsDataApi.Gateways
{
    public interface IConcernsTeamCaseworkGateway
    {
        Task<IList<ConcernsTeamCaseworkSelectedUser>> GetByOwnerId(string ownerId, CancellationToken cancellationToken);
        Task UpdateTeamCaseworkUserSelections(string ownerId, IList<ConcernsTeamCaseworkSelectedUser> selectedUsers, CancellationToken cancellationToken);
    }

    public class ConcernsTeamCaseworkGateway : IConcernsTeamCaseworkGateway
    {
        private readonly TramsDbContext _tramsDbContext;

        public ConcernsTeamCaseworkGateway(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext ?? throw new ArgumentNullException(nameof(tramsDbContext));
        }

        public async Task<IList<ConcernsTeamCaseworkSelectedUser>> GetByOwnerId(string ownerId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(ownerId))
            {
                throw new ArgumentNullException(nameof(ownerId));
            }

            return await _tramsDbContext.ConcernsTeamCaseworkSelectedUsers
                .Where(x => x.OwnerId == ownerId)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateTeamCaseworkUserSelections(string ownerId, IList<ConcernsTeamCaseworkSelectedUser> selectedUsers, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(ownerId))
            {
                throw new ArgumentNullException(nameof(ownerId));
            }
            _ = selectedUsers ?? throw new ArgumentNullException(nameof(selectedUsers));

            var oldSelections = await GetByOwnerId(ownerId, cancellationToken);
            
            _tramsDbContext.ConcernsTeamCaseworkSelectedUsers.RemoveRange(oldSelections);
            await _tramsDbContext.ConcernsTeamCaseworkSelectedUsers.AddRangeAsync(selectedUsers);
            await _tramsDbContext.SaveChangesAsync();
        }
    }
}

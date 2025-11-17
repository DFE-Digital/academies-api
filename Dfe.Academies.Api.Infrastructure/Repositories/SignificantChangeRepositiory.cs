using Dfe.Academies.Domain.Interfaces.Repositories;
using Dfe.Academies.Domain.SignificantChange; 
using Microsoft.EntityFrameworkCore; 

namespace Dfe.Academies.Infrastructure.Repositories;

public class SignificantChangeRepositiory(SigChgMstrContext context) : ISignificantChangeRepositiory
{
    public async Task<(IEnumerable<SignificantChange>, int)> SearchSignificantChanges(string deliveryofficer, bool orderByChangeEditDate = false, bool isDescending = false, int page = 1, int count = 10, CancellationToken cancellationToken = default)
    {
        IQueryable<SignificantChange> filteredSignificantChanges = context.SignificantChanges
            .AsNoTracking()
            .Where(x => x.DeliveryLead == deliveryofficer.Trim());

        if (orderByChangeEditDate)
        {
            filteredSignificantChanges = isDescending
                ? filteredSignificantChanges.OrderByDescending(x => x.ChangeEditDate)
                : filteredSignificantChanges.OrderBy(x => x.ChangeEditDate);
        }
        else
        {
            filteredSignificantChanges = isDescending
                ? filteredSignificantChanges.OrderByDescending(x => x.ChangeCreationDate)
                : filteredSignificantChanges.OrderBy(x => x.ChangeCreationDate);
        }

        return (await filteredSignificantChanges
            .Skip((page - 1) * count).Take(count).ToListAsync(cancellationToken),
            await filteredSignificantChanges.CountAsync(cancellationToken));
    }
}

using Dfe.Academies.Domain.Interfaces.Repositories;
using Dfe.Academies.Domain.SignificantChange; 
using Microsoft.EntityFrameworkCore; 

namespace Dfe.Academies.Infrastructure.Repositories;

public class SignificantChangeRepositiory(SigChgMstrContext context) : ISignificantChangeRepositiory
{
    public async Task<(IEnumerable<SignificantChange>, int)> SearchSignificantChanges(
        string deliveryofficer,
        bool orderByChangeEditDate = false,
        bool orderDescending = false,
        int page = 1,
        int count = 10,
        CancellationToken cancellationToken = default)
    {
        IQueryable<SignificantChange> filteredSignificantChanges = context.SignificantChanges
            .AsNoTracking()
            .Where(x => x.DeliveryLead == deliveryofficer);

        // choose key selector based on whether to order by edit date or creation date
        if (orderByChangeEditDate)
        {
            filteredSignificantChanges = orderDescending
                ? filteredSignificantChanges.OrderByDescending(x => x.ChangeEditDate)
                : filteredSignificantChanges.OrderBy(x => x.ChangeEditDate);
        }
        else
        {
            filteredSignificantChanges = orderDescending
                ? filteredSignificantChanges.OrderByDescending(x => x.ChangeCreationDate)
                : filteredSignificantChanges.OrderBy(x => x.ChangeCreationDate);
        }

        var items = await filteredSignificantChanges
            .Skip((page - 1) * count)
            .Take(count)
            .ToListAsync(cancellationToken);

        var total = await filteredSignificantChanges.CountAsync(cancellationToken);

        return (items, total);
    }
}
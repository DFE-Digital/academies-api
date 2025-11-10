using Dfe.Academies.Domain.Interfaces.Repositories;
using Dfe.Academies.Domain.SignificantChange;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Infrastructure.Repositories;

public class SignificantChangeRepositiory(SigChgMstrContext context) : ISignificantChangeRepositiory
{
    public async Task<SignificantChange?> Search(string deliveryofficer, CancellationToken cancellationToken)
    { 
        var significantChange = await context.SignificantChanges
               .AsNoTracking()
               .SingleOrDefaultAsync(x => x.DeliveryLead == deliveryofficer, cancellationToken)
               .ConfigureAwait(false);

        return significantChange;
    }
}

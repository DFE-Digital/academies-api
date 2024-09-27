using Dfe.Academies.Application.Common.Models;

namespace Dfe.Academies.Application.Common.Interfaces
{
    public interface ITrustQueryService
    {
        IQueryable<TrustGovernanceQueryModel?>? GetTrustGovernanceByGroupIdOrUkprn(string? groupId, string? ukPrn);
    }
}

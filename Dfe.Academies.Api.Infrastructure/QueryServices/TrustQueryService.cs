using Dfe.Academies.Application.Common.Interfaces;
using Dfe.Academies.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Infrastructure.QueryServices
{
    internal class TrustQueryService(MstrContext context) : ITrustQueryService
    {
        public IQueryable<TrustGovernanceQueryModel?>? GetTrustGovernanceByGroupIdOrUkprn(string? groupId, string? ukPrn)
        {

            // Check if the trust exists based on GroupID or UKPRN
            var trustExists = context.Trusts.AsNoTracking().Any(t =>
                (!string.IsNullOrEmpty(groupId) && t.GroupID == groupId) ||
                (!string.IsNullOrEmpty(ukPrn) && t.UKPRN == ukPrn));

            if (!trustExists)
            {
                return null;
            }

            var query = from t in context.Trusts.AsNoTracking()
                join tg in context.TrustGovernances.AsNoTracking()
                    on t.SK equals tg.TrustId
                join grt in context.GovernanceRoleTypes.AsNoTracking()
                    on tg.GovernanceRoleTypeId equals grt.SK
                where (!string.IsNullOrEmpty(groupId) && t.GroupID == groupId) ||
                      (!string.IsNullOrEmpty(ukPrn) && t.UKPRN == ukPrn)
                select new TrustGovernanceQueryModel(t, grt, tg);

            return query;
        }
    }

}

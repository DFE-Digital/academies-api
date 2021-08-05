using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Extensions;

namespace TramsDataApi.Gateways
{
    public class TrustGateway : ITrustGateway
    {
        private readonly LegacyTramsDbContext _dbContext;

        public TrustGateway(LegacyTramsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Group GetGroupByUkprn(string ukprn)
        {
            return _dbContext.Group.FirstOrDefault(g => g.Ukprn == ukprn);
        }

        public Trust GetIfdTrustByGroupId(string groupId)
        {
            return _dbContext.Trust.FirstOrDefault(t => t.TrustRef == groupId);
        }

        public IQueryable<Trust> GetIfdTrustsByTrustRef(string[] trustRefs)
        {
            var predicate = PredicateBuilder.False<Trust>();
            foreach (var trustRef in trustRefs)
            {
                predicate = predicate.Or(t => t.TrustRef == trustRef);
            }

            return _dbContext.Trust.Where(predicate);
        }

        public IList<Group> SearchGroups(string groupName, string ukprn, string companiesHouseNumber, int page)
        {
            if (groupName == null && ukprn == null && companiesHouseNumber == null)
            {
                return _dbContext.Group.OrderBy(group => group.GroupUid).Skip((page - 1) * 10).Take(10).ToList();
            }

            return _dbContext.Group
                .Where(g => (
                    (g.GroupName.Contains(groupName) ||
                    g.Ukprn.Contains(ukprn) ||
                    g.CompaniesHouseNumber.Contains(companiesHouseNumber))
                    && g.GroupType.Contains("trust")
                ))
                .OrderBy(group => group.GroupUid)
                .Skip((page - 1) * 10).Take(10).ToList();
        }
    }
}
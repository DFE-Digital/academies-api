using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;

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

        public IList<Group> SearchGroups(string groupName, string ukprn, string companiesHouseNumber)
        {
            return _dbContext.Group
                .Where(g => (
                    (groupName == null || g.GroupName == groupName) ||
                    (ukprn == null || g.Ukprn == ukprn) ||
                    (companiesHouseNumber == null || g.CompaniesHouseNumber == companiesHouseNumber)
                ))
                .ToList();
        }
    }
}
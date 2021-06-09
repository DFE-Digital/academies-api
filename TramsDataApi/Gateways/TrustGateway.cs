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
            if (groupName == null && ukprn == null && companiesHouseNumber == null)
            {
                return _dbContext.Group.ToList();
            }
            
            return _dbContext.Group
                .Where(g => (
                    g.GroupName == groupName ||
                    g.Ukprn == ukprn ||
                    g.CompaniesHouseNumber == companiesHouseNumber
                ))
                .ToList();
        }
    }
}
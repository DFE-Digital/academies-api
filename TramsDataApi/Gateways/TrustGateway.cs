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

        public IList<Group> SearchGroups(string groupName, string ukprn, string companiesHouseNumber, int page)
        {
            if (groupName == null && ukprn == null && companiesHouseNumber == null)
            {
                return _dbContext.Group.OrderBy(group => group.GroupUid).Skip((page - 1) * 10).Take(10).ToList();
            }

            return _dbContext.Group
                .Where(g => (
                    g.GroupName.Contains(groupName) ||
                    g.Ukprn.Contains(ukprn) ||
                    g.CompaniesHouseNumber.Contains(companiesHouseNumber)
                ))
                .OrderBy(group => group.GroupUid)
                .Skip((page - 1) * 10).Take(10).ToList();
        }
    }
}
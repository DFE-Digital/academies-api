using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface ITrustGateway
    {
        Group GetGroupByUkprn(string ukprn);
        Trust GetIfdTrustByGroupId(string groupId);
        IQueryable<Trust> GetIfdTrustsByTrustRef(string[] trustRefs);
        IList<Group> SearchGroups(string groupName, string ukprn, string companiesHouseNumber, int page);
    }
}
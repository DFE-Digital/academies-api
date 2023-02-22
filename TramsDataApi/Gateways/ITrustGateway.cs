using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface ITrustGateway
    {
        Group GetGroupByUkPrn(string ukPrn);
        Trust GetIfdTrustByGroupId(string groupId);
        Trust GetIfdTrustByRID(string RID);
        IList<Trust> GetIfdTrustsByTrustRef(string[] trustRefs);
        (IList<Group>, int) SearchGroups(int page, int count, string groupName, string ukPrn, string companiesHouseNumber);
        IEnumerable<Group> GetMultipleGroupsByUkprn(IEnumerable<string> ukprns);
        IEnumerable<Trust> GetMultipleTrustsByGroupId(IEnumerable<string> groupIds);
    }
}
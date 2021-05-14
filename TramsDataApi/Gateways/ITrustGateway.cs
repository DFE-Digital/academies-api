using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface ITrustGateway
    {
        public Group GetGroupByUkprn(string ukprn);
        public Trust GetIfdTrustByGroupId(string groupId);

        public IList<GroupLink> SearchGroups(string groupName, string urn, string companiesHouseNumber);
    }
}
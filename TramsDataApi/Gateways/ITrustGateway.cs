using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface ITrustGateway
    {
        public Group GetGroupByUkprn(string ukprn);
        public Trust GetIfdTrustByGroupId(string groupId);

        public IList<Group> SearchGroups(string groupName, string ukprn, string companiesHouseNumber);
    }
}
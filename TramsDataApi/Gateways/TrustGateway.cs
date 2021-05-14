using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class TrustGateway : ITrustGateway
    {
        private readonly TramsDbContext _dbContext;
        private readonly IEstablishmentGateway _establishmentGateway;

        public TrustGateway(TramsDbContext dbContext, IEstablishmentGateway establishmentGateway)
        {
            _dbContext = dbContext;
            _establishmentGateway = establishmentGateway;
        }

        public Group GetGroupByUkprn(string ukprn)
        {
            return _dbContext.Group.FirstOrDefault(g => g.Ukprn == ukprn);
        }

        public Trust GetIfdTrustByGroupId(string groupId)
        {
            return _dbContext.Trust.FirstOrDefault(t => t.TrustRef == groupId);
        }

        public IList<GroupLink> SearchGroups(string groupName, string urn, string companiesHouseNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}
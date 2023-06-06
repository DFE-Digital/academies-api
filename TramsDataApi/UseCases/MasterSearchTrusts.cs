using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class MasterSearchTrusts : IMstrSearchTrusts
    {
        private readonly ITrustGateway _trustGateway;
        private readonly IEstablishmentGateway _establishmentGateway;

        public MasterSearchTrusts(ITrustGateway trustGateway, IEstablishmentGateway establishmentGateway)
        {
            _trustGateway = trustGateway;
            _establishmentGateway = establishmentGateway;
        }

        public (IEnumerable<TrustSummaryResponse>, int) Execute(
            int page = 1, 
            int count = 50, 
            string groupName = "", 
            string ukPrn = "", 
            string companiesHouseNumber = "", 
            bool includeEstablishments = true)
        {
            var (groups, recordCount) = _trustGateway.SearchGroups(page, count, groupName, ukPrn, companiesHouseNumber);

            var groupIds = groups.Select(g => g.GroupId).ToArray();
            var trustsForGroup = _trustGateway.GetMstrTrustsByTrustRef(groupIds);

            IEnumerable<Establishment> establishmentsForGroup = Enumerable.Empty<Establishment>();
            
            if (includeEstablishments)
            {
                var groupUids = groups.Select(g => g.GroupUid).ToArray();
                establishmentsForGroup = _establishmentGateway.GetByTrustUids(groupUids);
            }
            
            return (
                groups.Select(group =>
                {
                    var trust = trustsForGroup.FirstOrDefault(e => e.GroupID == group.GroupId);
                    var establishments = establishmentsForGroup.Where(e => e.TrustsCode == group.GroupUid);
                    return TrustSummaryResponseFactory.CreateFromMaster(group, establishments, trust);
                }).ToArray(),
                recordCount
            );
        }
    }
}
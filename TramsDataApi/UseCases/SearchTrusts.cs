using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class SearchTrusts : ISearchTrusts
    {
        private readonly ITrustGateway _trustGateway;
        private readonly IEstablishmentGateway _establishmentGateway;

        public SearchTrusts(ITrustGateway trustGateway, IEstablishmentGateway establishmentGateway)
        {
            _trustGateway = trustGateway;
            _establishmentGateway = establishmentGateway;
        }

        public (IEnumerable<TrustSummaryResponse>, int) Execute(int page, int count, string groupName, string ukPrn, string companiesHouseNumber, 
            bool includeEstablishments)
        {
            var (groups, recordCount) = _trustGateway.SearchGroups(page, count, groupName, ukPrn, companiesHouseNumber);

            var groupIds = groups.Select(g => g.GroupId).ToArray();
            var trustsForGroup = _trustGateway.GetIfdTrustsByTrustRef(groupIds);

            IEnumerable<Establishment> establishmentsForGroup = Enumerable.Empty<Establishment>();
            
            if (includeEstablishments)
            {
                var groupUids = groups.Select(g => g.GroupUid).ToArray();
                establishmentsForGroup = _establishmentGateway.GetByTrustUids(groupUids);
            }
            
            return (
                groups.Select(group =>
                {
                    var establishments = establishmentsForGroup.Where(e => e.TrustsCode == group.GroupUid);
                    var trust = trustsForGroup.FirstOrDefault(e => e.TrustRef == group.GroupUid);
                    return TrustSummaryResponseFactory.Create(group, establishments, trust);
                }).ToArray(),
                recordCount
            );
        }
    }
}
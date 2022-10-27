using System.Collections.Generic;
using System.Linq;
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
        
        public (IEnumerable<TrustSummaryResponse>, int) Execute(int page, int count, string groupName, string ukPrn, string companiesHouseNumber)
        {
            var (groups, recordCount) = _trustGateway.SearchGroups(page, count, groupName, ukPrn, companiesHouseNumber);

            return (
                groups.Select(group =>
                {
                    var trust = _trustGateway.GetIfdTrustByGroupId(group.GroupId);
                    var establishments = _establishmentGateway.GetByTrustUid(group.GroupUid);
                    return TrustSummaryResponseFactory.Create(group, establishments, trust);
                }), 
                recordCount
            );
        }
    }
}
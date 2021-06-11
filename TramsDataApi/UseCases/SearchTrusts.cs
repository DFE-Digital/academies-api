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
        
        public IList<TrustSummaryResponse> Execute(string groupName, string ukprn, string companiesHouseNumber, int page)
        {
            return _trustGateway.SearchGroups(groupName, ukprn, companiesHouseNumber, page)
                .Select(g => TrustSummaryResponseFactory.Create(g, _establishmentGateway.GetByTrustUid(g.GroupUid)))
                .ToList();
        }
    }
}
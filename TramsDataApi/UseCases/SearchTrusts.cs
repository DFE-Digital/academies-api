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

        public SearchTrusts(ITrustGateway trustGateway)
        {
            _trustGateway = trustGateway;
        }
        
        public IList<TrustListItemResponse> Execute(string groupName, string urn, string companiesHouseNumber)
        {
            return _trustGateway.SearchGroups(groupName, urn, companiesHouseNumber)
                .Select(g => TrustListItemResponseFactory.Create(g))
                .ToList();
        }
    }
}
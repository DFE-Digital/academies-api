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
        
        public IList<TrustListItemResponse> Execute(string groupName, string urn, string companiesHouseNumber)
        {
            return _trustGateway.SearchGroups(groupName, urn, companiesHouseNumber)
                .Select(g => TrustListItemResponseFactory.Create(g, _establishmentGateway.GetByTrustUid(g.GroupUid)))
                .ToList();
        }
    }
}
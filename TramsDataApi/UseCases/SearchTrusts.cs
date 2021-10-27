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
        
        public IList<TrustSummaryResponse> Execute(int page, int count, string groupName, string ukPrn, string companiesHouseNumber)
        {
            var x = _trustGateway
                .SearchGroups(page, count, groupName, ukPrn, companiesHouseNumber)
                .Select(g => TrustSummaryResponseFactory.Create(g, _establishmentGateway.GetByTrustUid(g.GroupUid)))
                .ToList();

            return x;
        }
    }
}
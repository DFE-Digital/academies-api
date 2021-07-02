using System.Collections.Generic;
using System.Linq;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class SearchEstablishments : IUseCase<SearchEstablishmentsRequest, IList<EstablishmentSummaryResponse>>
    {
        private readonly IEstablishmentGateway _establishmentGateway;

        public SearchEstablishments(IEstablishmentGateway establishmentGateway)
        {
            _establishmentGateway = establishmentGateway;
        }

        public IList<EstablishmentSummaryResponse> Execute(SearchEstablishmentsRequest request)
        {
            return _establishmentGateway.SearchEstablishments(request?.Urn, request?.Ukprn, request?.Name)
                .Select(e => EstablishmentSummaryResponseFactory.Create(e))
                .ToList();
        }
    }
}
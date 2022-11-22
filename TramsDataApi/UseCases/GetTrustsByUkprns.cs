using System.Collections.Generic;
using System.Linq;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class GetTrustsByUkprns
    {
        private readonly ITrustGateway _trustGateway;
        private readonly IGetEstablishments _getEstablishmentsUseCase;

        public GetTrustsByUkprns(ITrustGateway trustGateway, IGetEstablishments getEstablishmentsUseCase)
        {
            _trustGateway = trustGateway;
            _getEstablishmentsUseCase = getEstablishmentsUseCase;
        }

        public IList<TrustResponse> Execute(GetTrustsByUkprnsRequest request)
        {
            var groups = _trustGateway.GetMultipleGroupsByUkprn(request.Ukprns);

            if (!groups.Any())
            {
                return null;
            }

            var groupIds = groups.Select(group => group.GroupId);
            var groupUids = groups.Select(group => group.GroupUid).ToArray();

            var trusts = _trustGateway.GetMultipleTrustsByGroupId(groupIds).ToList();
            var establishments = _getEstablishmentsUseCase.Execute(groupUids)?.ToList().Distinct();

            // Avoid any potential duplicate `Group`s. This mimics the way that
            // we call `FirstOrDefault` when fetching a single Group.
            var distinctGroups = groups.GroupBy(g => g.Ukprn).Select(g => g.First());

            return distinctGroups.Select(group =>
                    TrustResponseFactory.Create(
                        group,
                        trusts?.FirstOrDefault(trust => trust.TrustRef == group.GroupId),
                        establishments?.Where(establishment => establishment.Trusts.Code == group.GroupUid).ToList())
                    )
                .ToList();
        }
    }
}

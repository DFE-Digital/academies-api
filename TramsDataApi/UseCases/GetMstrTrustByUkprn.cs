using Microsoft.Extensions.Logging;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class GetMstrTrustByUkprn : IGetMstrTrustByUkprn
    {
        private readonly ITrustGateway _trustGateway;
        private readonly IGetEstablishmentsByTrustUid _getEstablishmentsByTrustUid;
        private readonly ILogger<GetMstrTrustByUkprn> _logger;

        public GetMstrTrustByUkprn(ITrustGateway trustGateway, IGetEstablishmentsByTrustUid getEstablishmentsByTrustUid, ILogger<GetMstrTrustByUkprn> logger)
        {
            _trustGateway = trustGateway;
            _getEstablishmentsByTrustUid = getEstablishmentsByTrustUid;
            _logger = logger;
        }
        
        public MasterTrustResponse Execute(string ukprn)
        {

            var group = _trustGateway.GetLatestGroupByUkPrn(ukprn);
            if (group == null)
            {
                return null;
            }
            _logger.LogInformation("GetMstrTrustByUkprn: Found group with id {GroupUid}", group.GroupUid);

            var trust = _trustGateway.GetMstrTrustByGroupId(group.GroupId);
            var establishments = _getEstablishmentsByTrustUid.Execute(group.GroupUid);
            return TrustResponseFactory.CreateFromMaster(group, trust, establishments);
        }
    }
}
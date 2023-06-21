using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class GetMstrTrustByUkprn : IGetMstrTrustByUkprn
    {
        private readonly ITrustGateway _trustGateway;
        private readonly IGetEstablishmentsByTrustUid _getEstablishmentsByTrustUid;

        public GetMstrTrustByUkprn(ITrustGateway trustGateway, IGetEstablishmentsByTrustUid getEstablishmentsByTrustUid)
        {
            _trustGateway = trustGateway;
            _getEstablishmentsByTrustUid = getEstablishmentsByTrustUid;
        }
        
        public MasterTrustResponse Execute(string ukprn)
        {
            var group = _trustGateway.GetGroupByUkPrn(ukprn);
            if (group == null)
            {
                return null;
            }

            var trust = _trustGateway.GetMstrTrustByGroupId(group.GroupId);
            var establishments = _getEstablishmentsByTrustUid.Execute(group.GroupUid);
            return TrustResponseFactory.CreateFromMaster(group, trust, establishments);
        }
    }
}
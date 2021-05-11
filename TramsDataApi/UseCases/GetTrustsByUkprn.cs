using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class GetTrustsByUkprn : IGetTrustsByUkprn
    {
        private readonly ITrustGateway _trustGateway;
        private readonly IEstablishmentGateway _establishmentGateway;

        public GetTrustsByUkprn(ITrustGateway trustGateway, IEstablishmentGateway establishmentGateway)
        {
            _trustGateway = trustGateway;
            _establishmentGateway = establishmentGateway;
        }
        
        public TrustResponse Execute(string ukprn)
        {
            var group = _trustGateway.GetGroupByUkprn(ukprn);
            if (group == null)
            {
                return null;
            }

            var trust = _trustGateway.GetIfdTrustByGroupId(group.GroupId);
            var establishments = _establishmentGateway.GetByTrustUid(group.GroupUid);
            return TrustResponseFactory.Create(group, trust, establishments);
        }
    }
}
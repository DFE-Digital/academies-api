using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Gateways
{
    public interface ITrustGateway
    {
        public TrustResponse GetByUkprn(string ukprn);
        public Group GetGroupByUkprn(string ukprn);
        public Trust GetIfdTrustByGroupId(string groupId);
    }
}
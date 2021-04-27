using TramsDataApi.ResponseModels;

namespace TramsDataApi.Gateways
{
    public interface ITrustGateway
    {
        public TrustResponse GetByUkprn(string ukprn);
    }
}
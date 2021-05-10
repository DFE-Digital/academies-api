using TramsDataApi.ResponseModels;

namespace TramsDataApi.Gateways
{
    public interface IEstablishmentGateway
    {
        public EstablishmentResponse GetByUkprn(string ukprn);
    }
}
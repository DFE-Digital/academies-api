using TramsDataApi.ResponseModels;

namespace TramsDataApi.Gateways
{
    public interface IAcademyGateway
    {
        public AcademyResponse GetByUkprn(string ukprn);
    }
}
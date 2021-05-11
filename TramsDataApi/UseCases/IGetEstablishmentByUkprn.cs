using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetEstablishmentByUkprn
    {
        public EstablishmentResponse Execute(string ukprn);
    }
}
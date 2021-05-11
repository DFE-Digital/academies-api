using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetTrustsByUkprn
    {
        public TrustResponse Execute(string ukprn);
    }
}
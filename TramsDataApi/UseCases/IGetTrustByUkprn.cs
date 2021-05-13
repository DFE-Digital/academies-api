using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetTrustByUkprn
    {
        public TrustResponse Execute(string ukprn);
    }
}
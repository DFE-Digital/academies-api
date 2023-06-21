using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetMstrTrustByUkprn
    {
        public MasterTrustResponse Execute(string ukprn);
    }
}
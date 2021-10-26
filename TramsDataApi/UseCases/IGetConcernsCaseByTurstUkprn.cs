using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetConcernsCaseByTurstUkprn
    {
        public ConcernsCaseResponse Execute(string trustUkprn);
    }
}
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface ICreateConcernsCase
    {
        public ConcernsCaseResponse Execute(ConcernCaseRequest request);
    }
}
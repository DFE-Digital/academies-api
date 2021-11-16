using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IUpdateConcernsCase
    {
       ConcernsCaseResponse Execute(int urn, ConcernCaseRequest request);
    }
}
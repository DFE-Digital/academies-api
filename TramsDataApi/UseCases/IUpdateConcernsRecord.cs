using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IUpdateConcernsRecord
    {
        ConcernsRecordResponse Execute(int urn, ConcernsRecordRequest request);
    }
}
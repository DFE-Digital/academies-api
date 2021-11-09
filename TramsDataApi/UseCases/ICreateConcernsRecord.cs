using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface ICreateConcernsRecord
    {
        public ConcernsRecordResponse Execute(ConcernsRecordRequest request);
    }
}
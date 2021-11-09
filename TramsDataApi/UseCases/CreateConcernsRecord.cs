using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class CreateConcernsRecord : ICreateConcernsRecord
    {
        private readonly IConcernsRecordGateway _concernsRecordGateway;

        public CreateConcernsRecord(IConcernsRecordGateway concernsRecordGateway)
        {
            _concernsRecordGateway = concernsRecordGateway;
        }
        public ConcernsRecordResponse Execute(ConcernsRecordRequest request)
        {
            var concernsRecordToCreate = ConcernsRecordFactory.Create(request);
            var savedConcernsRecord = _concernsRecordGateway.SaveConcernsCase(concernsRecordToCreate);
            return ConcernsRecordResponseFactory.Create(savedConcernsRecord);
        }
    }
}
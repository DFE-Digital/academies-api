using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class CreateConcernsRecord : ICreateConcernsRecord
    {
        private readonly IConcernsRecordGateway _concernsRecordGateway;
        private readonly IConcernsStatusGateway _concernsStatusGateway;

        public CreateConcernsRecord(IConcernsRecordGateway concernsRecordGateway, IConcernsStatusGateway concernsStatusGateway)
        {
            _concernsRecordGateway = concernsRecordGateway;
            _concernsStatusGateway = concernsStatusGateway;
        }
        public ConcernsRecordResponse Execute(ConcernsRecordRequest request)
        {
            var concernsStatus = _concernsStatusGateway.GetStatusByUrn(request.StatusUrn);
            var concernsRecordToCreate = ConcernsRecordFactory.Create(request, concernsStatus);
            var savedConcernsRecord = _concernsRecordGateway.SaveConcernsCase(concernsRecordToCreate);
            return ConcernsRecordResponseFactory.Create(savedConcernsRecord);
        }
    }
}
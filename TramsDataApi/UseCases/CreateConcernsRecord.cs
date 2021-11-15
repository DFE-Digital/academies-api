using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class CreateConcernsRecord : ICreateConcernsRecord
    {
        private readonly IConcernsRecordGateway _concernsRecordGateway;
        private readonly IConcernsCaseGateway _concernsCaseGateway;
        private readonly IConcernsTypeGateway _concernsTypeGateway;

        public CreateConcernsRecord(
            IConcernsRecordGateway concernsRecordGateway, 
            IConcernsCaseGateway concernsCaseGateway,
            IConcernsTypeGateway concernsTypeGateway)
        {
            _concernsRecordGateway = concernsRecordGateway;
            _concernsCaseGateway = concernsCaseGateway;
            _concernsTypeGateway = concernsTypeGateway;
        }
        public ConcernsRecordResponse Execute(ConcernsRecordRequest request)
        {
            var concernsCase = _concernsCaseGateway.GetConcernsCaseByUrn(request.CaseUrn);
            var concernsType = _concernsTypeGateway.GetConcernsTypeByUrn(request.TypeUrn);
            var concernsRecordToCreate = ConcernsRecordFactory.Create(request, concernsCase, concernsType);
            var savedConcernsRecord = _concernsRecordGateway.SaveConcernsCase(concernsRecordToCreate);
            return ConcernsRecordResponseFactory.Create(savedConcernsRecord);
        }
    }
}
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
        private readonly IConcernsRatingGateway _concernsRatingGateway;

        public CreateConcernsRecord(
            IConcernsRecordGateway concernsRecordGateway, 
            IConcernsCaseGateway concernsCaseGateway,
            IConcernsTypeGateway concernsTypeGateway,
            IConcernsRatingGateway concernsRatingGateway)
        {
            _concernsRecordGateway = concernsRecordGateway;
            _concernsCaseGateway = concernsCaseGateway;
            _concernsTypeGateway = concernsTypeGateway;
            _concernsRatingGateway = concernsRatingGateway;
        }
        public ConcernsRecordResponse Execute(ConcernsRecordRequest request)
        {
            var concernsCase = _concernsCaseGateway.GetConcernsCaseByUrn(request.CaseUrn);
            var concernsType = _concernsTypeGateway.GetConcernsTypeByUrn(request.TypeUrn);
            var concernsRatings = _concernsRatingGateway.GetRatingByUrn(request.RatingUrn);
            var concernsRecordToCreate = ConcernsRecordFactory.Create(request, concernsCase, concernsType, concernsRatings);
            var savedConcernsRecord = _concernsRecordGateway.SaveConcernsCase(concernsRecordToCreate);
            return ConcernsRecordResponseFactory.Create(savedConcernsRecord);
        }
    }
}
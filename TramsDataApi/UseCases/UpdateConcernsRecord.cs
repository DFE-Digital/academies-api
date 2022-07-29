using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class UpdateConcernsRecord : IUpdateConcernsRecord
    {
        private readonly IConcernsRecordGateway _concernsRecordGateway;
        private readonly IConcernsCaseGateway _concernsCaseGateway;
        private readonly IConcernsTypeGateway _concernsTypeGateway;
        private readonly IConcernsRatingGateway _concernsRatingGateway;       
        private readonly IConcernsMeansOfReferralGateway _concernsMeansOfReferralGateway;

        public UpdateConcernsRecord(
            IConcernsRecordGateway concernsRecordGateway,
            IConcernsCaseGateway concernsCaseGateway,
            IConcernsTypeGateway concernsTypeGateway,
            IConcernsRatingGateway concernsRatingGateway, 
            IConcernsMeansOfReferralGateway concernsMeansOfReferralGateway)
        {
            _concernsRecordGateway = concernsRecordGateway;
            _concernsCaseGateway = concernsCaseGateway;
            _concernsTypeGateway = concernsTypeGateway;
            _concernsRatingGateway = concernsRatingGateway;
            _concernsMeansOfReferralGateway = concernsMeansOfReferralGateway;
        }

        public ConcernsRecordResponse Execute(int urn, ConcernsRecordRequest request)
        {
            var currentConcernsRecord = _concernsRecordGateway.GetConcernsRecordByUrn(urn);
            var concernsCase = _concernsCaseGateway.GetConcernsCaseByUrn(request.CaseUrn) ??
                                currentConcernsRecord.ConcernsCase;
            var concernsType = _concernsTypeGateway.GetConcernsTypeByUrn(request.TypeUrn) ??
                                currentConcernsRecord.ConcernsType;
            var concernsRating = _concernsRatingGateway.GetRatingByUrn(request.RatingUrn) ?? 
                                currentConcernsRecord.ConcernsRating;
            var concernsMeansOfReferral = _concernsMeansOfReferralGateway.GetMeansOfReferralByUrn(request.MeansOfReferralUrn) ?? 
                                currentConcernsRecord.ConcernsMeansOfReferral;
            
            var concernsCaseToUpdate = ConcernsRecordFactory
                .Update(currentConcernsRecord, request, concernsCase, concernsType, concernsRating, concernsMeansOfReferral);
            
            var updatedConcernsRecord = _concernsRecordGateway.Update(concernsCaseToUpdate);
            return ConcernsRecordResponseFactory.Create(updatedConcernsRecord);
        }
    }
}
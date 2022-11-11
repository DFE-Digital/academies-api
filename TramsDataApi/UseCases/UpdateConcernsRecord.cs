using System;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
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

            if (!TryGetConcernsMeansOfReferralByUrn(request.MeansOfReferralUrn, out var concernsMeansOfReferral))
            {
                TryGetConcernsMeansOfReferralById(currentConcernsRecord.MeansOfReferralId, out concernsMeansOfReferral);
            }

            var concernsCaseToUpdate = ConcernsRecordFactory
                .Update(currentConcernsRecord, request, concernsCase, concernsType, concernsRating, concernsMeansOfReferral);
            
            var updatedConcernsRecord = _concernsRecordGateway.Update(concernsCaseToUpdate);
            return ConcernsRecordResponseFactory.Create(updatedConcernsRecord);
        }

        private bool TryGetConcernsMeansOfReferralById(int? id, out ConcernsMeansOfReferral meansOfReferral)
        {
            if (id == null)
            {
                meansOfReferral = null;
                return false;
            }

            meansOfReferral = _concernsMeansOfReferralGateway.GetMeansOfReferralById((int)id);

            return meansOfReferral != null;
        }
 
        private bool TryGetConcernsMeansOfReferralByUrn(int? urn, out ConcernsMeansOfReferral meansOfReferral)
        {
            if (urn == null)
            {
                meansOfReferral = null;
                return false;
            }

            meansOfReferral = _concernsMeansOfReferralGateway.GetMeansOfReferralByUrn((int)urn);

            return meansOfReferral != null;
        }
    }
}
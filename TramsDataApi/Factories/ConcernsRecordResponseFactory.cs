using System;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class ConcernsRecordResponseFactory
    {
        public static ConcernsRecordResponse Create(ConcernsRecord concernsRecord)
        {
            return new ConcernsRecordResponse
            {
                CreatedAt = concernsRecord.CreatedAt,
                UpdatedAt = concernsRecord.UpdatedAt,
                ReviewAt = concernsRecord.ReviewAt,
                ClosedAt = concernsRecord.ClosedAt,
                Name = concernsRecord.Name,
                Description = concernsRecord.Description,
                Reason = concernsRecord.Reason,
                Urn = concernsRecord.Urn,
                StatusUrn = concernsRecord.StatusUrn,
                TypeUrn = concernsRecord.ConcernsType.Urn,
                CaseUrn = concernsRecord.ConcernsCase.Urn,
                RatingUrn = concernsRecord.ConcernsRating.Urn,
                MeansOfReferralUrn = concernsRecord.ConcernsMeansOfReferral?.Urn
            };
        }
    }
}
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
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
                RatingId = concernsRecord.RatingId,
                Primary = concernsRecord.Primary,
                Urn = concernsRecord.Urn,
                StatusUrn = concernsRecord.StatusUrn,
                TypeUrn = concernsRecord.ConcernsType.Urn,
                CaseUrn = concernsRecord.ConcernsCase.Urn
            };
        }
    }
}
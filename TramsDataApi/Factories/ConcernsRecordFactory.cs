using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels;

namespace TramsDataApi.Factories
{
    public class ConcernsRecordFactory
    {
        public static ConcernsRecord Create(ConcernsRecordRequest concernsRecordRequest, ConcernsCase concernsCase, ConcernsType concernsType)
        {
            return new ConcernsRecord
            {
                CreatedAt = concernsRecordRequest.CreatedAt,
                UpdatedAt = concernsRecordRequest.UpdatedAt,
                ReviewAt = concernsRecordRequest.ReviewAt,
                ClosedAt = concernsRecordRequest.ClosedAt,
                Name = concernsRecordRequest.Name,
                Description = concernsRecordRequest.Description,
                Reason = concernsRecordRequest.Reason,
                ConcernsCase = concernsCase,
                ConcernsType = concernsType,
                RatingId = concernsRecordRequest.RatingId,
                Primary = concernsRecordRequest.Primary,
                StatusUrn = concernsRecordRequest.StatusUrn
            };
        }
    }
}
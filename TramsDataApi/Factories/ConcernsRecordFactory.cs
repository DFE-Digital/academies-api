using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels;

namespace TramsDataApi.Factories
{
    public class ConcernsRecordFactory
    {
        public static ConcernsRecord Create(ConcernsRecordRequest concernsRecordRequest, ConcernsStatus status)
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
                CaseId = concernsRecordRequest.CaseId,
                TypeId = concernsRecordRequest.TypeId,
                RatingId = concernsRecordRequest.RatingId,
                Primary = concernsRecordRequest.Primary,
                Status = status
            };
        }
    }
}
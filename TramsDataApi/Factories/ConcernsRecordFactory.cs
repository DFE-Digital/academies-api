using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels;

namespace TramsDataApi.Factories
{
    public class ConcernsRecordFactory
    {
        public static ConcernsRecord Create(
            ConcernsRecordRequest concernsRecordRequest, 
            ConcernsCase concernsCase, 
            ConcernsType concernsType, 
            ConcernsRating concernsRating)
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
                ConcernsRating = concernsRating,
                Primary = concernsRecordRequest.Primary,
                StatusUrn = concernsRecordRequest.StatusUrn
            };
        }
        
        public static ConcernsRecord Update( 
            ConcernsRecord original,
            ConcernsRecordRequest concernsRecordRequest, 
            ConcernsCase concernsCase, 
            ConcernsType concernsType, 
            ConcernsRating concernsRating)
        {
            return new ConcernsRecord
            {
                CreatedAt = concernsRecordRequest.CreatedAt,
                UpdatedAt = concernsRecordRequest.UpdatedAt,
                ReviewAt = concernsRecordRequest.ReviewAt,
                ClosedAt = concernsRecordRequest.ClosedAt,
                Name = concernsRecordRequest.Name ?? original.Name,
                Description = concernsRecordRequest.Description ?? original.Name,
                Reason = concernsRecordRequest.Reason ?? original.Name,
                ConcernsCase = concernsCase,
                ConcernsType = concernsType,
                ConcernsRating = concernsRating,
                Primary = concernsRecordRequest.Primary,
                StatusUrn = concernsRecordRequest.StatusUrn
            };
        }
    }
}
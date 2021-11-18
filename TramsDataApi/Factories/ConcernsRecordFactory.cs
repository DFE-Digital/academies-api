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

            original.CreatedAt = concernsRecordRequest.CreatedAt;
            original.UpdatedAt = concernsRecordRequest.UpdatedAt;
            original.ReviewAt = concernsRecordRequest.ReviewAt;
            original.ClosedAt = concernsRecordRequest.ClosedAt;
            original.Name = concernsRecordRequest.Name ?? original.Name;
            original.Description = concernsRecordRequest.Description ?? original.Name;
            original.Reason = concernsRecordRequest.Reason ?? original.Name;
            original.ConcernsCase = concernsCase;
            original.ConcernsType = concernsType;
            original.ConcernsRating = concernsRating;
            original.Primary = concernsRecordRequest.Primary;
            original.StatusUrn = concernsRecordRequest.StatusUrn;

            return original;
        }
    }
}
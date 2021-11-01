using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public class ConcernsCaseResponseFactory
    {
        public static ConcernsCaseResponse Create(ConcernsCase concernsCase)
        {
            return new ConcernsCaseResponse
            {
                CreatedAt = concernsCase.CreatedAt,
                UpdatedAt = concernsCase.UpdatedAt,
                ReviewedAt = concernsCase.ReviewAt,
                ClosedAt = concernsCase.ClosedAt,
                CreatedBy = concernsCase.CreatedBy,
                Description = concernsCase.Description,
                CrmEnquiry = concernsCase.CrmEnquiry,
                TrustUkprn = concernsCase.TrustUkprn,
                ReasonForReview = concernsCase.ReasonAtReview,
                DeEscalation = concernsCase.DeEscalation,
                Issue = concernsCase.Issue,
                CurrentStatus = concernsCase.CurrentStatus,
                CaseAim = concernsCase.CaseAim,
                DeEscalationPoint = concernsCase.DeEscalationPoint,
                NextSteps = concernsCase.NextSteps,
                DirectionOfTravel = concernsCase.DirectionOfTravel,
                Urn = concernsCase.Urn,
                Status = concernsCase.ConcernsStatusUrn
            };
        }
    }
}
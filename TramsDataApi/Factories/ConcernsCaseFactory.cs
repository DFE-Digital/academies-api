using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels;

namespace TramsDataApi.Factories
{
    public class ConcernsCaseFactory
    {
        public static ConcernsCase Create(ConcernCaseRequest request)
        {
            return new ConcernsCase
            {
                CreatedAt = request.CreatedAt,
                UpdatedAt = request.UpdatedAt,
                ReviewAt = request.ReviewAt,
                ClosedAt = request.ClosedAt,
                CreatedBy = request.CreatedBy,
                Description = request.Description,
                CrmEnquiry = request.CrmEnquiry,
                TrustUkprn = request.TrustUkprn,
                ReasonAtReview = request.ReasonForReview,
                DeEscalation = request.DeEscalation,
                Issue = request.Issue,
                CurrentStatus = request.CurrentStatus,
                CaseAim = request.CaseAim,
                DeEscalationPoint = request.DeEscalationPoint,
                NextSteps = request.NextSteps,
                DirectionOfTravel = request.DirectionOfTravel,
                ConcernsStatusUrn = request.Status
            };
        }
    }
}
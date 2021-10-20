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
                ReviewedAt = request.ReviewedAt,
                ClosedAt = request.ClosedAt,
                CreatedBy = request.CreatedBy,
                Description = request.Description,
                CrmEnquiry = request.CrmEnquiry,
                TrustUkprn = request.TrustUkprn,
                ReasonForReview = request.ReasonForReview,
                DeEscalation = request.DeEscalation,
                Issue = request.Issue,
                CurrentStatus = request.CurrentStatus,
                CaseAim = request.CaseAim,
                DeEscalationPoint = request.DeEscalationPoint,
                NextSteps = request.NextSteps,
                DirectionOfTravel = request.DirectionOfTravel,
                FkConcernsStatusId = request.ConcernsStatusId
            };
        }
    }
}
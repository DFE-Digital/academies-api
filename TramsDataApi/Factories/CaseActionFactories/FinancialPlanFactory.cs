using TramsDataApi.DatabaseModels;
using TramsDataApi.Enums;
using TramsDataApi.RequestModels.CaseActions.FinancialPlan;
using TramsDataApi.ResponseModels.CaseActions.FinancialPlan;

namespace TramsDataApi.Factories.CaseActionFactories
{
    public static class FinancialPlanFactory
    {
        public static FinancialPlanCase CreateDBModel(FinancialPlanRequest createSRMARequest)
        {
            return new FinancialPlanCase
            {
                Id = createSRMARequest.Id,
                CaseUrn = createSRMARequest.CaseUrn,
                Name = createSRMARequest.Name,
                ClosedAt = createSRMARequest.ClosedAt,
                CreatedAt = createSRMARequest.CreatedAt,
                CreatedBy = createSRMARequest.CreatedBy,    
                DatePlanRequested = createSRMARequest.DatePlanRequested,
                DateViablePlanReceived =  createSRMARequest.DateViablePlanReceived,
                Notes = createSRMARequest.Notes,
                StatusId = createSRMARequest.StatusId,
                UpdatedAt = createSRMARequest.UpdatedAt,
            };
        }

        public static FinancialPlanResponse CreateResponse(FinancialPlanCase model)
        {
            return new FinancialPlanResponse
            {
                Id = model.Id,
                CaseUrn = model.CaseUrn,
                Name = model.Name,
                CreatedAt = model.CreatedAt,
                CreatedBy = model.CreatedBy,
                ClosedAt = model.ClosedAt,
                DatePlanRequested = model.DatePlanRequested,
                DateViablePlanReceived= model.DateViablePlanReceived,
                Notes = model.Notes,
                Status = model.Status,
                UpdatedAt = model.UpdatedAt,
                StatusId=model.StatusId,
            };
        }


    }
}

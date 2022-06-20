using TramsDataApi.DatabaseModels;
using TramsDataApi.Enums;
using TramsDataApi.RequestModels.CaseActions.FinancialPlan;
using TramsDataApi.ResponseModels.CaseActions.FinancialPlan;

namespace TramsDataApi.Factories.CaseActionFactories
{
    public static class FinancialPlanFactory
    {
        public static FinancialPlanCase CreateDBModel(CreateFinancialPlanRequest createSRMARequest)
        {
            return new FinancialPlanCase
            {
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
        
        public static FinancialPlanCase CreateDBModel(PatchFinancialPlanRequest patchSRMARequest)
        {
            return new FinancialPlanCase
            {
                Id = patchSRMARequest.Id,
                CaseUrn = patchSRMARequest.CaseUrn,
                Name = patchSRMARequest.Name,
                ClosedAt = patchSRMARequest.ClosedAt,
                CreatedAt = patchSRMARequest.CreatedAt,
                CreatedBy = patchSRMARequest.CreatedBy,    
                DatePlanRequested = patchSRMARequest.DatePlanRequested,
                DateViablePlanReceived =  patchSRMARequest.DateViablePlanReceived,
                Notes = patchSRMARequest.Notes,
                StatusId = patchSRMARequest.StatusId,
                UpdatedAt = patchSRMARequest.UpdatedAt,
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

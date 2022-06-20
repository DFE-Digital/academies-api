using TramsDataApi.DatabaseModels;
using TramsDataApi.Enums;
using TramsDataApi.RequestModels.CaseActions.NTI.UnderConsideration;
using TramsDataApi.ResponseModels.CaseActions.NTI.UnderConsideration;

namespace TramsDataApi.Factories.CaseActionFactories
{
    public static class NTIUnderConsiderationFactory
    {
        public static NTIUnderConsideration CreateDBModel(CreateNTIUnderConsiderationRequest createNTIUnderConsiderationRequest)
        {

            return new NTIUnderConsideration
            {
                Id = createNTIUnderConsiderationRequest.Id,
                CaseUrn = createNTIUnderConsiderationRequest.CaseUrn,
                UnderConsiderationReasonsMapping = createNTIUnderConsiderationRequest.UnderConsiderationReasonsMapping,
                Notes = createNTIUnderConsiderationRequest.Notes,
                CreatedAt = createNTIUnderConsiderationRequest.CreatedAt,
                CreatedBy = createNTIUnderConsiderationRequest.CreatedBy
            };
        }

        public static NTIUnderConsiderationResponse CreateResponse(NTIUnderConsideration model)
        {
            return new NTIUnderConsiderationResponse
            {
                Id = model.Id,
                CaseUrn = model.CaseUrn,
                Notes = model.Notes,
                UnderConsiderationReasonsMapping = model.UnderConsiderationReasonsMapping,
                CreatedAt = model.CreatedAt,
                CreatedBy = model.CreatedBy,
                UpdatedAt = model.UpdatedAt,
                ClosedAt = model.ClosedAt,
                ClosedStatus = (Enums.NTIUnderConsiderationStatus)(model.CloseStatusId ?? 0)
            };
        }
    }
}

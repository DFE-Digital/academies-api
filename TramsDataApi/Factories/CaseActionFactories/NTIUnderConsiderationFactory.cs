using System;
using System.Linq;
using TramsDataApi.DatabaseModels;
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
                CaseUrn = createNTIUnderConsiderationRequest.CaseUrn,
                UnderConsiderationReasonsMapping = createNTIUnderConsiderationRequest.UnderConsiderationReasonsMapping.Select(r => {
                    return new NTIUnderConsiderationReasonMapping()
                    {
                        NTIUnderConsiderationReasonId = r
                    };
                }).ToList(),
                Notes = createNTIUnderConsiderationRequest.Notes,
                CreatedAt = createNTIUnderConsiderationRequest.CreatedAt,
                CreatedBy = createNTIUnderConsiderationRequest.CreatedBy
            };
        }

        public static NTIUnderConsideration CreateDBModel(PatchNTIUnderConsiderationRequest patchNTIUnderConsiderationRequest)
        {
            return new NTIUnderConsideration
            {
                Id = patchNTIUnderConsiderationRequest.Id,
                CaseUrn = patchNTIUnderConsiderationRequest.CaseUrn,
                UnderConsiderationReasonsMapping = patchNTIUnderConsiderationRequest.UnderConsiderationReasonsMapping.Select(r => {
                    return new NTIUnderConsiderationReasonMapping()
                    {
                        NTIUnderConsiderationReasonId = r
                    };
                }).ToList(),
                Notes = patchNTIUnderConsiderationRequest.Notes,
                CreatedAt = patchNTIUnderConsiderationRequest.CreatedAt,
                CreatedBy = patchNTIUnderConsiderationRequest.CreatedBy
            };
        }

        public static NTIUnderConsiderationResponse CreateResponse(NTIUnderConsideration model)
        {
            return new NTIUnderConsiderationResponse
            {
                Id = model.Id,
                CaseUrn = model.CaseUrn,
                Notes = model.Notes,
                UnderConsiderationReasonsMapping = model.UnderConsiderationReasonsMapping.Select(r => { return r.NTIUnderConsiderationReasonId; }).ToArray(),
                CreatedAt = model.CreatedAt,
                CreatedBy = model.CreatedBy,
                UpdatedAt = model.UpdatedAt,
                ClosedAt = model.ClosedAt,
                ClosedStatusId = model.CloseStatusId
            };
        }
    }
}

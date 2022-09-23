using System;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.CaseActions.NTI.UnderConsideration;
using TramsDataApi.ResponseModels.CaseActions.NTI.UnderConsideration;

namespace TramsDataApi.Factories.CaseActionFactories
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
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
                CreatedBy = createNTIUnderConsiderationRequest.CreatedBy,
                UpdatedAt = createNTIUnderConsiderationRequest.UpdatedAt,
                ClosedAt = createNTIUnderConsiderationRequest.ClosedAt,
                ClosedStatusId = createNTIUnderConsiderationRequest.ClosedStatusId
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
                CreatedBy = patchNTIUnderConsiderationRequest.CreatedBy,
                UpdatedAt = patchNTIUnderConsiderationRequest.UpdatedAt,
                ClosedAt = patchNTIUnderConsiderationRequest.ClosedAt,
                ClosedStatusId = patchNTIUnderConsiderationRequest.ClosedStatusId
              
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
                ClosedStatusId = model.ClosedStatusId
            };
        }
    }
}

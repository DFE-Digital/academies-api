using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public interface INTIUnderConsiderationGateway
    {
        Task<NTIUnderConsideration> CreateNTIUnderConsideration(NTIUnderConsideration request);
        Task<ICollection<NTIUnderConsideration>> GetNTIUnderConsiderationByCaseUrn(int caseUrn);
        Task<NTIUnderConsideration> GetNTIUnderConsiderationById(long ntiUnderConsiderationId);
        Task<NTIUnderConsideration> PatchNTIUnderConsideration(NTIUnderConsideration patchNTIUnderConsideration);
        Task<List<NTIUnderConsiderationStatus>> GetAllStatuses();
        Task<List<NTIUnderConsiderationReason>> GetAllReasons();
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface ISRMAGateway
    {
        Task<SRMACase> CreateSRMA(SRMACase request);
        Task<ICollection<SRMACase>> GetSRMAsByCaseId(int caseId);
        Task<SRMACase> GetSRMAById(int srmaId);
        Task<SRMACase> PatchSRMAAsync(int srmaId, Func<SRMACase, SRMACase> patchDelegate);
    }
}

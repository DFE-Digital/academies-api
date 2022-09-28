using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public interface INoticeToImproveGateway
    {
        Task<NoticeToImprove> CreateNoticeToImprove(NoticeToImprove request);
        Task<NoticeToImprove> GetNoticeToImproveById(long noticeToImproveId);
        Task<ICollection<NoticeToImprove>> GetNoticeToImproveByCaseUrn(int caseUrn);
        Task<List<NoticeToImproveStatus>> GetAllStatuses();
        Task<List<NoticeToImproveReason>> GetAllReasons();
        Task<List<NoticeToImproveConditionType>> GetAllConditionTypes();
        Task<List<NoticeToImproveCondition>> GetAllConditions();        
        Task<NoticeToImprove> PatchNoticeToImprove(NoticeToImprove patchNoticeToImprove);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
	public class NoticeToImproveGateway : INoticeToImproveGateway
    {
        private readonly TramsDbContext _tramsDbContext;
        private readonly ILogger<NoticeToImproveGateway> _logger;

        public NoticeToImproveGateway(TramsDbContext tramsDbContext, ILogger<NoticeToImproveGateway> logger)
		{
            _tramsDbContext = tramsDbContext;
            _logger = logger;
        }

        public async Task<NoticeToImprove> CreateNoticeToImprove(NoticeToImprove request)
        {
            try
            {
                _tramsDbContext.NoticesToImprove.Add(request);
                await _tramsDbContext.SaveChangesAsync();
                return request;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Failed to create NoticeToImprove with Id {Id}, {ex}", request.Id, ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("An application exception has occurred whilst creating NoticeToImprove with Id {Id}, {ex}", request.Id, ex);
                throw;
            }
        }

        public async Task<NoticeToImprove> GetNoticeToImproveById(long noticeToImproveId)
        {
            try
            {
                return await _tramsDbContext.NoticesToImprove.Include(r => r.NoticeToImproveReasonsMapping).Include(c => c.NoticeToImproveConditionsMapping).SingleOrDefaultAsync(n => n.Id == noticeToImproveId);
            }
            catch (InvalidOperationException iox)
            {
                _logger.LogError(iox, "Multiple NoticeToImprove records found with Id: {Id}", noticeToImproveId);
                throw;
            }
        }

        public async Task<ICollection<NoticeToImprove>> GetNoticeToImproveByCaseUrn(int caseUrn)
        {
            return await _tramsDbContext.NoticesToImprove.Include(r => r.NoticeToImproveReasonsMapping).Include(c => c.NoticeToImproveConditionsMapping).Where(n => n.CaseUrn == caseUrn).ToListAsync();
        }

        public async Task<List<NoticeToImproveStatus>> GetAllStatuses()
        {
            return await _tramsDbContext.NoticeToImproveStatuses.ToListAsync();
        }

        public async Task<List<NoticeToImproveReason>> GetAllReasons()
        {
            return await _tramsDbContext.NoticeToImproveReasons.ToListAsync();
        }

        public async Task<List<NoticeToImproveConditionType>> GetAllConditionTypes()
        {
            return await _tramsDbContext.NoticeToImproveConditionTypes.ToListAsync();
        }

        public async Task<List<NoticeToImproveCondition>> GetAllConditions()
        {
            return await _tramsDbContext.NoticeToImproveConditions.Include(c => c.ConditionType).ToListAsync();
        }

        public async Task<NoticeToImprove> PatchNoticeToImprove(NoticeToImprove patchNoticeToImprove)
        {
            try
            {
                var reasonsToRemove = await _tramsDbContext.NoticeToImproveReasonsMappings.Where(r => r.NoticeToImproveId == patchNoticeToImprove.Id).ToListAsync();
                var conditionsToRemove = await _tramsDbContext.NoticeToImproveConditionsMappings.Where(r => r.NoticeToImproveId == patchNoticeToImprove.Id).ToListAsync();

                _tramsDbContext.NoticeToImproveReasonsMappings.RemoveRange(reasonsToRemove);
                _tramsDbContext.NoticeToImproveConditionsMappings.RemoveRange(conditionsToRemove);

                var tracked = _tramsDbContext.Update<NoticeToImprove>(patchNoticeToImprove);
                await _tramsDbContext.SaveChangesAsync();

                return tracked.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while trying to patch the NoticeToImprove with Id:", patchNoticeToImprove.Id);
                throw;
            }
        }
    }
}


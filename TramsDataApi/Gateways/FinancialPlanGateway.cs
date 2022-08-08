using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using System.Linq;
using System.Collections.Generic;

namespace TramsDataApi.Gateways
{
    public class FinancialPlanGateway : IFinancialPlanGateway
    {
        private readonly TramsDbContext _tramsDbContext;
        private readonly ILogger<SRMAGateway> _logger;

        public FinancialPlanGateway(TramsDbContext tramsDbContext, ILogger<SRMAGateway> logger)
        {
            _tramsDbContext = tramsDbContext;
            _logger = logger;
        }

        public async Task<FinancialPlanCase> CreateFinancialPlan(FinancialPlanCase request)
        {
            try
            {
                var tracked = _tramsDbContext.FinancialPlanCases.Add(request);
                await _tramsDbContext.SaveChangesAsync();
                return tracked.Entity;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Failed to create Financial Plan with Id {Id}, {ex}", request.Id, ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("An application exception has occurred whilst creating Financial Plan with Id {Id}, {ex}", request.Id, ex);
                throw;
            }
        }

        public async Task<FinancialPlanCase> GetFinancialPlanById(long financialPlanId)
        {
            return await _tramsDbContext.FinancialPlanCases
                .Include(fp => fp.Status)
                .SingleOrDefaultAsync(fp => fp.Id == financialPlanId);
        }

        public async Task<ICollection<FinancialPlanCase>> GetFinancialPlansByCaseUrn(int caseUrn)
        {
            return await _tramsDbContext.FinancialPlanCases
                .Include(fp => fp.Status)
                .Where(s => s.CaseUrn == caseUrn).ToListAsync();
        }

        public async Task<FinancialPlanCase> PatchFinancialPlan(FinancialPlanCase patchedFinancialPlan)
        {
            try
            {
                var tracked = _tramsDbContext.Update<FinancialPlanCase>(patchedFinancialPlan);
                await _tramsDbContext.SaveChangesAsync();

                return tracked.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while trying to patch the financial plan with Id:", patchedFinancialPlan.Id);
                throw;
            }
        }

        public async Task<List<FinancialPlanStatus>> GetAllStatuses()
        {
            return await _tramsDbContext.FinancialPlanStatuses.ToListAsync();
        }
    }
}

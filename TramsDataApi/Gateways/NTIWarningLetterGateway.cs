using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
	public class NTIWarningLetterGateway : INTIWarningLetterGateway
    {
        private readonly TramsDbContext _tramsDbContext;
        private readonly ILogger<NTIWarningLetterGateway> _logger;

        public NTIWarningLetterGateway(TramsDbContext tramsDbContext, ILogger<NTIWarningLetterGateway> logger)
		{
            _tramsDbContext = tramsDbContext;
            _logger = logger;
        }

        public async Task<NTIWarningLetter> CreateNTIWarningLetter(NTIWarningLetter request)
        {
            try
            {
                _tramsDbContext.NTIWarningLetters.Add(request);
                await _tramsDbContext.SaveChangesAsync();
                return request;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Failed to create NTIWarningLetter with Id {Id}, {ex}", request.Id, ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("An application exception has occurred whilst creating NTIWarningLetter with Id {Id}, {ex}", request.Id, ex);
                throw;
            }
        }

        public async Task<List<NTIWarningLetterCondition>> GetAllConditions()
        {
            return await _tramsDbContext.NTIWarningLetterConditions.Include(c => c.ConditionType).ToListAsync();
        }

        public async Task<List<NTIWarningLetterConditionType>> GetAllConditionTypes()
        {
            return await _tramsDbContext.NTIWarningLetterConditionTypes.ToListAsync();
        }

        public async Task<List<NTIWarningLetterReason>> GetAllReasons()
        {
            return await _tramsDbContext.NTIWarningLetterReasons.ToListAsync();
        }

        public async Task<List<NTIWarningLetterStatus>> GetAllStatuses()
        {
            return await _tramsDbContext.NTIWarningLetterStatuses.ToListAsync();
        }

        public async Task<NTIWarningLetter> GetNTIWarningLetterById(long ntiWarningLetterId)
        {
            try
            {
                return await _tramsDbContext.NTIWarningLetters.Include(r => r.WarningLetterReasonsMapping).Include(c => c.WarningLetterConditionsMapping).SingleOrDefaultAsync(n => n.Id == ntiWarningLetterId);
            }
            catch (InvalidOperationException iox)
            {
                _logger.LogError(iox, "Multiple NTIWarningLetter records found with Id: {Id}", ntiWarningLetterId);
                throw;
            }
        }

        public async Task<ICollection<NTIWarningLetter>> GetNTIWarningLetterByCaseUrn(int caseUrn)
        {
            return await _tramsDbContext.NTIWarningLetters.Include(r => r.WarningLetterReasonsMapping).Include(c => c.WarningLetterConditionsMapping).Where(n => n.CaseUrn == caseUrn).ToListAsync();
        }

        public async Task<NTIWarningLetter> PatchNTIWarningLetter(NTIWarningLetter patchNTIWarningLetter)
        {
            try
            {
                var reasonsToRemove = await _tramsDbContext.NTIWarningLetterReasonsMapping.Where(r => r.NTIWarningLetterId == patchNTIWarningLetter.Id).ToListAsync();
                var conditionsToRemove = await _tramsDbContext.NTIWarningLetterConditionsMapping.Where(r => r.NTIWarningLetterId == patchNTIWarningLetter.Id).ToListAsync();

                _tramsDbContext.NTIWarningLetterReasonsMapping.RemoveRange(reasonsToRemove);
                _tramsDbContext.NTIWarningLetterConditionsMapping.RemoveRange(conditionsToRemove);

                var tracked = _tramsDbContext.Update<NTIWarningLetter>(patchNTIWarningLetter);
                await _tramsDbContext.SaveChangesAsync();

                return tracked.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while trying to patch the NTIWarningLetter with Id:", patchNTIWarningLetter.Id);
                throw;
            }
        }
    }
}


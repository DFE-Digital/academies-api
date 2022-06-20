using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
	public class NTIUnderConsiderationGateway : INTIUnderConsiderationGateway
    {
        private readonly TramsDbContext _tramsDbContext;
        private readonly ILogger<NTIUnderConsiderationGateway> _logger;

        public NTIUnderConsiderationGateway(TramsDbContext tramsDbContext, ILogger<NTIUnderConsiderationGateway> logger)
		{
            _tramsDbContext = tramsDbContext;
            _logger = logger;
        }

        public async Task<NTIUnderConsideration> CreateNTIUnderConsideration(NTIUnderConsideration request)
        {
            try
            {
                _tramsDbContext.NTIUnderConsiderations.Add(request);
                await _tramsDbContext.SaveChangesAsync();
                return request;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Failed to create NTIUnderConsideration with Id {Id}, {ex}", request.Id, ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("An application exception has occurred whilst creating NTIUnderConsideration with Id {Id}, {ex}", request.Id, ex);
                throw;
            }
        }

        public async Task<ICollection<NTIUnderConsideration>> GetNTIUnderConsiderationByCaseUrn(int caseUrn)
        {
            return await _tramsDbContext.NTIUnderConsiderations.Where(n => n.CaseUrn == caseUrn).ToListAsync();
        }

        public async Task<NTIUnderConsideration> GetNTIUnderConsiderationById(long ntiUnderConsiderationId)
        {
            try
            {
                return await _tramsDbContext.NTIUnderConsiderations.SingleOrDefaultAsync(n => n.Id == ntiUnderConsiderationId);
            }
            catch (InvalidOperationException iox)
            {
                _logger.LogError(iox, "Multiple NTIUnderConsiderations records found with Id: {Id}", ntiUnderConsiderationId);
                throw;
            }
        }

        public async Task<NTIUnderConsideration> PatchNTIUnderConsiderationAsync(long ntiUnderConsiderationId, Func<NTIUnderConsideration, NTIUnderConsideration> patchDelegate)
        {
            if (patchDelegate == null)
            {
                throw new ArgumentNullException("Delegate not provided");
            }

            try
            {
                var ntiUnderConsideration = await _tramsDbContext.NTIUnderConsiderations.FindAsync(ntiUnderConsiderationId);

                if (ntiUnderConsideration == null)
                {
                    throw new InvalidOperationException($"NTIUnderConsideration with Id:{ntiUnderConsiderationId} not found.");
                }

                var patchedNTIUnderConsideration = patchDelegate(ntiUnderConsideration);
                if (patchedNTIUnderConsideration == null || patchedNTIUnderConsideration.Id != ntiUnderConsideration.Id)
                {
                    throw new InvalidOperationException("Patched NTIUnderConsideration is invalid.");
                }

                var tracked = _tramsDbContext.Update<NTIUnderConsideration>(ntiUnderConsideration);
                await _tramsDbContext.SaveChangesAsync();

                return tracked.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while trying to patch the NTIUnderConsideration. NTIUnderConsideration Id:", ntiUnderConsiderationId);
                throw;
            }
        }
    }
}


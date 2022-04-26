using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using System.Linq;
using System.Collections.Generic;

namespace TramsDataApi.Gateways
{
    public class SRMAGateway : ISRMAGateway
    {
        private readonly TramsDbContext _tramsDbContext;
        private readonly ILogger<SRMAGateway> _logger;

        public SRMAGateway(TramsDbContext tramsDbContext, ILogger<SRMAGateway> logger)
        {
            _tramsDbContext = tramsDbContext;
            _logger = logger;
        }

        public async Task<SRMACase> CreateSRMA(SRMACase request)
        {
            SRMACase response = null;

            try
            {
                _tramsDbContext.SRMACases.Add(request);
                await _tramsDbContext.SaveChangesAsync();

                _logger.LogInformation("Successfully created SRMA with Id {Id}", request.Id);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Failed to create SRMA with Id {Id}, {ex}", request.Id, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    "An application exception has occurred whilst creating SRMA with Id {Id}, {ex}", request.Id, ex);
                throw;
            }

            return response;
        }

        public async Task<ICollection<SRMACase>> GetSRMAsByCaseId(int caseId)
        {
            return await _tramsDbContext.SRMACases.Where(s => s.CaseId == caseId).ToListAsync();
        }
    }
}

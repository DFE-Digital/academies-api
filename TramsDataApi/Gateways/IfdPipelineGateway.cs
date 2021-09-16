using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class IfdPipelineGateway : IIfdPipelineGateway
    {
        private LegacyTramsDbContext _dbContext;

        public IfdPipelineGateway(LegacyTramsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IEnumerable<IfdPipeline> GetPipelineProjectsByStatus(int page, int count, List<string> statues)
        {
            var lowerStatuses = statues.Select(s => s.ToLower());
            var results = _dbContext.IfdPipeline
                .Where(ifd => lowerStatuses.Contains(ifd.GeneralDetailsProjectStatus.ToLower()))
                .Skip((page - 1) * count)
                .Take(count)
                .AsNoTracking()
                .ToList();
            
            return results;
        }
    }
}
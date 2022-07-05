using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class AcademyConversionProjectGateway : IAcademyConversionProjectGateway
    {
        private readonly TramsDbContext _tramsDbContext;

        public AcademyConversionProjectGateway(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext;
        }

        public async Task<AcademyConversionProject> GetById(int id)
        {
            return await _tramsDbContext.AcademyConversionProjects
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<AcademyConversionProject>> GetProjects(int page, int count)
        {
            return await _tramsDbContext.AcademyConversionProjects
                .OrderByDescending(p => p.ApplicationReceivedDate)
                .Skip((page - 1) * count)
                .Take(count)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<AcademyConversionProject> Update(AcademyConversionProject academyConversionProject)
        {
            var entity = _tramsDbContext.AcademyConversionProjects
                .Update(academyConversionProject);
            
            await _tramsDbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task<List<AcademyConversionProject>> GetByStatuses(int page, int count, IEnumerable<string> statuses)
        {
            var lowerStatuses = statuses.Select(s => s.ToLower());
            var results = await _tramsDbContext.AcademyConversionProjects
                .Where(acp => lowerStatuses.Contains(acp.ProjectStatus.ToLower()))
                .OrderByDescending(acp => acp.Id)
                .Skip((page - 1) * count)
                .Take(count)
                .AsNoTracking()
                .ToListAsync();

            return results;
        }
    }
}
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
                .OrderByDescending(p => p.Id)
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

        public async Task<List<AcademyConversionProject>> SearchProjects(int page, int count, IEnumerable<string> statuses, int? urn)
        {
            IQueryable<AcademyConversionProject> academyConversionProjects = _tramsDbContext.AcademyConversionProjects
                .OrderByDescending(acp => acp.Id)
                .Skip((page - 1) * count)
                .Take(count)
                .AsNoTracking();

            if (statuses != null && statuses.Any())
            {
                var lowerStatuses = statuses.Select(status => status.ToLower());
                academyConversionProjects = academyConversionProjects.Where(acp => lowerStatuses.Contains(acp.ProjectStatus.ToLower()));
            }

            if (urn.HasValue)
            {
                academyConversionProjects = academyConversionProjects.Where(acp => acp.Urn == urn);
            }

            return await academyConversionProjects.ToListAsync();
        }
    }
}
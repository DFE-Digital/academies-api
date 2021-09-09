using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public AcademyConversionProject GetById(int id)
        {
            return _tramsDbContext.AcademyConversionProjects.AsNoTracking().SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<AcademyConversionProject> GetProjects(int take)
        {
            return _tramsDbContext.AcademyConversionProjects.Take(take).AsNoTracking().ToList();
        }

        public AcademyConversionProject Update(AcademyConversionProject academyConversionProject)
        {
            var entity =_tramsDbContext.AcademyConversionProjects.Update(academyConversionProject);
            _tramsDbContext.SaveChanges();
            return entity.Entity;
        }
        public IEnumerable<AcademyConversionProject> GetByStatuses(int take, List<string> statues)
        {
            var lowerStatuses = statues.Select(s => s.ToLower());
            var results = _tramsDbContext.AcademyConversionProjects
            .Where(acp => lowerStatuses.Contains(acp.ProjectStatus.ToLower()))
            .Take(take)
            .AsNoTracking()
            .ToList();

            return results;
        }
    }
}
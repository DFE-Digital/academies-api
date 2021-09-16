using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;

namespace TramsDataApi.Gateways
{
    public class AcademyConversionProjectGateway : IAcademyConversionProjectGateway
    {
        private readonly TramsDbContext _tramsDbContext;
        private readonly LegacyTramsDbContext _legacyDbContext;

        public AcademyConversionProjectGateway(TramsDbContext tramsDbContext, LegacyTramsDbContext legacyDbContext)
        {
            _tramsDbContext = tramsDbContext;
            _legacyDbContext = legacyDbContext;
        }

        public AcademyConversionProject GetById(int id)
        {
            return _tramsDbContext.AcademyConversionProjects.AsNoTracking().SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<AcademyConversionJoinModel> GetProjects(int take)
        {
            return _tramsDbContext.AcademyConversionProjects.Join(_legacyDbContext.IfdPipeline,
                acp => acp.IfdPipelineId,
                ifd => ifd.Sk,
                (acp, ifd) => AcademyConversionJoinModelFactory.Create(acp, ifd))
                .Take(take)
                .AsNoTracking()
                .ToList();
        }

        public AcademyConversionProject Update(AcademyConversionProject academyConversionProject)
        {
            var entity =_tramsDbContext.AcademyConversionProjects.Update(academyConversionProject);
            _tramsDbContext.SaveChanges();
            return entity.Entity;
        }
        public IEnumerable<AcademyConversionJoinModel> GetByStatuses(int take, List<string> statues)
        {
            var lowerStatuses = statues.Select(s => s.ToLower());
            var results = _tramsDbContext.AcademyConversionProjects
                .Join(_legacyDbContext.IfdPipeline,
                    acp => acp.IfdPipelineId,
                    ifd => ifd.Sk,
                (acp, ifd) => AcademyConversionJoinModelFactory.Create(acp, ifd))
                .Where(data => lowerStatuses.Contains(data.ProjectStatus.ToLower()))
            .Take(take)
            .AsNoTracking()
            .ToList();

            return results;
        }
        
        
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class AcademyTransferProjectGateway : IAcademyTransferProjectGateway
    {
        
        private readonly LegacyTramsDbContext _legacyTramsDbContext;
        private readonly TramsDbContext _tramsDbContext;

        public AcademyTransferProjectGateway(LegacyTramsDbContext legacyTramsDbContext, TramsDbContext tramsDbContext)
        {
            _legacyTramsDbContext = legacyTramsDbContext;
            _tramsDbContext = tramsDbContext;
        }
        
        public AcademyTransferProjects SaveAcademyTransferProject(AcademyTransferProjects project)
        {
            _tramsDbContext.AcademyTransferProjects.Update(project);
            _tramsDbContext.SaveChanges();

            return project;
        }
        
        public AcademyTransferProjects UpdateAcademyTransferProject(AcademyTransferProjects project)
        {
            
            _tramsDbContext.TransferringAcademies.RemoveRange(
                _tramsDbContext.TransferringAcademies.Where(
                    ta => ta.FkAcademyTransferProject == project
                    )
                );
            _tramsDbContext.AcademyTransferProjectIntendedTransferBenefits.RemoveRange(_tramsDbContext.AcademyTransferProjectIntendedTransferBenefits.Where(
                    ta => ta.FkAcademyTransferProject == project
                )
            );
            _tramsDbContext.AcademyTransferProjects.Update(project);
            
            _tramsDbContext.SaveChanges();

            return project;
        }

        public IList<AcademyTransferProjects> IndexAcademyTransferProjects(int page)
        {
            return _tramsDbContext.AcademyTransferProjects
                .Include(atp => atp.AcademyTransferProjectIntendedTransferBenefits)
                .Include(atp => atp.TransferringAcademies)
                .OrderByDescending(atp => atp.Id)
                .Skip((page - 1) * 10).Take(10).ToList();
        }

        public AcademyTransferProjects GetAcademyTransferProjectByUrn(int urn)
        {
            return _tramsDbContext.AcademyTransferProjects
                .Include(atp => atp.AcademyTransferProjectIntendedTransferBenefits)
                .Include(atp => atp.TransferringAcademies)
                .FirstOrDefault(atp => atp.Urn == urn);
        }
        public async Task<PagedResult<AcademyTransferProjects>> SearchProjects(int page, int count, int? urn, string title)
        {
            IQueryable<AcademyTransferProjects> academyTransferProjects = _tramsDbContext.AcademyTransferProjects
                .Include(atp => atp.AcademyTransferProjectIntendedTransferBenefits)
                .Include(atp => atp.TransferringAcademies);

            academyTransferProjects = FilterByUrn(urn, academyTransferProjects);
            academyTransferProjects = FilterByTrust(title, academyTransferProjects);

            var totalProjects = academyTransferProjects.Count();
            var projects = await academyTransferProjects.ToListAsync();
            return new PagedResult<AcademyTransferProjects>(projects
                .OrderByDescending(atp => atp.Id)
                .Skip((page - 1) * 10).Take(10).ToList(), totalProjects);
        }
        private static IQueryable<AcademyTransferProjects> FilterByTrust(string title, IQueryable<AcademyTransferProjects> queryable)
        {
            if (!string.IsNullOrWhiteSpace(title)) queryable = queryable.Where(p => p.ProjectReference!.ToLower().Contains(title!.ToLower()));

            return queryable;
        }
        private static IQueryable<AcademyTransferProjects> FilterByUrn(int? urn, IQueryable<AcademyTransferProjects> queryable)
        {
            if (urn.HasValue) queryable = queryable.Where(p => p.Urn == urn);

            return queryable;
        }
    }
}
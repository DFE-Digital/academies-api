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

        public async Task<List<string>> GetAvailableProjectStatuses()
        {
            return await _tramsDbContext.AcademyConversionProjects
                .OrderByDescending(p => p.ProjectStatus)
                .AsNoTracking()
                .Select(p => p.ProjectStatus)
                .Distinct()
                .ToListAsync();
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

        public async Task<PagedResult<AcademyConversionProject>> SearchProjects(int page, int count,
            IEnumerable<string> statuses, int? urn, string title, IEnumerable<string> deliveryOfficers, IEnumerable<int?> regions = default)
        {
            IQueryable<AcademyConversionProject> academyConversionProjects = _tramsDbContext.AcademyConversionProjects;

            academyConversionProjects = FilterByRegion(regions, academyConversionProjects);
            academyConversionProjects = FilterByStatus(statuses, academyConversionProjects);
            academyConversionProjects = FilterByUrn(urn, academyConversionProjects);
            academyConversionProjects = FilterBySchool(title, academyConversionProjects);
            academyConversionProjects = FilterByDeliveryOfficer(deliveryOfficers, academyConversionProjects);

            var totalProjects = academyConversionProjects.Count();
            var projects = await academyConversionProjects.OrderByDescending(acp => acp.ApplicationReceivedDate)
                .Skip((page - 1) * count)
                .Take(count).ToListAsync();
            return new PagedResult<AcademyConversionProject>(projects, totalProjects);
        }

        private static IQueryable<AcademyConversionProject> FilterByDeliveryOfficer(IEnumerable<string> deliveryOfficers,
            IQueryable<AcademyConversionProject> queryable)
        {
            if (deliveryOfficers != null && deliveryOfficers.Any())
            {
                var lowerCaseDeliveryOfficers = deliveryOfficers.Select(officer => officer.ToLower());

                if (lowerCaseDeliveryOfficers.Contains("not assigned"))
                {
                    // Query by unassigned or assigned delivery officer
                    queryable = queryable.Where(p =>
                        (!string.IsNullOrEmpty(p.AssignedUserFullName) &&
                         lowerCaseDeliveryOfficers.Contains(p.AssignedUserFullName.ToLower()))
                        || string.IsNullOrEmpty(p.AssignedUserFullName));
                }
                else
                {
                    // Query by assigned delivery officer only
                    queryable = queryable.Where(p =>
                        !string.IsNullOrEmpty(p.AssignedUserFullName) &&
                        lowerCaseDeliveryOfficers.Contains(p.AssignedUserFullName.ToLower()));
                }
            }

            return queryable;
        }
        private static IQueryable<AcademyConversionProject> FilterByStatus(IEnumerable<string> states, IQueryable<AcademyConversionProject> queryable)
        {
            if (states != null && states!.Any())
            {
                queryable = queryable.Where(p => states.Contains(p.ProjectStatus!.ToLower()));
            }

            return queryable;
        }
        private static IQueryable<AcademyConversionProject> FilterByRegion(IEnumerable<int?> regions, IQueryable<AcademyConversionProject> queryable)
        {
            if (regions != null)
            {
                queryable = queryable.Where(p => regions.Contains(p.Urn));
            }

            return queryable;
        }

        private static IQueryable<AcademyConversionProject> FilterByUrn(int? urn, IQueryable<AcademyConversionProject> queryable)
        {
            if (urn.HasValue) queryable = queryable.Where(p => p.Urn == urn);

            return queryable;
        }

        private static IQueryable<AcademyConversionProject> FilterBySchool(string title, IQueryable<AcademyConversionProject> queryable)
        {
            if (!string.IsNullOrWhiteSpace(title)) queryable = queryable.Where(p => p.SchoolName!.ToLower().Contains(title!.ToLower()));

            return queryable;
        }
    }
}
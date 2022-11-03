using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.AcademyTransferProject;

namespace TramsDataApi.UseCases
{
    public class SearchAcademyTransferProjects : ISearchAcademyTransferProjects
    {
        private readonly IAcademyTransferProjectGateway _academyTransferProjectGateway;
        private readonly IIndexAcademyTransferProjects _indexAcademyTransfer;

        public SearchAcademyTransferProjects(
            IAcademyTransferProjectGateway academyTransferProjectGateway, IIndexAcademyTransferProjects indexAcademyTransfer)
        {
            _academyTransferProjectGateway = academyTransferProjectGateway;
            _indexAcademyTransfer = indexAcademyTransfer;
        }

        public Task<PagedResult<AcademyTransferProjectSummaryResponse>> Execute(int page, int count, int? urn, string title)
        {
            IEnumerable<AcademyTransferProjects> academyTransferProjects = _academyTransferProjectGateway.GetAcademyTransferProjects();
            
            IEnumerable<AcademyTransferProjectSummaryResponse> projects = academyTransferProjects.Select(project => _indexAcademyTransfer.AcademyTransferProjectSummaryResponse(project)); //.ToList();

            projects = FilterByUrn(urn, projects);
            projects = FilterByIncomingTrust(title, projects);
            int recordTotal = academyTransferProjects.Count();
            projects = projects.OrderByDescending(atp => atp.ProjectUrn)
                .Skip((page - 1) * 10).Take(10).ToList();
            return Task.FromResult(new PagedResult<AcademyTransferProjectSummaryResponse>(projects, recordTotal));
        }
        private static IEnumerable<AcademyTransferProjectSummaryResponse> FilterByUrn(int? urn, IEnumerable<AcademyTransferProjectSummaryResponse> queryable)
        {
            if (urn.HasValue) queryable = queryable.Where(p => p.ProjectUrn == urn.ToString()); //.ToList();

            return queryable;
        }
        private static IEnumerable<AcademyTransferProjectSummaryResponse> FilterByIncomingTrust(string title, IEnumerable<AcademyTransferProjectSummaryResponse> queryable)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                queryable = queryable.Where(p => p.TransferringAcademies.Any(r => r.IncomingTrustName!.ToLower().Contains(title!.ToLower()))); //.ToList();
            }
            return queryable;
        }
}
}

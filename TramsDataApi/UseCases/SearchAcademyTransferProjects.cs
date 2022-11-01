using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.AcademyTransferProject;

namespace TramsDataApi.UseCases
{
    public class SearchAcademyTransferProjects : ISearchAcademyTransferProjects
    {
        private readonly IAcademyTransferProjectGateway _academyTransferProjectGateway;
        private readonly ITrustGateway _trustGateway;

        public SearchAcademyTransferProjects(
            IAcademyTransferProjectGateway academyTransferProjectGateway,
            IEstablishmentGateway establishmentGateway, ITrustGateway trustGateway)
        {
            _academyTransferProjectGateway = academyTransferProjectGateway;
        }

        public async Task<PagedResult<AcademyTransferProjectSummaryResponse>> Execute(int page, int count, int? urn, string title)
        {
            var academyTransferProjects = _academyTransferProjectGateway.GetAcademyTransferProjects();
            var recordTotal = academyTransferProjects.Count();

            var projects = _trustGateway.CreateAcademyTransferProjectSummaryResponseForTrust(academyTransferProjects);

            projects = FilterByUrn(urn, projects);
            projects = FilterByIncomingTrust(title, projects);
            projects = projects.OrderByDescending(atp => atp.ProjectUrn)
                .Skip((page - 1) * 10).Take(10).ToList();
            return new PagedResult<AcademyTransferProjectSummaryResponse>(projects, recordTotal);
        }

        private static List<AcademyTransferProjectSummaryResponse> FilterByUrn(int? urn, List<AcademyTransferProjectSummaryResponse> queryable)
        {
            if (urn.HasValue) queryable = queryable.Where(p => p.ProjectUrn == urn.ToString()).ToList();

            return queryable;
        }
        private static List<AcademyTransferProjectSummaryResponse> FilterByIncomingTrust(string title, List<AcademyTransferProjectSummaryResponse> queryable)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                queryable = queryable.Where(p => p.TransferringAcademies.Any(r => r.IncomingTrustName!.ToLower().Contains(title!.ToLower()))).ToList();
            }

            return queryable;
        }
    }
}

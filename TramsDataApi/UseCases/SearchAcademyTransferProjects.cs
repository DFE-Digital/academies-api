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
        private readonly IIndexAcademyTransferProjects _indexAcademyTransfer;

        public SearchAcademyTransferProjects(
            IAcademyTransferProjectGateway academyTransferProjectGateway, ITrustGateway trustGateway, IIndexAcademyTransferProjects indexAcademyTransfer)
        {
            _academyTransferProjectGateway = academyTransferProjectGateway;
            _indexAcademyTransfer = indexAcademyTransfer;
        }

        public async Task<PagedResult<AcademyTransferProjectSummaryResponse>> Execute(int page, int count, int? urn, string title)
        {
            var academyTransferProjects = await _academyTransferProjectGateway
                .SearchProjects(page, count, urn, title);

            if (academyTransferProjects == null) return new PagedResult<AcademyTransferProjectSummaryResponse>();

            var projects = academyTransferProjects.Results.Select(atp => _indexAcademyTransfer.AcademyTransferProjectSummaryResponse(atp)).ToList();

            return new PagedResult<AcademyTransferProjectSummaryResponse>(projects, academyTransferProjects.TotalCount);
        }
    }
}

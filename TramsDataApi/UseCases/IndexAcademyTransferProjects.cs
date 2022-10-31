using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.AcademyTransferProject;

namespace TramsDataApi.UseCases
{
    public class IndexAcademyTransferProjects : IIndexAcademyTransferProjects
    {
        private readonly IAcademyTransferProjectGateway _academyTransferProjectGateway;
        private readonly ITrustGateway _trustGateway;

        public IndexAcademyTransferProjects(IAcademyTransferProjectGateway academyTransferProjectGateway,
            ITrustGateway trustGateway)
        {
            _academyTransferProjectGateway = academyTransferProjectGateway;
            _trustGateway = trustGateway;
        }

        public IList<AcademyTransferProjectSummaryResponse> Execute(int page)
        {
            var listOfAcademyTransferProjects = _academyTransferProjectGateway.IndexAcademyTransferProjects(page);

            return AcademyTransferProjectFactory.AcademyTransferProjectSummaryResponseFactory(
                listOfAcademyTransferProjects);
        }
    }
}
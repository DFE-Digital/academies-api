using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class IndexAcademyTransferProjects : IIndexAcademyTransferProjects
    {
        private readonly IAcademyTransferProjectGateway _academyTranferProjectGateway;
        private readonly ITrustGateway _trustGateway;

        public IndexAcademyTransferProjects(IAcademyTransferProjectGateway academyTransferProjectGateway,
            ITrustGateway trustGateway)
        {
            _academyTranferProjectGateway = academyTransferProjectGateway;
            _trustGateway = trustGateway;
        }

        public IList<AcademyTransferProjectSummaryResponse> Execute(int page)
        {
            var listOfAcademyTransferProjects = _academyTranferProjectGateway.IndexAcademyTransferProjects(page);

            return listOfAcademyTransferProjects.ToList().Select(atp => new AcademyTransferProjectSummaryResponse
            {
                ProjectUrn = atp.Urn.ToString(),
                OutgoingTrustUkprn = atp.OutgoingTrustUkprn,
                OutgoingTrustName = _trustGateway.GetGroupByUkPrn(atp.OutgoingTrustUkprn).GroupName,
                TransferringAcademies = atp.TransferringAcademies.Select(ta =>
                {
                    var group = _trustGateway.GetGroupByUkPrn(ta.IncomingTrustUkprn);
                    return new TransferringAcademiesResponse
                    {
                        OutgoingAcademyUkprn = ta.OutgoingAcademyUkprn,
                        IncomingTrustUkprn = ta.IncomingTrustUkprn,
                        IncomingTrustName = group.GroupName,
                        IncomingTrustLeadRscRegion = _trustGateway.GetIfdTrustByGroupId(group.GroupId).LeadRscRegion
                    };
                }).ToList()
            }).ToList();
        }
    }
}
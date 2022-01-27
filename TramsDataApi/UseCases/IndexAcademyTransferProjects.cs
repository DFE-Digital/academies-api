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

            return listOfAcademyTransferProjects.ToList().Select(atp =>
            {
                var outgoingGroup = _trustGateway.GetGroupByUkPrn(atp.OutgoingTrustUkprn);
                return new AcademyTransferProjectSummaryResponse()
                {
                    ProjectUrn = atp.Urn.ToString(),
                    ProjectReference = atp.ProjectReference,
                    OutgoingTrustUkprn = atp.OutgoingTrustUkprn,
                    OutgoingTrustName = outgoingGroup.GroupName,
                    OutgoingTrustLeadRscRegion =
                        _trustGateway.GetIfdTrustByGroupId(outgoingGroup.GroupId).LeadRscRegion,
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
                };
            }).ToList();
        }
    }
}
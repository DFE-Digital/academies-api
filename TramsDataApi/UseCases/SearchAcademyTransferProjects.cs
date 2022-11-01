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
            IAcademyTransferProjectGateway academyTransferProjectGateway, ITrustGateway trustGateway)
        {
            _academyTransferProjectGateway = academyTransferProjectGateway;
            _trustGateway = trustGateway;
        }

        public async Task<PagedResult<AcademyTransferProjectSummaryResponse>> Execute(int page, int count, int? urn, string title)
        {
            var academyTransferProjects = await _academyTransferProjectGateway
                .SearchProjects(page, count, urn, title);

            if (academyTransferProjects == null) return new PagedResult<AcademyTransferProjectSummaryResponse>();

            var projects = academyTransferProjects.Results.Select(atp =>
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
                            IncomingTrustLeadRscRegion = _trustGateway.GetIfdTrustByGroupId(group.GroupId).LeadRscRegion,
                            PupilNumbersAdditionalInformation = ta.PupilNumbersAdditionalInformation,
                            LatestOfstedReportAdditionalInformation = ta.LatestOfstedReportAdditionalInformation,
                            KeyStage2PerformanceAdditionalInformation = ta.KeyStage2PerformanceAdditionalInformation,
                            KeyStage4PerformanceAdditionalInformation = ta.KeyStage4PerformanceAdditionalInformation,
                            KeyStage5PerformanceAdditionalInformation = ta.KeyStage5PerformanceAdditionalInformation
                        };
                    }).ToList()
                };
            }).ToList();

            return new PagedResult<AcademyTransferProjectSummaryResponse>(projects, academyTransferProjects.TotalCount);
        }
    }
}

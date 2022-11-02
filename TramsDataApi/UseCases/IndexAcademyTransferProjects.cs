using System;
using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;
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

        public Tuple<IList<AcademyTransferProjectSummaryResponse>, int> Execute(int page)
        {
           Tuple<IList<AcademyTransferProjects>, int> listOfAcademyTransferProjects =
              _academyTransferProjectGateway.IndexAcademyTransferProjects(page);

           return Tuple.Create<IList<AcademyTransferProjectSummaryResponse>, int>(
              listOfAcademyTransferProjects.Item1.Select(AcademyTransferProjectSummaryResponse).ToList(),
              listOfAcademyTransferProjects.Item2);
        }

        public AcademyTransferProjectSummaryResponse AcademyTransferProjectSummaryResponse(AcademyTransferProjects atp)
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
        }
    }
}
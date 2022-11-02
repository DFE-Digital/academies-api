using FizzWare.NBuilder;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.AcademyTransferProject;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class SearchAcademyTransferProjectsTests
    {
        [Fact]
        public void Search_ReturnsAListOfAcademyTransferProjectSummaryResponses_WhenThereAreAcademyTransferProjects_ByTitle()
        {
            string outgoingTrust = nameof(outgoingTrust);
            string incomingTrust = nameof(incomingTrust);
            var expectedAcademyTransferProjects = Builder<AcademyTransferProjects>.CreateListOfSize(5).All()
                .With(p => p.OutgoingTrustUkprn = outgoingTrust)
                .With(p => p.TransferringAcademies = Builder<TransferringAcademies>.CreateListOfSize(5).All()
                    .With(a => a.IncomingTrustUkprn = incomingTrust)
                    .With(a => a.PupilNumbersAdditionalInformation = "pupil numbers")
                    .With(a => a.LatestOfstedReportAdditionalInformation = "ofsted")
                    .With(a => a.KeyStage2PerformanceAdditionalInformation = "ks2")
                    .With(a => a.KeyStage4PerformanceAdditionalInformation = "ks4")
                    .With(a => a.KeyStage5PerformanceAdditionalInformation = "ks5")
                    .Build())
                .Build();

            var expectedOutgoingGroup = Builder<Group>.CreateNew().Build();
            var expectedOutgoingTrust = Builder<Trust>.CreateNew().Build();
            var expectedIncomingGroup = Builder<Group>.CreateNew().Build();
            var expectedIncomingTrust = Builder<Trust>.CreateNew().Build();

            var academyTransferProjectsGateway = new Mock<IAcademyTransferProjectGateway>();

            academyTransferProjectsGateway.Setup(atGateway => atGateway.GetAcademyTransferProjects())
                .Returns(() => expectedAcademyTransferProjects);

            var expectedIndexResponse = expectedAcademyTransferProjects
                .Select(atp => new AcademyTransferProjectSummaryResponse
                {
                    ProjectUrn = atp.Urn.ToString(),
                    ProjectReference = atp.ProjectReference,
                    OutgoingTrustUkprn = atp.OutgoingTrustUkprn,
                    OutgoingTrustName = expectedOutgoingGroup.GroupName,
                    OutgoingTrustLeadRscRegion = expectedOutgoingTrust.LeadRscRegion,
                    TransferringAcademies = atp.TransferringAcademies.Select(ta => new TransferringAcademiesResponse
                    {
                        OutgoingAcademyUkprn = ta.OutgoingAcademyUkprn,
                        IncomingTrustUkprn = ta.IncomingTrustUkprn,
                        IncomingTrustName = expectedIncomingGroup.GroupName,
                        IncomingTrustLeadRscRegion = expectedIncomingTrust.LeadRscRegion,
                        PupilNumbersAdditionalInformation = ta.PupilNumbersAdditionalInformation,
                        LatestOfstedReportAdditionalInformation = ta.LatestOfstedReportAdditionalInformation,
                        KeyStage2PerformanceAdditionalInformation = ta.KeyStage2PerformanceAdditionalInformation,
                        KeyStage4PerformanceAdditionalInformation = ta.KeyStage4PerformanceAdditionalInformation,
                        KeyStage5PerformanceAdditionalInformation = ta.KeyStage5PerformanceAdditionalInformation
                    }).ToList()
                }).ToList();

            var indexAcademyTransferProjects = new Mock<IIndexAcademyTransferProjects>();
            string searchCriteria = "Find me!";
            expectedIndexResponse[0].TransferringAcademies[0].IncomingTrustName = searchCriteria;
            for (int i = 0; i < expectedAcademyTransferProjects.Count; i++)
            {
                int j = i;
                indexAcademyTransferProjects.Setup(index => index.AcademyTransferProjectSummaryResponse(expectedAcademyTransferProjects[j]))
                .Returns(() => expectedIndexResponse[j]);
            }

            SearchAcademyTransferProjects useCase = new SearchAcademyTransferProjects(academyTransferProjectsGateway.Object, indexAcademyTransferProjects.Object);
            var searchResult = useCase.Execute(1, 50, default, searchCriteria).Result; 
            
            searchResult.Results.Should().NotBeEmpty();
            searchResult.Results.Count().Should().Be(1);
            searchResult.TotalCount.Should().Be(5);
            searchResult.Should().BeEquivalentTo(expectedIndexResponse[0]);
        }
    }
}

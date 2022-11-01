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
        //[Fact]
        //public void GetIndex_ReturnsAListOfAcademyTransferProjectSummaryResponses_WhenThereAreAcademyTransferProjects()
        //{
        //    var outgoingTrust = "outgoingTrust";
        //    var incomingTrust = "incomingTrust";
        //    var expectedAcademyTransferProjects = Builder<AcademyTransferProjects>.CreateListOfSize(5).All()
        //        .With(p => p.OutgoingTrustUkprn = outgoingTrust)
        //        .With(p => p.TransferringAcademies = Builder<TransferringAcademies>.CreateListOfSize(5).All()
        //            .With(a => a.IncomingTrustUkprn = incomingTrust)
        //            .With(a => a. = incomingTrust)
        //            .With(a => a.PupilNumbersAdditionalInformation = "pupil numbers")
        //            .With(a => a.LatestOfstedReportAdditionalInformation = "ofsted")
        //            .With(a => a.KeyStage2PerformanceAdditionalInformation = "ks2")
        //            .With(a => a.KeyStage4PerformanceAdditionalInformation = "ks4")
        //            .With(a => a.KeyStage5PerformanceAdditionalInformation = "ks5")
        //            .Build())
        //        .Build();

        //    var expectedOutgoingGroup = Builder<Group>.CreateNew().Build();
        //    var expectedOutgoingTrust = Builder<Trust>.CreateNew().Build();
        //    var expectedIncomingGroup = Builder<Group>.CreateNew().Build();
        //    var expectedIncomingTrust = Builder<Trust>.CreateNew().Build();

        //    var academyTransferProjectsGateway = new Mock<IAcademyTransferProjectGateway>();

        //    academyTransferProjectsGateway.Setup(atGateway => atGateway.SearchProjects(1, 50, expectedAcademyTransferProjects.First().Urn, expectedAcademyTransferProjects.First()))
        //        .Returns(() => expectedAcademyTransferProjects);

        //    var trustGateway = new Mock<ITrustGateway>();
        //    trustGateway.Setup(tg => tg.GetGroupByUkPrn(outgoingTrust)).Returns(expectedOutgoingGroup);
        //    trustGateway.Setup(tg => tg.GetGroupByUkPrn(incomingTrust)).Returns(expectedIncomingGroup);
        //    trustGateway.Setup(tg => tg.GetIfdTrustByGroupId(expectedOutgoingGroup.GroupId))
        //        .Returns(expectedOutgoingTrust);
        //    trustGateway.Setup(tg => tg.GetIfdTrustByGroupId(expectedIncomingGroup.GroupId))
        //        .Returns(expectedIncomingTrust);

        //    var expectedIndexResponse = expectedAcademyTransferProjects
        //        .Select(atp => new AcademyTransferProjectSummaryResponse
        //        {
        //            ProjectUrn = atp.Urn.ToString(),
        //            ProjectReference = atp.ProjectReference,
        //            OutgoingTrustUkprn = atp.OutgoingTrustUkprn,
        //            OutgoingTrustName = expectedOutgoingGroup.GroupName,
        //            OutgoingTrustLeadRscRegion = expectedOutgoingTrust.LeadRscRegion,
        //            TransferringAcademies = atp.TransferringAcademies.Select(ta => new TransferringAcademiesResponse
        //            {
        //                OutgoingAcademyUkprn = ta.OutgoingAcademyUkprn,
        //                IncomingTrustUkprn = ta.IncomingTrustUkprn,
        //                IncomingTrustName = expectedIncomingGroup.GroupName,
        //                IncomingTrustLeadRscRegion = expectedIncomingTrust.LeadRscRegion,
        //                PupilNumbersAdditionalInformation = ta.PupilNumbersAdditionalInformation,
        //                LatestOfstedReportAdditionalInformation = ta.LatestOfstedReportAdditionalInformation,
        //                KeyStage2PerformanceAdditionalInformation = ta.KeyStage2PerformanceAdditionalInformation,
        //                KeyStage4PerformanceAdditionalInformation = ta.KeyStage4PerformanceAdditionalInformation,
        //                KeyStage5PerformanceAdditionalInformation = ta.KeyStage5PerformanceAdditionalInformation
        //            }).ToList()
        //        }).ToList();


        //    var useCase = new IndexAcademyTransferProjects(academyTransferProjectsGateway.Object, trustGateway.Object);
        //    var result = useCase.Execute(1);

        //    result.Count.Should().Be(5);
        //    result.Should().BeEquivalentTo(expectedIndexResponse);
        }
    }

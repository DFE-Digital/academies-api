using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.AcademyTransferProject;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
   public class SearchAcademyTransferProjectsTests
   {
      private const int Outgoing = 0, Incoming = 1;

      [Fact]
      public void
         Search_ReturnsAListOfAcademyTransferProjectSummaryResponses_WhenThereAreAcademyTransferProjects_ByTitle()
      {
         IList<Trust> trusts = Builder<Trust>.CreateListOfSize(2).Build();
         IList<Group> groups = Builder<Group>.CreateListOfSize(2).Build();
         trusts[Outgoing].TrustRef = groups[Outgoing].GroupId;
         trusts[Incoming].TrustRef = groups[Incoming].GroupId;

         var academyTransferProjectsGateway = new Mock<IAcademyTransferProjectGateway>();
         var trustGateway = new Mock<ITrustGateway>();

         IList<AcademyTransferProjects> expectedAcademyTransferProjects = Builder<AcademyTransferProjects>
            .CreateListOfSize(5).All()
            .With(p => p.OutgoingTrustUkprn = groups[Outgoing].Ukprn)
            .With(p => p.TransferringAcademies = Builder<TransferringAcademies>.CreateListOfSize(3).All()
               .With(a => a.IncomingTrustUkprn = groups[Outgoing].Ukprn)
               .With(a => a.PupilNumbersAdditionalInformation = "pupil numbers")
               .With(a => a.LatestOfstedReportAdditionalInformation = "ofsted")
               .With(a => a.KeyStage2PerformanceAdditionalInformation = "ks2")
               .With(a => a.KeyStage4PerformanceAdditionalInformation = "ks4")
               .With(a => a.KeyStage5PerformanceAdditionalInformation = "ks5")
               .Build())
            .Build();

         expectedAcademyTransferProjects[1].TransferringAcademies.Skip(1).Take(1).First().IncomingTrustUkprn =
            groups[Incoming].Ukprn;

         academyTransferProjectsGateway.Setup(atGateway => atGateway.GetAcademyTransferProjects())
            .Returns(() => expectedAcademyTransferProjects);

         trustGateway.Setup(x => x.GetMultipleTrustsByGroupId(It.IsAny<IEnumerable<string>>()))
            .Returns(trusts);
         trustGateway.Setup(x => x.GetMultipleGroupsByUkprn(It.IsAny<IEnumerable<string>>()))
            .Returns(groups);

         var expectedIndexResponse = new List<AcademyTransferProjectSummaryResponse>
         {
            new AcademyTransferProjectSummaryResponse
            {
               ProjectUrn = expectedAcademyTransferProjects[1].Urn.ToString(),
               ProjectReference = expectedAcademyTransferProjects[1].ProjectReference,
               OutgoingTrustUkprn = expectedAcademyTransferProjects[1].OutgoingTrustUkprn,
               OutgoingTrustName = groups[Outgoing].GroupName,
               OutgoingTrustLeadRscRegion = trusts[Outgoing].LeadRscRegion,
               TransferringAcademies = expectedAcademyTransferProjects[1].TransferringAcademies.Select(ta =>
               {
                  Group group = groups.First(g => g.Ukprn == ta.IncomingTrustUkprn);
                  return new TransferringAcademiesResponse
                  {
                     OutgoingAcademyUkprn = ta.OutgoingAcademyUkprn,
                     IncomingTrustUkprn = ta.IncomingTrustUkprn,
                     IncomingTrustName = group.GroupName,
                     IncomingTrustLeadRscRegion = trusts.First(x => x.TrustRef == group.GroupId).LeadRscRegion,
                     PupilNumbersAdditionalInformation = ta.PupilNumbersAdditionalInformation,
                     LatestOfstedReportAdditionalInformation = ta.LatestOfstedReportAdditionalInformation,
                     KeyStage2PerformanceAdditionalInformation = ta.KeyStage2PerformanceAdditionalInformation,
                     KeyStage4PerformanceAdditionalInformation = ta.KeyStage4PerformanceAdditionalInformation,
                     KeyStage5PerformanceAdditionalInformation = ta.KeyStage5PerformanceAdditionalInformation
                  };
               }).ToList()
            }
         };

         var searchCriteria = groups[Incoming].GroupName;

         var useCase = new SearchAcademyTransferProjects(academyTransferProjectsGateway.Object, trustGateway.Object);

         PagedResult<AcademyTransferProjectSummaryResponse> searchResult =
            useCase.Execute(1, 50, default, searchCriteria).Result;

         searchResult.Results.Should().NotBeEmpty();
         searchResult.Results.Count().Should().Be(1);
         searchResult.TotalCount.Should().Be(1);
         searchResult.Results.Should().BeEquivalentTo(expectedIndexResponse);
      }
   }
}

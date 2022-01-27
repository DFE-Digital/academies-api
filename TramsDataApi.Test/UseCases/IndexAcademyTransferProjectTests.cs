using System.Linq;
using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class IndexAcademyTransferProjectTests
    {
        [Fact]
        public void GetIndex_ReturnsAListOfAcademyTransferProjectSummaryResponses_WhenThereAreAcademyTransferProjects()
        {
            var outgoingTrust = "outgoingTrust";
            var incomingTrust = "incomingTrust";
            var expectedAcademyTransferProjects = Builder<AcademyTransferProjects>.CreateListOfSize(5).All()
                .With(p => p.OutgoingTrustUkprn = outgoingTrust)
                .With(p => p.TransferringAcademies =  Builder<TransferringAcademies>.CreateListOfSize(5).All()
                    .With(a => a.IncomingTrustUkprn = incomingTrust).Build())
                .Build();
            
            var expectedOutgoingGroup = Builder<Group>.CreateNew().Build();
            var expectedIncomingGroup = Builder<Group>.CreateNew().Build();
            var expectedIncomingTrust = Builder<Trust>.CreateNew().Build();
            
            var academyTransferProjectsGateway = new Mock<IAcademyTransferProjectGateway>();

            academyTransferProjectsGateway.Setup(atGateway => atGateway.IndexAcademyTransferProjects(1))
                .Returns(() => expectedAcademyTransferProjects);

            var trustGateway = new Mock<ITrustGateway>();
            trustGateway.Setup(tg => tg.GetGroupByUkPrn(outgoingTrust)).Returns(expectedOutgoingGroup);
            trustGateway.Setup(tg => tg.GetGroupByUkPrn(incomingTrust)).Returns(expectedIncomingGroup);
            trustGateway.Setup(tg => tg.GetIfdTrustByGroupId(expectedIncomingGroup.GroupId)).Returns(expectedIncomingTrust);
            
            var expectedIndexResponse = expectedAcademyTransferProjects
                .Select(atp => new AcademyTransferProjectSummaryResponse
                {
                    ProjectUrn = atp.Urn.ToString(),
                    OutgoingTrustUkprn = atp.OutgoingTrustUkprn,
                    OutgoingTrustName = expectedOutgoingGroup.GroupName,
                    TransferringAcademies = atp.TransferringAcademies.Select(ta => new TransferringAcademiesResponse
                    {
                        OutgoingAcademyUkprn = ta.OutgoingAcademyUkprn,
                        IncomingTrustUkprn = ta.IncomingTrustUkprn,
                        IncomingTrustName = expectedIncomingGroup.GroupName,
                        IncomingTrustLeadRscRegion = expectedIncomingTrust.LeadRscRegion
                    }).ToList()
                }).ToList();

            
            var useCase = new IndexAcademyTransferProjects(academyTransferProjectsGateway.Object, trustGateway.Object);
            var result = useCase.Execute(1);


            result.Count.Should().Be(5);
            result.Should().BeEquivalentTo(expectedIndexResponse);
        }
    }
}
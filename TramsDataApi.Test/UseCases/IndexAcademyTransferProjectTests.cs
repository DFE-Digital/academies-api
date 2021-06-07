using System.Collections.Generic;
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
            var expectedAcademyTransferProjects = Builder<AcademyTransferProjects>.CreateListOfSize(5).Build();
            var academyTransferProjectsGateway = new Mock<IAcademyTransferProjectGateway>();

            academyTransferProjectsGateway.Setup(atGateway => atGateway.IndexAcademyTransferProjects(1))
                .Returns(() => expectedAcademyTransferProjects);

            var expectedIndexResponse = expectedAcademyTransferProjects
                .Select(atp => new AcademyTransferProjectSummaryResponse
                {
                    ProjectUrn = atp.Urn.ToString(),
                    OutgoingTrustUkprn = atp.OutgoingTrustUkprn,
                    TransferringAcademies = atp.TransferringAcademies.Select(ta => new TransferringAcademiesResponse
                    {
                        OutgoingAcademyUkprn = ta.OutgoingAcademyUkprn,
                        IncomingTrustUkprn = ta.IncomingTrustUkprn
                    }).ToList()
                }).ToList();
            
            var useCase = new IndexAcademyTransferProjects(academyTransferProjectsGateway.Object);
            var result = useCase.Execute(1);


            result.Count.Should().Be(5);
            result.Should().BeEquivalentTo(expectedIndexResponse);
        }
    }
}
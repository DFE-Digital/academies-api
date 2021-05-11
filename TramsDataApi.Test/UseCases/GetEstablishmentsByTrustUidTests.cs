using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class GetEstablishmentsByTrustUidTests
    {
        [Fact]
        public void GetEstablishmentsByTrustUid_ReturnsEmptyList_WhenNoEstablishmentsFound()
        {
            var trustUid = "trustuid";
            var establishmentsGateway = new Mock<IEstablishmentGateway>();
            establishmentsGateway.Setup(gateway => gateway.GetByTrustUid(trustUid)).Returns(() => new List<Establishment>());

            var useCase = new GetEstablishmentsByTrustUid(establishmentsGateway.Object);
            useCase.Execute(trustUid).Should().BeEmpty();
        }

        [Fact]
        public void GetEstablishmentsByTrustUid_ReturnsListOfEstablishmentResponses_WhenEstablishmentsAreFound()
        {
            var trustUid = "trustuid";
            var establishmentsGateway = new Mock<IEstablishmentGateway>();
            var establishments = Builder<Establishment>.CreateListOfSize(10).All()
                .With(e => e.TrustsCode = trustUid).Build();

            establishmentsGateway.Setup(gateway => gateway.GetByTrustUid(trustUid)).Returns(establishments);

            var expected = establishments.Select(AcademyResponseFactory.Create).ToList();
            var useCase = new GetEstablishmentsByTrustUid(establishmentsGateway.Object);
            var result = useCase.Execute(trustUid);

            result.Should().BeEquivalentTo(expected);
        }
    }
}
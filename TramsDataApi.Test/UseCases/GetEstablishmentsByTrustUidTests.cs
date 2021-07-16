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

            var expected = establishments.Select(e => EstablishmentResponseFactory.Create(e, null, null, null)).ToList();
            var useCase = new GetEstablishmentsByTrustUid(establishmentsGateway.Object);
            var result = useCase.Execute(trustUid);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void
            GetEstablishmentsByTrustUid_ReturnsListOfEstablishmentResponsesWithMisEstablishment_WhenMisEstablishmentsAreFound()
        {
            var trustUid = "trustuid";
            var establishmentsGateway = new Mock<IEstablishmentGateway>();
            var establishments = Builder<Establishment>.CreateListOfSize(10).All()
                .With(e => e.TrustsCode = trustUid).Build();
            var misEstablishments = Builder<MisEstablishments>.CreateListOfSize(establishments.Count)
                .All()
                .With((m, i) => m.Urn = establishments[i].Urn)
                .Build();
            
            establishmentsGateway.Setup(gateway => gateway.GetByTrustUid(trustUid)).Returns(establishments);
            for (var i = 0; i < establishments.Count; i++)
            {
                establishmentsGateway.Setup(gateway => gateway.GetMisEstablishmentByUrn(establishments[i].Urn)).Returns(misEstablishments[i]);

            }

            var expected = establishments.Select((e, i) => EstablishmentResponseFactory.Create(e, misEstablishments[i], null, null)).ToList();
;
            var useCase = new GetEstablishmentsByTrustUid(establishmentsGateway.Object);
            var result = useCase.Execute(trustUid);

            result.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void
            GetEstablishmentsByTrustUid_ReturnsListOfEstablishmentResponsesWithSmartData_WhenSmartDataIsFound()
        {
            var trustUid = "trustuid";
            var establishmentsGateway = new Mock<IEstablishmentGateway>();
            var establishments = Builder<Establishment>.CreateListOfSize(10).All()
                .With(e => e.TrustsCode = trustUid).Build();
            var smartDataList = Builder<SmartData>.CreateListOfSize(establishments.Count)
                .All()
                .With((s, i) => s.Urn = establishments[i].Urn.ToString())
                .Build();
            
            establishmentsGateway.Setup(gateway => gateway.GetByTrustUid(trustUid)).Returns(establishments);
            for (var i = 0; i < establishments.Count; i++)
            {
                establishmentsGateway.Setup(gateway => gateway.GetSmartDataByUrn(establishments[i].Urn)).Returns(smartDataList[i]);
            }

            var expected = establishments.Select((e, i) => EstablishmentResponseFactory.Create(e, null, smartDataList[i], null)).ToList();
            var useCase = new GetEstablishmentsByTrustUid(establishmentsGateway.Object);
            var result = useCase.Execute(trustUid);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetEstablishmentsByTrustUid_ReturnsListOfEstablishmentResponseWithFurtherEducationEstablishment_WhenFurtherEducationEstablishmentIsFound()
        {
            var trustUid = "trustuid";
            var establishmentsGateway = new Mock<IEstablishmentGateway>();
            var establishments = Builder<Establishment>.CreateListOfSize(10).All()
                .With(e => e.TrustsCode = trustUid).Build();

            var furtherEducationEstablishments = Builder<FurtherEducationEstablishments>.CreateListOfSize(establishments.Count)
                .All()
                .With((m, i) => m.ProviderUrn = establishments[i].Urn)
                .Build();

            establishmentsGateway.Setup(gateway => gateway.GetByTrustUid(trustUid)).Returns(establishments);
            for (var i = 0; i < establishments.Count; i++)
            {
                establishmentsGateway.Setup(gateway => gateway.GetFurtherEducationEstablishmentByUrn(establishments[i].Urn)).Returns(furtherEducationEstablishments[i]);
            }

            var expected = establishments.Select((e, i) => EstablishmentResponseFactory.Create(e, null, null, furtherEducationEstablishments[i])).ToList();

            var useCase = new GetEstablishmentsByTrustUid(establishmentsGateway.Object);
            var result = useCase.Execute(trustUid);

            result.Should().BeEquivalentTo(expected);
        }
    }
}
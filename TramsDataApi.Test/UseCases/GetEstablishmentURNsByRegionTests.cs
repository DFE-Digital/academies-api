using FizzWare.NBuilder.PropertyNaming;
using FizzWare.NBuilder;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using TramsDataApi.CensusData;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class GetEstablishmentURNsByRegionTests
    {
        private readonly GetEstablishmentsByRegion _useCase;
        private readonly Mock<IEstablishmentGateway> _establishmentGateway;

        private static readonly List<string> Regions = new List<string>()
        {
            "East",
            "West"
        };
        private static readonly List<string> SingularRegion = new List<string>()
        {
            "East"
        };

        public GetEstablishmentURNsByRegionTests()
        {
            BuilderSetup.SetDefaultPropertyName(new RandomValuePropertyNamer(new BuilderSettings()));

            _establishmentGateway = new Mock<IEstablishmentGateway>();
            _useCase = new GetEstablishmentsByRegion(_establishmentGateway.Object);
        }

        [Fact]
        public void GetEstablishmentURNsByRegion_ReturnsNull_WhenNoEstablishmentsAreFound()
        {
            _establishmentGateway.Setup(gateway => gateway.GetURNsByRegion(Regions)).Returns(() => new List<int>());

            _useCase.Execute(Regions).Should().BeEquivalentTo(new List<int>());
        }

        [Fact]
        public void GetEstablishmentURNsByRegion_ReturnsURN_WhenAnEstablishmentIsFound()
        {
            var establishment = Builder<Establishment>.CreateNew().With(e => e.GorName = Regions[0]).Build();
            var listOfURNs = new List<int>
            {
                establishment.Urn
            };
            _establishmentGateway.Setup(gateway => gateway.GetURNsByRegion(Regions)).Returns(listOfURNs);

            var result = _useCase.Execute(Regions);

            result.Should().BeEquivalentTo(listOfURNs);
        }
        [Fact]
        public void GetEstablishmentURNsByRegion_ReturnsURNs_WhenEstablishmentsAreFound()
        {
            var establishmentOne = Builder<Establishment>.CreateNew().With(e => e.GorName = Regions[0]).Build();
            var establishmentTwo = Builder<Establishment>.CreateNew().With(e => e.GorName = Regions[0]).Build();
            var listOfURNs = new List<int>
            {
                establishmentOne.Urn,
                establishmentTwo.Urn
            };
            _establishmentGateway.Setup(gateway => gateway.GetURNsByRegion(Regions)).Returns(listOfURNs);

            var result = _useCase.Execute(Regions);

            result.Should().BeEquivalentTo(listOfURNs);
            result.Count().Should().Be(2);
        }
        [Fact]
        public void GetEstablishmentURNsByRegion_ReturnsURNs_WhenAnEstablishmentsAreFoundWithMultipleRegions()
        {
            var establishmentOne = Builder<Establishment>.CreateNew().With(e => e.GorName = Regions[0]).Build();
            var establishmentTwo = Builder<Establishment>.CreateNew().With(e => e.GorName = Regions[1]).Build();
            var listOfURNs = new List<int>
            {
                establishmentOne.Urn,
                establishmentTwo.Urn
            };
            _establishmentGateway.Setup(gateway => gateway.GetURNsByRegion(Regions)).Returns(listOfURNs);

            var result = _useCase.Execute(Regions);

            result.Should().BeEquivalentTo(listOfURNs);
            result.Count().Should().Be(2);
        }
        [Fact]
        public void GetEstablishmentURNsByRegion_ReturnsRelevantURN_WhenAnEstablishmentsAreFoundWithMultipleRegions()
        {
            var establishmentOne = Builder<Establishment>.CreateNew().With(e => e.GorName = Regions[0]).Build();
            var listOfURNs = new List<int>
            {
                establishmentOne.Urn
            };
            _establishmentGateway.Setup(gateway => gateway.GetURNsByRegion(SingularRegion)).Returns(listOfURNs);

            var result = _useCase.Execute(SingularRegion);

            result.Should().BeEquivalentTo(listOfURNs);
            result.Count().Should().Be(1);
        }

    }
}
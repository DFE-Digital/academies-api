using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class SearchEstablishmentsTests
    {
        [Fact]
        public void SearchEstablishments_ReturnsEmptyList_IfGatewayReturnsNoEstablishments()
        {
            var request = new SearchEstablishmentsRequest
            {
                Name = "mockname",
                Ukprn = "mockukprn",
                Urn = 10010011,
            };

            var gateway = new Mock<IEstablishmentGateway>();
            gateway.Setup(g => g.SearchEstablishments(request.Urn, request.Ukprn, request.Name))
                .Returns(new List<Establishment>());

            var expected = new List<EstablishmentSummaryResponse>();
            var useCase = new SearchEstablishments(gateway.Object);
            
            var result = useCase.Execute(request);
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void SearchEstablishments_ReturnsListOfEstablishmentSummaryResponses_IfGatewayReturnsEstablishments()
        {
            var request = new SearchEstablishmentsRequest
            {
                Name = "mockname",
                Ukprn = "mockukprn",
                Urn = 10010011,
            };

            var responses = Builder<Establishment>.CreateListOfSize(10).Build();
            var gateway = new Mock<IEstablishmentGateway>();
            gateway.Setup(g => g.SearchEstablishments(request.Urn, request.Ukprn, request.Name))
                .Returns(responses);

            var expected = responses.Select(r => EstablishmentSummaryResponseFactory.Create(r)).ToList();
            var useCase = new SearchEstablishments(gateway.Object);
            
            var result = useCase.Execute(request);
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void SearchEstablishments_ReturnsListOfEstablishmentSummaryResponses_IfMissingParameters_AndIfGatewayReturnsEstablishments()
        {
            var request = new SearchEstablishmentsRequest
            {
                Name = "mockname",
                Ukprn = null,
                Urn = null
            };

            var responses = Builder<Establishment>.CreateListOfSize(10).Build();
            var gateway = new Mock<IEstablishmentGateway>();
            gateway.Setup(g => g.SearchEstablishments(request.Urn, request.Ukprn, request.Name))
                .Returns(responses);

            var expected = responses.Select(r => EstablishmentSummaryResponseFactory.Create(r)).ToList();
            var useCase = new SearchEstablishments(gateway.Object);
            
            var result = useCase.Execute(request);
            result.Should().BeEquivalentTo(expected);
        }


        [Fact]
        public void SearchEstablishments_ReturnsListOfEstablishmentSummaryResponses_IfRequestIsNull_AndIfGatewayReturnsEstablishments()
        {
            var responses = Builder<Establishment>.CreateListOfSize(10).Build();
            var gateway = new Mock<IEstablishmentGateway>();
            gateway.Setup(g => g.SearchEstablishments(null, null, null))
                .Returns(responses);

            var expected = responses.Select(r => EstablishmentSummaryResponseFactory.Create(r)).ToList();
            var useCase = new SearchEstablishments(gateway.Object);
            
            var result = useCase.Execute(null);
            result.Should().BeEquivalentTo(expected);
        }
    }
}
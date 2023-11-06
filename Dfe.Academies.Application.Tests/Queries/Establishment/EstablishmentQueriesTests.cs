using AutoFixture;
using Dfe.Academies.Application.Queries.Establishment;
using Dfe.Academies.Contracts.Establishments;
using Dfe.Academies.Contracts.Trusts;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;
using FluentAssertions;
using Moq;

namespace Dfe.Academies.Application.Tests.Queries.Establishment
{
    public class EstablishmentQueriesTests
    {

        private Fixture _fixture;

        public EstablishmentQueriesTests()
        {
            _fixture = new Fixture();
        }


        [Fact]
        public async Task GetByUkprn_WhenEstablishmentReturnedFromRepo_EstablishmentDtoIsReturned()
        {
            // Arrange
            var establishment = _fixture.Create<Domain.Establishment.Establishment?>();
            var mockRepo = new Mock<IEstablishmentRepository>();
            string ukprn = "1010101";
            mockRepo.Setup(x => x.GetEstablishmentByUkprn(It.Is<string>(v => v == ukprn), It.IsAny<CancellationToken>())).Returns(Task.FromResult(establishment));

            var establishmentQueries = new EstablishmentQueries(
                mockRepo.Object);

            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await establishmentQueries.GetByUkprn(
                ukprn,
                cancellationToken);

            // Assert
            result.Should().BeOfType(typeof(EstablishmentDto));
        }

        [Fact]
        public async Task GetByUrn_WhenEstablishmentReturnedFromRepo_EstablishmentDtoIsReturned()
        {
            // Arrange
            var establishment = _fixture.Create<Domain.Establishment.Establishment?>();
            var mockRepo = new Mock<IEstablishmentRepository>();
            string urn = "1010101";
            mockRepo.Setup(x => x.GetEstablishmentByUrn(It.Is<string>(v => v == urn), It.IsAny<CancellationToken>())).Returns(Task.FromResult(establishment));

            var establishmentQueries = new EstablishmentQueries(
                mockRepo.Object);

            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await establishmentQueries.GetByUrn(
                urn,
                cancellationToken);

            // Assert
            result.Should().BeOfType(typeof(EstablishmentDto));
        }

        [Fact]
        public async Task Search_WhenEstablishmentsReturnedFromRepo_EstablishmentDtoListAndCountIsReturned()
        {
            // Arrange
            var establishments = _fixture.Create<List<Domain.Establishment.Establishment>>();
            var mockRepo = new Mock<IEstablishmentRepository>();
            string urn = "1010101";
            string name = "Test name";
            string ukPrn = "Test UkPrn";
            mockRepo.Setup(x => x.Search(It.Is<string>(v => v == name), It.Is<string>(v => v == ukPrn), It.Is<string>(v => v == urn), It.IsAny<CancellationToken>())).Returns(Task.FromResult(establishments));

            var establishmentQueries = new EstablishmentQueries(
                mockRepo.Object);

            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await establishmentQueries.Search(
                name,
                ukPrn,
                urn,
                cancellationToken);

            // Assert
            result.Should().BeOfType(typeof((List<EstablishmentDto>, int)));
        }

        [Fact]
        public async Task GetURNsByRegion_WhenEstablishmentUrnsReturnedFromRepo_IEnumebrableOfIntIsReturned()
        {
            // Arrange
            string[] regions = _fixture.Create<string[]>();
            var establishmentUrns = _fixture.Create<List<int>>().AsEnumerable();
            var mockRepo = new Mock<IEstablishmentRepository>();
            mockRepo.Setup(x => x.GetURNsByRegion(It.Is<string[]>(v => v == regions), It.IsAny<CancellationToken>())).Returns(Task.FromResult(establishmentUrns));

            var establishmentQueries = new EstablishmentQueries(
                mockRepo.Object);
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await establishmentQueries.GetURNsByRegion(
                regions,
                cancellationToken);

            // Assert
            result.Should().BeAssignableTo(typeof(IEnumerable<int>));

        }

        [Fact]
        public async Task GetByUrns_WhenEstablishmentsReturnedFromRepo_ListOfEstablishmentDtoIsReturned()
        {
            // Arrange
            int[] Urns = _fixture.Create<int[]>();
            var establishments = _fixture.Create<List<Domain.Establishment.Establishment>>();
            var mockRepo = new Mock<IEstablishmentRepository>();
            mockRepo.Setup(x => x.GetByUrns(It.Is<int[]>(v => v == Urns), It.IsAny<CancellationToken>())).Returns(Task.FromResult(establishments));

            var establishmentQueries = new EstablishmentQueries(
                mockRepo.Object);
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);
            // Act
            var result = await establishmentQueries.GetByUrns(
                Urns, cancellationToken);

            // Assert
            result.Should().BeOfType(typeof(List<EstablishmentDto>));
        }
    }
}

using AutoFixture;
using Dfe.Academies.Application.Queries.Establishment;
using Dfe.Academies.Contracts.Establishments;
using Dfe.Academies.Contracts.Trusts;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

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

        //[Fact]
        //public async Task Search_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var establishmentQueries = this.CreateEstablishmentQueries();
        //    string name = null;
        //    string ukPrn = null;
        //    string urn = null;
        //    CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

        //    // Act
        //    var result = await establishmentQueries.Search(
        //        name,
        //        ukPrn,
        //        urn,
        //        cancellationToken);

        //    // Assert
        //    Assert.True(false);
        //    this.mockRepository.VerifyAll();
        //}

        //[Fact]
        //public async Task GetURNsByRegion_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var establishmentQueries = this.CreateEstablishmentQueries();
        //    string[] regions = null;
        //    CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

        //    // Act
        //    var result = await establishmentQueries.GetURNsByRegion(
        //        regions,
        //        cancellationToken);

        //    // Assert
        //    Assert.True(false);
        //    this.mockRepository.VerifyAll();
        //}

        //[Fact]
        //public async Task GetByUrns_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var establishmentQueries = this.CreateEstablishmentQueries();
        //    int[] Urns = null;

        //    // Act
        //    var result = await establishmentQueries.GetByUrns(
        //        Urns);

        //    // Assert
        //    Assert.True(false);
        //    this.mockRepository.VerifyAll();
        //}
    }
}

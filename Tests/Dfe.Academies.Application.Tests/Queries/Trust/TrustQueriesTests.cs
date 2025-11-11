using AutoFixture;
using Dfe.Academies.Application.Trust;
using Dfe.Academies.Domain.Interfaces.Repositories;
using Dfe.Academies.Domain.Trust;
using GovUK.Dfe.CoreLibs.Contracts.Academies.V4.Trusts;
using FluentAssertions;
using Moq;

namespace Dfe.Academies.Application.Tests.Queries.Trust
{
    public class TrustQueriesTests
    {
        private Fixture _fixture;

        public TrustQueriesTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetByUkprn_MatchingTrustInRepository_ReturnsTrustDto()
        {
            // Arrange
            var trust = _fixture.Create<Domain.Trust.Trust?>();
            var mockRepo = new Mock<ITrustRepository>();
            string ukprn = "1010101";
            mockRepo.Setup(x => x.GetTrustByUkprn(It.Is<string>(v => v == ukprn), It.IsAny<CancellationToken>())).Returns(Task.FromResult(trust));

                var trustQueries = new TrustQueries(mockRepo.Object);
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await trustQueries.GetByUkprn(
                ukprn,
                cancellationToken);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(trust.Name);
            result.Address.Street.Should().Be(trust.AddressLine1);
            result.Address.Additional.Should().Be(trust.AddressLine2);
            result.Address.Locality.Should().Be(trust.AddressLine3);
            result.Address.Town.Should().Be(trust.Town);
            result.Address.Postcode.Should().Be(trust.Postcode);
            result.Address.County.Should().Be(trust.County);
            result.ReferenceNumber.Should().Be(trust.GroupID);
            result.CompaniesHouseNumber.Should().Be(trust.CompaniesHouseNumber);
            result.Ukprn.Should().Be(trust.UKPRN);

        }

        [Fact]
        public async Task Search_TrustsReturnedFromRepo_eturnsAListOfTrustDtosInAPagedResponse()
        {
            // Arrange
            var trusts = _fixture.Create<List<Domain.Trust.Trust>>();
            var mockRepo = new Mock<ITrustRepository>();
            mockRepo.Setup(x => x.Search(
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<TrustStatus>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((trusts, trusts.Count))
            );

            var trustQueries = new TrustQueries(mockRepo.Object);
            int page = 0;
            int count = 0;
            string name = null;
            string ukPrn = null;
            string companiesHouseNumber = null;
            TrustStatus status = TrustStatus.Open;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await trustQueries.Search(
                page,
                count,
                name,
                ukPrn,
                companiesHouseNumber,
                status,
                cancellationToken);

            // Assert
            result.GetType().Should().Be(typeof((List<TrustDto>, int)));
            result.Should().NotBeNull();
            result.Item1.Count.Should().Be(trusts.Count);

            foreach (var trust in result.Item1)
            {
                var domainTrust = trusts.Single(x => x.UKPRN == trust.Ukprn);

                trust.Name.Should().Be(domainTrust.Name);
                trust.Address.Street.Should().Be(domainTrust.AddressLine1);
                trust.Address.Additional.Should().Be(domainTrust.AddressLine2);
                trust.Address.Locality.Should().Be(domainTrust.AddressLine3);
                trust.Address.Town.Should().Be(domainTrust.Town);
                trust.Address.Postcode.Should().Be(domainTrust.Postcode);
                trust.Address.County.Should().Be(domainTrust.County);
                trust.ReferenceNumber.Should().Be(domainTrust.GroupID);
                trust.CompaniesHouseNumber.Should().Be(domainTrust.CompaniesHouseNumber);
                trust.Ukprn.Should().Be(domainTrust.UKPRN);
            }
        }

        [Fact]
        public async Task GetByUkprns_TrustsReturnedFromRepo_ReturnsAListOfTrustDtos()
        {
            // Arrange
            var trusts = _fixture.Create<List<Domain.Trust.Trust>>();
            var mockRepo = new Mock<ITrustRepository>();
            mockRepo.Setup(x => x.GetTrustsByUkprns(It.IsAny<string[]>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(trusts));

            var trustQueries = new TrustQueries(mockRepo.Object);
            string[] ukprns = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await trustQueries.GetByUkprns(
                ukprns,
                cancellationToken);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(trusts.Count);

            foreach (var trust in result) {
                var domainTrust = trusts.Single(x => x.UKPRN == trust.Ukprn);

                trust.Name.Should().Be(domainTrust.Name);
                trust.Address.Street.Should().Be(domainTrust.AddressLine1);
                trust.Address.Additional.Should().Be(domainTrust.AddressLine2);
                trust.Address.Locality.Should().Be(domainTrust.AddressLine3);
                trust.Address.Town.Should().Be(domainTrust.Town);
                trust.Address.Postcode.Should().Be(domainTrust.Postcode);
                trust.Address.County.Should().Be(domainTrust.County);
                trust.ReferenceNumber.Should().Be(domainTrust.GroupID);
                trust.CompaniesHouseNumber.Should().Be(domainTrust.CompaniesHouseNumber);
                trust.Ukprn.Should().Be(domainTrust.UKPRN);
            }  
        }

        [Fact]
        public async Task GetTrustsByEstablishmentUrns_ReturnsMappedDictionary()
        {
            // Arrange 
            var urns = new List<int> { _fixture.Create<int>() % 1000000, _fixture.Create<int>() % 1000000 };
            var cancellationToken = CancellationToken.None;
            var trustsData = _fixture.CreateMany<Domain.Trust.Trust>(2).ToList();

            var trusts = new Dictionary<int, Domain.Trust.Trust>
            {
                [urns[0]] = trustsData.First(),
                [urns[1]] = trustsData.Last(), 
            };

            var mockRepo = new Mock<ITrustRepository>();
            mockRepo
            .Setup(repo => repo.GetTrustsByEstablishmentUrns(urns, cancellationToken))
            .ReturnsAsync(trusts);
            var trustQueries = new TrustQueries(mockRepo.Object);

            // Act
            var result = await trustQueries.GetTrustsByEstablishmentUrns(urns, cancellationToken);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(trusts.Count);
            foreach (var trust in result)
            {
                trust.Value.Should().NotBeNull();
                var trustData = trust.Value;
                var dbTrust = trusts.Select(x => x.Value).Single(x => x.UKPRN == trustData.Ukprn);

                trustData.Name.Should().Be(dbTrust.Name);
                trustData.Address.Street.Should().Be(dbTrust.AddressLine1);
                trustData.Address.Additional.Should().Be(dbTrust.AddressLine2);
                trustData.Address.Locality.Should().Be(dbTrust.AddressLine3);
                trustData.Address.Town.Should().Be(dbTrust.Town);
                trustData.Address.Postcode.Should().Be(dbTrust.Postcode);
                trustData.Address.County.Should().Be(dbTrust.County);
                trustData.ReferenceNumber.Should().Be(dbTrust.GroupID);
                trustData.CompaniesHouseNumber.Should().Be(dbTrust.CompaniesHouseNumber);
                trustData.Ukprn.Should().Be(dbTrust.UKPRN);
            }
        }
    }
}

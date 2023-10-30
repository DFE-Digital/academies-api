using Dfe.Academies.Application.Queries.Trust;
using Dfe.Academies.Domain.Trust;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Dfe.Academies.Application.Tests.Queries.Trust
{
    public class TrustQueriesTests
    {
        [Fact]
        public async Task GetByUkprn_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var trustQueries = new TrustQueries(TODO);
            string ukprn = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await trustQueries.GetByUkprn(
                ukprn,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task Search_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var trustQueries = new TrustQueries(TODO);
            int page = 0;
            int count = 0;
            string name = null;
            string ukPrn = null;
            string companiesHouseNumber = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await trustQueries.Search(
                page,
                count,
                name,
                ukPrn,
                companiesHouseNumber,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task GetByUkprns_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var trustQueries = new TrustQueries(TODO);
            string[] ukprns = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await trustQueries.GetByUkprns(
                ukprns,
                cancellationToken);

            // Assert
            Assert.True(false);
        }
    }
}

using Dfe.Academies.Application.LocalAuthority;
using Dfe.Academies.Domain.Interfaces.Repositories;
using GovUK.Dfe.CoreLibs.Contracts.Academies.V4.Establishments;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace Dfe.Academies.Application.Tests.Queries.LocalAuthority
{
    public class LocalAuthorityQueriesTests
    {
        private readonly ILocalAuthorityRepository _subLocalAuthorityRepository;

        public LocalAuthorityQueriesTests()
        {
            _subLocalAuthorityRepository = Substitute.For<ILocalAuthorityRepository>();
        }

        private LocalAuthorityQueries CreateLocalAuthorityQueries()
        {
            return new LocalAuthorityQueries(_subLocalAuthorityRepository);
        }

        #region Search Tests

        [Fact]
        public async Task Search_WithNullParameters_ReturnsAllLocalAuthorities()
        {
            // Arrange
            var localAuthorityQueries = CreateLocalAuthorityQueries();
            var expectedLocalAuthorities = CreateSampleLocalAuthorities();
            _subLocalAuthorityRepository.Search(Arg.Is<string>(x => x == null), Arg.Is<string>(x => x == null), Arg.Any<CancellationToken>())
                .Returns((expectedLocalAuthorities, expectedLocalAuthorities.Count));

            // Act
            var (result, recordCount) = await localAuthorityQueries.Search(null!, null!, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, recordCount);
            Assert.Equal(3, result.Count);
            Assert.Equal("Birmingham", result[0].Name);
            Assert.Equal("330", result[0].Code);
            Assert.Equal("Manchester", result[1].Name);
            Assert.Equal("352", result[1].Code);
            Assert.Equal("London", result[2].Name);
            Assert.Equal("201", result[2].Code);
        }

        [Fact]
        public async Task Search_WithNameParameter_ReturnsFilteredResults()
        {
            // Arrange
            var localAuthorityQueries = CreateLocalAuthorityQueries();
            var searchName = "Birmingham";
            var expectedLocalAuthorities = new List<Dfe.Academies.Domain.Establishment.LocalAuthority>
            {
                CreateLocalAuthority("Birmingham", "330")
            };
            _subLocalAuthorityRepository.Search(searchName, null!, Arg.Any<CancellationToken>())
                .Returns((expectedLocalAuthorities, expectedLocalAuthorities.Count));

            // Act
            var (result, recordCount) = await localAuthorityQueries.Search(searchName, null!, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, recordCount);
            Assert.Single(result);
            Assert.Equal("Birmingham", result[0].Name);
            Assert.Equal("330", result[0].Code);
            await _subLocalAuthorityRepository.Received(1).Search(searchName, Arg.Is<string>(x => x == null), Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task Search_WithCodeParameter_ReturnsFilteredResults()
        {
            // Arrange
            var localAuthorityQueries = CreateLocalAuthorityQueries();
            var searchCode = "330";
            var expectedLocalAuthorities = new List<Dfe.Academies.Domain.Establishment.LocalAuthority>
            {
                CreateLocalAuthority("Birmingham", "330")
            };
            _subLocalAuthorityRepository.Search(null!, searchCode, Arg.Any<CancellationToken>())
                .Returns((expectedLocalAuthorities, expectedLocalAuthorities.Count));

            // Act
            var (result, recordCount) = await localAuthorityQueries.Search(null!, searchCode, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, recordCount);
            Assert.Single(result);
            Assert.Equal("Birmingham", result[0].Name);
            Assert.Equal("330", result[0].Code);
            await _subLocalAuthorityRepository.Received(1).Search(Arg.Is<string>(x => x == null), searchCode, Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task Search_WithBothNameAndCodeParameters_ReturnsFilteredResults()
        {
            // Arrange
            var localAuthorityQueries = CreateLocalAuthorityQueries();
            var searchName = "Birmingham";
            var searchCode = "330";
            var expectedLocalAuthorities = new List<Dfe.Academies.Domain.Establishment.LocalAuthority>
            {
                CreateLocalAuthority("Birmingham", "330")
            };
            _subLocalAuthorityRepository.Search(searchName, searchCode, Arg.Any<CancellationToken>())
                .Returns((expectedLocalAuthorities, expectedLocalAuthorities.Count));

            // Act
            var (result, recordCount) = await localAuthorityQueries.Search(searchName, searchCode, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, recordCount);
            Assert.Single(result);
            Assert.Equal("Birmingham", result[0].Name);
            Assert.Equal("330", result[0].Code);
            await _subLocalAuthorityRepository.Received(1).Search(searchName, searchCode, Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task Search_WithNoMatchingResults_ReturnsEmptyList()
        {
            // Arrange
            var localAuthorityQueries = CreateLocalAuthorityQueries();
            var searchName = "NonExistentAuthority";
            var emptyList = new List<Dfe.Academies.Domain.Establishment.LocalAuthority>();
            _subLocalAuthorityRepository.Search(searchName, null!, Arg.Any<CancellationToken>())
                .Returns((emptyList, 0));

            // Act
            var (result, recordCount) = await localAuthorityQueries.Search(searchName, null!, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, recordCount);
            Assert.Empty(result);
            await _subLocalAuthorityRepository.Received(1).Search(searchName, Arg.Is<string>(x => x == null), Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task Search_WithEmptyStringParameters_CallsRepositoryWithEmptyStrings()
        {
            // Arrange
            var localAuthorityQueries = CreateLocalAuthorityQueries();
            var emptyName = "";
            var emptyCode = "";
            var expectedLocalAuthorities = CreateSampleLocalAuthorities();
            _subLocalAuthorityRepository.Search(emptyName, emptyCode, Arg.Any<CancellationToken>())
                .Returns((expectedLocalAuthorities, expectedLocalAuthorities.Count));

            // Act
            var (result, recordCount) = await localAuthorityQueries.Search(emptyName, emptyCode, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, recordCount);
            Assert.Equal(3, result.Count);
            await _subLocalAuthorityRepository.Received(1).Search(emptyName, emptyCode, Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task Search_WithCancellationToken_PassesTokenToRepository()
        {
            // Arrange
            var localAuthorityQueries = CreateLocalAuthorityQueries();
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            var expectedLocalAuthorities = CreateSampleLocalAuthorities();
            _subLocalAuthorityRepository.Search(null!, null!, cancellationToken)
                .Returns((expectedLocalAuthorities, expectedLocalAuthorities.Count));

            // Act
            var (result, recordCount) = await localAuthorityQueries.Search(null!, null!, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, recordCount);
            await _subLocalAuthorityRepository.Received(1).Search(Arg.Is<string>(x => x == null), Arg.Is<string>(x => x == null), cancellationToken);
        }

        [Fact]
        public async Task Search_MapsLocalAuthorityToNameAndCodeDto_Correctly()
        {
            // Arrange
            var localAuthorityQueries = CreateLocalAuthorityQueries();
            var localAuthority = CreateLocalAuthority("Test Authority", "999");
            var expectedLocalAuthorities = new List<Dfe.Academies.Domain.Establishment.LocalAuthority> { localAuthority };
            _subLocalAuthorityRepository.Search(null!, null!, Arg.Any<CancellationToken>())
                .Returns((expectedLocalAuthorities, expectedLocalAuthorities.Count));

            // Act
            var (result, recordCount) = await localAuthorityQueries.Search(null!, null!, default);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            var mappedDto = result[0];
            Assert.IsType<NameAndCodeDto>(mappedDto);
            Assert.Equal("Test Authority", mappedDto.Name);
            Assert.Equal("999", mappedDto.Code);
        }

        [Fact]
        public async Task Search_WhenRepositoryThrowsException_PropagatesException()
        {
            // Arrange
            var localAuthorityQueries = CreateLocalAuthorityQueries();
            var expectedException = new InvalidOperationException("Repository error");
            _subLocalAuthorityRepository.Search(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<CancellationToken>())
                .ThrowsAsync(expectedException);

            // Act & Assert
            var actualException = await Assert.ThrowsAsync<InvalidOperationException>(
                () => localAuthorityQueries.Search("test", "test", default));

            Assert.Equal(expectedException.Message, actualException.Message);
        }

        [Fact]
        public async Task Search_WithMultipleResults_ReturnsCorrectCount()
        {
            // Arrange
            var localAuthorityQueries = CreateLocalAuthorityQueries();
            var expectedLocalAuthorities = CreateSampleLocalAuthorities();
            _subLocalAuthorityRepository.Search(null!, null!, Arg.Any<CancellationToken>())
                .Returns((expectedLocalAuthorities, expectedLocalAuthorities.Count));

            // Act
            var (result, recordCount) = await localAuthorityQueries.Search(null!, null!, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedLocalAuthorities.Count, recordCount);
            Assert.Equal(expectedLocalAuthorities.Count, result.Count);

            // Verify all items are mapped correctly
            for (int i = 0; i < expectedLocalAuthorities.Count; i++)
            {
                Assert.Equal(expectedLocalAuthorities[i].Name, result[i].Name);
                Assert.Equal(expectedLocalAuthorities[i].Code, result[i].Code);
            }
        }

        #endregion

        #region GetByCode Tests

        [Fact]
        public async Task GetByCode_WithValidCode_ReturnsLocalAuthority()
        {
            // Arrange
            var localAuthorityQueries = CreateLocalAuthorityQueries();
            var searchCode = "330";
            var expectedLocalAuthority = CreateLocalAuthority("Birmingham", "330");
            _subLocalAuthorityRepository.GetLocalAuthorityByCode(searchCode, Arg.Any<CancellationToken>())
                .Returns(expectedLocalAuthority);

            // Act
            var result = await localAuthorityQueries.GetByCode(searchCode, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Birmingham", result.Name);
            Assert.Equal("330", result.Code);
            await _subLocalAuthorityRepository.Received(1).GetLocalAuthorityByCode(searchCode, Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task GetByCode_WithNonExistentCode_ReturnsNull()
        {
            // Arrange
            var localAuthorityQueries = CreateLocalAuthorityQueries();
            var nonExistentCode = "999";
            _subLocalAuthorityRepository.GetLocalAuthorityByCode(nonExistentCode, Arg.Any<CancellationToken>())
                .Returns((Dfe.Academies.Domain.Establishment.LocalAuthority?)null);

            // Act
            var result = await localAuthorityQueries.GetByCode(nonExistentCode, default);

            // Assert
            Assert.Null(result);
            await _subLocalAuthorityRepository.Received(1).GetLocalAuthorityByCode(nonExistentCode, Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task GetByCode_WithNullCode_CallsRepositoryWithNull()
        {
            // Arrange
            var localAuthorityQueries = CreateLocalAuthorityQueries();
            _subLocalAuthorityRepository.GetLocalAuthorityByCode(null!, Arg.Any<CancellationToken>())
                .Returns((Dfe.Academies.Domain.Establishment.LocalAuthority?)null);

            // Act
            var result = await localAuthorityQueries.GetByCode(null!, default);

            // Assert
            Assert.Null(result);
            await _subLocalAuthorityRepository.Received(1).GetLocalAuthorityByCode(Arg.Is<string>(x => x == null), Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task GetByCode_WithEmptyCode_CallsRepositoryWithEmptyString()
        {
            // Arrange
            var localAuthorityQueries = CreateLocalAuthorityQueries();
            var emptyCode = "";
            _subLocalAuthorityRepository.GetLocalAuthorityByCode(emptyCode, Arg.Any<CancellationToken>())
                .Returns((Dfe.Academies.Domain.Establishment.LocalAuthority?)null);

            // Act
            var result = await localAuthorityQueries.GetByCode(emptyCode, default);

            // Assert
            Assert.Null(result);
            await _subLocalAuthorityRepository.Received(1).GetLocalAuthorityByCode(emptyCode, Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task GetByCode_WithCancellationToken_PassesTokenToRepository()
        {
            // Arrange
            var localAuthorityQueries = CreateLocalAuthorityQueries();
            var searchCode = "330";
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            var expectedLocalAuthority = CreateLocalAuthority("Birmingham", "330");

            _subLocalAuthorityRepository.GetLocalAuthorityByCode(searchCode, cancellationToken)
                .Returns(expectedLocalAuthority);

            // Act
            var result = await localAuthorityQueries.GetByCode(searchCode, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Birmingham", result.Name);
            Assert.Equal("330", result.Code);
            await _subLocalAuthorityRepository.Received(1).GetLocalAuthorityByCode(searchCode, cancellationToken);
        }

        [Fact]
        public async Task GetByCode_MapsLocalAuthorityToNameAndCodeDto_Correctly()
        {
            // Arrange
            var localAuthorityQueries = CreateLocalAuthorityQueries();
            var searchCode = "999";
            var localAuthority = CreateLocalAuthority("Test Authority", "999");
            _subLocalAuthorityRepository.GetLocalAuthorityByCode(searchCode, Arg.Any<CancellationToken>())
                .Returns(localAuthority);

            // Act
            var result = await localAuthorityQueries.GetByCode(searchCode, default);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NameAndCodeDto>(result);
            Assert.Equal("Test Authority", result.Name);
            Assert.Equal("999", result.Code);
        }

        [Fact]
        public async Task GetByCode_WhenRepositoryThrowsException_PropagatesException()
        {
            // Arrange
            var localAuthorityQueries = CreateLocalAuthorityQueries();
            var searchCode = "330";
            var expectedException = new InvalidOperationException("Database connection error");
            _subLocalAuthorityRepository.GetLocalAuthorityByCode(searchCode, Arg.Any<CancellationToken>())
                .ThrowsAsync(expectedException);

            // Act & Assert
            var actualException = await Assert.ThrowsAsync<InvalidOperationException>(
                () => localAuthorityQueries.GetByCode(searchCode, default));

            Assert.Equal(expectedException.Message, actualException.Message);
        }

        [Fact]
        public async Task GetByCode_WithWhitespaceCode_CallsRepositoryWithWhitespace()
        {
            // Arrange
            var localAuthorityQueries = CreateLocalAuthorityQueries();
            var whitespaceCode = "   ";
            _subLocalAuthorityRepository.GetLocalAuthorityByCode(whitespaceCode, Arg.Any<CancellationToken>())
                .Returns((Dfe.Academies.Domain.Establishment.LocalAuthority?)null);

            // Act
            var result = await localAuthorityQueries.GetByCode(whitespaceCode, default);

            // Assert
            Assert.Null(result);
            await _subLocalAuthorityRepository.Received(1).GetLocalAuthorityByCode(whitespaceCode, Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task GetByCode_WithSpecialCharacters_CallsRepositoryCorrectly()
        {
            // Arrange
            var localAuthorityQueries = CreateLocalAuthorityQueries();
            var specialCode = "A-1/B";
            var expectedLocalAuthority = CreateLocalAuthority("Special Authority", "A-1/B");
            _subLocalAuthorityRepository.GetLocalAuthorityByCode(specialCode, Arg.Any<CancellationToken>())
                .Returns(expectedLocalAuthority);

            // Act
            var result = await localAuthorityQueries.GetByCode(specialCode, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Special Authority", result.Name);
            Assert.Equal("A-1/B", result.Code);
            await _subLocalAuthorityRepository.Received(1).GetLocalAuthorityByCode(specialCode, Arg.Any<CancellationToken>());
        }

        #endregion

        #region Helper Methods

        private static List<Dfe.Academies.Domain.Establishment.LocalAuthority> CreateSampleLocalAuthorities()
        {
            return new List<Dfe.Academies.Domain.Establishment.LocalAuthority>
            {
                CreateLocalAuthority("Birmingham", "330"),
                CreateLocalAuthority("Manchester", "352"),
                CreateLocalAuthority("London", "201")
            };
        }

        private static Dfe.Academies.Domain.Establishment.LocalAuthority CreateLocalAuthority(string name, string code)
        {
            return new Dfe.Academies.Domain.Establishment.LocalAuthority
            {
                Name = name,
                Code = code,
                SK = Random.Shared.NextInt64(1, 1000)
            };
        }

        #endregion
    }
}

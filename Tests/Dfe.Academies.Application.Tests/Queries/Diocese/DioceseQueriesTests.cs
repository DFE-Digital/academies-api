using Dfe.Academies.Application.LocalAuthority;
using Dfe.Academies.Domain.Interfaces.Repositories;
using GovUK.Dfe.CoreLibs.Contracts.Academies.V4.Establishments;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace Dfe.Academies.Application.Tests.Queries.Diocese
{
    public class DioceseQueriesTests
    {
        private readonly IEstablishmentRepository _subEstablishmentRepository;

        public DioceseQueriesTests()
        {
            _subEstablishmentRepository = Substitute.For<IEstablishmentRepository>();
        }

        private DioceseQueries CreateDioceseQueries()
        {
            return new DioceseQueries(_subEstablishmentRepository);
        }

        #region Search Tests

        [Fact]
        public async Task Search_WithNullParameters_ReturnsAllDioceses()
        {
            // Arrange
            var dioceseQueries = CreateDioceseQueries();
            var expectedDioceses = CreateSampleDioceses();

            _subEstablishmentRepository
                .SearchDioceses(Arg.Is<string>(x => x == null), Arg.Is<string>(x => x == null), Arg.Any<CancellationToken>())
                .Returns((expectedDioceses, expectedDioceses.Count));

            // Act
            var (result, recordCount) = await dioceseQueries.Search(null!, null!, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, recordCount);
            Assert.Equal(3, result.Count);
            Assert.Equal("Diocese of Birmingham", result[0].Name);
            Assert.Equal("D330", result[0].Code);
        }

        [Fact]
        public async Task Search_WithNameParameter_ReturnsFilteredResults()
        {
            // Arrange
            var dioceseQueries = CreateDioceseQueries();
            var searchName = "Birmingham";
            var expectedDioceses = new List<Dfe.Academies.Domain.Establishment.Diocese>
            {
                CreateDiocese("Diocese of Birmingham", "D330")
            };

            _subEstablishmentRepository
                .SearchDioceses(searchName, null!, Arg.Any<CancellationToken>())
                .Returns((expectedDioceses, expectedDioceses.Count));

            // Act
            var (result, recordCount) = await dioceseQueries.Search(searchName, null!, default);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(1, recordCount);
            Assert.Equal("Diocese of Birmingham", result[0].Name);
            Assert.Equal("D330", result[0].Code);

            await _subEstablishmentRepository.Received(1)
                .SearchDioceses(searchName, Arg.Is<string>(x => x == null), Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task Search_WithCodeParameter_ReturnsFilteredResults()
        {
            // Arrange
            var dioceseQueries = CreateDioceseQueries();
            var searchCode = "D330";
            var expectedDioceses = new List<Dfe.Academies.Domain.Establishment.Diocese>
            {
                CreateDiocese("Diocese of Birmingham", "D330")
            };

            _subEstablishmentRepository
                .SearchDioceses(null!, searchCode, Arg.Any<CancellationToken>())
                .Returns((expectedDioceses, expectedDioceses.Count));

            // Act
            var (result, recordCount) = await dioceseQueries.Search(null!, searchCode, default);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(1, recordCount);
            Assert.Equal("Diocese of Birmingham", result[0].Name);
            Assert.Equal("D330", result[0].Code);

            await _subEstablishmentRepository.Received(1)
                .SearchDioceses(Arg.Is<string>(x => x == null), searchCode, Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task Search_WithNoMatchingResults_ReturnsEmptyList()
        {
            // Arrange
            var dioceseQueries = CreateDioceseQueries();
            var emptyList = new List<Dfe.Academies.Domain.Establishment.Diocese>();

            _subEstablishmentRepository
                .SearchDioceses("NoMatch", null!, Arg.Any<CancellationToken>())
                .Returns((emptyList, 0));

            // Act
            var (result, recordCount) = await dioceseQueries.Search("NoMatch", null!, default);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.Equal(0, recordCount);
        }

        [Fact]
        public async Task Search_WhenRepositoryThrowsException_PropagatesException()
        {
            // Arrange
            var dioceseQueries = CreateDioceseQueries();
            var expectedException = new InvalidOperationException("Repository error");

            _subEstablishmentRepository
                .SearchDioceses(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<CancellationToken>())
                .ThrowsAsync(expectedException);

            // Act & Assert
            var actualException = await Assert.ThrowsAsync<InvalidOperationException>(
                () => dioceseQueries.Search("test", "test", default));

            Assert.Equal(expectedException.Message, actualException.Message);
        }

        #endregion

        #region GetByCode Tests

        [Fact]
        public async Task GetByCode_WithValidCode_ReturnsDiocese()
        {
            // Arrange
            var dioceseQueries = CreateDioceseQueries();
            var code = "D330";
            var expected = CreateDiocese("Diocese of Birmingham", "D330");

            _subEstablishmentRepository
                .GetDioceseByCode(code, Arg.Any<CancellationToken>())
                .Returns(expected);

            // Act
            var result = await dioceseQueries.GetByCode(code, default);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NameAndCodeDto>(result);
            Assert.Equal("Diocese of Birmingham", result.Name);
            Assert.Equal("D330", result.Code);

            await _subEstablishmentRepository.Received(1)
                .GetDioceseByCode(code, Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task GetByCode_WithNonExistentCode_ReturnsNull()
        {
            // Arrange
            var dioceseQueries = CreateDioceseQueries();
            var code = "UNKNOWN";

            _subEstablishmentRepository
                .GetDioceseByCode(code, Arg.Any<CancellationToken>())
                .Returns((Dfe.Academies.Domain.Establishment.Diocese?)null);

            // Act
            var result = await dioceseQueries.GetByCode(code, default);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetByCode_WithCancellationToken_PassesTokenToRepository()
        {
            // Arrange
            var dioceseQueries = CreateDioceseQueries();
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var code = "D330";
            var expected = CreateDiocese("Diocese of Birmingham", "D330");

            _subEstablishmentRepository
                .GetDioceseByCode(code, token)
                .Returns(expected);

            // Act
            var result = await dioceseQueries.GetByCode(code, token);

            // Assert
            Assert.NotNull(result);
            await _subEstablishmentRepository.Received(1)
                .GetDioceseByCode(code, token);
        }

        [Fact]
        public async Task GetByCode_WhenRepositoryThrowsException_PropagatesException()
        {
            // Arrange
            var dioceseQueries = CreateDioceseQueries();
            var expectedException = new InvalidOperationException("Repository error");

            _subEstablishmentRepository
                .GetDioceseByCode(Arg.Any<string>(), Arg.Any<CancellationToken>())
                .ThrowsAsync(expectedException);

            // Act & Assert
            var actualException = await Assert.ThrowsAsync<InvalidOperationException>(
                () => dioceseQueries.GetByCode("D330", default));

            Assert.Equal(expectedException.Message, actualException.Message);
        }

        #endregion

        #region Helpers

        private static List<Dfe.Academies.Domain.Establishment.Diocese> CreateSampleDioceses()
        {
            return new List<Dfe.Academies.Domain.Establishment.Diocese>
            {
                CreateDiocese("Diocese of Birmingham", "D330"),
                CreateDiocese("Diocese of Sheffield", "D456"),
                CreateDiocese("Diocese of London", "D123")
            };
        }

        private static Dfe.Academies.Domain.Establishment.Diocese CreateDiocese(string name, string code)
        {
            return new Dfe.Academies.Domain.Establishment.Diocese
            {
                Name = name,
                Code = code
            };
        }

        #endregion
    }
}
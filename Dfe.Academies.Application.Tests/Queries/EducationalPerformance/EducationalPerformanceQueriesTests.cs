using AutoFixture;
using Dfe.Academies.Application.EducationalPerformance;
using Dfe.Academies.Contracts.V1.EducationalPerformance;
using Dfe.Academies.Domain.EducationalPerformance;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Dfe.Academies.Application.Tests.Queries.EducationalPerformance
{
    public class EducationalPerformanceQueriesTests
    {
        private Fixture _fixture = new Fixture();

        private MockRepository mockRepository;

        private Mock<IEducationalPerformanceRepository> mockEducationalPerformanceRepository;

        public EducationalPerformanceQueriesTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockEducationalPerformanceRepository = mockRepository.Create<IEducationalPerformanceRepository>();
        }

        private EducationalPerformanceQueries CreateEducationalPerformanceQueries()
        {
            return new EducationalPerformanceQueries(
                mockEducationalPerformanceRepository.Object);
        }

        [Fact]
        public async Task GetAchoolAbsenceDataByUrn_WhenAbsenceDataExists_DtoListIsReturnedWithCorrectCount()
        {
            // Arrange
            var urn = "100022";
            var absenceData = _fixture.Create<List<SchoolAbsence>>();
            mockEducationalPerformanceRepository.Setup(x => x.GetSchoolAbsencesByURN(It.Is<string>(y => y == urn), It.IsAny<CancellationToken>())).ReturnsAsync(absenceData);
            var educationalPerformanceQueries = CreateEducationalPerformanceQueries();

            // Act
            var result = await educationalPerformanceQueries.GetSchoolAbsenceDataByUrn(
                urn,
                default);

            // Assert
            result.Count.Should().Be(absenceData.Count);
            mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetAchoolAbsenceDataByUrn_WhenAbsenceDataExists_DtoListIsReturnedAndDataIsMappedCorrectly()
        {
            // Arrange
            var urn = "100022";
            var absenceData = _fixture.Create<List<SchoolAbsence>>();
            mockEducationalPerformanceRepository.Setup(x => x.GetSchoolAbsencesByURN(It.Is<string>(y => y == urn), It.IsAny<CancellationToken>())).ReturnsAsync(absenceData);
            var educationalPerformanceQueries = CreateEducationalPerformanceQueries();

            // Act
            var result = await educationalPerformanceQueries.GetSchoolAbsenceDataByUrn(
                urn,
                default);

            // Assert
            foreach (var absence in absenceData)
            {
                result.Should().ContainEquivalentOf(new SchoolAbsenceDataDto{ OverallAbsence = absence.PERCTOT, PersistentAbsence = absence.PPERSABS10, Year = absence.DownloadYear });
            }

            mockRepository.VerifyAll();
        }
    }
}

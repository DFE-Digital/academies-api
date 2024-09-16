using AutoFixture.Xunit2;
using AutoMapper;
using Dfe.Academies.Application.Common.Interfaces;
using Dfe.Academies.Application.Common.Models;
using Dfe.Academies.Application.Establishment.Queries.GetAllPersonsAssociatedWithAcademyByUrn;
using Dfe.Academies.Application.MappingProfiles;
using Dfe.Academies.Domain.Interfaces.Caching;
using Dfe.Academies.Infrastructure.Models;
using Dfe.Academies.Testing.Common.Attributes;
using Dfe.Academies.Testing.Common.Customizations;
using Dfe.Academies.Testing.Common.Customizations.Models;
using Dfe.Academies.Utils.Caching;
using NSubstitute;

namespace Dfe.Academies.Application.Tests.QueryHandlers.Establishment
{
    public class GetAllPersonsAssociatedWithAcademyByUrnQueryHandlerTests
    {
        [Theory]
        [CustomAutoData(
            typeof(AcademyGovernanceCustomization),
            typeof(AcademyGovernanceQueryModelCustomization),
            typeof(AutoMapperCustomization))]
        public async Task Handle_ShouldReturnPersonsAssociatedWithAcademy_WhenUrnExists(
            [Frozen] IEstablishmentQueryService mockEstablishmentQueryService,
            [Frozen] IMapper mockMapper,
            [Frozen] ICacheService mockCacheService,
            GetAllPersonsAssociatedWithAcademyByUrnQueryHandler handler,
            GetAllPersonsAssociatedWithAcademyByUrnQuery query,
            List<AcademyGovernance> expectedGovernances,
            IQueryable<AcademyGovernanceQueryModel> governanceQueryModels)
        {
            // Arrange
            var cacheKey = $"PersonsAssociatedWithAcademy_{CacheKeyHelper.GenerateHashedCacheKey(query.Urn.ToString())}";

            mockEstablishmentQueryService.GetPersonsAssociatedWithAcademyByUrn(query.Urn)
                .Returns(governanceQueryModels);

            mockCacheService.GetOrAddAsync(cacheKey, Arg.Any<Func<Task<List<AcademyGovernance>?>>>(), Arg.Any<string>())
                .Returns(expectedGovernances);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedGovernances.Count, result.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.Equal(expectedGovernances[i].FirstName, result[i].FirstName);
                Assert.Equal(expectedGovernances[i].LastName, result[i].LastName);
            }

            await mockCacheService.Received(1).GetOrAddAsync(cacheKey, Arg.Any<Func<Task<List<AcademyGovernance>?>>>(), nameof(GetAllPersonsAssociatedWithAcademyByUrnQueryHandler));
        }
    }
}

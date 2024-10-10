using AutoFixture;
using AutoFixture.Xunit2;
using Dfe.Academies.Application.Common.Interfaces;
using Dfe.Academies.Application.Common.Models;
using Dfe.Academies.Application.Establishment.Queries.GetAllPersonsAssociatedWithAcademyByUrn;
using Dfe.Academies.Application.MappingProfiles;
using Dfe.Academies.Testing.Common.Customizations.Models;
using DfE.CoreLibs.Caching.Helpers;
using DfE.CoreLibs.Caching.Interfaces;
using DfE.CoreLibs.Testing.AutoFixture.Attributes;
using DfE.CoreLibs.Testing.AutoFixture.Customizations;
using MockQueryable;
using NSubstitute;

namespace Dfe.Academies.Application.Tests.QueryHandlers.Establishment
{
    public class GetAllPersonsAssociatedWithAcademyByUrnQueryHandlerTests
    {
        [Theory]
        [CustomAutoData(
            typeof(OmitCircularReferenceCustomization),
            typeof(AcademyGovernanceCustomization),
            typeof(AcademyGovernanceQueryModelCustomization),
            typeof(AutoMapperCustomization<AcademyWithGovernanceProfile>))]
        public async Task Handle_ShouldReturnPersonsAssociatedWithAcademy_WhenUrnExists(
            [Frozen] IEstablishmentQueryService mockEstablishmentQueryService,
            [Frozen] ICacheService<IMemoryCacheType> mockCacheService,
            GetAllPersonsAssociatedWithAcademyByUrnQueryHandler handler,
            GetAllPersonsAssociatedWithAcademyByUrnQuery query,
            List<AcademyGovernanceQueryModel> governanceQueryModels,
            IFixture fixture)

        {
            // Arrange
            var expectedGovernances = governanceQueryModels.Select(governance =>
                fixture.Customize(new AcademyGovernanceCustomization
                {
                    FirstName = governance?.EducationEstablishmentGovernance?.Forename1,
                    LastName = governance?.EducationEstablishmentGovernance?.Surname,
                }).Create<AcademyGovernance>()).ToList();

            var cacheKey = $"PersonsAssociatedWithAcademy_{CacheKeyHelper.GenerateHashedCacheKey(query.Urn.ToString())}";

            var mock = governanceQueryModels.BuildMock();

            mockEstablishmentQueryService.GetPersonsAssociatedWithAcademyByUrn(query.Urn)
                .Returns(mock);

            mockCacheService.GetOrAddAsync(cacheKey, Arg.Any<Func<Task<List<AcademyGovernance>>>>(), Arg.Any<string>())
                .Returns(callInfo =>
                {
                    var callback = callInfo.ArgAt<Func<Task<List<AcademyGovernance>>>>(1);
                    return callback();
                });

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

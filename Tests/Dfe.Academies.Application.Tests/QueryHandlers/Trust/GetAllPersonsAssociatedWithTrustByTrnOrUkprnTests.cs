using AutoFixture;
using AutoFixture.Xunit2;
using Dfe.Academies.Application.Common.Interfaces;
using Dfe.Academies.Application.Common.Models;
using Dfe.Academies.Application.MappingProfiles;
using Dfe.Academies.Application.Trust.Queries.GetAllPersonsAssociatedWithTrustByTrnOrUkprn;
using Dfe.Academies.Testing.Common.Customizations.Models;
using DfE.CoreLibs.Caching.Helpers;
using DfE.CoreLibs.Caching.Interfaces;
using DfE.CoreLibs.Testing.AutoFixture.Attributes;
using DfE.CoreLibs.Testing.AutoFixture.Customizations;
using MockQueryable;
using NSubstitute;

namespace Dfe.Academies.Application.Tests.QueryHandlers.Trust
{
    public class GetAllPersonsAssociatedWithTrustByTrnOrUkprnQueryHandlerTests
    {
        [Theory]
        [CustomAutoData(
            typeof(OmitCircularReferenceCustomization),
            typeof(TrustGovernanceCustomization),
            typeof(TrustGovernanceQueryModelCustomization),
            typeof(AutoMapperCustomization<TrustWithGovernanceProfile>))]
        public async Task Handle_ShouldReturnPersonsAssociatedWithTrust_WhenTrustExists(
            [Frozen] ITrustQueryService mockTrustQueryService,
            [Frozen] ICacheService<IMemoryCacheType> mockCacheService,
            GetAllPersonsAssociatedWithTrustByTrnOrUkprnQueryHandler handler,
            List<TrustGovernanceQueryModel> governanceQueryModels,
            IFixture fixture)
        {
            // Arrange
            var expectedGovernances = governanceQueryModels.Select(governance =>
                fixture.Customize(new TrustGovernanceCustomization
                {
                    FirstName = governance?.TrustGovernance?.Forename1,
                    LastName = governance?.TrustGovernance?.Surname,
                }).Create<TrustGovernance>()).ToList();

            var query = new GetAllPersonsAssociatedWithTrustByTrnOrUkprnQuery("09532567");

            var cacheKey = $"PersonsAssociatedWithTrust_{CacheKeyHelper.GenerateHashedCacheKey(query.Id)}";

            var mock = governanceQueryModels.BuildMock();

            mockTrustQueryService.GetTrustGovernanceByGroupIdOrUkprn(Arg.Any<string>(), Arg.Any<string>())
                .Returns(mock);

            mockCacheService.GetOrAddAsync(cacheKey, Arg.Any<Func<Task<List<TrustGovernance>>>>(), Arg.Any<string>())
                .Returns(callInfo =>
                {
                    var callback = callInfo.ArgAt<Func<Task<List<TrustGovernance>>>>(1);
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

            await mockCacheService.Received(1).GetOrAddAsync(cacheKey, Arg.Any<Func<Task<List<TrustGovernance>?>>>(), nameof(GetAllPersonsAssociatedWithTrustByTrnOrUkprnQueryHandler));
        }
    }
}

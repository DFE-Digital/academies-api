using AutoFixture.Xunit2;
using AutoMapper;
using Dfe.Academies.Application.Common.Models;
using Dfe.Academies.Application.Constituencies.Queries.GetMemberOfParliamentByConstituencies;
using Dfe.Academies.Application.MappingProfiles;
using Dfe.Academies.Domain.Interfaces.Caching;
using Dfe.Academies.Domain.Interfaces.Repositories;
using Dfe.Academies.Testing.Common.Attributes;
using Dfe.Academies.Testing.Common.Customizations;
using Dfe.Academies.Testing.Common.Customizations.Entities;
using Dfe.Academies.Testing.Common.Customizations.Models;
using Dfe.Academies.Utils.Caching;
using NSubstitute;


namespace Dfe.Academies.Application.Tests.QueryHandlers.Constituency
{
    public class GetMemberOfParliamentByConstituenciesQueryHandlerTests
    {
        [Theory]
        [CustomAutoData(
            typeof(MemberOfParliamentCustomization),
            typeof(ConstituencyCustomization),
            typeof(AutoMapperCustomization<ConstituencyProfile>))]
        public async Task Handle_ShouldReturnMemberOfParliament_WhenConstituencyExists(
            [Frozen] IConstituencyRepository mockConstituencyRepository,
            [Frozen] IMapper mockMapper,
            [Frozen] ICacheService mockCacheService,
            GetMembersOfParliamentByConstituenciesQueryHandler handler,
            GetMembersOfParliamentByConstituenciesQuery query,
            List<Domain.Constituencies.Constituency> constituencies,
            List<MemberOfParliament> expectedMps)
        {
            // Arrange
            var cacheKey = $"MemberOfParliament_{CacheKeyHelper.GenerateHashedCacheKey(query.ConstituencyNames)}";

            mockConstituencyRepository.GetMembersOfParliamentByConstituenciesQueryable(query.ConstituencyNames)
                .Returns(constituencies.AsQueryable());

            mockCacheService.GetOrAddAsync(cacheKey, Arg.Any<Func<Task<List<MemberOfParliament>>>>(), Arg.Any<string>())
                .Returns(expectedMps);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMps.Count, result.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.Equal(expectedMps[i].FirstName, result[i].FirstName);
                Assert.Equal(expectedMps[i].LastName, result[i].LastName);
                Assert.Equal(expectedMps[i].ConstituencyName, result[i].ConstituencyName);
            }

            await mockCacheService.Received(1).GetOrAddAsync(cacheKey, Arg.Any<Func<Task<List<MemberOfParliament>>>>(), nameof(GetMembersOfParliamentByConstituenciesQueryHandler));
        }
    }
}

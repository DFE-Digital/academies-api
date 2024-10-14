using AutoFixture;
using AutoFixture.Xunit2;
using Dfe.Academies.Application.Common.Models;
using Dfe.Academies.Application.Constituencies.Queries.GetMemberOfParliamentByConstituencies;
using Dfe.Academies.Application.MappingProfiles;
using Dfe.Academies.Domain.Interfaces.Repositories;
using Dfe.Academies.Testing.Common.Customizations.Models;
using Dfe.Academies.Tests.Common.Customizations.Entities;
using DfE.CoreLibs.Caching.Helpers;
using DfE.CoreLibs.Caching.Interfaces;
using DfE.CoreLibs.Testing.AutoFixture.Attributes;
using DfE.CoreLibs.Testing.AutoFixture.Customizations;
using MockQueryable;
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
            [Frozen] ICacheService<IMemoryCacheType> mockCacheService,
            GetMembersOfParliamentByConstituenciesQueryHandler handler,
            GetMembersOfParliamentByConstituenciesQuery query,
            List<Domain.Constituencies.Constituency> constituencies,
            IFixture fixture)
        {
            // Arrange
            var expectedMps = constituencies.Select(constituency =>
                fixture.Customize(new MemberOfParliamentCustomization()
                {
                    FirstName = constituency.NameDetails.NameListAs.Split(",")[1].Trim(),
                    LastName = constituency.NameDetails.NameListAs.Split(",")[0].Trim(),
                    ConstituencyName = constituency.ConstituencyName,
                }).Create<MemberOfParliament>()).ToList();

            var cacheKey = $"MemberOfParliament_{CacheKeyHelper.GenerateHashedCacheKey(query.ConstituencyNames)}";

            var mock = constituencies.BuildMock();

            mockConstituencyRepository.GetMembersOfParliamentByConstituenciesQueryable(query.ConstituencyNames)
                .Returns(mock);

            mockCacheService.GetOrAddAsync(cacheKey, Arg.Any<Func<Task<Result<List<MemberOfParliament>>>>>(), Arg.Any<string>())
                .Returns(callInfo =>
                {
                    var callback = callInfo.ArgAt<Func<Task<Result<List<MemberOfParliament>>>>>(1);
                    return callback();
                });

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMps.Count, result.Value!.Count);
            for (int i = 0; i < result.Value!.Count; i++)
            {
                Assert.Equal(expectedMps[i].FirstName, result.Value![i].FirstName);
                Assert.Equal(expectedMps[i].LastName, result.Value![i].LastName);
                Assert.Equal(expectedMps[i].ConstituencyName, result.Value![i].ConstituencyName);
            }

            mockConstituencyRepository.Received(1).GetMembersOfParliamentByConstituenciesQueryable(query.ConstituencyNames);
        }
    }
}

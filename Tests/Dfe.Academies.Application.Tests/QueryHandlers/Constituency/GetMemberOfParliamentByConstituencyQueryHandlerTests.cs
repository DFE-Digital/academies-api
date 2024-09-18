using AutoFixture;
using AutoFixture.Xunit2;
using Dfe.Academies.Application.Common.Models;
using Dfe.Academies.Application.Constituencies.Queries.GetMemberOfParliamentByConstituency;
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
    public class GetMemberOfParliamentByConstituencyQueryHandlerTests
    {
        [Theory]
        [CustomAutoData(
            typeof(MemberOfParliamentCustomization),
            typeof(ConstituencyCustomization),
            typeof(AutoMapperCustomization))]
        public async Task Handle_ShouldReturnMemberOfParliament_WhenConstituencyExists(
            [Frozen] IConstituencyRepository mockConstituencyRepository,
            [Frozen] ICacheService mockCacheService,
            GetMemberOfParliamentByConstituencyQueryHandler handler,
            GetMemberOfParliamentByConstituencyQuery query,
            Domain.Constituencies.Constituency constituency,
            IFixture fixture)
        {
            // Arrange
            var expectedMp = fixture.Customize(new MemberOfParliamentCustomization()
                {
                    FirstName = constituency.NameDetails.NameListAs.Split(",")[1].Trim(),
                    LastName = constituency.NameDetails.NameListAs.Split(",")[0].Trim(),
                    ConstituencyName = constituency.ConstituencyName,
            }).Create<MemberOfParliament>();

            var cacheKey = $"MemberOfParliament_{CacheKeyHelper.GenerateHashedCacheKey(query.ConstituencyName)}";

            mockConstituencyRepository.GetMemberOfParliamentByConstituencyAsync(query.ConstituencyName, default)
                .Returns(constituency);

            mockCacheService.GetOrAddAsync(
                    cacheKey,
                    Arg.Any<Func<Task<MemberOfParliament>>>(),
                    Arg.Any<string>())
                .Returns(callInfo =>
                {
                    var callback = callInfo.ArgAt<Func<Task<MemberOfParliament>>>(1);
                    return callback();
                });

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMp.FirstName, result.FirstName);
            Assert.Equal(expectedMp.LastName, result.LastName);
            Assert.Equal(expectedMp.ConstituencyName, result.ConstituencyName);

            await mockConstituencyRepository.Received(1).GetMemberOfParliamentByConstituencyAsync(query.ConstituencyName, default);
        }
    }
}

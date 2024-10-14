using AutoFixture;
using AutoFixture.Xunit2;
using Dfe.Academies.Application.Common.Models;
using Dfe.Academies.Application.Establishment.Queries.GetMemberOfParliamentBySchool;
using Dfe.Academies.Application.MappingProfiles;
using Dfe.Academies.Domain.Interfaces.Repositories;
using Dfe.Academies.Testing.Common.Customizations.Models;
using Dfe.Academies.Tests.Common.Customizations.Entities;
using DfE.CoreLibs.Caching.Helpers;
using DfE.CoreLibs.Caching.Interfaces;
using DfE.CoreLibs.Testing.AutoFixture.Attributes;
using DfE.CoreLibs.Testing.AutoFixture.Customizations;
using NSubstitute;

namespace Dfe.Academies.Application.Tests.QueryHandlers.Establishment
{
    public class GetMemberOfParliamentBySchoolQueryHandlerTests
    {
        [Theory]
        [CustomAutoData(
            typeof(MemberOfParliamentCustomization),
            typeof(ConstituencyCustomization),
            typeof(OmitCircularReferenceCustomization),
            typeof(AutoMapperCustomization<ConstituencyProfile>))]
        public async Task Handle_ShouldReturnMemberOfParliament_WhenSchoolExists(
            [Frozen] IConstituencyRepository mockConstituencyRepository,
            [Frozen] IEstablishmentRepository establishmentRepository,
            [Frozen] ICacheService<IMemoryCacheType> mockCacheService,
            GetMemberOfParliamentBySchoolQueryHandler handler,
            GetMemberOfParliamentBySchoolQuery query,
            Domain.Constituencies.Constituency constituency,
            Domain.Establishment.Establishment establishment,
            IFixture fixture)
        {
            // Arrange
            fixture.Customize<Domain.Establishment.Establishment>(composer => composer
                .With(x => x.ParliamentaryConstituency, "ConstituencyName"));

            var expectedMp = fixture.Customize(new MemberOfParliamentCustomization()
                {
                    FirstName = constituency.NameDetails.NameListAs.Split(",")[1].Trim(),
                    LastName = constituency.NameDetails.NameListAs.Split(",")[0].Trim(),
                    ConstituencyName = constituency.ConstituencyName,
            }).Create<MemberOfParliament>();

            var cacheKey = $"MPbySchool_{CacheKeyHelper.GenerateHashedCacheKey(query.Urn.ToString())}";

            establishmentRepository.GetEstablishmentByUrn(query.Urn.ToString(), default)
                .Returns(establishment);

            mockConstituencyRepository.GetMemberOfParliamentByConstituencyAsync(establishment.ParliamentaryConstituency!, default)
                .Returns(constituency);

            mockCacheService.GetOrAddAsync(
                    cacheKey,
                    Arg.Any<Func<Task<Result<MemberOfParliament>>>>(),
                    Arg.Any<string>())
                .Returns(callInfo =>
                {
                    var callback = callInfo.ArgAt<Func<Task<Result<MemberOfParliament>>>>(1);
                    return callback();
                });

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMp.FirstName, result.Value!.FirstName);
            Assert.Equal(expectedMp.LastName, result.Value!.LastName);
            Assert.Equal(expectedMp.ConstituencyName, result.Value!.ConstituencyName);
        }

        [Theory]
        [CustomAutoData(
    typeof(MemberOfParliamentCustomization),
            typeof(ConstituencyCustomization),
            typeof(OmitCircularReferenceCustomization),
            typeof(AutoMapperCustomization<ConstituencyProfile>))]
                public async Task Handle_ShouldReturnNotFound_WhenSchoolDoesntExists(
            [Frozen] IEstablishmentRepository establishmentRepository,
            [Frozen] ICacheService<IMemoryCacheType> mockCacheService,
            GetMemberOfParliamentBySchoolQueryHandler handler,
            GetMemberOfParliamentBySchoolQuery query)
        {
            // Arrange

            var cacheKey = $"MPbySchool_{CacheKeyHelper.GenerateHashedCacheKey(query.Urn.ToString())}";

            establishmentRepository.GetEstablishmentByUrn(query.Urn.ToString(), default)
                .Returns((Domain.Establishment.Establishment?)null);

            mockCacheService.GetOrAddAsync(
                    cacheKey,
                    Arg.Any<Func<Task<Result<MemberOfParliament>>>>(),
                    Arg.Any<string>())
                .Returns(callInfo =>
                {
                    var callback = callInfo.ArgAt<Func<Task<Result<MemberOfParliament>>>>(1);
                    return callback();
                });

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsSuccess);
        }
    }
}

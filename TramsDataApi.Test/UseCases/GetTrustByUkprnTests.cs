using FizzWare.NBuilder;
using FizzWare.NBuilder.PropertyNaming;
using Moq;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class GetTrustByUkprnTests
    {
        public GetTrustByUkprnTests()
        {
            BuilderSetup.SetDefaultPropertyName(new RandomValuePropertyNamer(new BuilderSettings()));
        }
        
        [Fact]
        public void TestGettingTrustByUkprn_ReturnsNull_WhenNoTrustsAreFound()
        {
            var ukprn = "mockukprn";
            var mockTrustsGateway = new Mock<ITrustGateway>();
            var mockGetEstablishmentsByTrustUid = new Mock<IGetEstablishmentsByTrustUid>();
            mockTrustsGateway.Setup(gateway => gateway.GetGroupByUkprn(ukprn)).Returns(() => null);
            var useCase = new GetTrustByUkprn(mockTrustsGateway.Object, mockGetEstablishmentsByTrustUid.Object);

            useCase.Execute(ukprn).Should().BeNull();
        }

        [Fact]
        public void TestGettingTrustByUkprn_ReturnsTrustResponse_WithoutAcademies_WhenEstablishmentsAreNull()
        {
            var ukprn = "mockukprn";
            var expectedGroup = Builder<Group>.CreateNew().With(g => g.Ukprn = ukprn).Build();
            var expectedTrust = Builder<Trust>.CreateNew().With(t => t.TrustRef = expectedGroup.GroupId).Build();
            
            var mockTrustsGateway = new Mock<ITrustGateway>();
            var mockGetEstablishmentsByTrustUid = new Mock<IGetEstablishmentsByTrustUid>();
            
            mockTrustsGateway.Setup(gateway => gateway.GetGroupByUkprn(ukprn))
                .Returns(expectedGroup);
            mockTrustsGateway.Setup(gateway => gateway.GetIfdTrustByGroupId(expectedGroup.GroupId))
                .Returns(expectedTrust);
            mockGetEstablishmentsByTrustUid.Setup(gateway => gateway.Execute(expectedGroup.GroupUid))
                .Returns(() => null);
            
            var useCase = new GetTrustByUkprn(mockTrustsGateway.Object, mockGetEstablishmentsByTrustUid.Object);
            var expected = TrustResponseFactory.Create(expectedGroup, expectedTrust, null);
            var result = useCase.Execute(ukprn);

            result.Should().BeEquivalentTo(expected);
        }
    }
}
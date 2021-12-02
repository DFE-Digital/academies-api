using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    
    public class CreateA2BApplicationStatusTests
    {
        [Fact]
        public void CreateA2BApplicationStatus_ShouldCreateAndReturnA2BApplicationStatus_WhenGivenA2BApplicationStatus()
        {
            var applicationStatusCreateRequest = Builder<A2BApplicationStatusCreateRequest>.CreateNew().Build();

            var expectedStatus = new A2BApplicationStatus
            {
                ApplicationStatusId = 10001,
                Name = applicationStatusCreateRequest.Name
            };
            
            var mockGateway = new Mock<IA2BApplicationStatusGateway>();
            
            mockGateway.Setup(g => g.CreateA2BApplicationStatus(It.IsAny<A2BApplicationStatus>())).Returns(expectedStatus);
            
            var useCase = new CreateA2BApplicationStatus(mockGateway.Object);
            
            var result = useCase.Execute(applicationStatusCreateRequest);

            result.Should().NotBeNull();
            result.ApplicationStatusId.Should().BeGreaterThan(0);
            result.Should().BeEquivalentTo(expectedStatus);
        }
    }
}
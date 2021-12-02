using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class GetA2BApplicationStatusTests
    {
        [Fact]
        public void GetA2BApplicationStatus_ShouldReturnNull_WhenApplicationStatusIdIsNotFound()
        {
            const int applicationStatusId = 10001;
            var mockGateway = new Mock<IA2BApplicationStatusGateway>();

            mockGateway.Setup(g => g.GetByStatusId(applicationStatusId));
           
            var useCase = new GetA2BApplicationStatus(mockGateway.Object);
            var result = useCase.Execute(applicationStatusId);

            result.Should().BeNull();
        }

        [Fact]
        public void GetA2BApplicationStatus_ShouldReturnA2BApplicationStatusResponse_WhenApplicationStatusIdIsFound()
        {
            const int applicationStatusId = 10001;
            var mockGateway = new Mock<IA2BApplicationStatusGateway>();
            var status = Builder<A2BApplicationStatus>
                .CreateNew()
                .With(a => a.ApplicationStatusId == applicationStatusId)
                .Build();

           
            var expected = A2BApplicationStatusResponseFactory.Create(status);

            mockGateway.Setup(g => g.GetByStatusId(applicationStatusId)).Returns(status);
            
            var useCase = new GetA2BApplicationStatus(mockGateway.Object);
            var result = useCase.Execute(applicationStatusId);
            
            result.Should().BeEquivalentTo(expected);
        }
    }
}
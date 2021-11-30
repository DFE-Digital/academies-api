using System;
using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class GetA2BApplicationTests
    {
        [Fact]
        public void GetA2BApplication_ShouldReturnNull_WhenApplicationIdIsNotFound()
        {
            const int applicationId = 10001;
            var mockGateway = new Mock<IA2BApplicationGateway>();

            mockGateway.Setup(g => g.GetByApplicationId(applicationId));
           
            var useCase = new GetA2BApplication(mockGateway.Object);
            var result = useCase.Execute(applicationId);

            result.Should().BeNull();
        }

        [Fact]
        public void GetA2BApplication_ShouldReturnA2BApplicationResponse_WhenApplicationIdIsFound()
        {
            const int applicationId = 10001;
            var mockGateway = new Mock<IA2BApplicationGateway>();
            var application = Builder<A2BApplication>
                .CreateNew()
                .With(a => a.ApplicationId == applicationId)
                .Build();

            var expected = A2BApplicationResponseFactory.Create(application, null);

            mockGateway.Setup(g => g.GetByApplicationId(applicationId)).Returns(application);
            
            var useCase = new GetA2BApplication(mockGateway.Object);
            var result = useCase.Execute(applicationId);
            
            result.Should().BeEquivalentTo(expected);
        }
    }
}
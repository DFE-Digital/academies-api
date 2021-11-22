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
        public void GetA2BApplication_ShouldReturnNull_WhenA2BApplicationRequestByIdIsNull()
        {
            var mockGateway = new Mock<IA2BApplicationGateway>();
            
            var useCase = new GetA2BApplication(mockGateway.Object);
            var result = useCase.Execute(null);

            result.Should().BeNull();
        }
        
        [Fact]
        public void GetA2BApplication_ShouldReturnNull_WhenApplicationIdIsNotFound()
        {
            var mockGateway = new Mock<IA2BApplicationGateway>();

            var request = new A2BApplicationByIdRequest
            {
                ApplicationId = "ApplicationId"
            };
            
            mockGateway.Setup(g => g.GetByApplicationId("ApplicationId"));
           
            var useCase = new GetA2BApplication(mockGateway.Object);
            var result = useCase.Execute(null);

            result.Should().BeNull();
        }

        [Fact]
        public void GetA2BApplication_ShouldReturnA2BApplicationResponse_WhenApplicationIdIsFound()
        {
            var mockGateway = new Mock<IA2BApplicationGateway>();
            var application = Builder<A2BApplication>
                .CreateNew()
                .With(a => a.ApplicationId == "ApplicationId")
                .Build();

            var request = new A2BApplicationByIdRequest
            {
                ApplicationId = "ApplicationId"
            };
            var expected = A2BApplicationResponseFactory.Create(application, null);

            mockGateway.Setup(g => g.GetByApplicationId("ApplicationId")).Returns(application);
            
            var useCase = new GetA2BApplication(mockGateway.Object);
            var result = useCase.Execute(request);
            
            result.Should().BeEquivalentTo(expected);
        }
    }
}
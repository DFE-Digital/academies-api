using FluentAssertions;
using FizzWare.NBuilder;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels.ApplyToBecome;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class A2BApplicationStatusResponseFactoryTests
    {
        [Fact]
        public void Create_ReturnsNull_WhenA2BApplicationStatusIsNull()
        {
            var response = A2BApplicationStatusResponseFactory.Create(null);

            response.Should().BeNull();
        }

        [Fact]
        public void Create_ReturnsExpectedA2BApplicationStatusResponse_WhenA2BApplicationStatusIsProvided()
        {
            var applicationStatus = Builder<A2BApplicationStatus>
                .CreateNew()
                .Build();

            var expectedResponse = new A2BApplicationStatusResponse
            {
                ApplicationStatusId = applicationStatus.ApplicationStatusId,
                Name = applicationStatus.Name
            };
                
            var response = A2BApplicationStatusResponseFactory.Create(applicationStatus);

            response.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
using FluentAssertions;
using FizzWare.NBuilder;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.RequestModels.ApplyToBecome;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class A2BApplicationStatusFactoryTests
    {
        [Fact]
        public void Create_ReturnsNull_WhenA2BApplicationStatusIsNull()
        {
            var response = A2BApplicationStatusFactory.Create(null);

            response.Should().BeNull();
        }

        [Fact]
        public void Create_ReturnsExpectedA2BApplicationStatus_WhenA2BApplicationStatusResponseIsProvided()
        {
            var applicationStatusCreateRequest = Builder<A2BApplicationStatusCreateRequest>
                .CreateNew()
                .Build();

            var expectedStatus = new A2BApplicationStatus
            {
                Name = applicationStatusCreateRequest.Name
            };
                
            var response = A2BApplicationStatusFactory.Create(applicationStatusCreateRequest);

            response.Should().BeEquivalentTo(expectedStatus);
        }
    }
}
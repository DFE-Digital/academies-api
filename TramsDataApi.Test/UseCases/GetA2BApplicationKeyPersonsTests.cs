using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class GetA2BApplicationKeyPersonsTests
    {
        [Fact]
        public void GetA2BApplicationKeyPersons_ShouldReturnNull_WhenA2BApplicationKeyPersonsRequestByIdIsNull()
        {
            var mockGateway = new Mock<IA2BApplicationKeyPersonsGateway>();
            
            var useCase = new GetA2BApplicationKeyPersons(mockGateway.Object);
            var result = useCase.Execute(null);

            result.Should().BeNull();
        }
        
        [Fact]
        public void GetA2BApplicationKeyPersons_ShouldReturnNull_WhenKeyPersonsIdIsNotFound()
        {
            var applicationId = 10001;
            var mockGateway = new Mock<IA2BApplicationKeyPersonsGateway>();

            mockGateway.Setup(g => g.GetByKeyPersonsId(applicationId));
           
            var useCase = new GetA2BApplicationKeyPersons(mockGateway.Object);
            var result = useCase.Execute(null);

            result.Should().BeNull();
        }

        [Fact]
        public void GetA2BApplicationKeyPersons_ShouldReturnA2BApplicationKeyPersonsResponse_WhenKeyPersonsIdIsFound()
        {
            var keyPersonsId = 10001;
            var mockGateway = new Mock<IA2BApplicationKeyPersonsGateway>();
            var keyPersons = Builder<A2BApplicationKeyPersons>
                .CreateNew()
                .With(a => a.KeyPersonId == keyPersonsId)
                .Build();

            var request = new A2BApplicationKeyPersonsByIdRequest
            {
                KeyPersonsId = keyPersonsId
            };
            var expected = A2BApplicationKeyPersonsResponseFactory.Create(keyPersons);

            mockGateway.Setup(g => g.GetByKeyPersonsId(keyPersonsId)).Returns(keyPersons);
            
            var useCase = new GetA2BApplicationKeyPersons(mockGateway.Object);
            var result = useCase.Execute(request);
            
            result.Should().BeEquivalentTo(expected);
        }
    }
}
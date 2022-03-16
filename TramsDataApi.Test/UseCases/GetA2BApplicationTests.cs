using System.Linq;
using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories.A2BApplicationFactories;
using TramsDataApi.Gateways;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class GetA2BApplicationTests
    {
        [Fact]
        public void GetA2BApplication_ShouldReturnNull_WhenApplicationIdIsNotFound()
        {
            const string applicationId = "10001";
            var mockGateway = new Mock<IA2BApplicationGateway>();

            mockGateway.Setup(g => g.GetByApplicationId(applicationId));
           
            var useCase = new GetA2BApplication(mockGateway.Object);
            var result = useCase.Execute(applicationId);

            result.Should().BeNull();
        }

        [Fact]
        public void GetA2BApplication_ShouldReturnA2BApplicationResponse_WhenApplicationIdIsFound()
        {
            const string applicationId = "10001";
            var mockGateway = new Mock<IA2BApplicationGateway>();
            var keyPersons = Builder<A2BApplicationKeyPersons>.CreateListOfSize(1).Build().ToList();
            var applyingSchools = Builder<A2BApplicationApplyingSchool>.CreateListOfSize(1).Build().ToList();
            var application = Builder<A2BApplication>
                .CreateNew()
                .With(a => a.ApplicationId == applicationId)
                .With(a => a.ApplicationType = "FormMat")
                .With(a => a.KeyPersons = keyPersons)
                .With(a => a.ApplyingSchools = applyingSchools)
                .Build();

            var expected = A2BApplicationFactory.Create(application);

            mockGateway.Setup(g => g.GetByApplicationId(applicationId)).Returns(application);
            
            var useCase = new GetA2BApplication(mockGateway.Object);
            var result = useCase.Execute(applicationId);
            
            result.Should().BeEquivalentTo(expected);
        }
    }
}
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
    public class GetA2BSchoolLeaseTests
    {
        
        [Fact]
        public void GetA2BSchoolLease_ShouldReturnNull_WhenCSchoolLeaseIdIsNotFound()
        {
            const string leaseId = "10001";
            var mockGateway = new Mock<IA2BSchoolLeaseGateway>();

            mockGateway.Setup(g => g.GetByLeaseId(leaseId));
           
            var useCase = new GetA2BSchoolLease(mockGateway.Object);
            var result = useCase.Execute(leaseId);

            result.Should().BeNull();
        }

        [Fact]
        public void GetA2BSchoolLease_ShouldReturnA2BSchoolLeaseResponse_WhenSchoolLeaseIdIsFound()
        {
            const string leaseId = "10001";
            var mockGateway = new Mock<IA2BSchoolLeaseGateway>();
            var lease = Builder<A2BSchoolLease>
                .CreateNew()
                .With(a => a.SchoolLeaseId == leaseId)
                .Build();

           
            var expected = A2BSchoolLeaseResponseFactory.Create(lease);

            mockGateway.Setup(g => g.GetByLeaseId(leaseId)).Returns(lease);
            
            var useCase = new GetA2BSchoolLease(mockGateway.Object);
            var result = useCase.Execute(leaseId);
            
            result.Should().BeEquivalentTo(expected);
        }
    }
}
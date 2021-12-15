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
    public class GetA2BSchoolLoanTests
    {
        
        [Fact]
        public void GetA2BSchoolLoan_ShouldReturnNull_WhenCSchoolLoanIdIsNotFound()
        {
            const string loanId = "9001";
            var mockGateway = new Mock<IA2BSchoolLoanGateway>();

            mockGateway.Setup(g => g.GetByLoanId(loanId));
           
            var useCase = new GetA2BSchoolLoan(mockGateway.Object);
            var result = useCase.Execute(loanId);

            result.Should().BeNull();
        }

        [Fact]
        public void GetA2BSchoolLoan_ShouldReturnA2BSchoolLoanResponse_WhenSchoolLoanIdIsFound()
        {
            const string loanId = "9001";
            var mockGateway = new Mock<IA2BSchoolLoanGateway>();
            var loan = Builder<A2BSchoolLoan>
                .CreateNew()
                .With(a => a.SchoolLoanId == loanId)
                .Build();

           
            var expected = A2BSchoolLoanResponseFactory.Create(loan);

            mockGateway.Setup(g => g.GetByLoanId(loanId)).Returns(loan);
            
            var useCase = new GetA2BSchoolLoan(mockGateway.Object);
            var result = useCase.Execute(loanId);
            
            result.Should().BeEquivalentTo(expected);
        }
    }
}
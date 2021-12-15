using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class CreateA2BSchoolLoanTests
    {
        [Fact]
        public void CreateA2BSchoolLoan_ShouldCreateAndReturnA2BSchoolLoan_WhenGivenA2BSchoolLoanRequest()
        {
            var schoolLoanCreateRequest = Builder<A2BSchoolLoanCreateRequest>.CreateNew().Build();

            var savedLoan = new A2BSchoolLoan
            {
                SchoolLoanId = schoolLoanCreateRequest.SchoolLoanId,
                SchoolLoanAmount = schoolLoanCreateRequest.SchoolLoanAmount,
                SchoolLoanPurpose = schoolLoanCreateRequest.SchoolLoanPurpose,
                SchoolLoanProvider = schoolLoanCreateRequest.SchoolLoanProvider,
                SchoolLoanInterestRate = schoolLoanCreateRequest.SchoolLoanInterestRate,
                SchoolLoanSchedule = schoolLoanCreateRequest.SchoolLoanSchedule
            };

            var expected = new A2BSchoolLoanResponse
            {
                SchoolLoanId = schoolLoanCreateRequest.SchoolLoanId,
                SchoolLoanAmount = schoolLoanCreateRequest.SchoolLoanAmount,
                SchoolLoanPurpose = schoolLoanCreateRequest.SchoolLoanPurpose,
                SchoolLoanProvider = schoolLoanCreateRequest.SchoolLoanProvider,
                SchoolLoanInterestRate = schoolLoanCreateRequest.SchoolLoanInterestRate,
                SchoolLoanSchedule = schoolLoanCreateRequest.SchoolLoanSchedule
            };
            
            var mockGateway = new Mock<IA2BSchoolLoanGateway>();
            
            mockGateway.Setup(g => g.CreateA2BSchoolLoan(It.IsAny<A2BSchoolLoan>())).Returns(savedLoan);
            
            var useCase = new CreateA2BSchoolLoan(mockGateway.Object);
            
            var result = useCase.Execute(schoolLoanCreateRequest);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expected);
        }
    }
}
using FizzWare.NBuilder;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories.A2BApplicationFactories;
using TramsDataApi.ServiceModels.ApplyToBecome;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class A2BSchoolLoanFactoryTests
    {
        [Fact]
        public void Create_ReturnsNull_WhenA2BSchoolLoanRequestIsNull()
        {
            var response = A2BSchoolLoanFactory.Create(null);

            response.Should().BeNull();
        }

        [Fact]
        public void Create_ReturnsExpectedA2BSchoolLoanWhenA2BSchoolLoanResponseIsProvided()
        {
            var schoolLoanCreateRequest = Builder<A2BSchoolLoanServiceModel>
                .CreateNew()
                .Build();

            var expectedSchoolLoan = new A2BSchoolLoan
            {
                SchoolLoanAmount = schoolLoanCreateRequest.SchoolLoanAmount,
                SchoolLoanPurpose = schoolLoanCreateRequest.SchoolLoanPurpose,
                SchoolLoanProvider = schoolLoanCreateRequest.SchoolLoanProvider,
                SchoolLoanInterestRate = schoolLoanCreateRequest.SchoolLoanInterestRate,
                SchoolLoanSchedule = schoolLoanCreateRequest.SchoolLoanSchedule,
                DynamicsSchoolLoanId = schoolLoanCreateRequest.DynamicsSchoolLoanId
            };
                
            var response = A2BSchoolLoanFactory.Create(schoolLoanCreateRequest);

            response.Should().BeEquivalentTo(expectedSchoolLoan);
        }
    }
}
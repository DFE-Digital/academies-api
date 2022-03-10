using FizzWare.NBuilder;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels.ApplyToBecome;
using TramsDataApi.ServiceModels.ApplyToBecome;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class A2BSchoolLoanServiceModelFactoryTests
    {
        [Fact]
        public void Create_ReturnsNull_WhenA2BSchoolLoanIsNull()
        {
            var response = A2BSchoolLoanServiceModelFactory.Create(null);

            response.Should().BeNull();
        }

        [Fact]
        public void Create_ReturnsExpectedA2BSchoolLoanResponseWhenA2BSchoolLoanIsProvided()
        {
            var schoolLoan = Builder<A2BSchoolLoan>
                .CreateNew()
                .Build();

            var expectedSchoolLoanResponse = new A2BSchoolLoanServiceModel
            {
                SchoolLoanAmount = schoolLoan.SchoolLoanAmount,
                SchoolLoanPurpose = schoolLoan.SchoolLoanPurpose,
                SchoolLoanProvider = schoolLoan.SchoolLoanProvider,
                SchoolLoanInterestRate = schoolLoan.SchoolLoanInterestRate,
                SchoolLoanSchedule = schoolLoan.SchoolLoanSchedule
            };
                
            var response = A2BSchoolLoanServiceModelFactory.Create(schoolLoan);

            response.Should().BeEquivalentTo(expectedSchoolLoanResponse);
        }
    }
}
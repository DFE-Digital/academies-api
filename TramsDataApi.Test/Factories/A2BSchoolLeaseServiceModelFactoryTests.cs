using FizzWare.NBuilder;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels.ApplyToBecome;
using TramsDataApi.ServiceModels.ApplyToBecome;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class A2BSchoolLeaseServiceModelFactoryTests
    {
        [Fact]
        public void Create_ReturnsNull_WhenA2BSchoolLeaseIsNull()
        {
            var response = A2BSchoolLeaseServiceModelFactory.Create(null);

            response.Should().BeNull();
        }

        [Fact]
        public void Create_ReturnsExpectedA2BSchoolLeaseResponseWhenA2BSchoolLeaseIsProvided()
        {
            var schoolLease = Builder<A2BSchoolLease>
                .CreateNew()
                .Build();

            var expectedSchoolLeaseResponse = new A2BSchoolLeaseServiceModel
            {
                SchoolLeaseTerm = schoolLease.SchoolLeaseTerm,
                SchoolLeaseRepaymentValue = schoolLease.SchoolLeaseRepaymentValue,
                SchoolLeaseInterestRate = schoolLease.SchoolLeaseInterestRate,
                SchoolLeasePaymentToDate = schoolLease.SchoolLeasePaymentToDate,
                SchoolLeasePurpose = schoolLease.SchoolLeasePurpose,
                SchoolLeaseValueOfAssets = schoolLease.SchoolLeaseValueOfAssets,
                SchoolLeaseResponsibleForAssets = schoolLease.SchoolLeaseResponsibleForAssets
            };
                
            var response = A2BSchoolLeaseServiceModelFactory.Create(schoolLease);

            response.Should().BeEquivalentTo(expectedSchoolLeaseResponse);
        }
    }
}
using FizzWare.NBuilder;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ServiceModels.ApplyToBecome;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class A2BSchoolLeaseFactoryTests
    {
        [Fact]
        public void Create_ReturnsNull_WhenA2BSchoolLeaseRequestIsNull()
        {
            var response = A2BSchoolLeaseFactory.Create(null);

            response.Should().BeNull();
        }

        [Fact]
        public void Create_ReturnsExpectedA2BSchoolLeaseWhenA2BSchoolLeaseServiceModelProvided()
        {
            var schoolLeaseCreateRequest = Builder<A2BSchoolLeaseServiceModel>
                .CreateNew()
                .Build();

            var expectedSchoolLease = new A2BSchoolLease
            {
                SchoolLeaseTerm = schoolLeaseCreateRequest.SchoolLeaseTerm,
                SchoolLeaseRepaymentValue = schoolLeaseCreateRequest.SchoolLeaseRepaymentValue,
                SchoolLeaseInterestRate = schoolLeaseCreateRequest.SchoolLeaseInterestRate,
                SchoolLeasePaymentToDate = schoolLeaseCreateRequest.SchoolLeasePaymentToDate,
                SchoolLeasePurpose = schoolLeaseCreateRequest.SchoolLeasePurpose,
                SchoolLeaseValueOfAssets = schoolLeaseCreateRequest.SchoolLeaseValueOfAssets,
                SchoolLeaseResponsibleForAssets = schoolLeaseCreateRequest.SchoolLeaseResponsibleForAssets
            };
                
            var response = A2BSchoolLeaseFactory.Create(schoolLeaseCreateRequest);

            response.Should().BeEquivalentTo(expectedSchoolLease);
        }
    }
}
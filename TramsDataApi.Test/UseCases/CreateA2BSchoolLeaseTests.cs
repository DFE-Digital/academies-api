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
    public class CreateA2BSchoolLeaseTests
    {
        [Fact]
        public void CreateA2BSchoolLease_ShouldCreateAndReturnA2BSchoolLease_WhenGivenA2BSchoolLeaseRequest()
        {
            var schoolLeaseCreateRequest = Builder<A2BSchoolLeaseCreateRequest>.CreateNew().Build();

            var savedLease = new A2BSchoolLease
            {
                SchoolLeaseId = schoolLeaseCreateRequest.SchoolLeaseId,
                SchoolLeaseTerm = schoolLeaseCreateRequest.SchoolLeaseTerm,
                SchoolLeaseRepaymentValue = schoolLeaseCreateRequest.SchoolLeaseRepaymentValue,
                SchoolLeaseInterestRate = schoolLeaseCreateRequest.SchoolLeaseInterestRate,
                SchoolLeasePaymentToDate = schoolLeaseCreateRequest.SchoolLeasePaymentToDate,
                SchoolLeasePurpose = schoolLeaseCreateRequest.SchoolLeasePurpose,
                SchoolLeaseValueOfAssets = schoolLeaseCreateRequest.SchoolLeaseValueOfAssets,
                SchoolLeaseResponsibleForAssets = schoolLeaseCreateRequest.SchoolLeaseResponsibleForAssets
            };

            var expected = new A2BSchoolLeaseResponse
            {
                SchoolLeaseId = schoolLeaseCreateRequest.SchoolLeaseId,
                SchoolLeaseTerm = schoolLeaseCreateRequest.SchoolLeaseTerm,
                SchoolLeaseRepaymentValue = schoolLeaseCreateRequest.SchoolLeaseRepaymentValue,
                SchoolLeaseInterestRate = schoolLeaseCreateRequest.SchoolLeaseInterestRate,
                SchoolLeasePaymentToDate = schoolLeaseCreateRequest.SchoolLeasePaymentToDate,
                SchoolLeasePurpose = schoolLeaseCreateRequest.SchoolLeasePurpose,
                SchoolLeaseValueOfAssets = schoolLeaseCreateRequest.SchoolLeaseValueOfAssets,
                SchoolLeaseResponsibleForAssets = schoolLeaseCreateRequest.SchoolLeaseResponsibleForAssets
            };
            
            var mockGateway = new Mock<IA2BSchoolLeaseGateway>();
            
            mockGateway.Setup(g => g.CreateA2BSchoolLease(It.IsAny<A2BSchoolLease>())).Returns(savedLease);
            
            var useCase = new CreateA2BSchoolLease(mockGateway.Object);
            
            var result = useCase.Execute(schoolLeaseCreateRequest);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expected);
        }
    }
}
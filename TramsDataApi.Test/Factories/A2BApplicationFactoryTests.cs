using FluentAssertions;
using FizzWare.NBuilder;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class A2BApplicationFactoryTests
    {
	    [Fact]
        public void Create_ReturnsNull_WhenA2BApplicationIsNull()
        {
            var response = A2BApplicationFactory.Create(null);

            response.Should().BeNull();
        }

        [Fact]
        public void Create_ReturnsExpectedA2BApplication_WhenA2BApplicationResponseIsProvided()
        {
            var applicationCreateRequest = Builder<A2BApplicationCreateRequest>
                .CreateNew()
                .Build();

            var expectedApplication = new A2BApplication
            {
	            Name = applicationCreateRequest.Name,
	            ApplicationType = applicationCreateRequest.ApplicationType,
	            FormTrustProposedNameOfTrust = applicationCreateRequest.FormTrustProposedNameOfTrust,
	            ApplicationSubmitted = applicationCreateRequest.ApplicationSubmitted,
	            ApplicationLeadAuthorId = applicationCreateRequest.ApplicationLeadAuthorId,
	            ApplicationVersion = applicationCreateRequest.ApplicationVersion,
	            ApplicationLeadAuthorName = applicationCreateRequest.ApplicationLeadAuthorName,
	            ApplicationRole = applicationCreateRequest.ApplicationRole,
	            ApplicationRoleOtherDescription = applicationCreateRequest.ApplicationRoleOtherDescription,
	            ChangesToTrust = applicationCreateRequest.ChangesToTrust,
	            ChangesToTrustExplained = applicationCreateRequest.ChangesToTrustExplained,
	            ChangesToLaGovernance = applicationCreateRequest.ChangesToLaGovernance,
	            ChangesToLaGovernanceExplained = applicationCreateRequest.ChangesToLaGovernanceExplained,
	            FormTrustOpeningDate = applicationCreateRequest.FormTrustOpeningDate,
	            TrustId = applicationCreateRequest.TrustId,
	            TrustApproverName = applicationCreateRequest.TrustApproverName,
	            TrustApproverEmail = applicationCreateRequest.TrustApproverEmail,
	            FormTrustReasonApprovalToConvertAsSat = applicationCreateRequest.FormTrustReasonApprovalToConvertAsSat,
	            FormTrustReasonApprovedPerson = applicationCreateRequest.FormTrustReasonApprovedPerson,
	            FormTrustReasonForming = applicationCreateRequest.FormTrustReasonForming,
	            FormTrustReasonVision = applicationCreateRequest.FormTrustReasonVision,
	            FormTrustReasonGeoAreas = applicationCreateRequest.FormTrustReasonGeoAreas,
	            FormTrustReasonFreedom = applicationCreateRequest.FormTrustReasonFreedom,
	            FormTrustReasonImproveTeaching = applicationCreateRequest.FormTrustReasonImproveTeaching,
	            FormTrustPlanForGrowth = applicationCreateRequest.FormTrustPlanForGrowth,
	            FormTrustPlansForNoGrowth = applicationCreateRequest.FormTrustPlansForNoGrowth,
	            FormTrustGrowthPlansYesNo = applicationCreateRequest.FormTrustGrowthPlansYesNo,
	            FormTrustImprovementSupport = applicationCreateRequest.FormTrustImprovementSupport,
	            FormTrustImprovementStrategy = applicationCreateRequest.FormTrustImprovementStrategy,
	            FormTrustImprovementApprovedSponsor = applicationCreateRequest.FormTrustImprovementApprovedSponsor
            };
                
            var response = A2BApplicationFactory.Create(applicationCreateRequest);

            response.Should().BeEquivalentTo(expectedApplication);
        }
    }
}
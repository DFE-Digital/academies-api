using FluentAssertions;
using FizzWare.NBuilder;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels.ApplyToBecome;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class A2BApplicationResponseFactoryTests
    {
	    [Fact]
        public void Create_ReturnsNull_WhenA2BApplicationIsNull()
        {
            var response = A2BApplicationResponseFactory.Create(null, null);

            response.Should().BeNull();
        }

        [Fact]
        public void Create_ReturnsExpectedA2BApplicationResponse_WhenA2BApplicationIsProvided()
        {
            var application = Builder<A2BApplication>
                .CreateNew()
                .Build();

            var expectedResponse = new A2BApplicationResponse
            {
	            Name = application.Name,
	            ApplicationId = application.ApplicationId,
	            ApplicationType = application.ApplicationType,
	            FormTrustProposedNameOfTrust = application.FormTrustProposedNameOfTrust,
	            ApplicationSubmitted = application.ApplicationSubmitted,
	            ApplicationLeadAuthorId = application.ApplicationLeadAuthorId,
	            ApplicationVersion = application.ApplicationVersion,
	            ApplicationLeadAuthorName = application.ApplicationLeadAuthorName,
	            ApplicationRole = application.ApplicationRole,
	            ApplicationRoleOtherDescription = application.ApplicationRoleOtherDescription,
	            ChangesToTrust = application.ChangesToTrust,
	            ChangesToTrustExplained = application.ChangesToTrustExplained,
	            ChangesToLaGovernance = application.ChangesToLaGovernance,
	            ChangesToLaGovernanceExplained = application.ChangesToLaGovernanceExplained,
	            FormTrustOpeningDate = application.FormTrustOpeningDate,
	            TrustId = application.TrustId,
	            TrustApproverName = application.TrustApproverName,
	            TrustApproverEmail = application.TrustApproverEmail,
	            FormTrustReasonApprovalToConvertAsSat = application.FormTrustReasonApprovalToConvertAsSat,
	            FormTrustReasonApprovedPerson = application.FormTrustReasonApprovedPerson,
	            FormTrustReasonForming = application.FormTrustReasonForming,
	            FormTrustReasonVision = application.FormTrustReasonVision,
	            FormTrustReasonGeoAreas = application.FormTrustReasonGeoAreas,
	            FormTrustReasonFreedom = application.FormTrustReasonFreedom,
	            FormTrustReasonImproveTeaching = application.FormTrustReasonImproveTeaching,
	            FormTrustPlanForGrowth = application.FormTrustPlanForGrowth,
	            FormTrustPlansForNoGrowth = application.FormTrustPlansForNoGrowth,
	            FormTrustGrowthPlansYesNo = application.FormTrustGrowthPlansYesNo,
	            FormTrustImprovementSupport = application.FormTrustImprovementSupport,
	            FormTrustImprovementStrategy = application.FormTrustImprovementStrategy,
	            FormTrustImprovementApprovedSponsor = application.FormTrustImprovementApprovedSponsor,
            };
                
            var response = A2BApplicationResponseFactory.Create(application, null);

            response.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
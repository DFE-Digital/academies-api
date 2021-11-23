using System;
using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    
    public class CreateA2BApplicationTests
    {
	    [Fact]
        public void CreateA2BApplication_ShouldCreateAndReturnA2BApplication_WhenGiveA2BApplication()
        {
            var applicationCreateRequest = Builder<A2BApplicationCreateRequest>.CreateNew().Build();

            var expectedApplication = new A2BApplication
            {
	            ApplicationId = 10001,
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
            
            var mockGateway = new Mock<IA2BApplicationGateway>();
            
            mockGateway.Setup(g => g.CreateA2BApplication(It.IsAny<A2BApplication>())).Returns(expectedApplication);
            
            var useCase = new CreateA2BApplication(mockGateway.Object);
            
            var result = useCase.Execute(applicationCreateRequest);

            result.Should().NotBeNull();
            result.ApplicationId.Should().BeGreaterThan(0);
            result.Should().BeEquivalentTo(expectedApplication);
        }

        [Fact]
        public void GetA2BApplication_ShouldReturnA2BApplicationResponse_WhenApplicationIdIsFound()
        {
            var applicationId = 10001;
            var mockGateway = new Mock<IA2BApplicationGateway>();
            var application = Builder<A2BApplication>
                .CreateNew()
                .With(a => a.ApplicationId == applicationId)
                .Build();

            var request = new A2BApplicationByIdRequest
            {
                ApplicationId = applicationId
            };
            var expected = A2BApplicationResponseFactory.Create(application, null);

            mockGateway.Setup(g => g.GetByApplicationId(applicationId)).Returns(application);
            
            var useCase = new GetA2BApplication(mockGateway.Object);
            var result = useCase.Execute(request);
            
            result.Should().BeEquivalentTo(expected);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Enums;
using TramsDataApi.Factories;
using TramsDataApi.Factories.A2BApplicationFactories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;
using TramsDataApi.ServiceModels.ApplyToBecome;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{ 
	public class CreateA2BApplicationTests
    {
	    [Fact]
        public void CreateA2BApplication_ShouldCreateAndReturnA2BApplicationResponse_WhenGivenA2BApplication()
        {
	        var keyPersons = Builder<A2BApplicationKeyPersonsServiceModel>.CreateNew().Build();
	        var applyingSchools = Builder<A2BApplyingSchoolServiceModel>.CreateNew().Build();
	        var applicationCreateRequest = Builder<A2BApplicationCreateRequest>
	            .CreateNew()
	            .With(r => r.ApplicationType = (int?) A2BApplicationTypeEnum.FormMat)
	            .With(r => r.KeyPersons = new List<A2BApplicationKeyPersonsServiceModel> {keyPersons})
	            .With(r => r.ApplyingSchools = new List<A2BApplyingSchoolServiceModel> {applyingSchools})
	            .Build();

            var application = new A2BApplication
            {
	            ApplicationId = "10001",
	            Name = applicationCreateRequest.Name,
	            ApplicationType = applicationCreateRequest.ApplicationType,
	            FormTrustProposedNameOfTrust = applicationCreateRequest.FormTrustProposedNameOfTrust,
	            ApplicationSubmitted = applicationCreateRequest.ApplicationSubmitted,
	            ApplicationLeadAuthorId = applicationCreateRequest.ApplicationLeadAuthorId,
	            ApplicationVersion = applicationCreateRequest.ApplicationVersion,
	            ApplicationLeadAuthorName = applicationCreateRequest.ApplicationLeadAuthorName,
	            ApplicationLeadEmail = applicationCreateRequest.ApplicationLeadEmail,
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
	            FormTrustImprovementApprovedSponsor = applicationCreateRequest.FormTrustImprovementApprovedSponsor,
	            ApplicationStatusId = applicationCreateRequest.ApplicationStatusId,
	            KeyPersons = applicationCreateRequest.KeyPersons
		            .Select(A2BApplicationKeyPersonsFactory.Create)
		            .ToList(),
	            ApplyingSchools = applicationCreateRequest.ApplyingSchools
		            .Select(A2BApplicationApplyingSchoolFactory.Create)
		            .ToList()
	            
            };

            var expectedResult = new A2BApplicationResponse
            {
	            ApplicationId = "10001",
	            Name = applicationCreateRequest.Name,
	            ApplicationType = Enum.GetName(typeof(A2BApplicationTypeEnum), applicationCreateRequest.ApplicationType!),
	            FormTrustProposedNameOfTrust = applicationCreateRequest.FormTrustProposedNameOfTrust,
	            ApplicationSubmitted = applicationCreateRequest.ApplicationSubmitted,
	            ApplicationLeadAuthorId = applicationCreateRequest.ApplicationLeadAuthorId,
	            ApplicationVersion = applicationCreateRequest.ApplicationVersion,
	            ApplicationLeadAuthorName = applicationCreateRequest.ApplicationLeadAuthorName,
	            ApplicationLeadEmail = applicationCreateRequest.ApplicationLeadEmail,
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
	            FormTrustImprovementApprovedSponsor = applicationCreateRequest.FormTrustImprovementApprovedSponsor,
	            ApplicationStatusId = applicationCreateRequest.ApplicationStatusId,
	            KeyPersons = applicationCreateRequest.KeyPersons,
	            ApplyingSchools = applicationCreateRequest.ApplyingSchools
            };
            
            var mockGateway = new Mock<IA2BApplicationGateway>();
            
            mockGateway.Setup(g => g.CreateA2BApplication(It.IsAny<A2BApplication>())).Returns(application);
            
            var useCase = new CreateA2BApplication(mockGateway.Object);
            
            var result = useCase.Execute(applicationCreateRequest);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
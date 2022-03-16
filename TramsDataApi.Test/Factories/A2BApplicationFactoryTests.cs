using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FizzWare.NBuilder;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories.A2BApplicationFactories;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;
using Xunit;
using TramsDataApi.ServiceModels.ApplyToBecome;

namespace TramsDataApi.Test.Factories
{
    public class A2BApplicationFactoryTests
    {
	    [Fact]
        public void Create_ReturnsExpectedA2BApplication_WhenA2BApplicationCreateRequestIsProvided()
        {
	        var keyPerson = Builder<A2BApplicationKeyPersonsServiceModel>.CreateNew().Build();
			var financialYear = Builder<FinancialYearServiceModel>.CreateNew().Build();
	        var applyingSchool = Builder<A2BApplicationApplyingSchoolServiceModel>
				.CreateNew()
				.With(r => r.PreviousFinancialYear = financialYear)
				.With(r => r.CurrentFinancialYear = financialYear)
				.With(r => r.NextFinancialYear = financialYear)
				.Build();
            var applicationCreateRequest = Builder<A2BApplicationCreateRequest>
                .CreateNew()
                .With(r => r.ApplicationType = "JoinMat")
                .With(r => r.KeyPersons = new List<A2BApplicationKeyPersonsServiceModel> { keyPerson })
                .With(r => r.ApplyingSchools = new List<A2BApplicationApplyingSchoolServiceModel> { applyingSchool })
                .Build();

            var expectedApplication = new A2BApplication
            {
	            ApplicationId = applicationCreateRequest.ApplicationId,
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
	            KeyPersons = applicationCreateRequest.KeyPersons.Select(A2BApplicationKeyPersonsFactory.Create).ToList(),
	            ApplyingSchools = applicationCreateRequest.ApplyingSchools.Select(A2BApplicationApplyingSchoolFactory.Create).ToList()
            };
                
            var response = A2BApplicationFactory.Create(applicationCreateRequest);

            response.Should().BeEquivalentTo(expectedApplication);
        }
        
	    [Fact]
        public void Create_ReturnsExpectedA2BApplicationResponse_WhenA2BApplicationIsProvided()
        {
	        var keyPerson = Builder<A2BApplicationKeyPersons>.CreateNew().Build();
	        var applyingSchool = Builder<A2BApplicationApplyingSchool>.CreateNew().Build();
	        
            var application = Builder<A2BApplication>
                .CreateNew()
                .With(a => a.ApplicationType = "JoinMat")
                .With(a => a.KeyPersons = new List<A2BApplicationKeyPersons> {keyPerson})
                .With(a => a.ApplyingSchools = new List<A2BApplicationApplyingSchool> { applyingSchool })
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
	            ApplicationLeadEmail = application.ApplicationLeadEmail,
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
	            ApplicationStatusId = application.ApplicationStatusId,
	            KeyPersons = application.KeyPersons
		            .Select(A2BApplicationKeyPersonsFactory.Create)
		            .ToList(),
	            ApplyingSchools = application.ApplyingSchools
		            .Select(A2BApplicationApplyingSchoolFactory.Create)
		            .ToList()
            };
                
            var response = A2BApplicationFactory.Create(application);

            response.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
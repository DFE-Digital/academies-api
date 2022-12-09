using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;
using TramsDataApi.ServiceModels.ApplyToBecome;

namespace TramsDataApi.Factories.A2BApplicationFactories
{
    public static class A2BApplicationFactory
    {
	    public static A2BApplication Create(A2BApplicationCreateRequest request) => new A2BApplication
	    {
		    ApplicationId = request.ApplicationId,
			TrustName  = request.TrustName,
		    ApplicationStatusId = request.ApplicationStatusId,
		    ApplicationType = request.ApplicationType,
		    Name = request.Name,
		    TrustId = request.TrustId,
		    FormTrustProposedNameOfTrust = request.FormTrustProposedNameOfTrust,
		    ApplicationSubmitted = request.ApplicationSubmitted,
		    ApplicationLeadAuthorId = request.ApplicationLeadAuthorId,
		    ApplicationVersion = request.ApplicationVersion,
		    ApplicationLeadAuthorName = request.ApplicationLeadAuthorName,
		    ApplicationLeadEmail = request.ApplicationLeadEmail,
		    ApplicationRole = request.ApplicationRole,
		    ApplicationRoleOtherDescription = request.ApplicationRoleOtherDescription,
		    ChangesToTrust = request.ChangesToTrust,
		    ChangesToTrustExplained = request.ChangesToTrustExplained,
		    ChangesToLaGovernance = request.ChangesToLaGovernance,
		    ChangesToLaGovernanceExplained = request.ChangesToLaGovernanceExplained,
		    FormTrustOpeningDate = request.FormTrustOpeningDate,
		    TrustApproverName = request.TrustApproverName,
		    TrustApproverEmail = request.TrustApproverEmail,
		    FormTrustReasonApprovalToConvertAsSat = request.FormTrustReasonApprovalToConvertAsSat,
		    FormTrustReasonApprovedPerson = request.FormTrustReasonApprovedPerson,
		    FormTrustReasonForming = request.FormTrustReasonForming,
		    FormTrustReasonVision = request.FormTrustReasonVision,
		    FormTrustReasonGeoAreas = request.FormTrustReasonGeoAreas,
		    FormTrustReasonFreedom = request.FormTrustReasonFreedom,
		    FormTrustReasonImproveTeaching = request.FormTrustReasonImproveTeaching,
		    FormTrustPlanForGrowth = request.FormTrustPlanForGrowth,
		    FormTrustPlansForNoGrowth = request.FormTrustPlansForNoGrowth,
		    FormTrustGrowthPlansYesNo = request.FormTrustGrowthPlansYesNo,
		    FormTrustImprovementSupport = request.FormTrustImprovementSupport,
		    FormTrustImprovementStrategy = request.FormTrustImprovementStrategy,
		    FormTrustImprovementApprovedSponsor = request.FormTrustImprovementApprovedSponsor,
		    KeyPersons = request.KeyPersons
			    .Select(A2BApplicationKeyPersonsFactory.Create)
			    .ToList(),
		    ApplyingSchools = request.ApplyingSchools
			    .Select(A2BApplicationApplyingSchoolFactory.Create)
			    .ToList(),
			DynamicsApplicationId = request.DynamicsApplicationId,
			
	    };

	    public static A2BApplicationResponse Create(A2BApplication application) => new A2BApplicationResponse
	    {
		    Name = application.Name,
			TrustName = application.TrustName,
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
		    TrustApproverName = application.TrustApproverName,
		    TrustApproverEmail = application.TrustApproverEmail,
		    TrustId = application.TrustId,
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
		    KeyPersons = application.KeyPersons == null 
			    ? new List<A2BApplicationKeyPersonsServiceModel>()
			    : application.KeyPersons
					.Select(A2BApplicationKeyPersonsFactory.Create)
					.ToList(),
		    ApplyingSchools = application.ApplyingSchools == null 
			    ? new List<A2BApplicationApplyingSchoolServiceModel>()
			    : application.ApplyingSchools
					.Select(A2BApplicationApplyingSchoolFactory.Create)
					.ToList(),
			DynamicsApplicationId = application.DynamicsApplicationId,
			
	    };
    }
}
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.Factories
{
	public class A2BApplicationResponseFactory
    {
	    public static A2BApplicationResponse Create(A2BApplication application, A2BApplicationAccount account)
	    { 
		    return application is null ? null : new A2BApplicationResponse
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
			    Account = account
		    };
	    }
    }
}

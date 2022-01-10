using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.ApplyToBecome;

namespace TramsDataApi.Factories
{
    public static class A2BApplicationFactory
    {
        public static A2BApplication Create(A2BApplicationCreateRequest request)
        {
            return request == null
                ? null
                : new A2BApplication
                {
                    ApplicationId = request.ApplicationId,
                    Name = request.Name,
                    ApplicationType = request.ApplicationType,
                    TrustId = request.TrustId,
                    FormTrustProposedNameOfTrust = request.FormTrustProposedNameOfTrust,
                    ApplicationSubmitted = request.ApplicationSubmitted,
                    ApplicationLeadAuthorId = request.ApplicationLeadAuthorId,
                    ApplicationVersion = request.ApplicationVersion,
                    ApplicationLeadAuthorName = request.ApplicationLeadAuthorName,
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
                    FormTrustImprovementApprovedSponsor = request.FormTrustImprovementApprovedSponsor
                };
        }
    }
}
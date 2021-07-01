using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.Factories
{
    public class AcademyConversionProjectResponseFactory
    {
	    public static AcademyConversionProjectResponse Create(IfdPipeline ifdPipeline, Trust trust = null, AcademyConversionProject academyConversionProject = null)
        {
			var response = new AcademyConversionProjectResponse
			{
				Id = (int)ifdPipeline.Sk,
				Urn = int.Parse(ifdPipeline.GeneralDetailsUrn),
				SchoolName = ifdPipeline.GeneralDetailsProjectName,
				LocalAuthority = ifdPipeline.GeneralDetailsLocalAuthority,
				ApplicationReceivedDate = ifdPipeline.InterestDateOfInterest,
				AssignedDate = ifdPipeline.ApprovalProcessApplicationDate,
				ProjectStatus = "Pre HTB",
				Author = ifdPipeline.GeneralDetailsProjectLead,
				ClearedBy = ifdPipeline.GeneralDetailsTeamLeader,
				HeadTeacherBoardDate = ifdPipeline.DeliveryProcessDateForDiscussionByRscHtb,
				AcademyTypeAndRoute = ifdPipeline.GeneralDetailsRouteOfProject,
				ProposedAcademyOpeningDate = ifdPipeline.GeneralDetailsExpectedOpeningDate,
				PublishedAdmissionNumber = ifdPipeline.DeliveryProcessPan,
				PartOfPfiScheme = ifdPipeline.DeliveryProcessPfi,
				ViabilityIssues = ifdPipeline.ProjectTemplateInformationViabilityIssue,
				FinancialDeficit = ifdPipeline.ProjectTemplateInformationDeficit,
				RationaleForProject = ifdPipeline.ProjectTemplateInformationRationaleForProject,
				RationaleForTrust = ifdPipeline.ProjectTemplateInformationRationaleForSponsor,
				RisksAndIssues = ifdPipeline.ProjectTemplateInformationRisksAndIssues,
				RevenueCarryForwardAtEndMarchCurrentYear = !string.IsNullOrEmpty(ifdPipeline.ProjectTemplateInformationFyRevenueBalanceCarriedForward) ?
				    decimal.Parse(ifdPipeline.ProjectTemplateInformationFyRevenueBalanceCarriedForward) : (decimal?)null,
				ProjectedRevenueBalanceAtEndMarchNextYear = !string.IsNullOrEmpty(ifdPipeline.ProjectTemplateInformationFy1RevenueBalanceCarriedForward) ?
					decimal.Parse(ifdPipeline.ProjectTemplateInformationFy1RevenueBalanceCarriedForward) : (decimal?)null
			};

			if (trust != null)
            {
				response.TrustReferenceNumber = trust.TrustRef;
				response.NameOfTrust = trust.TrustsTrustName;
				response.SponsorReferenceNumber = trust.LeadSponsor;
				response.SponsorName = trust.TrustsLeadSponsorName;
            }

			if (academyConversionProject != null)
			{
				response.RationaleSectionComplete = academyConversionProject.RationaleSectionComplete;
				response.LocalAuthorityInformationTemplateSentDate = academyConversionProject.LocalAuthorityInformationTemplateSentDate;
				response.LocalAuthorityInformationTemplateReturnedDate = academyConversionProject.LocalAuthorityInformationTemplateReturnedDate;
				response.LocalAuthorityInformationTemplateComments = academyConversionProject.LocalAuthorityInformationTemplateComments;
				response.LocalAuthorityInformationTemplateLink = academyConversionProject.LocalAuthorityInformationTemplateLink;
				response.LocalAuthorityInformationTemplateSectionComplete = academyConversionProject.LocalAuthorityInformationTemplateSectionComplete;
				response.RecommendationForProject = academyConversionProject.RecommendationForProject;
				response.AcademyOrderRequired = academyConversionProject.AcademyOrderRequired;
				response.SchoolAndTrustInformationSectionComplete = academyConversionProject.SchoolAndTrustInformationSectionComplete;
				response.DistanceFromSchoolToTrustHeadquarters = academyConversionProject.DistanceFromSchoolToTrustHeadquarters;
				response.DistanceFromSchoolToTrustHeadquartersAdditionalInformation = academyConversionProject.DistanceFromSchoolToTrustHeadquartersAdditionalInformation;
				response.GeneralInformationSectionComplete = academyConversionProject.GeneralInformationSectionComplete;
				response.RisksAndIssuesSectionComplete = academyConversionProject.RisksAndIssuesSectionComplete;
				response.SchoolPerformanceAdditionalInformation = academyConversionProject.SchoolPerformanceAdditionalInformation;
				response.CapitalCarryForwardAtEndMarchCurrentYear = academyConversionProject.CapitalCarryForwardAtEndMarchCurrentYear;
				response.CapitalCarryForwardAtEndMarchNextYear = academyConversionProject.CapitalCarryForwardAtEndMarchNextYear;
				response.SchoolBudgetInformationAdditionalInformation = academyConversionProject.SchoolBudgetInformationAdditionalInformation;
				response.SchoolBudgetInformationSectionComplete = academyConversionProject.SchoolBudgetInformationSectionComplete;
            }

			return response;
		}
    }
}

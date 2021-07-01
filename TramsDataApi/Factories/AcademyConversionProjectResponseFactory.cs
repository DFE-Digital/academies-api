using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.Factories
{
	/// <remarks>
	/// NB: any changes here may need replicating in TramsDataApi.ApplyToBecome.SyncAcademyConversionProjectFactory
	/// </remarks>
	public class AcademyConversionProjectResponseFactory
    {
	    public static AcademyConversionProjectResponse Create(AcademyConversionProject academyConversionProject, Trust trust = null)
        {
			var response = new AcademyConversionProjectResponse
			{
				Id = academyConversionProject.Id,
				Urn = academyConversionProject.Urn ?? 0,
				SchoolName = academyConversionProject.SchoolName,
				LocalAuthority = academyConversionProject.LocalAuthority,
				ApplicationReceivedDate = academyConversionProject.ApplicationReceivedDate,
				AssignedDate = academyConversionProject.AssignedDate,
				ProjectStatus = "Pre HTB",
				Author = academyConversionProject.Author,
				ClearedBy = academyConversionProject.ClearedBy,
				HeadTeacherBoardDate = academyConversionProject.HeadTeacherBoardDate,
				AcademyTypeAndRoute = academyConversionProject.AcademyTypeAndRoute,
				ProposedAcademyOpeningDate = academyConversionProject.ProposedAcademyOpeningDate,
				PublishedAdmissionNumber = academyConversionProject.PublishedAdmissionNumber,
				PartOfPfiScheme = academyConversionProject.PartOfPfiScheme,
				ViabilityIssues = academyConversionProject.ViabilityIssues,
				FinancialDeficit = academyConversionProject.FinancialDeficit,
				RationaleForProject = academyConversionProject.RationaleForProject,
				RationaleForTrust = academyConversionProject.RationaleForTrust,
				RisksAndIssues = academyConversionProject.RisksAndIssues,
				RevenueCarryForwardAtEndMarchCurrentYear = academyConversionProject.RevenueCarryForwardAtEndMarchCurrentYear,
				ProjectedRevenueBalanceAtEndMarchNextYear = academyConversionProject.ProjectedRevenueBalanceAtEndMarchNextYear,
				RationaleSectionComplete = academyConversionProject.RationaleSectionComplete,
				LocalAuthorityInformationTemplateSentDate = academyConversionProject.LocalAuthorityInformationTemplateSentDate,
				LocalAuthorityInformationTemplateReturnedDate = academyConversionProject.LocalAuthorityInformationTemplateReturnedDate,
				LocalAuthorityInformationTemplateComments = academyConversionProject.LocalAuthorityInformationTemplateComments,
				LocalAuthorityInformationTemplateLink = academyConversionProject.LocalAuthorityInformationTemplateLink,
				LocalAuthorityInformationTemplateSectionComplete = academyConversionProject.LocalAuthorityInformationTemplateSectionComplete,
				RecommendationForProject = academyConversionProject.RecommendationForProject,
				AcademyOrderRequired = academyConversionProject.AcademyOrderRequired,
				SchoolAndTrustInformationSectionComplete = academyConversionProject.SchoolAndTrustInformationSectionComplete,
				DistanceFromSchoolToTrustHeadquarters = academyConversionProject.DistanceFromSchoolToTrustHeadquarters,
				DistanceFromSchoolToTrustHeadquartersAdditionalInformation = academyConversionProject.DistanceFromSchoolToTrustHeadquartersAdditionalInformation,
				GeneralInformationSectionComplete = academyConversionProject.GeneralInformationSectionComplete,
				RisksAndIssuesSectionComplete = academyConversionProject.RisksAndIssuesSectionComplete,
				SchoolPerformanceAdditionalInformation = academyConversionProject.SchoolPerformanceAdditionalInformation,
				CapitalCarryForwardAtEndMarchCurrentYear = academyConversionProject.CapitalCarryForwardAtEndMarchCurrentYear,
				CapitalCarryForwardAtEndMarchNextYear = academyConversionProject.CapitalCarryForwardAtEndMarchNextYear,
				SchoolBudgetInformationAdditionalInformation = academyConversionProject.SchoolBudgetInformationAdditionalInformation,
				SchoolBudgetInformationSectionComplete = academyConversionProject.SchoolBudgetInformationSectionComplete
			};

			if (trust != null)
            {
				response.TrustReferenceNumber = trust.TrustRef;
				response.NameOfTrust = trust.TrustsTrustName;
				response.SponsorReferenceNumber = trust.LeadSponsor;
				response.SponsorName = trust.TrustsLeadSponsorName;
            }

			return response;
		}
    }
}

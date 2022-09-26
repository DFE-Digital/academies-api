using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.Factories
{
	public class AcademyConversionProjectResponseFactory
    {
	    public static AcademyConversionProjectResponse Create(AcademyConversionProject academyConversionProject) =>
			new AcademyConversionProjectResponse
			{
				Id = academyConversionProject.Id,
				ApplicationReferenceNumber = academyConversionProject.ApplicationReferenceNumber,
				NameOfTrust = academyConversionProject.NameOfTrust,
				SponsorName = academyConversionProject.SponsorName,
				SponsorReferenceNumber = academyConversionProject.SponsorReferenceNumber,
				Urn = academyConversionProject.Urn ?? 0,
				SchoolName = academyConversionProject.SchoolName,
				LocalAuthority = academyConversionProject.LocalAuthority,
				TrustReferenceNumber = academyConversionProject.TrustReferenceNumber,
				ApplicationReceivedDate = academyConversionProject.ApplicationReceivedDate,
				AssignedDate = academyConversionProject.AssignedDate,
				ProjectStatus = academyConversionProject.ProjectStatus,
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
				PreviousHeadTeacherBoardDateQuestion = academyConversionProject.PreviousHeadTeacherBoardDateQuestion,
				PreviousHeadTeacherBoardDate = academyConversionProject.PreviousHeadTeacherBoardDate,
				SchoolAndTrustInformationSectionComplete = academyConversionProject.SchoolAndTrustInformationSectionComplete,
				DistanceFromSchoolToTrustHeadquarters = academyConversionProject.DistanceFromSchoolToTrustHeadquarters,
				DistanceFromSchoolToTrustHeadquartersAdditionalInformation = academyConversionProject.DistanceFromSchoolToTrustHeadquartersAdditionalInformation,
				MemberOfParliamentName = academyConversionProject.MemberOfParliamentName,
				MemberOfParliamentParty = academyConversionProject.MemberOfParliamentParty,
				GeneralInformationSectionComplete = academyConversionProject.GeneralInformationSectionComplete,
				RisksAndIssuesSectionComplete = academyConversionProject.RisksAndIssuesSectionComplete,
				// Legal Requirements
				LegalRequirementsSectionComplete = academyConversionProject.LegalRequirementsSectionComplete,
				GoverningBodyResolution = academyConversionProject.GoverningBodyResolution,
				DiocesanConsent = academyConversionProject.DiocesanConsent,
				FoundationConsent = academyConversionProject.FoundationConsent,
				Consultation = academyConversionProject.Consultation,

				SchoolPerformanceAdditionalInformation = academyConversionProject.SchoolPerformanceAdditionalInformation,
				CapitalCarryForwardAtEndMarchCurrentYear = academyConversionProject.CapitalCarryForwardAtEndMarchCurrentYear,
				CapitalCarryForwardAtEndMarchNextYear = academyConversionProject.CapitalCarryForwardAtEndMarchNextYear,
				SchoolBudgetInformationAdditionalInformation = academyConversionProject.SchoolBudgetInformationAdditionalInformation,
				SchoolBudgetInformationSectionComplete = academyConversionProject.SchoolBudgetInformationSectionComplete,
				SchoolPupilForecastsAdditionalInformation = academyConversionProject.SchoolPupilForecastsAdditionalInformation,
				YearOneProjectedCapacity = academyConversionProject.YearOneProjectedCapacity,
				YearOneProjectedPupilNumbers = academyConversionProject.YearOneProjectedPupilNumbers,
				YearTwoProjectedCapacity = academyConversionProject.YearTwoProjectedCapacity,
				YearTwoProjectedPupilNumbers = academyConversionProject.YearTwoProjectedPupilNumbers,
				YearThreeProjectedCapacity = academyConversionProject.YearThreeProjectedCapacity,
				YearThreeProjectedPupilNumbers = academyConversionProject.YearThreeProjectedPupilNumbers,
				KeyStage2PerformanceAdditionalInformation = academyConversionProject.KeyStage2PerformanceAdditionalInformation,
				KeyStage4PerformanceAdditionalInformation = academyConversionProject.KeyStage4PerformanceAdditionalInformation,
				KeyStage5PerformanceAdditionalInformation = academyConversionProject.KeyStage5PerformanceAdditionalInformation,
				ConversionSupportGrantAmount = academyConversionProject.ConversionSupportGrantAmount,
				ConversionSupportGrantChangeReason = academyConversionProject.ConversionSupportGrantChangeReason,
				EqualitiesImpactAssessmentConsidered = academyConversionProject.EqualitiesImpactAssessmentConsidered
			};
    }
}

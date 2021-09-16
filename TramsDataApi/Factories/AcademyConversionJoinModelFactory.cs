using System;
using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.AcademyConversionProject;

namespace TramsDataApi.Factories
{
    public class AcademyConversionJoinModelFactory
    {
         public static AcademyConversionJoinModel Create(AcademyConversionProject acp, IfdPipeline ifdPipeline)
         {
             return new AcademyConversionJoinModel
             {
                 Id = acp.Id,
                 IfdPipelineId = acp.IfdPipelineId,
                 Urn = acp.Urn,
                 SchoolName = acp.SchoolName,
                 LocalAuthority = acp.LocalAuthority,
                 ApplicationReferenceNumber = acp.ApplicationReferenceNumber,
                 ProjectStatus = acp.ProjectStatus,
                 ApplicationReceivedDate = acp.ApplicationReceivedDate,
                 AssignedDate = acp.AssignedDate,
                 HeadTeacherBoardDate = acp.HeadTeacherBoardDate,
                 OpeningDate = acp.OpeningDate,
                 BaselineDate = acp.BaselineDate,
                 LocalAuthorityInformationTemplateSentDate = acp.LocalAuthorityInformationTemplateSentDate,
                 LocalAuthorityInformationTemplateReturnedDate = acp.LocalAuthorityInformationTemplateReturnedDate,
                 LocalAuthorityInformationTemplateComments = acp.LocalAuthorityInformationTemplateComments,
                 LocalAuthorityInformationTemplateLink = acp.LocalAuthorityInformationTemplateLink,
                 LocalAuthorityInformationTemplateSectionComplete = acp.LocalAuthorityInformationTemplateSectionComplete,
                 RecommendationForProject = acp.RecommendationForProject,
                 Author = acp.Author,
                 Version = acp.Version,
                 ClearedBy = acp.ClearedBy,
                 AcademyOrderRequired = acp.AcademyOrderRequired,
                 PreviousHeadTeacherBoardDate = acp.PreviousHeadTeacherBoardDate,
                 PreviousHeadTeacherBoardDateQuestion = acp.PreviousHeadTeacherBoardDateQuestion,
                 PreviousHeadTeacherBoardLink = acp.PreviousHeadTeacherBoardLink,
                 TrustReferenceNumber = acp.TrustReferenceNumber,
                 NameOfTrust = acp.NameOfTrust,
                 SponsorReferenceNumber = acp.SponsorReferenceNumber,
                 SponsorName = acp.SponsorName,
                 AcademyTypeAndRoute = acp.AcademyTypeAndRoute,
                 ProposedAcademyOpeningDate = acp.ProposedAcademyOpeningDate,
                 SchoolAndTrustInformationSectionComplete = acp.SchoolAndTrustInformationSectionComplete,
                 SchoolPhase = acp.SchoolPhase,
                 AgeRange = acp.AgeRange,
                 SchoolType = acp.SchoolType,
                 ActualPupilNumbers = acp.ActualPupilNumbers,
                 Capacity = acp.Capacity,
                 PublishedAdmissionNumber = acp.PublishedAdmissionNumber,
                 PercentageFreeSchoolMeals = acp.PercentageFreeSchoolMeals,
                 PartOfPfiScheme = acp.PartOfPfiScheme,
                 ViabilityIssues = acp.ViabilityIssues,
                 FinancialDeficit = acp.FinancialDeficit,
                 DiocesanTrust = acp.DiocesanTrust,
                 PercentageOfGoodOrOutstandingSchoolsInTheDiocesanTrust = acp.PercentageOfGoodOrOutstandingSchoolsInTheDiocesanTrust,
                 DistanceFromSchoolToTrustHeadquarters = acp.DistanceFromSchoolToTrustHeadquarters,
                 DistanceFromSchoolToTrustHeadquartersAdditionalInformation = acp.DistanceFromSchoolToTrustHeadquartersAdditionalInformation,
                 MemberOfParliamentParty = acp.MemberOfParliamentParty,
                 GeneralInformationSectionComplete = acp.GeneralInformationSectionComplete,
                 SchoolPerformanceAdditionalInformation = acp.SchoolPerformanceAdditionalInformation,
                 RationaleForProject = acp.RationaleForProject,
                 RationaleForTrust = acp.RationaleForTrust,
                 RationaleSectionComplete = acp.RationaleSectionComplete,
                 RisksAndIssues = acp.RisksAndIssues,
                 EqualitiesImpactAssessmentConsidered = acp.EqualitiesImpactAssessmentConsidered,
                 RisksAndIssuesSectionComplete = acp.RisksAndIssuesSectionComplete,
                 RevenueCarryForwardAtEndMarchCurrentYear = acp.RevenueCarryForwardAtEndMarchCurrentYear,
                 ProjectedRevenueBalanceAtEndMarchNextYear = acp.ProjectedRevenueBalanceAtEndMarchNextYear,
                 CapitalCarryForwardAtEndMarchCurrentYear = acp.CapitalCarryForwardAtEndMarchCurrentYear,
                 CapitalCarryForwardAtEndMarchNextYear = acp.CapitalCarryForwardAtEndMarchNextYear,
                 SchoolBudgetInformationAdditionalInformation = acp.SchoolBudgetInformationAdditionalInformation,
                 SchoolBudgetInformationSectionComplete = acp.SchoolBudgetInformationSectionComplete,
                 YearOneProjectedCapacity = acp.YearOneProjectedCapacity,
                 YearOneProjectedPupilNumbers = acp.YearOneProjectedPupilNumbers,
                 YearTwoProjectedCapacity = acp.YearTwoProjectedCapacity,
                 YearTwoProjectedPupilNumbers = acp.YearTwoProjectedPupilNumbers,
                 YearThreeProjectedCapacity = acp.YearThreeProjectedCapacity,
                 YearThreeProjectedPupilNumbers = acp.YearThreeProjectedPupilNumbers,
                 SchoolPupilForecastsAdditionalInformation = acp.SchoolPupilForecastsAdditionalInformation,
                 KeyStage2PerformanceAdditionalInformation = acp.KeyStage2PerformanceAdditionalInformation,
                 KeyStage4PerformanceAdditionalInformation = acp.KeyStage4PerformanceAdditionalInformation,
                 KeyStage5PerformanceAdditionalInformation = acp.KeyStage5PerformanceAdditionalInformation,
                 Upin = ifdPipeline.EfaFundingUpin,
                 NewAcademyUrn = ifdPipeline.ProposedAcademyDetailsNewAcademyUrn
             };
         }
    }
}
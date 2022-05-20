using AutoFixture;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels.AcademyConversionProject;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class AcademyConversionProjectResponseFactoryTests
    {
        private readonly Fixture _fixture;

        public AcademyConversionProjectResponseFactoryTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void ReturnsAnAcademyConversionProjectResponse_WhenGivenAcademyConversionProjectAndTrust()
        {
            var academyConversionProject = _fixture.Create<AcademyConversionProject>();
            var trust = _fixture.Create<Trust>();
         
            var expectedResponse = CreateExpected(academyConversionProject, trust);

            var academyConversionProjectResponse = AcademyConversionProjectResponseFactory.Create(academyConversionProject, trust, null);

            academyConversionProjectResponse.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void ReturnsAnAcademyConversionProjectResponse_WhenGivenAcademyConversionProject()
        {
            var academyConversionProject = _fixture.Create<AcademyConversionProject>();
            var expectedResponse = CreateExpected(academyConversionProject, null);

            var academyConversionProjectResponse = AcademyConversionProjectResponseFactory.Create(academyConversionProject, null);

            academyConversionProjectResponse.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void ReturnsAnAcademyConversionProjectResponse_WhenGivenAcademyConversionProjectWithNullSchoolBudgetAndPupilForecastValues()
        {
              var academyConversionProject = _fixture.Build<AcademyConversionProject>()
                .Without(x => x.CapitalCarryForwardAtEndMarchCurrentYear)
                .Without(x => x.CapitalCarryForwardAtEndMarchNextYear)
                .Without(x => x.YearOneProjectedCapacity)
                .Without(x => x.YearOneProjectedPupilNumbers)
                .Without(x => x.YearTwoProjectedPupilNumbers)
                .Without(x => x.YearTwoProjectedPupilNumbers)
                .Without(x => x.YearThreeProjectedPupilNumbers)
                .Without(x => x.YearThreeProjectedPupilNumbers)
                .Create();

            var expectedResponse = CreateExpected(academyConversionProject, null);

            var academyConversionProjectResponse = AcademyConversionProjectResponseFactory.Create(academyConversionProject, null);

            academyConversionProjectResponse.Should().BeEquivalentTo(expectedResponse);
        }

        private AcademyConversionProjectResponse CreateExpected(AcademyConversionProject academyConversionProject, Trust trust = null)
        {
            var expected = new AcademyConversionProjectResponse
            {
                Id = academyConversionProject.Id,                
                ApplicationReferenceNumber = academyConversionProject.ApplicationReferenceNumber,
                Urn = academyConversionProject.Urn ?? 0,
                SchoolName = academyConversionProject.SchoolName,
                LocalAuthority = academyConversionProject.LocalAuthority,
                ApplicationReceivedDate = academyConversionProject.ApplicationReceivedDate,
                AssignedDate = academyConversionProject.AssignedDate,
                ProjectStatus = academyConversionProject.ProjectStatus,
                TrustReferenceNumber = academyConversionProject.TrustReferenceNumber,
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

                RecommendationForProject = academyConversionProject.RecommendationForProject,
                AcademyOrderRequired = academyConversionProject.AcademyOrderRequired,
                DistanceFromSchoolToTrustHeadquarters = academyConversionProject.DistanceFromSchoolToTrustHeadquarters,
                DistanceFromSchoolToTrustHeadquartersAdditionalInformation = academyConversionProject.DistanceFromSchoolToTrustHeadquartersAdditionalInformation,
                PreviousHeadTeacherBoardDateQuestion = academyConversionProject.PreviousHeadTeacherBoardDateQuestion,
                PreviousHeadTeacherBoardDate = academyConversionProject.PreviousHeadTeacherBoardDate,
                SchoolAndTrustInformationSectionComplete = academyConversionProject.SchoolAndTrustInformationSectionComplete,
                MemberOfParliamentName = academyConversionProject.MemberOfParliamentName,
                MemberOfParliamentParty = academyConversionProject.MemberOfParliamentParty,
                GeneralInformationSectionComplete = academyConversionProject.GeneralInformationSectionComplete,
                RationaleSectionComplete = academyConversionProject.RationaleSectionComplete,
                LocalAuthorityInformationTemplateSentDate = academyConversionProject.LocalAuthorityInformationTemplateSentDate,
                LocalAuthorityInformationTemplateReturnedDate = academyConversionProject.LocalAuthorityInformationTemplateReturnedDate,
                LocalAuthorityInformationTemplateComments = academyConversionProject.LocalAuthorityInformationTemplateComments,
                LocalAuthorityInformationTemplateLink = academyConversionProject.LocalAuthorityInformationTemplateLink,
                LocalAuthorityInformationTemplateSectionComplete = academyConversionProject.LocalAuthorityInformationTemplateSectionComplete,
                RisksAndIssuesSectionComplete = academyConversionProject.RisksAndIssuesSectionComplete,
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

            if (trust != null)
            {
                expected.NameOfTrust = trust.TrustsTrustName;
                expected.SponsorReferenceNumber = trust.LeadSponsor;
                expected.SponsorName = trust.TrustsLeadSponsorName;
            }
            return expected;
        }
    }
}

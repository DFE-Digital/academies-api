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
        public void ReturnsAnAcademyConversionProjectResponse_WhenGivenIfdPipeline()
        {
            var academyConversionProject = _fixture.Create<AcademyConversionProject>();
            var expectedResponse = CreateExpected(academyConversionProject);

            var academyConversionProjectResponse = AcademyConversionProjectResponseFactory.Create(academyConversionProject, null);

            academyConversionProjectResponse.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void ReturnsAnAcademyConversionProjectResponse_WhenGivenIfdPipelineAndTrust()
        {
            var academyConversionProject = _fixture.Create<AcademyConversionProject>();
            var trust = _fixture.Create<Trust>();

            var expectedResponse = CreateExpected(academyConversionProject, trust);

            var academyConversionProjectResponse = AcademyConversionProjectResponseFactory.Create(academyConversionProject, trust);

            academyConversionProjectResponse.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void ReturnsAnAcademyConversionProjectResponse_WhenGivenIfdPipelineAndAcademyConversionProject()
        {
            var academyConversionProject = _fixture.Create<AcademyConversionProject>();

            var expectedResponse = CreateExpected(academyConversionProject, null);

            var academyConversionProjectResponse = AcademyConversionProjectResponseFactory.Create(academyConversionProject, null);

            academyConversionProjectResponse.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void ReturnsAnAcademyConversionProjectResponse_WhenGivenIfdPipelineAndAcademyConversionProjectWithNullSchoolBudgetValues()
        {
              var academyConversionProject = _fixture.Build<AcademyConversionProject>()
                .Without(x => x.CapitalCarryForwardAtEndMarchCurrentYear)
                .Without(x => x.CapitalCarryForwardAtEndMarchNextYear)
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
                Urn = academyConversionProject.Urn ?? 0,
                SchoolName = academyConversionProject.SchoolName,
                LocalAuthority = academyConversionProject.LocalAuthority,
                ApplicationReceivedDate = academyConversionProject.ApplicationReceivedDate,
                AssignedDate = academyConversionProject.AssignedDate,
                ProjectStatus = "Pre HTB",
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
                SchoolAndTrustInformationSectionComplete = academyConversionProject.SchoolAndTrustInformationSectionComplete,
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
                SchoolBudgetInformationSectionComplete = academyConversionProject.SchoolBudgetInformationSectionComplete
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

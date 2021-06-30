using System.Linq;
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
            var ifdPipeline = _fixture.Build<IfdPipeline>()
                .With(x => x.GeneralDetailsUrn, "12345")
                .With(x => x.ProjectTemplateInformationFyRevenueBalanceCarriedForward, _fixture.Create<decimal>().ToString)
                .With(x => x.ProjectTemplateInformationFy1RevenueBalanceCarriedForward, _fixture.Create<decimal>().ToString)
                .Create();

            var expectedResponse = CreateExpected(ifdPipeline);

            var academyConversionProjectResponse = AcademyConversionProjectResponseFactory.Create(ifdPipeline, null);

            academyConversionProjectResponse.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void ReturnsAnAcademyConversionProjectResponse_WhenGivenIfdPipelineAndTrust()
        {
            var ifdPipeline = _fixture.Build<IfdPipeline>()
                .With(x => x.GeneralDetailsUrn, "12345")
                .With(x => x.ProjectTemplateInformationFyRevenueBalanceCarriedForward, _fixture.Create<decimal>().ToString)
                .With(x => x.ProjectTemplateInformationFy1RevenueBalanceCarriedForward, _fixture.Create<decimal>().ToString)
                .Create();
            var trust = _fixture.Create<Trust>();

            var expectedResponse = CreateExpected(ifdPipeline, trust);

            var academyConversionProjectResponse = AcademyConversionProjectResponseFactory.Create(ifdPipeline, trust);

            academyConversionProjectResponse.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void ReturnsAnAcademyConversionProjectResponse_WhenGivenIfdPipelineAndAcademyConversionProject()
        {
            var ifdPipeline = _fixture.Build<IfdPipeline>().With(x => x.GeneralDetailsUrn, "12345")
                .With(x => x.ProjectTemplateInformationFyRevenueBalanceCarriedForward, _fixture.Create<decimal>().ToString)
                .With(x => x.ProjectTemplateInformationFy1RevenueBalanceCarriedForward, _fixture.Create<decimal>().ToString)
                .Create();
            var academyConversionProject = _fixture.Create<AcademyConversionProject>();

            var expectedResponse = CreateExpected(ifdPipeline, null, academyConversionProject);

            var academyConversionProjectResponse = AcademyConversionProjectResponseFactory.Create(ifdPipeline, null, academyConversionProject);

            academyConversionProjectResponse.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void ReturnsAnAcademyConversionProjectResponse_WhenGivenIfdPipelineAndAcademyConversionProjectWithNullSchoolBudgetAndProjectNotesValues()
        {
            var ifdPipeline = _fixture.Build<IfdPipeline>()
                .With(x => x.GeneralDetailsUrn, "12345")
                .Without(x => x.ProjectTemplateInformationFyRevenueBalanceCarriedForward)
                .Without(x => x.ProjectTemplateInformationFy1RevenueBalanceCarriedForward)
                .Create();

            var academyConversionProject = _fixture.Build<AcademyConversionProject>()
                .Without(x => x.CapitalCarryForwardAtEndMarchCurrentYear)
                .Without(x => x.CapitalCarryForwardAtEndMarchNextYear)
                .Create();

            var expectedResponse = CreateExpected(ifdPipeline, null, academyConversionProject);

            var academyConversionProjectResponse = AcademyConversionProjectResponseFactory.Create(ifdPipeline, null, academyConversionProject);

            academyConversionProjectResponse.Should().BeEquivalentTo(expectedResponse);
        }

        private AcademyConversionProjectResponse CreateExpected(IfdPipeline ifdPipeline, Trust trust = null, AcademyConversionProject academyConversionProject = null)
        {
            var expected = new AcademyConversionProjectResponse
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
                    decimal.Parse(ifdPipeline.ProjectTemplateInformationFy1RevenueBalanceCarriedForward) : (decimal?)null,
            };
            if (trust != null)
            {
                expected.TrustReferenceNumber = trust.TrustRef;
                expected.NameOfTrust = trust.TrustsTrustName;
                expected.SponsorReferenceNumber = trust.LeadSponsor;
                expected.SponsorName = trust.TrustsLeadSponsorName;
            }
            if (academyConversionProject != null)
            {
                expected.RecommendationForProject = academyConversionProject.RecommendationForProject;
                expected.AcademyOrderRequired = academyConversionProject.AcademyOrderRequired;
                expected.DistanceFromSchoolToTrustHeadquarters = academyConversionProject.DistanceFromSchoolToTrustHeadquarters;
                expected.DistanceFromSchoolToTrustHeadquartersAdditionalInformation = academyConversionProject.DistanceFromSchoolToTrustHeadquartersAdditionalInformation;
                expected.SchoolAndTrustInformationSectionComplete = academyConversionProject.SchoolAndTrustInformationSectionComplete;
                expected.GeneralInformationSectionComplete = academyConversionProject.GeneralInformationSectionComplete;
                expected.RationaleSectionComplete = academyConversionProject.RationaleSectionComplete;
                expected.LocalAuthorityInformationTemplateSentDate = academyConversionProject.LocalAuthorityInformationTemplateSentDate;
                expected.LocalAuthorityInformationTemplateReturnedDate = academyConversionProject.LocalAuthorityInformationTemplateReturnedDate;
                expected.LocalAuthorityInformationTemplateComments = academyConversionProject.LocalAuthorityInformationTemplateComments;
                expected.LocalAuthorityInformationTemplateLink = academyConversionProject.LocalAuthorityInformationTemplateLink;
                expected.LocalAuthorityInformationTemplateSectionComplete = academyConversionProject.LocalAuthorityInformationTemplateSectionComplete;
                expected.RisksAndIssuesSectionComplete = academyConversionProject.RisksAndIssuesSectionComplete;
                expected.SchoolPerformanceAdditionalInformation = academyConversionProject.SchoolPerformanceAdditionalInformation;
                expected.CapitalCarryForwardAtEndMarchCurrentYear = academyConversionProject.CapitalCarryForwardAtEndMarchCurrentYear;
                expected.CapitalCarryForwardAtEndMarchNextYear = academyConversionProject.CapitalCarryForwardAtEndMarchNextYear;
                expected.SchoolBudgetInformationAdditionalInformation = academyConversionProject.SchoolBudgetInformationAdditionalInformation;
                expected.SchoolBudgetInformationSectionComplete = academyConversionProject.SchoolBudgetInformationSectionComplete;
            }
            return expected;
        }
    }
}

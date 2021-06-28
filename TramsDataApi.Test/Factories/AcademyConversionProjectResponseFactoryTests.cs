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
        [Fact]
        public void ReturnsAnAcademyConversionProjectResponse_WhenGivenIfdPipeline()
        {
            var fixture = new Fixture();
            var ifdPipeline = fixture.Build<IfdPipeline>()
                .With(x => x.GeneralDetailsUrn, "12345")
                .With(x => x.ProjectTemplateInformationFyRevenueBalanceCarriedForward, fixture.Create<decimal>().ToString)
                .With(x => x.ProjectTemplateInformationFy1RevenueBalanceCarriedForward, fixture.Create<decimal>().ToString)
                .Create();

            var expectedResponse = CreateExpected(ifdPipeline);

            var academyConversionProjectResponse = AcademyConversionProjectResponseFactory.Create(ifdPipeline);

            academyConversionProjectResponse.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void ReturnsAnAcademyConversionProjectResponse_WhenGivenIfdPipelineAndAcademyConversionProject()
        {
            var fixture = new Fixture();
            var ifdPipeline = fixture.Build<IfdPipeline>().With(x => x.GeneralDetailsUrn, "12345")
                .With(x => x.ProjectTemplateInformationFyRevenueBalanceCarriedForward, fixture.Create<decimal>().ToString)
                .With(x => x.ProjectTemplateInformationFy1RevenueBalanceCarriedForward, fixture.Create<decimal>().ToString)
                .Create();
            var academyConversionProject = fixture.Create<AcademyConversionProject>();

            var expectedResponse = CreateExpected(ifdPipeline, academyConversionProject);

            var academyConversionProjectResponse = AcademyConversionProjectResponseFactory.Create(ifdPipeline, academyConversionProject);

            academyConversionProjectResponse.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void ReturnsAnAcademyConversionProjectResponse_WhenGivenIfdPipelineAndAcademyConversionProjectWithNullSchoolBudgetAndProjectNotesValues()
        {
            var fixture = new Fixture();
            var ifdPipeline = fixture.Build<IfdPipeline>()
                .With(x => x.GeneralDetailsUrn, "12345")
                .Without(x => x.ProjectTemplateInformationFyRevenueBalanceCarriedForward)
                .Without(x => x.ProjectTemplateInformationFy1RevenueBalanceCarriedForward)
                .Create();

            var academyConversionProject = fixture.Build<AcademyConversionProject>()
                .Without(x => x.CapitalCarryForwardAtEndMarchCurrentYear)
                .Without(x => x.CapitalCarryForwardAtEndMarchNextYear)
                .Without(x => x.ProjectNotes)
                .Create();

            var expectedResponse = CreateExpected(ifdPipeline, academyConversionProject);

            var academyConversionProjectResponse = AcademyConversionProjectResponseFactory.Create(ifdPipeline, academyConversionProject);

            academyConversionProjectResponse.Should().BeEquivalentTo(expectedResponse);
        }

        private AcademyConversionProjectResponse CreateExpected(IfdPipeline ifdPipeline, AcademyConversionProject academyConversionProject = null)
        {
            var expected =  new AcademyConversionProjectResponse
            {
                Id = (int)ifdPipeline.Sk,
                Urn = int.Parse(ifdPipeline.GeneralDetailsUrn),
                SchoolName = ifdPipeline.GeneralDetailsProjectName,
                LocalAuthority = ifdPipeline.GeneralDetailsLocalAuthority,
                ApplicationReceivedDate = ifdPipeline.InterestDateOfInterest,
                AssignedDate = ifdPipeline.ApprovalProcessApplicationDate,
                ProjectStatus = "Pre HTB",
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
            if (academyConversionProject != null)
            {
                expected.DistanceFromSchoolToTrustHeadquarters = academyConversionProject.DistanceFromSchoolToTrustHeadquarters;
                expected.DistanceFromSchoolToTrustHeadquartersAdditionalInformation = academyConversionProject.DistanceFromSchoolToTrustHeadquartersAdditionalInformation;
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
                expected.ProjectNotes = academyConversionProject.ProjectNotes?.Select(p => new ProjectNoteResponse
                {
                    Subject = p.Subject,
                    Note = p.Note,
                    Author = p.Author,
                    Date = p.Date
                }).ToList();
            }
            return expected;
        }
    }
}

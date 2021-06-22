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

            var expectedResponse = new AcademyConversionProjectResponse
            {
                Id = (int)ifdPipeline.Sk,
                Urn = int.Parse(ifdPipeline.GeneralDetailsUrn),
                SchoolName = ifdPipeline.GeneralDetailsProjectName,
                LocalAuthority = ifdPipeline.GeneralDetailsLocalAuthority,
                ApplicationReceivedDate = ifdPipeline.InterestDateOfInterest,
                AssignedDate = ifdPipeline.ApprovalProcessApplicationDate,
                ProjectStatus = "Pre HTB",
                RationaleForProject = ifdPipeline.ProjectTemplateInformationRationaleForProject,
                RationaleForTrust = ifdPipeline.ProjectTemplateInformationRationaleForSponsor,
                RationaleSectionComplete = null,
                RisksAndIssues = ifdPipeline.ProjectTemplateInformationRisksAndIssues,
                RisksAndIssuesSectionComplete = null,
                RevenueCarryForwardAtEndMarchCurrentYear = decimal.Parse(ifdPipeline.ProjectTemplateInformationFyRevenueBalanceCarriedForward),
                ProjectedRevenueBalanceAtEndMarchNextYear = decimal.Parse(ifdPipeline.ProjectTemplateInformationFy1RevenueBalanceCarriedForward)

            };

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

            var expectedResponse = new AcademyConversionProjectResponse
            {
                Id = (int)ifdPipeline.Sk,
                Urn = int.Parse(ifdPipeline.GeneralDetailsUrn),
                SchoolName = ifdPipeline.GeneralDetailsProjectName,
                LocalAuthority = ifdPipeline.GeneralDetailsLocalAuthority,
                ApplicationReceivedDate = ifdPipeline.InterestDateOfInterest,
                AssignedDate = ifdPipeline.ApprovalProcessApplicationDate,
                ProjectStatus = "Pre HTB",
                RationaleForProject = ifdPipeline.ProjectTemplateInformationRationaleForProject,
                RationaleForTrust = ifdPipeline.ProjectTemplateInformationRationaleForSponsor,
                RationaleSectionComplete = academyConversionProject.RationaleSectionComplete,
                LocalAuthorityInformationTemplateSentDate = academyConversionProject.LocalAuthorityInformationTemplateSentDate,
                LocalAuthorityInformationTemplateReturnedDate = academyConversionProject.LocalAuthorityInformationTemplateReturnedDate,
                LocalAuthorityInformationTemplateComments = academyConversionProject.LocalAuthorityInformationTemplateComments,
                LocalAuthorityInformationTemplateLink = academyConversionProject.LocalAuthorityInformationTemplateLink,
                LocalAuthorityInformationTemplateSectionComplete = academyConversionProject.LocalAuthorityInformationTemplateSectionComplete,
                RisksAndIssues = ifdPipeline.ProjectTemplateInformationRisksAndIssues,
                RisksAndIssuesSectionComplete = academyConversionProject.RisksAndIssuesSectionComplete,
                SchoolPerformanceAdditionalInformation = academyConversionProject.SchoolPerformanceAdditionalInformation,
                RevenueCarryForwardAtEndMarchCurrentYear = academyConversionProject.RevenueCarryForwardAtEndMarchCurrentYear,
                ProjectedRevenueBalanceAtEndMarchNextYear = academyConversionProject.ProjectedRevenueBalanceAtEndMarchNextYear,
                SchoolBudgetInformationAdditionalInformation = academyConversionProject.SchoolBudgetInformationAdditionalInformation,
                SchoolBudgetInformationSectionComplete = academyConversionProject.SchoolBudgetInformationSectionComplete
            };

            var academyConversionProjectResponse = AcademyConversionProjectResponseFactory.Create(ifdPipeline, academyConversionProject);

            academyConversionProjectResponse.Should().BeEquivalentTo(expectedResponse);
        }
    }
}

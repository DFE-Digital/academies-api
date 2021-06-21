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
            var ifdPipeline = fixture.Build<IfdPipeline>().With(x => x.GeneralDetailsUrn, "12345").Create();

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
                RisksAndIssuesSectionComplete = null
            };

            var academyConversionProjectResponse = AcademyConversionProjectResponseFactory.Create(ifdPipeline);

            academyConversionProjectResponse.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void ReturnsAnAcademyConversionProjectResponse_WhenGivenIfdPipelineAndAcademyConversionProject()
        {
            var fixture = new Fixture();
            var ifdPipeline = fixture.Build<IfdPipeline>().With(x => x.GeneralDetailsUrn, "12345").Create();
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
                RisksAndIssuesSectionComplete = academyConversionProject.RisksAndIssuesSectionComplete
            };

            var academyConversionProjectResponse = AcademyConversionProjectResponseFactory.Create(ifdPipeline, academyConversionProject);

            academyConversionProjectResponse.Should().BeEquivalentTo(expectedResponse);
        }
    }
}

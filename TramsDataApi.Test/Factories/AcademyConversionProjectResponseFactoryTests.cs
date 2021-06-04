using System;
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
        public void ReturnsAnAcademyConversionProjectResponse_WhenGivenAnAcademyConversionProject()
        {
            var fixture = new Fixture();
            var academyConversionProject = new IfdPipeline
            {
                Sk = fixture.Create<int>(),
                GeneralDetailsUrn = fixture.Create<string>(),
                GeneralDetailsProjectName = fixture.Create<string>(),
                GeneralDetailsLocalAuthority = fixture.Create<string>(),
                TrustSponsorManagementCoSponsor1 = fixture.Create<string>(),
                TrustSponsorManagementCoSponsor1SponsorName = fixture.Create<string>(),
                InterestDateOfInterest = new DateTime(),
                ApprovalProcessApplicationDate = new DateTime(),
                ProjectTemplateInformationRationaleForProject = fixture.Create<string>(),
                ProjectTemplateInformationRationaleForSponsor = fixture.Create<string>()
            };

            var expectedResponse = new AcademyConversionProjectResponse
            {
                Id = (int)academyConversionProject.Sk,
                School = new SchoolResponse
                {
                    Id = academyConversionProject.GeneralDetailsUrn,
                    Name = academyConversionProject.GeneralDetailsProjectName,
                    URN = academyConversionProject.GeneralDetailsUrn,
                    LocalAuthority = academyConversionProject.GeneralDetailsLocalAuthority
                },
                Trust = new TrustResponse
                {
                    Id = academyConversionProject.TrustSponsorManagementCoSponsor1,
                    Name = academyConversionProject.TrustSponsorManagementCoSponsor1SponsorName
                },
                ApplicationReceivedDate = academyConversionProject.InterestDateOfInterest,
                AssignedDate = academyConversionProject.ApprovalProcessApplicationDate,
                Phase = ProjectPhase.PreHTB,
                ProjectDocuments = new DocumentDetailsResponse[0],
                Rationale = new RationaleResponse
                {
                    ProjectRationale = academyConversionProject.ProjectTemplateInformationRationaleForProject,
                    TrustRationale = academyConversionProject.ProjectTemplateInformationRationaleForSponsor
                }
            };

            var academyConversionProjectResponse = AcademyConversionProjectResponseFactory.Create(academyConversionProject);

            academyConversionProjectResponse.Should().BeEquivalentTo(expectedResponse);
        }
    }
}

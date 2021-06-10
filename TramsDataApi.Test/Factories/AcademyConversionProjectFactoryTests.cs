using System;
using AutoFixture;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.RequestModels.AcademyConversionProject;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class AcademyConversionProjectFactoryTests
    {
        private readonly Fixture _fixture;

        public AcademyConversionProjectFactoryTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void ReturnsOriginalAcademyConversionProject_WhenUpdating_IfUpdateAcademyConversionProjectRequestIsNull()
        {
            var academyConversionProject = CreateAcademyConversionProject();

            var result = AcademyConversionProjectFactory.Update(academyConversionProject, null);

            result.Should().BeEquivalentTo(academyConversionProject);
        }

        [Fact]
        public void ReturnsOriginalAcademyConversionProject_WhenUpdating_IfUpdateAcademyConversionProjectRequestFieldsAreNull()
        {
            var academyConversionProject = CreateAcademyConversionProject();

            var updateRequest = new UpdateAcademyConversionProjectRequest
            {
                Id = academyConversionProject.Sk,
                RationaleForProject = null,
                RationaleForTrust = null
            };

            var result = AcademyConversionProjectFactory.Update(academyConversionProject, updateRequest);
            result.Should().BeEquivalentTo(academyConversionProject);
        }

        [Fact]
        public void ReturnsUpdatedAcademyConversionProject_WhenUpdating_IfUpdateAcademyConversionProjectRequestFieldsAreEmpty()
        {
            var academyConversionProject = CreateAcademyConversionProject();

            var updateRequest = new UpdateAcademyConversionProjectRequest
            {
                Id = academyConversionProject.Sk,
                RationaleForProject = "",
                RationaleForTrust = ""
            };

            var expected = new IfdPipeline
            {
                Sk = academyConversionProject.Sk,
                GeneralDetailsUrn = academyConversionProject.GeneralDetailsUrn,
                GeneralDetailsProjectName = academyConversionProject.GeneralDetailsProjectName,
                GeneralDetailsLocalAuthority = academyConversionProject.GeneralDetailsLocalAuthority,
                TrustSponsorManagementCoSponsor1 = academyConversionProject.TrustSponsorManagementCoSponsor1,
                TrustSponsorManagementCoSponsor1SponsorName = academyConversionProject.TrustSponsorManagementCoSponsor1SponsorName,
                InterestDateOfInterest = academyConversionProject.InterestDateOfInterest,
                ApprovalProcessApplicationDate = academyConversionProject.ApprovalProcessApplicationDate,
                ProjectTemplateInformationRationaleForProject = updateRequest.RationaleForProject,
                ProjectTemplateInformationRationaleForSponsor = updateRequest.RationaleForTrust
            };

            var result = AcademyConversionProjectFactory.Update(academyConversionProject, updateRequest);
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ReturnsUpdatedAcademyConversionProject_WhenUpdating_IfUpdateAcademyConversionProjectRequestFieldsAreNotNull()
        {
            var fixture = new Fixture();
            var academyConversionProject = CreateAcademyConversionProject();

            var updateRequest = new UpdateAcademyConversionProjectRequest
            {
                Id = academyConversionProject.Sk,
                RationaleForProject = fixture.Create<string>(),
                RationaleForTrust = fixture.Create<string>()
            };

            var result = AcademyConversionProjectFactory.Update(academyConversionProject, updateRequest);

            var expected = new IfdPipeline
            {
                Sk = academyConversionProject.Sk,
                GeneralDetailsUrn = academyConversionProject.GeneralDetailsUrn,
                GeneralDetailsProjectName = academyConversionProject.GeneralDetailsProjectName,
                GeneralDetailsLocalAuthority = academyConversionProject.GeneralDetailsLocalAuthority,
                TrustSponsorManagementCoSponsor1 = academyConversionProject.TrustSponsorManagementCoSponsor1,
                TrustSponsorManagementCoSponsor1SponsorName = academyConversionProject.TrustSponsorManagementCoSponsor1SponsorName,
                InterestDateOfInterest = academyConversionProject.InterestDateOfInterest,
                ApprovalProcessApplicationDate = academyConversionProject.ApprovalProcessApplicationDate,
                ProjectTemplateInformationRationaleForProject = updateRequest.RationaleForProject,
                ProjectTemplateInformationRationaleForSponsor = updateRequest.RationaleForTrust
            };

            result.Should().BeEquivalentTo(expected);
        }

        private IfdPipeline CreateAcademyConversionProject()
        {
            return new IfdPipeline
            {
                Sk = _fixture.Create<int>(),
                GeneralDetailsUrn = _fixture.Create<string>(),
                GeneralDetailsProjectName = _fixture.Create<string>(),
                GeneralDetailsLocalAuthority = _fixture.Create<string>(),
                TrustSponsorManagementCoSponsor1 = _fixture.Create<string>(),
                TrustSponsorManagementCoSponsor1SponsorName = _fixture.Create<string>(),
                InterestDateOfInterest = DateTime.Now,
                ApprovalProcessApplicationDate = DateTime.Now.AddMonths(2),
                ProjectTemplateInformationRationaleForProject = _fixture.Create<string>(),
                ProjectTemplateInformationRationaleForSponsor = _fixture.Create<string>()
            };
        }
    }
}

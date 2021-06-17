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
        public void ReturnsOriginalAcademyConversionProject_WhenUpdatingIfdPipeline_IfUpdateAcademyConversionProjectRequestIsNull()
        {
            var academyConversionProject = CreateIfdPipeline();

            var result = AcademyConversionProjectFactory.Update(academyConversionProject, null);

            result.Should().BeEquivalentTo(academyConversionProject);
        }

        [Fact]
        public void ReturnsOriginalAcademyConversionProject_WhenUpdatingIfdPipeline_IfUpdateAcademyConversionProjectRequestFieldsAreNull()
        {
            var academyConversionProject = CreateIfdPipeline();

            var updateRequest = new UpdateAcademyConversionProjectRequest
            {
                RationaleForProject = null,
                RationaleForTrust = null
            };

            var result = AcademyConversionProjectFactory.Update(academyConversionProject, updateRequest);
            result.Should().BeEquivalentTo(academyConversionProject);
        }

        [Fact]
        public void ReturnsUpdatedAcademyConversionProject_WhenUpdatingIfdPipeline_IfUpdateAcademyConversionProjectRequestFieldsAreEmpty()
        {
            var academyConversionProject = CreateIfdPipeline();

            var updateRequest = new UpdateAcademyConversionProjectRequest
            {
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
        public void ReturnsUpdatedAcademyConversionProject_WhenUpdatingIfdPipeline_IfUpdateAcademyConversionProjectRequestFieldsAreNotNull()
        {
            var academyConversionProject = CreateIfdPipeline();

            var updateRequest = new UpdateAcademyConversionProjectRequest
            {
                RationaleForProject = _fixture.Create<string>(),
                RationaleForTrust = _fixture.Create<string>()
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

        [Fact]
        public void ReturnsOriginalAcademyConversionProject_WhenUpdatingAcademyConversionProject_IfUpdateAcademyConversionProjectRequestIsNull()
        {
            var academyConversionProject = CreateAcademyConversionProject();

            var result = AcademyConversionProjectFactory.Update(academyConversionProject, null);

            result.Should().BeEquivalentTo(academyConversionProject);
        }

        [Fact]
        public void ReturnsOriginalAcademyConversionProject_WhenUpdatingAcademyConversionProject_IfUpdateAcademyConversionProjectRequestFieldsAreNull()
        {
            var academyConversionProject = CreateAcademyConversionProject();

            var updateRequest = new UpdateAcademyConversionProjectRequest
            {
                RationaleSectionComplete = null,
                LocalAuthorityInformationTemplateSentDate = null,
                LocalAuthorityInformationTemplateReturnedDate = null,
                LocalAuthorityInformationTemplateComments = null,
                LocalAuthorityInformationTemplateLink = null,
                LocalAuthorityInformationTemplateSectionComplete = null
            };

            var result = AcademyConversionProjectFactory.Update(academyConversionProject, updateRequest);
            result.Should().BeEquivalentTo(academyConversionProject);
        }

        [Fact]
        public void ReturnsUpdatedAcademyConversionProject_WhenUpdatingAcademyConversionProject_IfUpdateAcademyConversionProjectRequestFieldsAreNotNull()
        {
            var academyConversionProject = CreateAcademyConversionProject();

            var updateRequest = new UpdateAcademyConversionProjectRequest
            {
                RationaleSectionComplete = _fixture.Create<bool>(),
                LocalAuthorityInformationTemplateSentDate = DateTime.Now,
                LocalAuthorityInformationTemplateReturnedDate = DateTime.Now.AddDays(10),
                LocalAuthorityInformationTemplateComments = _fixture.Create<string>(),
                LocalAuthorityInformationTemplateLink = _fixture.Create<string>(),
                LocalAuthorityInformationTemplateSectionComplete = _fixture.Create<bool>()
            };

            var result = AcademyConversionProjectFactory.Update(academyConversionProject, updateRequest);

            var expected = new AcademyConversionProject
            {
                Id = academyConversionProject.Id,
                RationaleSectionComplete = updateRequest.RationaleSectionComplete,
                LocalAuthorityInformationTemplateSentDate = updateRequest.LocalAuthorityInformationTemplateSentDate,
                LocalAuthorityInformationTemplateReturnedDate = updateRequest.LocalAuthorityInformationTemplateReturnedDate,
                LocalAuthorityInformationTemplateComments = updateRequest.LocalAuthorityInformationTemplateComments,
                LocalAuthorityInformationTemplateLink = updateRequest.LocalAuthorityInformationTemplateLink,
                LocalAuthorityInformationTemplateSectionComplete = updateRequest.LocalAuthorityInformationTemplateSectionComplete
            };

            result.Should().BeEquivalentTo(expected);
        }

        private IfdPipeline CreateIfdPipeline()
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

        private AcademyConversionProject CreateAcademyConversionProject()
        {
            return new AcademyConversionProject
            {
                Id = _fixture.Create<int>(),
                RationaleSectionComplete = _fixture.Create<bool>()
            };
        }
    }
}

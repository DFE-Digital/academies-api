using System;
using AutoFixture;
using FluentAssertions;
using Newtonsoft.Json;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.Test.Utils;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class AcademyConversionProjectFactoryTests
    {
        private readonly Fixture _fixture;

        public AcademyConversionProjectFactoryTests()
        {
            _fixture = new Fixture();
            _fixture.Customizations.Add(new RandomDateGenerator(DateTime.Today.AddMonths(-6), DateTime.Today.AddMonths(12)));
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

            var updateRequest = _fixture.Build<UpdateAcademyConversionProjectRequest>().WithAutoProperties().Create();

            var result = AcademyConversionProjectFactory.Update(academyConversionProject, updateRequest);
            result.Should().BeEquivalentTo(academyConversionProject);
        }

        [Fact]
        public void ReturnsUpdatedAcademyConversionProject_WhenUpdatingIfdPipeline_IfUpdateAcademyConversionProjectRequestFieldsAreEmpty()
        {
            var academyConversionProject = CreateIfdPipeline();

            _fixture.Customize<string>(x => x.FromFactory(() => string.Empty));
            var updateRequest = _fixture.Create<UpdateAcademyConversionProjectRequest>();

            var expected = CreateExpectedIfdPipeline(academyConversionProject, updateRequest);

            AcademyConversionProjectFactory.Update(academyConversionProject, updateRequest).Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ReturnsUpdatedAcademyConversionProject_WhenUpdatingIfdPipeline_IfUpdateAcademyConversionProjectRequestFieldsAreNotNull()
        {
            var academyConversionProject = CreateIfdPipeline();

            var updateRequest = _fixture.Create<UpdateAcademyConversionProjectRequest>();

            var expected = CreateExpectedIfdPipeline(academyConversionProject, updateRequest);

            AcademyConversionProjectFactory.Update(academyConversionProject, updateRequest).Should().BeEquivalentTo(expected);
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

            var updateRequest = _fixture.Build<UpdateAcademyConversionProjectRequest>().WithAutoProperties().Create();

            AcademyConversionProjectFactory.Update(academyConversionProject, updateRequest).Should().BeEquivalentTo(academyConversionProject);
        }

        [Fact]
        public void ReturnsUpdatedAcademyConversionProject_WhenUpdatingAcademyConversionProject_IfUpdateAcademyConversionProjectRequestFieldsAreNotNull()
        {
            var academyConversionProject = CreateAcademyConversionProject();

            var updateRequest = _fixture.Create<UpdateAcademyConversionProjectRequest>();

            var expected = CreateExpectedAcademyConversionProject(academyConversionProject, updateRequest);

            AcademyConversionProjectFactory.Update(academyConversionProject, updateRequest).Should().BeEquivalentTo(expected);
        }

        private IfdPipeline CreateIfdPipeline()
        {
            return _fixture.Create<IfdPipeline>();
        }

        private IfdPipeline CreateExpectedIfdPipeline(IfdPipeline original, UpdateAcademyConversionProjectRequest updateRequest)
        {
            var expected = JsonConvert.DeserializeObject<IfdPipeline>(JsonConvert.SerializeObject(original));
            expected.ProjectTemplateInformationRationaleForProject = updateRequest.RationaleForProject;
            expected.ProjectTemplateInformationRationaleForSponsor = updateRequest.RationaleForTrust;
            expected.ProjectTemplateInformationRisksAndIssues = updateRequest.RisksAndIssues;
            return expected;
        }

        private AcademyConversionProject CreateAcademyConversionProject()
        {
            return _fixture.Create<AcademyConversionProject>();
        }

        private AcademyConversionProject CreateExpectedAcademyConversionProject(AcademyConversionProject original, UpdateAcademyConversionProjectRequest updateRequest)
        {
            var expected = JsonConvert.DeserializeObject<AcademyConversionProject>(JsonConvert.SerializeObject(original));
            expected.RationaleSectionComplete = updateRequest.RationaleSectionComplete;
            expected.LocalAuthorityInformationTemplateSentDate = updateRequest.LocalAuthorityInformationTemplateSentDate;
            expected.LocalAuthorityInformationTemplateReturnedDate = updateRequest.LocalAuthorityInformationTemplateReturnedDate;
            expected.LocalAuthorityInformationTemplateComments = updateRequest.LocalAuthorityInformationTemplateComments;
            expected.LocalAuthorityInformationTemplateLink = updateRequest.LocalAuthorityInformationTemplateLink;
            expected.LocalAuthorityInformationTemplateSectionComplete = updateRequest.LocalAuthorityInformationTemplateSectionComplete;
            expected.RisksAndIssuesSectionComplete = updateRequest.RisksAndIssuesSectionComplete;
            expected.SchoolPerformanceAdditionalInformation = updateRequest.SchoolPerformanceAdditionalInformation;
            return expected;
        }
    }
}

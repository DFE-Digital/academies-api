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

            var updateRequest = _fixture.Build<UpdateAcademyConversionProjectRequest>().OmitAutoProperties().Create();

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
        public void ReturnsUpdatedAcademyConversionProjectWithFieldValues_WhenUpdatingIfdPipeline_IfUpdateAcademyConversionProjectRequestDecimalFieldsAreSetToDefaultValues()
        {
            var ifdPipeline = CreateIfdPipeline();

            var updateRequest = new UpdateAcademyConversionProjectRequest
            {
                RevenueCarryForwardAtEndMarchCurrentYear = default(decimal),
                ProjectedRevenueBalanceAtEndMarchNextYear = default(decimal),
            };

            var expected = JsonConvert.DeserializeObject<IfdPipeline>(JsonConvert.SerializeObject(ifdPipeline));
            expected.ProjectTemplateInformationFyRevenueBalanceCarriedForward = null;
            expected.ProjectTemplateInformationFy1RevenueBalanceCarriedForward = null;
            AcademyConversionProjectFactory.Update(ifdPipeline, updateRequest).Should().BeEquivalentTo(expected);
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

            var updateRequest = _fixture.Build<UpdateAcademyConversionProjectRequest>().OmitAutoProperties().Create();

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

        [Fact]
        public void ReturnsUpdatedAcademyConversionProjectWithNullFieldValues_WhenUpdatingAcademyConversionProject_IfUpdateAcademyConversionProjectRequestDateAndDecimalFieldsAreSetToDefaulValues()
        {
            var academyConversionProject = CreateAcademyConversionProject();

            var updateRequest = new UpdateAcademyConversionProjectRequest
            {
                LocalAuthorityInformationTemplateSentDate = default(DateTime),
                LocalAuthorityInformationTemplateReturnedDate = default(DateTime),
                CapitalCarryForwardAtEndMarchCurrentYear = default(decimal),
                CapitalCarryForwardAtEndMarchNextYear = default(decimal)
            };

            var expected = JsonConvert.DeserializeObject<AcademyConversionProject>(JsonConvert.SerializeObject(academyConversionProject));
            expected.LocalAuthorityInformationTemplateSentDate = null;
            expected.LocalAuthorityInformationTemplateReturnedDate = null;
            expected.CapitalCarryForwardAtEndMarchCurrentYear = null;
            expected.CapitalCarryForwardAtEndMarchNextYear = null;
            AcademyConversionProjectFactory.Update(academyConversionProject, updateRequest).Should().BeEquivalentTo(expected);
        }

        private IfdPipeline CreateIfdPipeline()
        {
            return _fixture.Build<IfdPipeline>().OmitAutoProperties().Create();
        }

        private IfdPipeline CreateExpectedIfdPipeline(IfdPipeline original, UpdateAcademyConversionProjectRequest updateRequest)
        {
            var expected = JsonConvert.DeserializeObject<IfdPipeline>(JsonConvert.SerializeObject(original));
            expected.DeliveryProcessDateForDiscussionByRscHtb = updateRequest.HeadTeacherBoardDate;
            expected.GeneralDetailsProjectLead = updateRequest.Author;
            expected.GeneralDetailsTeamLeader = updateRequest.ClearedBy;
            expected.GeneralDetailsExpectedOpeningDate = updateRequest.ProposedAcademyOpeningDate;
            expected.DeliveryProcessPan = updateRequest.PublishedAdmissionNumber;
            expected.ProjectTemplateInformationViabilityIssue = updateRequest.ViabilityIssues;
            expected.ProjectTemplateInformationDeficit = updateRequest.FinancialDeficit;
            expected.ProjectTemplateInformationRationaleForProject = updateRequest.RationaleForProject;
            expected.ProjectTemplateInformationRationaleForSponsor = updateRequest.RationaleForTrust;
            expected.ProjectTemplateInformationRisksAndIssues = updateRequest.RisksAndIssues;
            expected.ProjectTemplateInformationFyRevenueBalanceCarriedForward = updateRequest.RevenueCarryForwardAtEndMarchCurrentYear.ToString();
            expected.ProjectTemplateInformationFy1RevenueBalanceCarriedForward = updateRequest.ProjectedRevenueBalanceAtEndMarchNextYear.ToString();
            return expected;
        }

        private AcademyConversionProject CreateAcademyConversionProject()
        {
            return _fixture.Build<AcademyConversionProject>().OmitAutoProperties().Create();
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
            expected.RecommendationForProject = updateRequest.RecommendationForProject;
            expected.AcademyOrderRequired = updateRequest.AcademyOrderRequired;
            expected.SchoolAndTrustInformationSectionComplete = updateRequest.SchoolAndTrustInformationSectionComplete;
            expected.DistanceFromSchoolToTrustHeadquarters = updateRequest.DistanceFromSchoolToTrustHeadquarters;
            expected.DistanceFromSchoolToTrustHeadquartersAdditionalInformation = updateRequest.DistanceFromSchoolToTrustHeadquartersAdditionalInformation;
            expected.GeneralInformationSectionComplete = updateRequest.GeneralInformationSectionComplete;
            expected.RisksAndIssuesSectionComplete = updateRequest.RisksAndIssuesSectionComplete;
            expected.SchoolPerformanceAdditionalInformation = updateRequest.SchoolPerformanceAdditionalInformation;
            expected.CapitalCarryForwardAtEndMarchCurrentYear = updateRequest.CapitalCarryForwardAtEndMarchCurrentYear;
            expected.CapitalCarryForwardAtEndMarchNextYear = updateRequest.CapitalCarryForwardAtEndMarchNextYear;
            expected.SchoolBudgetInformationAdditionalInformation = updateRequest.SchoolBudgetInformationAdditionalInformation;
            expected.SchoolBudgetInformationSectionComplete = updateRequest.SchoolBudgetInformationSectionComplete;

            return expected;
        }
    }
}

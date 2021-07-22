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
                CapitalCarryForwardAtEndMarchNextYear = default(decimal),
                PreviousHeadTeacherBoardDate = default(DateTime)
            };

            var expected = JsonConvert.DeserializeObject<AcademyConversionProject>(JsonConvert.SerializeObject(academyConversionProject));
            expected.LocalAuthorityInformationTemplateSentDate = null;
            expected.LocalAuthorityInformationTemplateReturnedDate = null;
            expected.CapitalCarryForwardAtEndMarchCurrentYear = null;
            expected.CapitalCarryForwardAtEndMarchNextYear = null;
            expected.PreviousHeadTeacherBoardDate = null;
            AcademyConversionProjectFactory.Update(academyConversionProject, updateRequest).Should().BeEquivalentTo(expected);
        }

        private AcademyConversionProject CreateAcademyConversionProject()
        {
            return _fixture.Build<AcademyConversionProject>().OmitAutoProperties().Create();
        }

        private AcademyConversionProject CreateExpectedAcademyConversionProject(AcademyConversionProject original, UpdateAcademyConversionProjectRequest updateRequest)
        {
            var expected = JsonConvert.DeserializeObject<AcademyConversionProject>(JsonConvert.SerializeObject(original));
            expected.HeadTeacherBoardDate = updateRequest.HeadTeacherBoardDate;
            expected.Author = updateRequest.Author;
            expected.ClearedBy = updateRequest.ClearedBy;
            expected.ProposedAcademyOpeningDate = updateRequest.ProposedAcademyOpeningDate;
            expected.PublishedAdmissionNumber = updateRequest.PublishedAdmissionNumber;
            expected.ViabilityIssues = updateRequest.ViabilityIssues;
            expected.FinancialDeficit = updateRequest.FinancialDeficit;
            expected.RationaleForProject = updateRequest.RationaleForProject;
            expected.RationaleForTrust = updateRequest.RationaleForTrust;
            expected.RisksAndIssues = updateRequest.RisksAndIssues;
            expected.RevenueCarryForwardAtEndMarchCurrentYear = updateRequest.RevenueCarryForwardAtEndMarchCurrentYear;
            expected.ProjectedRevenueBalanceAtEndMarchNextYear = updateRequest.ProjectedRevenueBalanceAtEndMarchNextYear;

            expected.RationaleSectionComplete = updateRequest.RationaleSectionComplete;
            expected.LocalAuthorityInformationTemplateSentDate = updateRequest.LocalAuthorityInformationTemplateSentDate;
            expected.LocalAuthorityInformationTemplateReturnedDate = updateRequest.LocalAuthorityInformationTemplateReturnedDate;
            expected.LocalAuthorityInformationTemplateComments = updateRequest.LocalAuthorityInformationTemplateComments;
            expected.LocalAuthorityInformationTemplateLink = updateRequest.LocalAuthorityInformationTemplateLink;
            expected.LocalAuthorityInformationTemplateSectionComplete = updateRequest.LocalAuthorityInformationTemplateSectionComplete;
            expected.RecommendationForProject = updateRequest.RecommendationForProject;
            expected.AcademyOrderRequired = updateRequest.AcademyOrderRequired;
            expected.PreviousHeadTeacherBoardDateQuestion = updateRequest.PreviousHeadTeacherBoardDateQuestion;
            expected.PreviousHeadTeacherBoardDate = updateRequest.PreviousHeadTeacherBoardDate;
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
            expected.SchoolPupilForecastsAdditionalInformation = updateRequest.SchoolPupilForecastsAdditionalInformation;
            expected.YearOneProjectedCapacity = updateRequest.YearOneProjectedCapacity;
            expected.YearOneProjectedPupilNumbers = updateRequest.YearOneProjectedPupilNumbers;
            expected.YearTwoProjectedCapacity = updateRequest.YearTwoProjectedCapacity;
            expected.YearTwoProjectedPupilNumbers = updateRequest.YearTwoProjectedPupilNumbers;
            expected.YearThreeProjectedCapacity = updateRequest.YearThreeProjectedCapacity;
            expected.YearThreeProjectedPupilNumbers = updateRequest.YearThreeProjectedPupilNumbers;
            expected.KeyStagePerformanceTablesAdditionalInformation = updateRequest.KeyStagePerformanceTablesAdditionalInformation;

            return expected;
        }
    }
}

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
            var expected = JsonConvert.DeserializeObject<AcademyConversionProject>(JsonConvert.SerializeObject(academyConversionProject));

            var result = AcademyConversionProjectFactory.Update(academyConversionProject, null);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ReturnsOriginalAcademyConversionProject_WhenUpdatingAcademyConversionProject_IfUpdateAcademyConversionProjectRequestFieldsAreNull()
        {
            var academyConversionProject = CreateAcademyConversionProject();
            var expected = JsonConvert.DeserializeObject<AcademyConversionProject>(JsonConvert.SerializeObject(academyConversionProject));

            var updateRequest = _fixture.Build<UpdateAcademyConversionProjectRequest>().OmitAutoProperties().Create();

            AcademyConversionProjectFactory.Update(academyConversionProject, updateRequest).Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void
            ReturnsOriginalAcademyConversionProject_WhenUpdatingAcademyConversionProject_IfUpdateAcademyConversionProjectGrantFieldsAreNullOrDefault()
        {
            var academyConversionProject = CreateAcademyConversionProject();
            var expected = JsonConvert.DeserializeObject<AcademyConversionProject>(JsonConvert.SerializeObject(academyConversionProject));

            var updateRequest = new UpdateAcademyConversionProjectRequest
            {
                ConversionSupportGrantAmount = null,
                ConversionSupportGrantChangeReason = null
            };

            var updatedProject = AcademyConversionProjectFactory.Update(academyConversionProject, updateRequest);
            updatedProject.ConversionSupportGrantAmount.Should().Be(expected.ConversionSupportGrantAmount);
            updatedProject.ConversionSupportGrantChangeReason.Should().Be(expected.ConversionSupportGrantChangeReason);
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
                DistanceFromSchoolToTrustHeadquarters = default(decimal),
                PreviousHeadTeacherBoardDate = default(DateTime)
            };

            var expected = JsonConvert.DeserializeObject<AcademyConversionProject>(JsonConvert.SerializeObject(academyConversionProject));
            expected.LocalAuthorityInformationTemplateSentDate = null;
            expected.LocalAuthorityInformationTemplateReturnedDate = null;
            expected.CapitalCarryForwardAtEndMarchCurrentYear = null;
            expected.CapitalCarryForwardAtEndMarchNextYear = null;
            expected.DistanceFromSchoolToTrustHeadquarters = null;
            expected.PreviousHeadTeacherBoardDate = null;
            AcademyConversionProjectFactory.Update(academyConversionProject, updateRequest).Should().BeEquivalentTo(expected);
        }

        private AcademyConversionProject CreateAcademyConversionProject()
        {
            return _fixture.Build<AcademyConversionProject>().Create();
        }

        private AcademyConversionProject CreateExpectedAcademyConversionProject(AcademyConversionProject original, UpdateAcademyConversionProjectRequest updateRequest)
        {
            var expected =
               JsonConvert.DeserializeObject<AcademyConversionProject>(JsonConvert.SerializeObject(original));

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

            expected.Consultation = updateRequest.Consultation;
            expected.DiocesanConsent = updateRequest.DiocesanConsent;
            expected.GoverningBodyResolution = updateRequest.GoverningBodyResolution;
            expected.FoundationConsent = updateRequest.FoundationConsent;
            expected.LegalRequirementsSectionComplete = updateRequest.LegalRequirementsSectionComplete;

            expected.RationaleSectionComplete = updateRequest.RationaleSectionComplete;
            expected.LocalAuthorityInformationTemplateSentDate = updateRequest.LocalAuthorityInformationTemplateSentDate;
            expected.LocalAuthorityInformationTemplateReturnedDate =
               updateRequest.LocalAuthorityInformationTemplateReturnedDate;
            expected.LocalAuthorityInformationTemplateComments = updateRequest.LocalAuthorityInformationTemplateComments;
            expected.LocalAuthorityInformationTemplateLink = updateRequest.LocalAuthorityInformationTemplateLink;
            expected.LocalAuthorityInformationTemplateSectionComplete =
               updateRequest.LocalAuthorityInformationTemplateSectionComplete;
            expected.RecommendationForProject = updateRequest.RecommendationForProject;
            expected.AcademyOrderRequired = updateRequest.AcademyOrderRequired;
            expected.PreviousHeadTeacherBoardDateQuestion = updateRequest.PreviousHeadTeacherBoardDateQuestion;
            expected.PreviousHeadTeacherBoardDate = updateRequest.PreviousHeadTeacherBoardDate;
            expected.SchoolAndTrustInformationSectionComplete = updateRequest.SchoolAndTrustInformationSectionComplete;
            expected.DistanceFromSchoolToTrustHeadquarters = updateRequest.DistanceFromSchoolToTrustHeadquarters;
            expected.DistanceFromSchoolToTrustHeadquartersAdditionalInformation =
               updateRequest.DistanceFromSchoolToTrustHeadquartersAdditionalInformation;
            expected.MemberOfParliamentParty = updateRequest.MemberOfParliamentParty;
            expected.MemberOfParliamentName = updateRequest.MemberOfParliamentName;
            expected.GeneralInformationSectionComplete = updateRequest.GeneralInformationSectionComplete;
            expected.RisksAndIssuesSectionComplete = updateRequest.RisksAndIssuesSectionComplete;
            expected.SchoolPerformanceAdditionalInformation = updateRequest.SchoolPerformanceAdditionalInformation;
            expected.CapitalCarryForwardAtEndMarchCurrentYear = updateRequest.CapitalCarryForwardAtEndMarchCurrentYear;
            expected.EndOfCurrentFinancialYear = updateRequest.EndOfCurrentFinancialYear;
            expected.EndOfNextFinancialYear = updateRequest.EndOfNextFinancialYear;
            expected.CapitalCarryForwardAtEndMarchNextYear = updateRequest.CapitalCarryForwardAtEndMarchNextYear;
            expected.SchoolBudgetInformationAdditionalInformation =
               updateRequest.SchoolBudgetInformationAdditionalInformation;
            expected.SchoolBudgetInformationSectionComplete = updateRequest.SchoolBudgetInformationSectionComplete;
            expected.SchoolPupilForecastsAdditionalInformation = updateRequest.SchoolPupilForecastsAdditionalInformation;
            expected.YearOneProjectedCapacity = updateRequest.YearOneProjectedCapacity;
            expected.YearOneProjectedPupilNumbers = updateRequest.YearOneProjectedPupilNumbers;
            expected.YearTwoProjectedCapacity = updateRequest.YearTwoProjectedCapacity;
            expected.YearTwoProjectedPupilNumbers = updateRequest.YearTwoProjectedPupilNumbers;
            expected.YearThreeProjectedCapacity = updateRequest.YearThreeProjectedCapacity;
            expected.YearThreeProjectedPupilNumbers = updateRequest.YearThreeProjectedPupilNumbers;
            expected.KeyStage2PerformanceAdditionalInformation = updateRequest.KeyStage2PerformanceAdditionalInformation;
            expected.KeyStage4PerformanceAdditionalInformation = updateRequest.KeyStage4PerformanceAdditionalInformation;
            expected.KeyStage5PerformanceAdditionalInformation = updateRequest.KeyStage5PerformanceAdditionalInformation;
            expected.ConversionSupportGrantAmount = updateRequest.ConversionSupportGrantAmount ?? default;
            expected.ConversionSupportGrantChangeReason = updateRequest.ConversionSupportGrantChangeReason;
            expected.ProjectStatus = updateRequest.ProjectStatus;
            expected.AssignedUserId = updateRequest.AssignedUser.Id;
            expected.AssignedUserFullName = updateRequest.AssignedUser.FullName;
            expected.AssignedUserEmailAddress = updateRequest.AssignedUser.EmailAddress;

            return expected;
        }
    }
}

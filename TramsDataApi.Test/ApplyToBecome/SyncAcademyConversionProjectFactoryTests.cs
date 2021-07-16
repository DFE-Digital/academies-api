using AutoFixture;
using FluentAssertions;
using TramsDataApi.ApplyToBecome;
using Xunit;

namespace TramsDataApi.Test.ApplyToBecome
{
    public class SyncAcademyConversionProjectFactoryTests
    {
        private readonly Fixture _fixture;

        public SyncAcademyConversionProjectFactoryTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void ReturnsSyncAcademyConversionProject_WhenGivenSyncIfdPipeline()
        {
            var ifdPipeline = _fixture.Build<SyncIfdPipeline>()
                .With(x => x.GeneralDetailsUrn, "123456")
                .With(x => x.ProjectTemplateInformationFyRevenueBalanceCarriedForward,
                    _fixture.Create<decimal>().ToString)
                .With(x => x.ProjectTemplateInformationFy1RevenueBalanceCarriedForward,
                    _fixture.Create<decimal>().ToString)
                .With(x => x.ProjectTemplateInformationAy1CapacityForecast, _fixture.Create<int>().ToString)
                .With(x => x.ProjectTemplateInformationAy1TotalPupilNumberForecast, _fixture.Create<int>().ToString)
                .With(x => x.ProjectTemplateInformationAy2CapacityForecast, _fixture.Create<int>().ToString)
                .With(x => x.ProjectTemplateInformationAy2TotalPupilNumberForecast, _fixture.Create<int>().ToString)
                .With(x => x.ProjectTemplateInformationAy3CapacityForecast, _fixture.Create<int>().ToString)
                .With(x => x.ProjectTemplateInformationAy3TotalPupilNumberForecast, _fixture.Create<int>().ToString)
                .Create();

            var expectedAcademyConversionProject = new SyncAcademyConversionProject
            {
                IfdPipelineId = (int)ifdPipeline.Sk,
                Urn = int.Parse(ifdPipeline.GeneralDetailsUrn),
                SchoolName = ifdPipeline.GeneralDetailsProjectName,
                LocalAuthority = ifdPipeline.GeneralDetailsLocalAuthority,
                ProjectStatus = "Active",
                ApplicationReceivedDate = ifdPipeline.ApprovalProcessApplicationDate,
                AssignedDate = ifdPipeline.ApprovalProcessApplicationDate,
                HeadTeacherBoardDate = ifdPipeline.DeliveryProcessDateForDiscussionByRscHtb,
                Author = ifdPipeline.GeneralDetailsProjectLead,
                ClearedBy = ifdPipeline.GeneralDetailsTeamLeader,
                TrustReferenceNumber = ifdPipeline.TrustSponsorManagementTrust,
                ProposedAcademyOpeningDate = ifdPipeline.GeneralDetailsExpectedOpeningDate,
                PublishedAdmissionNumber = ifdPipeline.DeliveryProcessPan,
                PartOfPfiScheme = ifdPipeline.DeliveryProcessPfi,
                ViabilityIssues = ifdPipeline.ProjectTemplateInformationViabilityIssue,
                FinancialDeficit = ifdPipeline.ProjectTemplateInformationDeficit,
                RationaleForProject = ifdPipeline.ProjectTemplateInformationRationaleForProject,
                RationaleForTrust = ifdPipeline.ProjectTemplateInformationRationaleForSponsor,
                RisksAndIssues = ifdPipeline.ProjectTemplateInformationRisksAndIssues,
                RevenueCarryForwardAtEndMarchCurrentYear = decimal.Parse(ifdPipeline.ProjectTemplateInformationFyRevenueBalanceCarriedForward),
                ProjectedRevenueBalanceAtEndMarchNextYear = decimal.Parse(ifdPipeline.ProjectTemplateInformationFy1RevenueBalanceCarriedForward),
                YearOneProjectedCapacity = int.Parse(ifdPipeline.ProjectTemplateInformationAy1CapacityForecast),
                YearOneProjectedPupilNumbers = int.Parse(ifdPipeline.ProjectTemplateInformationAy1TotalPupilNumberForecast),
                YearTwoProjectedCapacity = int.Parse(ifdPipeline.ProjectTemplateInformationAy2CapacityForecast),
                YearTwoProjectedPupilNumbers = int.Parse(ifdPipeline.ProjectTemplateInformationAy2TotalPupilNumberForecast),
                YearThreeProjectedCapacity = int.Parse(ifdPipeline.ProjectTemplateInformationAy3CapacityForecast),
                YearThreeProjectedPupilNumbers = int.Parse(ifdPipeline.ProjectTemplateInformationAy3TotalPupilNumberForecast)
            };

            var academyConversionProject = SyncAcademyConversionProjectFactory.Create(ifdPipeline);

            academyConversionProject.Should().BeEquivalentTo(expectedAcademyConversionProject);
        }
    }
}

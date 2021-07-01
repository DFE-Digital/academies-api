using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;
using TramsDataApi.Test.Utils;
using Xunit;

namespace TramsDataApi.Test.Integration
{
    [Collection("Database")]
    public class AcademyConversionProjectsIntegrationTests : IClassFixture<TramsDataApiFactory>, IDisposable
    {
        private readonly HttpClient _client;
        private readonly LegacyTramsDbContext _legacyDbContext;
        private readonly TramsDbContext _dbContext;
        private readonly Fixture _fixture;

        public AcademyConversionProjectsIntegrationTests(TramsDataApiFactory fixture)
        {
            _client = fixture.CreateClient();
            _client.DefaultRequestHeaders.Add("ApiKey", "testing-api-key");
            _legacyDbContext = fixture.Services.GetRequiredService<LegacyTramsDbContext>();
            _dbContext = fixture.Services.GetRequiredService<TramsDbContext>();
            _fixture = new Fixture();
            _fixture.Customizations.Add(new RandomDateGenerator(DateTime.Now.AddMonths(-24), DateTime.Now.AddMonths(6)));
        }

        [Fact]
        public async Task Get_request_should_get_all_academy_conversion_projects()
        {
            var ifdPipelines = _fixture.Build<IfdPipeline>()
                .With(x => x.GeneralDetailsUrn, "123456")
                .With(x => x.ProjectTemplateInformationFyRevenueBalanceCarriedForward, _fixture.Create<decimal>().ToString)
                .With(x => x.ProjectTemplateInformationFy1RevenueBalanceCarriedForward, _fixture.Create<decimal>().ToString)
                .CreateMany();
            _legacyDbContext.IfdPipeline.AddRange(ifdPipelines);
            _legacyDbContext.SaveChanges();
            var expected = ifdPipelines.Select(p => AcademyConversionProjectResponseFactory.Create(p)).ToList();

            var response = await _client.GetAsync("/conversion-projects");
            var content = await response.Content.ReadFromJsonAsync<IEnumerable<AcademyConversionProjectResponse>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Get_request_should_get_an_academy_conversion_project_by_id()
        {
            var ifdPipeline = _fixture.Build<IfdPipeline>().With(x => x.GeneralDetailsUrn, "789456")
                .With(x => x.ProjectTemplateInformationFyRevenueBalanceCarriedForward, _fixture.Create<decimal>().ToString)
                .With(x => x.ProjectTemplateInformationFy1RevenueBalanceCarriedForward, _fixture.Create<decimal>().ToString)
                .Create();
            _legacyDbContext.IfdPipeline.Add(ifdPipeline);

            var trust = CreateTrust(ifdPipeline);
            _legacyDbContext.Trust.Add(trust);

            _legacyDbContext.SaveChanges();

            var academyConversionProject = _fixture.Build<AcademyConversionProject>()
                .Without(p => p.Id).With(p => p.IfdPipelineId, ifdPipeline.Sk).Create();
            _dbContext.AcademyConversionProjects.Add(academyConversionProject);
            _dbContext.SaveChanges();
            var expected = AcademyConversionProjectResponseFactory.Create(ifdPipeline, trust, academyConversionProject);

            var response = await _client.GetAsync($"/conversion-projects/{ifdPipeline.Sk}");
            var content = await response.Content.ReadFromJsonAsync<AcademyConversionProjectResponse>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Get_request_should_be_a_not_found_response_when_id_does_not_match()
        {
            var ifdPipeline = _fixture.Create<IfdPipeline>();

            var response = await _client.GetAsync($"/conversion-projects/{ifdPipeline.Sk}");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Patch_request_should_update_an_academy_conversion_project()
        {
            var ifdPipeline = _fixture.Build<IfdPipeline>().With(x => x.GeneralDetailsUrn, "987654")
                .With(x => x.ProjectTemplateInformationFyRevenueBalanceCarriedForward, _fixture.Create<decimal>().ToString)
                .With(x => x.ProjectTemplateInformationFy1RevenueBalanceCarriedForward, _fixture.Create<decimal>().ToString)
                .Create();
            _legacyDbContext.IfdPipeline.Add(ifdPipeline);

            var trust = CreateTrust(ifdPipeline);
            _legacyDbContext.Trust.Add(trust);

            _legacyDbContext.SaveChanges();

            var updateRequest = _fixture.Create<UpdateAcademyConversionProjectRequest>();

            var expected = CreateExpectedApiResponse(ifdPipeline, trust, null, updateRequest);

            var response = await _client.PatchAsync($"/conversion-projects/{ifdPipeline.Sk}", JsonContent.Create(updateRequest));
            var content = await response.Content.ReadFromJsonAsync<AcademyConversionProjectResponse>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().BeEquivalentTo(expected);

            _legacyDbContext.Entry(ifdPipeline).Reload();
            var academyConversionProject = _dbContext.AcademyConversionProjects
                .Single(p => p.IfdPipelineId == ifdPipeline.Sk);

            AssertDatabaseUpdated(ifdPipeline, academyConversionProject, updateRequest);
        }

        [Fact]
        public async Task Patch_request_should_update_an_academy_conversion_project_when_project_entity_already_exists_in_db()
        {
            var ifdPipeline = _fixture.Build<IfdPipeline>()
                .With(x => x.GeneralDetailsUrn, "987654")
                .With(x => x.ProjectTemplateInformationFyRevenueBalanceCarriedForward, _fixture.Create<decimal>().ToString)
                .With(x => x.ProjectTemplateInformationFy1RevenueBalanceCarriedForward, _fixture.Create<decimal>().ToString)
                .Create();
            _legacyDbContext.IfdPipeline.Add(ifdPipeline);

            var trust = CreateTrust(ifdPipeline);
            _legacyDbContext.Trust.Add(trust);

            _legacyDbContext.SaveChanges();

            var academyConversionProject = _fixture.Build<AcademyConversionProject>()
                .Without(p => p.Id).With(p => p.IfdPipelineId, ifdPipeline.Sk).Create();
            _dbContext.AcademyConversionProjects.Add(academyConversionProject);
            _dbContext.SaveChanges();

            var updateRequest = _fixture.Create<UpdateAcademyConversionProjectRequest>();

            var expected = CreateExpectedApiResponse(ifdPipeline, trust, academyConversionProject, updateRequest);

            var response = await _client.PatchAsync($"/conversion-projects/{ifdPipeline.Sk}", JsonContent.Create(updateRequest));
            var content = await response.Content.ReadFromJsonAsync<AcademyConversionProjectResponse>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().BeEquivalentTo(expected);

            _legacyDbContext.Entry(ifdPipeline).Reload();
            _dbContext.Entry(academyConversionProject).Reload();

            AssertDatabaseUpdated(ifdPipeline, academyConversionProject, updateRequest);
        }

        [Fact]
        public async Task Patch_request_should_be_a_not_found_response_when_id_does_not_match_project()
        {
            var updateRequest = _fixture.Create<UpdateAcademyConversionProjectRequest>();

            var response = await _client.PatchAsync($"/conversion-projects/{_fixture.Create<int>()}", JsonContent.Create(updateRequest));
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        private void AssertDatabaseUpdated(IfdPipeline ifdPipeline, AcademyConversionProject academyConversionProject, UpdateAcademyConversionProjectRequest updateRequest)
        {
            ifdPipeline.ProjectTemplateInformationRationaleForProject.Should().Be(updateRequest.RationaleForProject);
            ifdPipeline.ProjectTemplateInformationRationaleForSponsor.Should().Be(updateRequest.RationaleForTrust);
            academyConversionProject.RationaleSectionComplete.Should().Be(updateRequest.RationaleSectionComplete);
            academyConversionProject.LocalAuthorityInformationTemplateSentDate.Should().Be(updateRequest.LocalAuthorityInformationTemplateSentDate);
            academyConversionProject.LocalAuthorityInformationTemplateReturnedDate.Should().Be(updateRequest.LocalAuthorityInformationTemplateReturnedDate);
            academyConversionProject.LocalAuthorityInformationTemplateComments.Should().Be(updateRequest.LocalAuthorityInformationTemplateComments);
            academyConversionProject.LocalAuthorityInformationTemplateLink.Should().Be(updateRequest.LocalAuthorityInformationTemplateLink);
            academyConversionProject.LocalAuthorityInformationTemplateSectionComplete.Should().Be(updateRequest.LocalAuthorityInformationTemplateSectionComplete);
            ifdPipeline.DeliveryProcessPan.Should().Be(updateRequest.PublishedAdmissionNumber);
            ifdPipeline.ProjectTemplateInformationViabilityIssue.Should().Be(updateRequest.ViabilityIssues);
            ifdPipeline.ProjectTemplateInformationDeficit.Should().Be(updateRequest.FinancialDeficit);
            academyConversionProject.DistanceFromSchoolToTrustHeadquarters.Should().Be(updateRequest.DistanceFromSchoolToTrustHeadquarters);
            academyConversionProject.DistanceFromSchoolToTrustHeadquartersAdditionalInformation.Should().Be(updateRequest.DistanceFromSchoolToTrustHeadquartersAdditionalInformation);
            academyConversionProject.GeneralInformationSectionComplete.Should().Be(updateRequest.GeneralInformationSectionComplete);
            ifdPipeline.ProjectTemplateInformationRisksAndIssues.Should().Be(updateRequest.RisksAndIssues);
            academyConversionProject.RisksAndIssuesSectionComplete.Should().Be(updateRequest.RisksAndIssuesSectionComplete);
            academyConversionProject.SchoolPerformanceAdditionalInformation.Should().Be(updateRequest.SchoolPerformanceAdditionalInformation);
            ifdPipeline.ProjectTemplateInformationFyRevenueBalanceCarriedForward.Should().Be(updateRequest.RevenueCarryForwardAtEndMarchCurrentYear.ToString());
            ifdPipeline.ProjectTemplateInformationFy1RevenueBalanceCarriedForward.Should().Be(updateRequest.ProjectedRevenueBalanceAtEndMarchNextYear.ToString());
            academyConversionProject.CapitalCarryForwardAtEndMarchCurrentYear.Should().Be(updateRequest.CapitalCarryForwardAtEndMarchCurrentYear);
            academyConversionProject.CapitalCarryForwardAtEndMarchNextYear.Should().Be(updateRequest.CapitalCarryForwardAtEndMarchNextYear);
            academyConversionProject.SchoolBudgetInformationAdditionalInformation.Should().Be(updateRequest.SchoolBudgetInformationAdditionalInformation);
            academyConversionProject.SchoolBudgetInformationSectionComplete.Should().Be(updateRequest.SchoolBudgetInformationSectionComplete);
        }

        private AcademyConversionProjectResponse CreateExpectedApiResponse(IfdPipeline ifdPipeline, Trust trust, AcademyConversionProject academyConversionProject, UpdateAcademyConversionProjectRequest updateRequest)
        {
            var updatedIfdPipeline = AcademyConversionProjectFactory.Update(ifdPipeline, updateRequest);
            var updatedAcademyConversionProject = AcademyConversionProjectFactory.Update(academyConversionProject ?? new AcademyConversionProject(), updateRequest);
            return AcademyConversionProjectResponseFactory.Create(updatedIfdPipeline, trust, updatedAcademyConversionProject);
        }

        private Trust CreateTrust(IfdPipeline ifdPipeline)
        {
            ifdPipeline.TrustSponsorManagementTrust = ifdPipeline.TrustSponsorManagementTrust.Substring(0, 7);
            return new Trust
            {
                Rid = _fixture.Create<string>().Substring(0, 11),
                TrustRef = ifdPipeline.TrustSponsorManagementTrust,
                TrustsTrustName = _fixture.Create<string>(),
                LeadSponsor = _fixture.Create<string>().Substring(0, 7),
                TrustsLeadSponsorName = _fixture.Create<string>(),
            };
        }

        public void Dispose()
        {
            foreach (var entity in _legacyDbContext.IfdPipeline)
            {
                _legacyDbContext.IfdPipeline.Remove(entity);
            }
            _legacyDbContext.SaveChanges();

            foreach (var entity in _dbContext.AcademyConversionProjects)
            {
                _dbContext.AcademyConversionProjects.Remove(entity);
            }
            _dbContext.SaveChanges();
        }
    }
}

﻿using AutoFixture;
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
            var academyConversionProjects = _fixture.Build<AcademyConversionProject>()
                .Without(x => x.Id)
                .CreateMany();
            _dbContext.AcademyConversionProjects.AddRange(academyConversionProjects);
            _dbContext.SaveChanges();
            var expected = academyConversionProjects.Select(p => AcademyConversionProjectResponseFactory.Create(p)).ToList();

            var response = await _client.GetAsync("/conversion-projects");
            var content = await response.Content.ReadFromJsonAsync<IEnumerable<AcademyConversionProjectResponse>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Get_request_should_get_an_academy_conversion_project_by_id()
        {
            var academyConversionProject = _fixture.Build<AcademyConversionProject>()
                .Without(x => x.Id)
                .Create();
            var trust = CreateTrust(academyConversionProject);

            _dbContext.AcademyConversionProjects.Add(academyConversionProject);
            _dbContext.SaveChanges();
            _legacyDbContext.Trust.Add(trust);
            _legacyDbContext.SaveChanges();

            var expected = AcademyConversionProjectResponseFactory.Create(academyConversionProject, trust);

            var response = await _client.GetAsync($"/conversion-projects/{academyConversionProject.Id}");
            var content = await response.Content.ReadFromJsonAsync<AcademyConversionProjectResponse>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Get_request_should_be_a_not_found_response_when_id_does_not_match()
        {
            var academyConversionProject = _fixture.Build<AcademyConversionProject>()
                .Without(x => x.Id)
                .Create();

            var response = await _client.GetAsync($"/conversion-projects/{academyConversionProject.Id}");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Patch_request_should_update_an_academy_conversion_project_when_project_entity_already_exists_in_db()
        {
            var academyConversionProject = _fixture.Build<AcademyConversionProject>()
                .Without(x => x.Id)
                .Create();
            var trust = CreateTrust(academyConversionProject);

            _dbContext.AcademyConversionProjects.Add(academyConversionProject);
            _dbContext.SaveChanges();
            _legacyDbContext.Trust.Add(trust);
            _legacyDbContext.SaveChanges();

            var updateRequest = _fixture.Create<UpdateAcademyConversionProjectRequest>();

            var expected = CreateExpectedApiResponse(trust, academyConversionProject, updateRequest);

            var response = await _client.PatchAsync($"/conversion-projects/{academyConversionProject.Id}", JsonContent.Create(updateRequest));
            var content = await response.Content.ReadFromJsonAsync<AcademyConversionProjectResponse>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().BeEquivalentTo(expected);

            _dbContext.Entry(academyConversionProject).Reload();

            AssertDatabaseUpdated(academyConversionProject, updateRequest);
        }

        [Fact]
        public async Task Patch_request_should_be_a_not_found_response_when_id_does_not_match_project()
        {
            var updateRequest = _fixture.Create<UpdateAcademyConversionProjectRequest>();

            var response = await _client.PatchAsync($"/conversion-projects/{_fixture.Create<int>()}", JsonContent.Create(updateRequest));
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        private void AssertDatabaseUpdated(AcademyConversionProject academyConversionProject, UpdateAcademyConversionProjectRequest updateRequest)
        {
            academyConversionProject.RationaleForProject.Should().Be(updateRequest.RationaleForProject);
            academyConversionProject.RationaleForTrust.Should().Be(updateRequest.RationaleForTrust);
            academyConversionProject.RationaleSectionComplete.Should().Be(updateRequest.RationaleSectionComplete);
            academyConversionProject.LocalAuthorityInformationTemplateSentDate.Should().Be(updateRequest.LocalAuthorityInformationTemplateSentDate);
            academyConversionProject.LocalAuthorityInformationTemplateReturnedDate.Should().Be(updateRequest.LocalAuthorityInformationTemplateReturnedDate);
            academyConversionProject.LocalAuthorityInformationTemplateComments.Should().Be(updateRequest.LocalAuthorityInformationTemplateComments);
            academyConversionProject.LocalAuthorityInformationTemplateLink.Should().Be(updateRequest.LocalAuthorityInformationTemplateLink);
            academyConversionProject.LocalAuthorityInformationTemplateSectionComplete.Should().Be(updateRequest.LocalAuthorityInformationTemplateSectionComplete);
            academyConversionProject.PublishedAdmissionNumber.Should().Be(updateRequest.PublishedAdmissionNumber);
            academyConversionProject.ViabilityIssues.Should().Be(updateRequest.ViabilityIssues);
            academyConversionProject.FinancialDeficit.Should().Be(updateRequest.FinancialDeficit);
            academyConversionProject.DistanceFromSchoolToTrustHeadquarters.Should().Be(updateRequest.DistanceFromSchoolToTrustHeadquarters);
            academyConversionProject.DistanceFromSchoolToTrustHeadquartersAdditionalInformation.Should().Be(updateRequest.DistanceFromSchoolToTrustHeadquartersAdditionalInformation);
            academyConversionProject.GeneralInformationSectionComplete.Should().Be(updateRequest.GeneralInformationSectionComplete);
            academyConversionProject.RisksAndIssues.Should().Be(updateRequest.RisksAndIssues);
            academyConversionProject.RisksAndIssuesSectionComplete.Should().Be(updateRequest.RisksAndIssuesSectionComplete);
            academyConversionProject.SchoolPerformanceAdditionalInformation.Should().Be(updateRequest.SchoolPerformanceAdditionalInformation);
            academyConversionProject.RevenueCarryForwardAtEndMarchCurrentYear.Should().Be(updateRequest.RevenueCarryForwardAtEndMarchCurrentYear);
            academyConversionProject.ProjectedRevenueBalanceAtEndMarchNextYear.Should().Be(updateRequest.ProjectedRevenueBalanceAtEndMarchNextYear);
            academyConversionProject.CapitalCarryForwardAtEndMarchCurrentYear = updateRequest.CapitalCarryForwardAtEndMarchCurrentYear;
            academyConversionProject.CapitalCarryForwardAtEndMarchNextYear = updateRequest.CapitalCarryForwardAtEndMarchNextYear;
            academyConversionProject.SchoolBudgetInformationAdditionalInformation = updateRequest.SchoolBudgetInformationAdditionalInformation;
            academyConversionProject.SchoolBudgetInformationSectionComplete = updateRequest.SchoolBudgetInformationSectionComplete;
        }

        private AcademyConversionProjectResponse CreateExpectedApiResponse(Trust trust, AcademyConversionProject academyConversionProject, UpdateAcademyConversionProjectRequest updateRequest)
        {
            var updatedAcademyConversionProject = AcademyConversionProjectFactory.Update(academyConversionProject ?? new AcademyConversionProject(), updateRequest);
            return AcademyConversionProjectResponseFactory.Create(updatedAcademyConversionProject, trust);
        }

        private Trust CreateTrust(AcademyConversionProject academyConversionProject)
        {
            academyConversionProject.TrustReferenceNumber = academyConversionProject.TrustReferenceNumber.Substring(0, 7);
            return new Trust
            {
                Rid = _fixture.Create<string>().Substring(0, 11),
                TrustRef = academyConversionProject.TrustReferenceNumber,
                TrustsTrustName = _fixture.Create<string>(),
                LeadSponsor = _fixture.Create<string>().Substring(0, 7),
                TrustsLeadSponsorName = _fixture.Create<string>(),
            };
        }

        public void Dispose()
        {
            foreach (var entity in _legacyDbContext.Trust)
            {
                _legacyDbContext.Trust.Remove(entity);
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

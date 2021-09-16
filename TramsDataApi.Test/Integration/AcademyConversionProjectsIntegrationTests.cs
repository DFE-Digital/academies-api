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
using TramsDataApi.ResponseModels;
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

        private const string PreHtb = "Pre HTB";

        public AcademyConversionProjectsIntegrationTests(TramsDataApiFactory fixture)
        {
            _client = fixture.CreateClient();
            _client.DefaultRequestHeaders.Add("ApiKey", "testing-api-key");
            _legacyDbContext = fixture.Services.GetRequiredService<LegacyTramsDbContext>();
            _dbContext = fixture.Services.GetRequiredService<TramsDbContext>();
            _fixture = new Fixture();
            _fixture.Customizations.Add(new RandomDateGenerator(DateTime.Now.AddMonths(-24), DateTime.Now.AddMonths(6)));
        }

#region ApiV1
        [Fact]
        public async Task Get_request_should_get_all_academy_conversion_projects()
        {
            var academyConversionProjects = _fixture.Build<AcademyConversionProject>()
                .Without(x => x.Id)
                .CreateMany()
                .ToList();

            var academyConversionProjectWithoutName = _fixture.Build<AcademyConversionProject>()
                .Without(x => x.Id)
                .Without(x => x.SchoolName)
                .Create();
            
            _dbContext.AcademyConversionProjects.AddRange(academyConversionProjects);
            _dbContext.AcademyConversionProjects.Add(academyConversionProjectWithoutName);
            _dbContext.SaveChanges();
            var expected = academyConversionProjects.Select(p => AcademyConversionProjectResponseFactory.Create(p)).ToList();
            expected.ForEach(p => p.ProjectStatus = PreHtb);
            
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
            expected.ProjectStatus = PreHtb;

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
#endregion
        
#region ApiV2

        [Fact]
        public async Task Get_request_with_state_should_get_response_with_data_as_list_of_academy_conversion_projects_filtered_by_state()
        {
            var academyConversionProjects = _fixture.Build<AcademyConversionProject>()
                .Without(x => x.Id)
                .CreateMany()
                .ToList();

            var expectedProjects = new List<AcademyConversionProject>
            {
                _fixture.Build<AcademyConversionProject>().Without(x => x.Id).Create(),
                _fixture.Build<AcademyConversionProject>().Without(x => x.Id).Create()
            };
            
            expectedProjects.First().ProjectStatus = "Approved for AO";
            expectedProjects.Last().ProjectStatus = "Converter Pre-AO";
            academyConversionProjects.AddRange(expectedProjects);

            _dbContext.AcademyConversionProjects.AddRange(academyConversionProjects);
            _dbContext.SaveChanges();
            _legacyDbContext.SaveChanges();

            var expectedData = expectedProjects.Select(p => AcademyConversionProjectResponseFactory.Create(p));
            var expected = new ApiResponseV2<AcademyConversionProjectResponse>(expectedData);
            var states = new []{"Approved for AO", "Converter Pre-AO"};
            
            var response = await _client.GetAsync($"v2/conversion-projects/?states={string.Join(",", states)}");
            var content = await response.Content.ReadFromJsonAsync<ApiResponseV2<AcademyConversionProjectResponse>>();
 
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async void Get_request_should_return_response_with_data_having_ukPrn_and_Laestab_set()
        {
            var urns = new List<int> {1, 2};
            var projects = urns
                .Select(u => _fixture.Build<AcademyConversionProject>().Without(f => f.Id).With(f => f.Urn, u).Create())
                .ToList();
            var establishments = urns
                .Select(u => _fixture.Build<Establishment>().With(e => e.Urn, u).With(e => e.Ukprn, $"est{u}").Create())
                .ToList();
            var misEstablishments = urns
                .Select(u => _fixture.Build<MisEstablishments>().With(m => m.Urn, u).With(m => m.Laestab, 1000 + u).Create())
                .ToList();

            var expectedData = projects.Select(p =>
            {
                var response = AcademyConversionProjectResponseFactory.Create(p);
                response.UkPrn = $"est{p.Urn}";
                response.Laestab = 1000 + p.Urn ?? 0;
                return response;
            });

            var expected = new ApiResponseV2<AcademyConversionProjectResponse>(expectedData);

            _dbContext.AcademyConversionProjects.AddRange(projects);
            _legacyDbContext.Establishment.AddRange(establishments);
            _legacyDbContext.MisEstablishments.AddRange(misEstablishments);
            
            _dbContext.SaveChanges();
            _legacyDbContext.SaveChanges();
            
            var response = await _client.GetAsync("v2/conversion-projects/");
            var content = await response.Content.ReadFromJsonAsync<ApiResponseV2<AcademyConversionProjectResponse>>();
 
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async void Get_request_without_state_should_return_response_with_data_containing_all_records()
        {
            var academyConversionProjects = _fixture.Build<AcademyConversionProject>()
                .Without(x => x.Id)
                .CreateMany()
                .ToList();

            var academyConversionProjectWithoutName = _fixture.Build<AcademyConversionProject>()
                .Without(x => x.Id)
                .Without(x => x.SchoolName)
                .Create();
            
            _dbContext.AcademyConversionProjects.AddRange(academyConversionProjects);
            _dbContext.AcademyConversionProjects.Add(academyConversionProjectWithoutName);
            _dbContext.SaveChanges();
            
            var expectedData = academyConversionProjects.Select(p => AcademyConversionProjectResponseFactory.Create(p)).ToList();
            var expected = new ApiResponseV2<AcademyConversionProjectResponse>(expectedData);
            
            var response = await _client.GetAsync("v2/conversion-projects/");
            var content = await response.Content.ReadFromJsonAsync<ApiResponseV2<AcademyConversionProjectResponse>>();
 
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Get_request_with_states_not_in_db_should_get_response_with_data_as_empty_list()
        {
            var academyConversionProjects = _fixture.Build<AcademyConversionProject>()
                .Without(f => f.Id)
                .CreateMany()
                .ToList();
            
            _dbContext.AcademyConversionProjects.AddRange(academyConversionProjects);
            _dbContext.SaveChanges();

            var expected = new ApiResponseV2<AcademyConversionProjectResponse>();
            var states = new []{"Approved for AO", "Converter Pre-AO"};
            
            var response = await _client.GetAsync($"v2/conversion-projects/?states={string.Join(",", states)}");
            var content = await response.Content.ReadFromJsonAsync<ApiResponseV2<AcademyConversionProjectResponse>>();
 
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public async Task Get_request_without_states_and_no_projects_in_db_should_get_response_with_data_as_empty_list()
        {
            
            var expected = new ApiResponseV2<AcademyConversionProjectResponse>();
            var states = new []{"Approved for AO", "Converter Pre-AO"};
            
            var response = await _client.GetAsync($"v2/conversion-projects/?states={string.Join(",", states)}");
            var content = await response.Content.ReadFromJsonAsync<ApiResponseV2<AcademyConversionProjectResponse>>();
 
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public async void Get_request_should_return_response_with_data_having_Upin_and_NewAcademyUrn_set()
        {
            var urns = new List<int> {1, 2};
            var projects = urns
                .Select(u => _fixture.Build<AcademyConversionProject>().Without(f => f.Id)
                    .With(f => f.Urn, u)
                    .With(f => f.IfdPipelineId, u).Create())
                .ToList();

            var ifdPipelineProjects1 = _fixture.Build<IfdPipeline>()
                .With(i => i.Sk, 1)
                .With(i => i.EfaFundingUpin, "1234")
                .With(i => i.ProposedAcademyDetailsNewAcademyUrn, "100003")
                .With(i => i.GeneralDetailsProjectStatus, "Approved for AO").Create();
            var ifdPipelineProjects2 = _fixture.Build<IfdPipeline>()
                .With(i => i.Sk, 2)
                .With(i => i.EfaFundingUpin, "4567")
                .With(i => i.ProposedAcademyDetailsNewAcademyUrn, "100089")
                .With(i => i.GeneralDetailsProjectStatus, "Converter Pre-AO").Create();
            var ifdPipelineProjects = new List<IfdPipeline> {ifdPipelineProjects1, ifdPipelineProjects2};


            var expectedData = projects.Select(p =>
            {
                var ifdProject = ifdPipelineProjects.FirstOrDefault(i => i.Sk == p.IfdPipelineId);
                var response = AcademyConversionProjectResponseFactory.Create(AcademyConversionJoinModelFactory.Create(p, ifdProject));
                response.Upin = ifdProject.EfaFundingUpin;
                response.NewAcademyUrn = ifdProject.ProposedAcademyDetailsNewAcademyUrn;
                return response;
            });

            var expected = new ApiResponseV2<AcademyConversionProjectResponse>(expectedData);

            _dbContext.AcademyConversionProjects.AddRange(projects);
            _legacyDbContext.IfdPipeline.AddRange(ifdPipelineProjects);

            _dbContext.SaveChanges();
            _legacyDbContext.SaveChanges();
            
            var states = new []{"Approved for AO", "Converter Pre-AO"};
            
            var response = await _client.GetAsync($"v2/conversion-projects/?states={string.Join(",", states)}");
            var content = await response.Content.ReadFromJsonAsync<ApiResponseV2<AcademyConversionProjectResponse>>();
 
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().BeEquivalentTo(expected);
        }
        
#endregion

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
            academyConversionProject.CapitalCarryForwardAtEndMarchCurrentYear.Should().Be(updateRequest.CapitalCarryForwardAtEndMarchCurrentYear);
            academyConversionProject.CapitalCarryForwardAtEndMarchNextYear.Should().Be(updateRequest.CapitalCarryForwardAtEndMarchNextYear);
            academyConversionProject.SchoolBudgetInformationAdditionalInformation.Should().Be(updateRequest.SchoolBudgetInformationAdditionalInformation);
            academyConversionProject.SchoolBudgetInformationSectionComplete.Should().Be(updateRequest.SchoolBudgetInformationSectionComplete);
            academyConversionProject.SchoolPupilForecastsAdditionalInformation.Should().Be(updateRequest.SchoolPupilForecastsAdditionalInformation);
            academyConversionProject.KeyStage2PerformanceAdditionalInformation.Should().Be(updateRequest.KeyStage2PerformanceAdditionalInformation);
            academyConversionProject.KeyStage4PerformanceAdditionalInformation.Should().Be(updateRequest.KeyStage4PerformanceAdditionalInformation);
            academyConversionProject.KeyStage5PerformanceAdditionalInformation.Should().Be(updateRequest.KeyStage5PerformanceAdditionalInformation);
            academyConversionProject.RecommendationForProject.Should().Be(updateRequest.RecommendationForProject);
            academyConversionProject.Author.Should().Be(updateRequest.Author);
            academyConversionProject.ClearedBy.Should().Be(updateRequest.ClearedBy);
            academyConversionProject.HeadTeacherBoardDate.Should().Be(updateRequest.HeadTeacherBoardDate);
            academyConversionProject.PreviousHeadTeacherBoardDateQuestion.Should().Be(updateRequest.PreviousHeadTeacherBoardDateQuestion);
            academyConversionProject.PreviousHeadTeacherBoardDate.Should().Be(updateRequest.PreviousHeadTeacherBoardDate);
            academyConversionProject.ProposedAcademyOpeningDate.Should().Be(updateRequest.ProposedAcademyOpeningDate);
            academyConversionProject.SchoolAndTrustInformationSectionComplete.Should().Be(updateRequest.SchoolAndTrustInformationSectionComplete);
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
            _legacyDbContext.Trust.RemoveRange(_legacyDbContext.Trust);
            _legacyDbContext.IfdPipeline.RemoveRange(_legacyDbContext.IfdPipeline);
            _legacyDbContext.Establishment.RemoveRange(_legacyDbContext.Establishment);
            _legacyDbContext.MisEstablishments.RemoveRange(_legacyDbContext.MisEstablishments);
            _dbContext.AcademyConversionProjects.RemoveRange(_dbContext.AcademyConversionProjects);

            _legacyDbContext.SaveChanges();
            _dbContext.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;
using TramsDataApi.Test.Utils;
using Xunit;

namespace TramsDataApi.Test.Integration
{
    [Collection("Database")]

    public class AcademyConversionProjectNotesIntegrationTests : IClassFixture<TramsDataApiFactory>, IDisposable
    {
        private readonly HttpClient _client;
        private readonly TramsDbContext _dbContext;
        private readonly Fixture _fixture;

        public AcademyConversionProjectNotesIntegrationTests(TramsDataApiFactory fixture)
        {
            _client = fixture.CreateClient();
            _client.DefaultRequestHeaders.Add("ApiKey", "testing-api-key");
            _dbContext = fixture.Services.GetRequiredService<TramsDbContext>();
            _fixture = new Fixture();
            _fixture.Customizations.Add(new RandomDateGenerator(DateTime.Now.AddMonths(-24), DateTime.Now.AddMonths(6)));
        }

        [Fact]
        public async Task Get_request_should_get_academy_conversion_project_notes_by_id()
        {
            var academyConversionProject = _fixture.Build<AcademyConversionProject>()
                .Without(p => p.Id)
                .Create();

            var secondAcademyConversionProject = _fixture.Build<AcademyConversionProject>()
                .Without(p => p.Id)
                .Create();

            _dbContext.AcademyConversionProjects.Add(academyConversionProject);
            _dbContext.AcademyConversionProjects.Add(secondAcademyConversionProject);
            _dbContext.SaveChanges();
            _dbContext.Entry(academyConversionProject).Reload();
            _dbContext.Entry(secondAcademyConversionProject).Reload();

            var projectNotes = _fixture.Build<AcademyConversionProjectNote>()
                .Without(pn => pn.Id)
                .With(pn => pn.AcademyConversionProject, academyConversionProject)
                .CreateMany(10)
                .ToList();

            var projectNotesForDifferentProject = _fixture.Build<AcademyConversionProjectNote>()
                .Without(pn => pn.Id)
                .With(pn => pn.AcademyConversionProject, secondAcademyConversionProject)
                .CreateMany(10)
                .ToList();

            _dbContext.AcademyConversionProjectNotes.AddRange(projectNotes);
            _dbContext.AcademyConversionProjectNotes.AddRange(projectNotesForDifferentProject);
            _dbContext.SaveChanges();

            var expected = projectNotes.Select(pn => new AcademyConversionProjectNoteResponse
            {
                Subject = pn.Subject,
                Note = pn.Note,
                Author = pn.Author,
                Date = pn.Date
            });

            var response = await _client.GetAsync($"/project-notes/{academyConversionProject.Id}");
            var content = await response.Content.ReadFromJsonAsync<IEnumerable<AcademyConversionProjectNoteResponse>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Get_request_should_return_empty_list_when_no_matching_project_notes()
        {
            var academyConversionProject = _fixture.Build<AcademyConversionProject>()
                .Without(p => p.Id)
                .Create();

            _dbContext.AcademyConversionProjects.Add(academyConversionProject);
            _dbContext.SaveChanges();
            _dbContext.Entry(academyConversionProject).Reload();

            var projectNotes = _fixture.Build<AcademyConversionProjectNote>()
                .Without(pn => pn.Id)
                .With(pn => pn.AcademyConversionProject, academyConversionProject)
                .CreateMany(10)
                .ToList();

            _dbContext.AcademyConversionProjectNotes.AddRange(projectNotes);
            _dbContext.SaveChanges();

            var response = await _client.GetAsync($"/project-notes/{_fixture.Create<int>()}");
            var content = await response.Content.ReadFromJsonAsync<IEnumerable<AcademyConversionProjectNoteResponse>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().BeEquivalentTo(new List<AcademyConversionProjectNoteResponse>());
        }

        [Fact]
        public async Task Post_request_should_add_project_note_to_database_and_respond_with_added_note()
        {
            var academyConversionProject = _fixture.Build<AcademyConversionProject>()
                .Without(p => p.Id)
                .Create();

            var secondAcademyConversionProject = _fixture.Build<AcademyConversionProject>()
                .Without(p => p.Id)
                .Create();

            _dbContext.AcademyConversionProjects.Add(academyConversionProject);
            _dbContext.AcademyConversionProjects.Add(secondAcademyConversionProject);
            _dbContext.SaveChanges();
            _dbContext.Entry(academyConversionProject).Reload();
            _dbContext.Entry(secondAcademyConversionProject).Reload();

            var addProjectNoteRequest = _fixture.Create<AddAcademyConversionProjectNoteRequest>();
            var response = await _client.PostAsync($"/project-notes/{academyConversionProject.Id}", JsonContent.Create(addProjectNoteRequest));
            var content = await response.Content.ReadFromJsonAsync<AcademyConversionProjectNoteResponse>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().BeEquivalentTo(new AcademyConversionProjectNoteResponse
            {
                Subject = addProjectNoteRequest.Subject,
                Note = addProjectNoteRequest.Note,
                Author = addProjectNoteRequest.Author,
            }, config => config.Excluding(pn => pn.SelectedMemberPath.Contains("Date")));

            var projectNoteInDb = _dbContext.AcademyConversionProjectNotes.Single(pn => pn.AcademyConversionProjectId == academyConversionProject.Id);
            projectNoteInDb.Subject.Should().Be(addProjectNoteRequest.Subject);
            projectNoteInDb.Note.Should().Be(addProjectNoteRequest.Note);
            projectNoteInDb.Author.Should().Be(addProjectNoteRequest.Author);
            projectNoteInDb.Date.Should().BeCloseTo(DateTime.Now, 1000);
        }

        [Fact]
        public async Task Post_request_should_respond_with_bad_request_when_project_id_not_found()
        {
            var requestId = _fixture.Create<int>();
            var addProjectNoteRequest = _fixture.Create<AddAcademyConversionProjectNoteRequest>();
            var response = await _client.PostAsync($"/project-notes/{requestId}", JsonContent.Create(addProjectNoteRequest));

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var projectNotesInDb = _dbContext.AcademyConversionProjectNotes
                .Where(pn => pn.AcademyConversionProjectId == requestId).ToList();
            projectNotesInDb.Count.Should().Be(0);
        }

        public void Dispose()
        {
            foreach (var entity in _dbContext.AcademyConversionProjects)
            {
                _dbContext.AcademyConversionProjects.Remove(entity);
            }
            _dbContext.SaveChanges();

            foreach (var entity in _dbContext.AcademyConversionProjectNotes)
            {
                _dbContext.AcademyConversionProjectNotes.Remove(entity);
            }
            _dbContext.SaveChanges();
        }
    }
}

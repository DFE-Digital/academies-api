using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
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
using TramsDataApi.ResponseModels.AcademyConversionProject;
using TramsDataApi.Test.Utils;
using Xunit;

namespace TramsDataApi.Test.Integration
{
    [Collection("Database")]
    public class AcademyConversionProjectsIntegrationTests : IClassFixture<TramsDataApiFactory>, IDisposable
    {
        private readonly HttpClient _client;
        private readonly TramsDbContext _dbContext;
        private readonly Fixture _fixture;

        public AcademyConversionProjectsIntegrationTests(TramsDataApiFactory fixture)
        {
            _client = fixture.CreateClient();
            _client.DefaultRequestHeaders.Add("ApiKey", "testing-api-key");
            _dbContext = fixture.Services.GetRequiredService<TramsDbContext>();
            _fixture = new Fixture();
            _fixture.Customizations.Add(new RandomDateGenerator(DateTime.Now.AddMonths(-24), DateTime.Now.AddMonths(6)));
            _fixture.Customize<IfdPipeline>(c => c.Without(x => x.Sk));
        }

        [Fact]
        public async Task Should_get_all_academy_conversion_projects()
        {
            var ifdPipelines = _fixture.CreateMany<IfdPipeline>();
            _dbContext.IfdPipeline.AddRange(ifdPipelines);
            _dbContext.SaveChanges();
            var expected = ifdPipelines.Select(p => AcademyConversionProjectResponseFactory.Create(p)).ToList();

            var response = await _client.GetAsync("/conversion-projects");
            var content = await response.Content.ReadFromJsonAsync<IEnumerable<AcademyConversionProjectResponse>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Should_get_an_academy_conversion_project_by_id()
        {
            var ifdPipeline = _fixture.Create<IfdPipeline>();
            _dbContext.IfdPipeline.Add(ifdPipeline);
            _dbContext.SaveChanges();
            var expected = AcademyConversionProjectResponseFactory.Create(ifdPipeline);

            var response = await _client.GetAsync($"/conversion-projects/{ifdPipeline.Sk}");
            var content = await response.Content.ReadFromJsonAsync<AcademyConversionProjectResponse>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Should_get_a_not_found_response_when_id_does_not_match()
        {
            var ifdPipeline = _fixture.Create<IfdPipeline>();
            _dbContext.IfdPipeline.Add(ifdPipeline);
            _dbContext.SaveChanges();

            var response = await _client.GetAsync($"/conversion-projects/{ifdPipeline.Sk + 1}");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        public void Dispose()
        {
            foreach (var entity in _dbContext.IfdPipeline)
            {
                _dbContext.IfdPipeline.Remove(entity);
            }
            _dbContext.SaveChanges();
        }
    }
}

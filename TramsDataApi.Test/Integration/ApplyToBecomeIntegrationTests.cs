using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoFixture;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.ApplyToBecome;
using TramsDataApi.Test.Utils;
using Xunit;

namespace TramsDataApi.Test.Integration
{
    [Collection("Database")]
    public class ApplyToBecomeIntegrationTests: IClassFixture<TramsDataApiFactory>, IDisposable
    {
        
        private readonly HttpClient _client;
        private readonly TramsDbContext _dbContext;
        private readonly Fixture _fixture;
        private readonly RandomGenerator _randomGenerator;

        public ApplyToBecomeIntegrationTests(TramsDataApiFactory fixture)
        {
            _client = fixture.CreateClient();
            _client.DefaultRequestHeaders.Add("ApiKey", "testing-api-key");
            _dbContext = fixture.Services.GetRequiredService<TramsDbContext>();
            _fixture = new Fixture();
            _randomGenerator = new RandomGenerator();
        }

        
        
        [Fact]
        public async Task CanGetApplicationByApplicationId()
        {
            SetupA2BApplicationData();
            
            var application = _dbContext.A2BApplications.First();
            var expected = A2BApplicationResponseFactory.Create(application, null);
            var expectedResponse = new ApiSingleResponseV2<A2BApplicationResponse>(expected);
            
            var response = await _client.GetAsync($"/v2/apply-to-become/application/{application.ApplicationId}");

            response.StatusCode.Should().Be(200);
            
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BApplicationResponse>>();
            result.Should().BeEquivalentTo(expectedResponse); 
            result.Data.ApplicationId.Should().Be(expectedResponse.Data.ApplicationId);
        }
        
        private void SetupA2BApplicationData()
        {
            var applications = Builder<A2BApplication>
                .CreateListOfSize(10)
                .Build()
                .ToList();

            _dbContext.A2BApplications.AddRange(applications);
            _dbContext.SaveChanges();
        }
        
        public void Dispose()
        {
            _dbContext.A2BApplications.RemoveRange(_dbContext.A2BApplications);
            _dbContext.SaveChanges();
        }
    }
}
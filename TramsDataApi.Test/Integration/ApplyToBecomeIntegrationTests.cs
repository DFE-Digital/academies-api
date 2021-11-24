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
using FluentAssertions.Common;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.RequestModels;
using TramsDataApi.RequestModels.ApplyToBecome;
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

        [Fact]
        public async Task CanCreateApplication()
        {
            var application = Builder<A2BApplicationCreateRequest>.CreateNew().Build();
   
            var response = await _client.PostAsJsonAsync($"/v2/apply-to-become/application/", application);

            response.StatusCode.Should().Be(201);
            
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BApplicationResponse>>();

            result.Should().NotBeNull();
            result.Data.ApplicationId.Should().BeGreaterThan(0);
            
            var createdApplication =
                _dbContext.A2BApplications.FirstOrDefault(a => a.ApplicationId == result.Data.ApplicationId);

            createdApplication.Should().NotBeNull();
            
            result.Data.Should().BeEquivalentTo(createdApplication);
        }
        
        [Fact]
        public async Task CanGetApplicationKeyPersonsByKeyPersonId()
        {
            SetupA2BApplicationKeyPersonsData();
            
            var keyPerson = _dbContext.A2BApplicationKeyPersons.First();
            var expected = A2BApplicationKeyPersonsResponseFactory.Create(keyPerson);
            var expectedResponse = new ApiSingleResponseV2<A2BApplicationKeyPersonsResponse>(expected);
            
            var response = await _client.GetAsync($"/v2/apply-to-become/keyPersons/{keyPerson.KeyPersonId}");

            response.StatusCode.Should().Be(200);
            
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BApplicationKeyPersonsResponse>>();
            result.Should().BeEquivalentTo(expectedResponse); 
            result.Data.KeyPersonId.Should().Be(expectedResponse.Data.KeyPersonId);
        }

        [Fact]
        public async Task CanCreateApplicationKeyPerson()
        {
            SetupA2BApplicationKeyPersonsData();
            
            var keyPerson = Builder<A2BApplicationKeyPersonsCreateRequest>.CreateNew().Build();
   
            var response = await _client.PostAsJsonAsync($"/v2/apply-to-become/keyPersons/", keyPerson);

            response.StatusCode.Should().Be(201);
            
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BApplicationKeyPersonsResponse>>();

            result.Should().NotBeNull();
            result.Data.KeyPersonId.Should().BeGreaterThan(0);
            
            var createdKeyPerson =
                _dbContext.A2BApplicationKeyPersons.FirstOrDefault(a => a.KeyPersonId == result.Data.KeyPersonId);

            createdKeyPerson.Should().NotBeNull();
            
            result.Data.Should().BeEquivalentTo(createdKeyPerson);
        }
        
        private void SetupA2BApplicationData()
        {
            var applications = Enumerable.Range(1, 10).Select(a => new A2BApplication
            {
                Name = _randomGenerator.NextString(3,10),
                ApplicationType = _randomGenerator.NextString(3,10),
                TrustId = _randomGenerator.NextString(3,10),
                FormTrustProposedNameOfTrust = _randomGenerator.NextString(3,10),
                ApplicationSubmitted = _randomGenerator.Boolean(),
                ApplicationLeadAuthorId = _randomGenerator.NextString(3,10),
                ApplicationVersion = _randomGenerator.NextString(3,10),
                ApplicationLeadAuthorName = _randomGenerator.NextString(3,10),
                ApplicationRole = _randomGenerator.NextString(3,10),
                ApplicationRoleOtherDescription = _randomGenerator.NextString(3,10),
                ChangesToTrust = _randomGenerator.Int(),
                ChangesToTrustExplained = _randomGenerator.NextString(3,10),
                FormTrustOpeningDate = _randomGenerator.DateTime(),
                TrustApproverName = _randomGenerator.NextString(3,10),
                TrustApproverEmail = _randomGenerator.NextString(3,10),
                FormTrustReasonApprovalToConvertAsSat = _randomGenerator.Int(),
                FormTrustReasonApprovedPerson = _randomGenerator.NextString(3,10),
                FormTrustReasonForming = _randomGenerator.NextString(3,10),
                FormTrustReasonVision = _randomGenerator.NextString(3,10),
                FormTrustReasonGeoAreas = _randomGenerator.NextString(3,10),
                FormTrustReasonFreedom = _randomGenerator.NextString(3,10),
                FormTrustReasonImproveTeaching = _randomGenerator.NextString(3,10),
                FormTrustPlanForGrowth = _randomGenerator.NextString(3,10),
                FormTrustPlansForNoGrowth = _randomGenerator.NextString(3,10),
                FormTrustGrowthPlansYesNo = _randomGenerator.Int(),
                FormTrustImprovementSupport = _randomGenerator.NextString(3,10),
                FormTrustImprovementStrategy = _randomGenerator.NextString(3,10),
                FormTrustImprovementApprovedSponsor = _randomGenerator.NextString(3,10),
            });

            _dbContext.A2BApplications.AddRange(applications);
            _dbContext.SaveChanges();
        }


        private void SetupA2BApplicationKeyPersonsData()
        {
            var keyPersons = Enumerable.Range(1, 10).Select(k => new A2BApplicationKeyPersons
            {
                Name = _randomGenerator.NextString(3, 10),
                KeyPersonDateOfBirth = _randomGenerator.NextString(3, 10),
                KeyPersonBiography = _randomGenerator.NextString(3, 10),
                KeyPersonCeoExecutive = _randomGenerator.NextString(3, 10),
                KeyPersonChairOfTrust = _randomGenerator.NextString(3, 10),
                KeyPersonFinancialDirector = _randomGenerator.NextString(3, 10),
                KeyPersonFinancialDirectorTime = _randomGenerator.NextString(3, 10),
                KeyPersonMember = _randomGenerator.NextString(3, 10),
                KeyPersonOther = _randomGenerator.NextString(3, 10),
                KeyPersonTrustee = _randomGenerator.NextString(3, 10)
            });
            
            _dbContext.A2BApplicationKeyPersons.AddRange(keyPersons);
            _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext.A2BApplications.RemoveRange(_dbContext.A2BApplications);
            _dbContext.A2BApplicationKeyPersons.RemoveRange(_dbContext.A2BApplicationKeyPersons);
            _dbContext.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels;
using Xunit;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Test.Integration
{
    [Collection("Database")]
    public class AcademyTransferProjectIntegrationTests : IClassFixture<TramsDataApiFactory>
    {
        private readonly HttpClient _client;
        private readonly LegacyTramsDbContext _legacyTramsDbContext;
        private readonly TramsDbContext _tramsDbContext;
        
        public AcademyTransferProjectIntegrationTests(TramsDataApiFactory fixture){
            _client = fixture.CreateClient();
            _client.BaseAddress = new Uri("https://trams-api.com/");
            _legacyTramsDbContext = fixture.Services.GetRequiredService<LegacyTramsDbContext>();
            _tramsDbContext = fixture.Services.GetRequiredService<TramsDbContext>();
        }

        [Fact]
        public async Task CanCreateAnInitialAcademyTransferProject()
        {
            var randomGenerator = new RandomGenerator();
            
            var createRequest = Builder<AcademyTransferProjectRequest>.CreateNew()
                .With(c => c.OutgoingTrustUkprn = randomGenerator.NextString(8,8))
                .With(c => c.Benefits = null)
                .With(c => c.Dates = null)
                .With(c => c.Rationale = null)
                .With(c => c.Features = null)
                .With(c => c.TransferringAcademies = (List<TransferringAcademiesRequest>) Builder<TransferringAcademiesRequest>
                    .CreateListOfSize(5).All()
                    .With(ta => ta.OutgoingAcademyUkprn = randomGenerator.NextString(8,8))
                    .With(ta => ta.IncomingTrustUkprn = null).Build())
                .Build();
            
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://trams-api.com/academyTransferProject"),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                },
                Content =  JsonContent.Create(createRequest)
            };
            
            var response = await _client.SendAsync(httpRequestMessage);
            response.StatusCode.Should().Be(201);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AcademyTransferProjectResponse>(jsonString);

            var createdProject = _tramsDbContext.AcademyTransferProjects.FirstOrDefault(atp => atp.Urn.ToString() == result.ProjectUrn);
            createdProject.Should().NotBe(null);
            createdProject.OutgoingTrustUkprn.Should().BeEquivalentTo(createRequest.OutgoingTrustUkprn);
            
            _tramsDbContext.TransferringAcademies.RemoveRange(_tramsDbContext.TransferringAcademies);
            _tramsDbContext.AcademyTransferProjects.RemoveRange(_tramsDbContext.AcademyTransferProjects);
            _tramsDbContext.SaveChanges();
        }

        [Fact]
        public async Task CanCreateAFullAcademyTransferProject()
        {
            var randomGenerator = new RandomGenerator();
            
            var benefitsRequest = Builder<AcademyTransferProjectBenefitsRequest>.CreateNew()
                .With(b => b.IntendedTransferBenefits = Builder<IntendedTransferBenefitRequest>.CreateNew()
                    .With(i => i.SelectedBenefits =  new List<string>()).Build())
                .With(b => b.OtherFactorsToConsider = Builder<OtherFactorsToConsiderRequest>.CreateNew()
                    .With(o => o.ComplexLandAndBuilding = Builder<BenefitConsideredFactorRequest>.CreateNew().Build())
                    .With(o => o.FinanceAndDebt = Builder<BenefitConsideredFactorRequest>.CreateNew().Build())
                    .With(o => o.HighProfile = Builder<BenefitConsideredFactorRequest>.CreateNew().Build()).Build())
                .Build();
            
            var datesRequest = Builder<AcademyTransferProjectDatesRequest>.CreateNew()
                .With(d => d.TransferFirstDiscussed =
                    randomGenerator.DateTime().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
                .With(d => d.TargetDateForTransfer =
                    randomGenerator.DateTime().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
                .With(d => d.HtbDate = randomGenerator.DateTime().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
                .Build();
            
            var createRequest = Builder<AcademyTransferProjectRequest>.CreateNew()
                .With(c => c.OutgoingTrustUkprn = randomGenerator.NextString(8,8))
                .With(c => c.Benefits = benefitsRequest)
                .With(c => c.Dates = datesRequest)
                .With(c => c.Rationale = Builder<AcademyTransferProjectRationaleRequest>.CreateNew().Build())
                .With(c => c.Features = Builder<AcademyTransferProjectFeaturesRequest>.CreateNew().Build())
                .With(c => c.TransferringAcademies = (List<TransferringAcademiesRequest>) Builder<TransferringAcademiesRequest>
                    .CreateListOfSize(5).All()
                    .With(ta => ta.IncomingTrustUkprn = randomGenerator.NextString(8,8))
                    .With(ta => ta.OutgoingAcademyUkprn = randomGenerator.NextString(8,8)).Build())
                .Build();
            
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://trams-api.com/academyTransferProject"),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                },
                Content =  JsonContent.Create(createRequest)
            };
            
            var response = await _client.SendAsync(httpRequestMessage);
            response.StatusCode.Should().Be(201);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AcademyTransferProjectResponse>(jsonString);

            var createdProject = _tramsDbContext.AcademyTransferProjects.FirstOrDefault(atp => atp.Urn.ToString() == result.ProjectUrn);
            createdProject.Should().NotBe(null);
            createdProject.OutgoingTrustUkprn.Should().BeEquivalentTo(createRequest.OutgoingTrustUkprn);
            
            _tramsDbContext.TransferringAcademies.RemoveRange(_tramsDbContext.TransferringAcademies);
            _tramsDbContext.AcademyTransferProjects.RemoveRange(_tramsDbContext.AcademyTransferProjects);
            _tramsDbContext.SaveChanges();
        }

        [Fact]
        public async Task CanUpdateAnAcademyTransferProject()
        {
            var randomGenerator = new RandomGenerator();
            
            var benefitsRequest = Builder<AcademyTransferProjectBenefitsRequest>.CreateNew()
                .With(b => b.IntendedTransferBenefits = Builder<IntendedTransferBenefitRequest>.CreateNew()
                    .With(i => i.SelectedBenefits =  new List<string>()).Build())
                .With(b => b.OtherFactorsToConsider = Builder<OtherFactorsToConsiderRequest>.CreateNew()
                    .With(o => o.ComplexLandAndBuilding = Builder<BenefitConsideredFactorRequest>.CreateNew().Build())
                    .With(o => o.FinanceAndDebt = Builder<BenefitConsideredFactorRequest>.CreateNew().Build())
                    .With(o => o.HighProfile = Builder<BenefitConsideredFactorRequest>.CreateNew().Build()).Build())
                .Build();
            
            var datesRequest = Builder<AcademyTransferProjectDatesRequest>.CreateNew()
                .With(d => d.TransferFirstDiscussed =
                    randomGenerator.DateTime().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
                .With(d => d.TargetDateForTransfer =
                    randomGenerator.DateTime().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
                .With(d => d.HtbDate = randomGenerator.DateTime().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
                .Build();
            
            var createRequest = Builder<AcademyTransferProjectRequest>.CreateNew()
                .With(c => c.OutgoingTrustUkprn = randomGenerator.NextString(8,8))
                .With(c => c.Benefits = benefitsRequest)
                .With(c => c.Dates = datesRequest)
                .With(c => c.Rationale = Builder<AcademyTransferProjectRationaleRequest>.CreateNew().Build())
                .With(c => c.Features = Builder<AcademyTransferProjectFeaturesRequest>.CreateNew().Build())
                .With(c => c.TransferringAcademies = (List<TransferringAcademiesRequest>) Builder<TransferringAcademiesRequest>
                    .CreateListOfSize(5).All()
                    .With(ta => ta.IncomingTrustUkprn = randomGenerator.NextString(8,8))
                    .With(ta => ta.OutgoingAcademyUkprn = randomGenerator.NextString(8,8)).Build())
                .Build();
            
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://trams-api.com/academyTransferProject"),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                },
                Content =  JsonContent.Create(createRequest)
            };
            
            var response = await _client.SendAsync(httpRequestMessage);
            response.StatusCode.Should().Be(201);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AcademyTransferProjectResponse>(jsonString);

            createRequest.OutgoingTrustUkprn = "14567231";

            var updateRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Patch,
                RequestUri = new Uri($"https://trams-api.com/academyTransferProject/{result.ProjectUrn}"),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                },
                Content =  JsonContent.Create(createRequest)
            };

            var updateResponse = await _client.SendAsync(updateRequestMessage);
            updateResponse.StatusCode.Should().Be(200);
            var updateJson = await updateResponse.Content.ReadAsStringAsync();
            var updatedProjectResponse = JsonConvert.DeserializeObject<AcademyTransferProjectResponse>(updateJson);

            var updatedProject = _tramsDbContext.AcademyTransferProjects.FirstOrDefault(atp => atp.Urn.ToString() == updatedProjectResponse.ProjectUrn);
            updatedProject.OutgoingTrustUkprn.Should().Be(createRequest.OutgoingTrustUkprn);
            
            _tramsDbContext.TransferringAcademies.RemoveRange(_tramsDbContext.TransferringAcademies);
            _tramsDbContext.AcademyTransferProjects.RemoveRange(_tramsDbContext.AcademyTransferProjects);
            _tramsDbContext.SaveChanges();
        }
        
        [Fact]
        public async Task CanUpdateTheSelectedBenefitsOfAnAcademyTransferProject()
        {
            var randomGenerator = new RandomGenerator();
            
            var benefitsRequest = Builder<AcademyTransferProjectBenefitsRequest>.CreateNew()
                .With(b => b.IntendedTransferBenefits = Builder<IntendedTransferBenefitRequest>.CreateNew()
                    .With(i => i.SelectedBenefits =  new List<string>(){"Initial benefit", "other benefit"}).Build())
                .With(b => b.OtherFactorsToConsider = Builder<OtherFactorsToConsiderRequest>.CreateNew()
                    .With(o => o.ComplexLandAndBuilding = Builder<BenefitConsideredFactorRequest>.CreateNew().Build())
                    .With(o => o.FinanceAndDebt = Builder<BenefitConsideredFactorRequest>.CreateNew().Build())
                    .With(o => o.HighProfile = Builder<BenefitConsideredFactorRequest>.CreateNew().Build()).Build())
                .Build();
            
            var datesRequest = Builder<AcademyTransferProjectDatesRequest>.CreateNew()
                .With(d => d.TransferFirstDiscussed =
                    randomGenerator.DateTime().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
                .With(d => d.TargetDateForTransfer =
                    randomGenerator.DateTime().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
                .With(d => d.HtbDate = randomGenerator.DateTime().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
                .Build();
            
            var createRequest = Builder<AcademyTransferProjectRequest>.CreateNew()
                .With(c => c.OutgoingTrustUkprn = randomGenerator.NextString(8,8))
                .With(c => c.Benefits = benefitsRequest)
                .With(c => c.Dates = datesRequest)
                .With(c => c.Rationale = Builder<AcademyTransferProjectRationaleRequest>.CreateNew().Build())
                .With(c => c.Features = Builder<AcademyTransferProjectFeaturesRequest>.CreateNew().Build())
                .With(c => c.TransferringAcademies = (List<TransferringAcademiesRequest>) Builder<TransferringAcademiesRequest>
                    .CreateListOfSize(1).All()
                    .With(ta => ta.IncomingTrustUkprn = randomGenerator.NextString(8,8))
                    .With(ta => ta.OutgoingAcademyUkprn = randomGenerator.NextString(8,8)).Build())
                .Build();

            _tramsDbContext.AcademyTransferProjectIntendedTransferBenefits.Count().Should().Be(0);
            
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://trams-api.com/academyTransferProject"),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                },
                Content =  JsonContent.Create(createRequest)
            };
            
            var response = await _client.SendAsync(httpRequestMessage);
            response.StatusCode.Should().Be(201);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AcademyTransferProjectResponse>(jsonString);

            createRequest.Benefits.IntendedTransferBenefits.SelectedBenefits = new List<string>() {"new initial benefit", "new other benefit"};

            var updateRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Patch,
                RequestUri = new Uri($"https://trams-api.com/academyTransferProject/{result.ProjectUrn}"),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                },
                Content =  JsonContent.Create(createRequest)
            };

            var updateResponse = await _client.SendAsync(updateRequestMessage);
            updateResponse.StatusCode.Should().Be(200);
            var updateJson = await updateResponse.Content.ReadAsStringAsync();
            var updatedProjectResponse = JsonConvert.DeserializeObject<AcademyTransferProjectResponse>(updateJson);

            var updatedProject = _tramsDbContext.AcademyTransferProjects
                .Include(atp => atp.AcademyTransferProjectIntendedTransferBenefits)
                .FirstOrDefault(atp => atp.Urn.ToString() == updatedProjectResponse.ProjectUrn);
            
            updatedProject?.AcademyTransferProjectIntendedTransferBenefits.Count.Should().Be(2);
            _tramsDbContext.AcademyTransferProjectIntendedTransferBenefits.Count().Should().Be(2);
            
            updatedProject?.AcademyTransferProjectIntendedTransferBenefits
                .ElementAt(0).SelectedBenefit.Should().Be("new initial benefit");
            updatedProject?.AcademyTransferProjectIntendedTransferBenefits
                .ElementAt(1).SelectedBenefit.Should().Be("new other benefit");
            
            _tramsDbContext.TransferringAcademies.RemoveRange(_tramsDbContext.TransferringAcademies);
            _tramsDbContext.AcademyTransferProjects.RemoveRange(_tramsDbContext.AcademyTransferProjects);
            _tramsDbContext.AcademyTransferProjectIntendedTransferBenefits.RemoveRange(_tramsDbContext.AcademyTransferProjectIntendedTransferBenefits);
            _tramsDbContext.SaveChanges();
        }
        
        [Fact]
        public async Task CanUpdateTheTransferringAcademiesOfAnAcademyTransferProject()
        {
            var randomGenerator = new RandomGenerator();
            
            var benefitsRequest = Builder<AcademyTransferProjectBenefitsRequest>.CreateNew()
                .With(b => b.IntendedTransferBenefits = Builder<IntendedTransferBenefitRequest>.CreateNew()
                    .With(i => i.SelectedBenefits =  new List<string>()).Build())
                .With(b => b.OtherFactorsToConsider = Builder<OtherFactorsToConsiderRequest>.CreateNew()
                    .With(o => o.ComplexLandAndBuilding = Builder<BenefitConsideredFactorRequest>.CreateNew().Build())
                    .With(o => o.FinanceAndDebt = Builder<BenefitConsideredFactorRequest>.CreateNew().Build())
                    .With(o => o.HighProfile = Builder<BenefitConsideredFactorRequest>.CreateNew().Build()).Build())
                .Build();
            
            var datesRequest = Builder<AcademyTransferProjectDatesRequest>.CreateNew()
                .With(d => d.TransferFirstDiscussed =
                    randomGenerator.DateTime().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
                .With(d => d.TargetDateForTransfer =
                    randomGenerator.DateTime().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
                .With(d => d.HtbDate = randomGenerator.DateTime().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
                .Build();
            
            var createRequest = Builder<AcademyTransferProjectRequest>.CreateNew()
                .With(c => c.OutgoingTrustUkprn = randomGenerator.NextString(8,8))
                .With(c => c.Benefits = benefitsRequest)
                .With(c => c.Dates = datesRequest)
                .With(c => c.Rationale = Builder<AcademyTransferProjectRationaleRequest>.CreateNew().Build())
                .With(c => c.Features = Builder<AcademyTransferProjectFeaturesRequest>.CreateNew().Build())
                .With(c => c.TransferringAcademies = (List<TransferringAcademiesRequest>) Builder<TransferringAcademiesRequest>
                    .CreateListOfSize(2).All()
                    .With(ta => ta.IncomingTrustUkprn = randomGenerator.NextString(8,8))
                    .With(ta => ta.OutgoingAcademyUkprn = randomGenerator.NextString(8,8)).Build())
                .Build();
            
            _tramsDbContext.TransferringAcademies.Count().Should().Be(0);
            
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://trams-api.com/academyTransferProject"),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                },
                Content =  JsonContent.Create(createRequest)
            };
            
            var response = await _client.SendAsync(httpRequestMessage);
            response.StatusCode.Should().Be(201);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AcademyTransferProjectResponse>(jsonString);

            createRequest.TransferringAcademies = new List<TransferringAcademiesRequest>()
            {
                new TransferringAcademiesRequest
                {
                    OutgoingAcademyUkprn = "12345678",
                    IncomingTrustUkprn = "12345678"
                }, 
                new TransferringAcademiesRequest
                {
                    OutgoingAcademyUkprn = "87654321",
                    IncomingTrustUkprn = "87654321"
                }
            };
            
            var updateRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Patch,
                RequestUri = new Uri($"https://trams-api.com/academyTransferProject/{result.ProjectUrn}"),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                },
                Content =  JsonContent.Create(createRequest)
            };

            var updateResponse = await _client.SendAsync(updateRequestMessage);
            updateResponse.StatusCode.Should().Be(200);
            var updateJson = await updateResponse.Content.ReadAsStringAsync();
            var updatedProjectResponse = JsonConvert.DeserializeObject<AcademyTransferProjectResponse>(updateJson);
            
            var updatedProject = _tramsDbContext.AcademyTransferProjects
                .Include(atp => atp.TransferringAcademies)
                .FirstOrDefault(atp => atp.Urn.ToString() == updatedProjectResponse.ProjectUrn);
            
            updatedProject?.TransferringAcademies.Count.Should().Be(2);
            _tramsDbContext.TransferringAcademies.Count().Should().Be(2);
            
            updatedProject?.TransferringAcademies.ElementAt(0).IncomingTrustUkprn.Should().Be("12345678");
            updatedProject?.TransferringAcademies.ElementAt(0).OutgoingAcademyUkprn.Should().Be("12345678");
            
            updatedProject?.TransferringAcademies.ElementAt(1).IncomingTrustUkprn.Should().Be("87654321");
            updatedProject?.TransferringAcademies.ElementAt(1).OutgoingAcademyUkprn.Should().Be("87654321");
            
            _tramsDbContext.TransferringAcademies.RemoveRange(_tramsDbContext.TransferringAcademies);
            _tramsDbContext.AcademyTransferProjects.RemoveRange(_tramsDbContext.AcademyTransferProjects);
            _tramsDbContext.SaveChanges();
        }
    }
}
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
using AutoFixture.Kernel;
using AutoFixture;
using TramsDataApi.Test.Utils;
using System.Text.Json.Serialization;
using TramsDataApi.Factories;

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
                .With(c => c.GeneralInformation = null)
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
                .With(c => c.GeneralInformation = Builder<AcademyTransferProjectGeneralInformationRequest>.CreateNew().Build())
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
                .With(c => c.GeneralInformation = Builder<AcademyTransferProjectGeneralInformationRequest>.CreateNew().Build())
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
                .With(c => c.GeneralInformation = Builder<AcademyTransferProjectGeneralInformationRequest>.CreateNew().Build())
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
                .With(c => c.GeneralInformation = Builder<AcademyTransferProjectGeneralInformationRequest>.CreateNew().Build())
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

        [Fact]
        public async Task CanGetTheFirstPageOfAllAcademyTransferProjects()
        {
            var randomGenerator = new RandomGenerator();
            var academyTransferProjectsToCreate = Builder<AcademyTransferProjects>
                .CreateListOfSize(20)
                .All()
                .With(atp => atp.OutgoingTrustUkprn = randomGenerator.NextString(8, 8))
                .With(atp => atp.Urn = 0)
                .With(atp => atp.Id = 0)
                .With(atp => atp.TransferringAcademies = Builder<TransferringAcademies>
                    .CreateListOfSize(3)
                    .All()
                    .With(ta => ta.Id = 0)
                    .With(ta => ta.OutgoingAcademyUkprn = randomGenerator.NextString(8, 8))
                    .With(ta => ta.IncomingTrustUkprn = randomGenerator.NextString(8, 8))
                    .With(ta => ta.FkAcademyTransferProjectId = null)
                    .Build()
                )
                .With(atp => atp.AcademyTransferProjectIntendedTransferBenefits =
                    Builder<AcademyTransferProjectIntendedTransferBenefits>
                        .CreateListOfSize(5)
                        .All()
                        .With(benefit => benefit.Id = 0)
                        .Build()
                )
                .Build().ToList();
            
            _tramsDbContext.AcademyTransferProjects.AddRange(academyTransferProjectsToCreate);
            _tramsDbContext.SaveChanges();

            var indexAcademyTransferProjectRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://trams-api.com/academyTransferProject/"),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                },
            };

            var indexResponse = await _client.SendAsync(indexAcademyTransferProjectRequest);
            indexResponse.StatusCode.Should().Be(200);
            var indexJson = await indexResponse.Content.ReadAsStringAsync();
            var indexProjectResponse =
                JsonConvert.DeserializeObject<List<AcademyTransferProjectSummaryResponse>>(indexJson);

            var expectedResponse = academyTransferProjectsToCreate.OrderBy(atp => atp.Urn).Take(10).Select(atp =>
                new AcademyTransferProjectSummaryResponse
                {
                    ProjectUrn = atp.Urn.ToString(),
                    ProjectNumber = null,
                    OutgoingTrustUkprn = atp.OutgoingTrustUkprn,
                    TransferringAcademies = atp.TransferringAcademies.Select(ta => new TransferringAcademiesResponse
                    {
                        OutgoingAcademyUkprn = ta.OutgoingAcademyUkprn,
                        IncomingTrustUkprn = ta.IncomingTrustUkprn
                    }).ToList()
                }).ToList();
            indexProjectResponse.Count().Should().Be(10);
            indexProjectResponse.Should().BeEquivalentTo(expectedResponse);
            
            _tramsDbContext.TransferringAcademies.RemoveRange(_tramsDbContext.TransferringAcademies);
            _tramsDbContext.AcademyTransferProjectIntendedTransferBenefits
                .RemoveRange(_tramsDbContext.AcademyTransferProjectIntendedTransferBenefits);
            _tramsDbContext.AcademyTransferProjects.RemoveRange(_tramsDbContext.AcademyTransferProjects);
            _tramsDbContext.SaveChanges();
        }
        
        
        [Fact]
        public async Task CanGetTheSecondPageOfAllAcademyTransferProjects()
        {
            var randomGenerator = new RandomGenerator();
            var academyTransferProjectsToCreate = Builder<AcademyTransferProjects>
                .CreateListOfSize(20)
                .All()
                .With(atp => atp.OutgoingTrustUkprn = randomGenerator.NextString(8, 8))
                .With(atp => atp.Urn = 0)
                .With(atp => atp.Id = 0)
                .With(atp => atp.TransferringAcademies = Builder<TransferringAcademies>
                    .CreateListOfSize(3)
                    .All()
                    .With(ta => ta.Id = 0)
                    .With(ta => ta.OutgoingAcademyUkprn = randomGenerator.NextString(8, 8))
                    .With(ta => ta.IncomingTrustUkprn = randomGenerator.NextString(8, 8))
                    .With(ta => ta.FkAcademyTransferProjectId = null)
                    .Build()
                )
                .With(atp => atp.AcademyTransferProjectIntendedTransferBenefits =
                    Builder<AcademyTransferProjectIntendedTransferBenefits>
                        .CreateListOfSize(5)
                        .All()
                        .With(benefit => benefit.Id = 0)
                        .Build()
                )
                .Build().ToList();
            
            _tramsDbContext.AcademyTransferProjects.AddRange(academyTransferProjectsToCreate);
            _tramsDbContext.SaveChanges();

            var indexAcademyTransferProjectRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://trams-api.com/academyTransferProject?page=2"),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                },
            };

            var indexResponse = await _client.SendAsync(indexAcademyTransferProjectRequest);
            indexResponse.StatusCode.Should().Be(200);
            var indexJson = await indexResponse.Content.ReadAsStringAsync();
            var indexProjectResponse =
                JsonConvert.DeserializeObject<List<AcademyTransferProjectSummaryResponse>>(indexJson);

            var expectedResponse = academyTransferProjectsToCreate.OrderBy(atp => atp.Urn).Skip(10).Take(10).Select(atp =>
                new AcademyTransferProjectSummaryResponse
                {
                    ProjectUrn = atp.Urn.ToString(),
                    ProjectNumber = null,
                    OutgoingTrustUkprn = atp.OutgoingTrustUkprn,
                    TransferringAcademies = atp.TransferringAcademies.Select(ta => new TransferringAcademiesResponse
                    {
                        OutgoingAcademyUkprn = ta.OutgoingAcademyUkprn,
                        IncomingTrustUkprn = ta.IncomingTrustUkprn
                    }).ToList()
                }).ToList();
            indexProjectResponse.Count().Should().Be(10);
            indexProjectResponse.Should().BeEquivalentTo(expectedResponse);
            
            _tramsDbContext.TransferringAcademies.RemoveRange(_tramsDbContext.TransferringAcademies);
            _tramsDbContext.AcademyTransferProjectIntendedTransferBenefits
                .RemoveRange(_tramsDbContext.AcademyTransferProjectIntendedTransferBenefits);
            _tramsDbContext.AcademyTransferProjects.RemoveRange(_tramsDbContext.AcademyTransferProjects);
            _tramsDbContext.SaveChanges();
        }
        
        
         [Fact]
        public async Task ReturnsEmptyListWhenPageTooHigh()
        {
            var randomGenerator = new RandomGenerator();
            var academyTransferProjectsToCreate = Builder<AcademyTransferProjects>
                .CreateListOfSize(20)
                .All()
                .With(atp => atp.OutgoingTrustUkprn = randomGenerator.NextString(8, 8))
                .With(atp => atp.Urn = 0)
                .With(atp => atp.Id = 0)
                .With(atp => atp.TransferringAcademies = Builder<TransferringAcademies>
                    .CreateListOfSize(3)
                    .All()
                    .With(ta => ta.Id = 0)
                    .With(ta => ta.OutgoingAcademyUkprn = randomGenerator.NextString(8, 8))
                    .With(ta => ta.IncomingTrustUkprn = randomGenerator.NextString(8, 8))
                    .With(ta => ta.FkAcademyTransferProjectId = null)
                    .Build()
                )
                .With(atp => atp.AcademyTransferProjectIntendedTransferBenefits =
                    Builder<AcademyTransferProjectIntendedTransferBenefits>
                        .CreateListOfSize(5)
                        .All()
                        .With(benefit => benefit.Id = 0)
                        .Build()
                )
                .Build().ToList();
            
            _tramsDbContext.AcademyTransferProjects.AddRange(academyTransferProjectsToCreate);
            _tramsDbContext.SaveChanges();

            var indexAcademyTransferProjectRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://trams-api.com/academyTransferProject?page=4"),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                },
            };

            var indexResponse = await _client.SendAsync(indexAcademyTransferProjectRequest);
            indexResponse.StatusCode.Should().Be(200);
            var indexJson = await indexResponse.Content.ReadAsStringAsync();
            var indexProjectResponse =
                JsonConvert.DeserializeObject<List<AcademyTransferProjectSummaryResponse>>(indexJson);
            
            indexProjectResponse.Count().Should().Be(0);
            indexProjectResponse.Should().BeEquivalentTo(new List<AcademyTransferProjectSummaryResponse>());
            
            _tramsDbContext.TransferringAcademies.RemoveRange(_tramsDbContext.TransferringAcademies);
            _tramsDbContext.AcademyTransferProjectIntendedTransferBenefits
                .RemoveRange(_tramsDbContext.AcademyTransferProjectIntendedTransferBenefits);
            _tramsDbContext.AcademyTransferProjects.RemoveRange(_tramsDbContext.AcademyTransferProjects);
            _tramsDbContext.SaveChanges();
        }
        
        [Fact]
        public async Task Returns404WhenAcademyTransferProjectDoesNotExist()
        {
             var getAcademyTransferProjectRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://trams-api.com/academyTransferProject/10012313"),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                },

            };

            var getResponse = await _client.SendAsync(getAcademyTransferProjectRequest);
            getResponse.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task CanGetAnAcademyTransferProject()
        {
            var randomGenerator = new RandomGenerator();

            var academyTransferProject = Builder<AcademyTransferProjects>
                .CreateNew()
                .With(atp => atp.OutgoingTrustUkprn = randomGenerator.NextString(8, 8))
                .With(atp => atp.Urn = 0)
                .With(atp => atp.Id = 0)
                .With(atp => atp.TransferringAcademies = Builder<TransferringAcademies>
                    .CreateListOfSize(3)
                    .All()
                    .With(ta => ta.Id = 0)
                    .With(ta => ta.OutgoingAcademyUkprn = randomGenerator.NextString(8, 8))
                    .With(ta => ta.IncomingTrustUkprn = randomGenerator.NextString(8, 8))
                    .With(ta => ta.FkAcademyTransferProjectId = null)
                    .Build()
                )
                .With(atp => atp.AcademyTransferProjectIntendedTransferBenefits = Builder<AcademyTransferProjectIntendedTransferBenefits>
                    .CreateListOfSize(5)
                    .All()
                    .With(benefit => benefit.Id = 0)
                    .Build()
                )
                .Build();
            
            _tramsDbContext.AcademyTransferProjects.Add(academyTransferProject);
            _tramsDbContext.SaveChanges();

            var getAcademyTransferProjectRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://trams-api.com/academyTransferProject/{academyTransferProject.Urn}"),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                },
            };

            var getResponse = await _client.SendAsync(getAcademyTransferProjectRequest);
            getResponse.StatusCode.Should().Be(200);

            var responseJson = await getResponse.Content.ReadAsStringAsync();
            var responseModel = JsonConvert.DeserializeObject<AcademyTransferProjectResponse>(responseJson);

            var expected = AcademyTransferProjectResponseFactory.Create(academyTransferProject);

            responseModel.Should().BeEquivalentTo(expected);

            _tramsDbContext.TransferringAcademies.RemoveRange(_tramsDbContext.TransferringAcademies);
            _tramsDbContext.AcademyTransferProjectIntendedTransferBenefits
                .RemoveRange(_tramsDbContext.AcademyTransferProjectIntendedTransferBenefits);
            _tramsDbContext.AcademyTransferProjects.RemoveRange(_tramsDbContext.AcademyTransferProjects);
            _tramsDbContext.SaveChanges();
        }

        private AcademyTransferProjectRequest GenerateCreateRequest()
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
            
            return Builder<AcademyTransferProjectRequest>.CreateNew()
                .With(c => c.OutgoingTrustUkprn = randomGenerator.NextString(8,8))
                .With(c => c.Benefits = benefitsRequest)
                .With(c => c.Dates = datesRequest)
                .With(c => c.Rationale = Builder<AcademyTransferProjectRationaleRequest>.CreateNew().Build())
                .With(c => c.GeneralInformation = Builder<AcademyTransferProjectGeneralInformationRequest>.CreateNew().Build())
                .With(c => c.Features = Builder<AcademyTransferProjectFeaturesRequest>.CreateNew().Build())
                .With(c => c.TransferringAcademies = (List<TransferringAcademiesRequest>) Builder<TransferringAcademiesRequest>
                    .CreateListOfSize(2).All()
                    .With(ta => ta.IncomingTrustUkprn = randomGenerator.NextString(8,8))
                    .With(ta => ta.OutgoingAcademyUkprn = randomGenerator.NextString(8,8)).Build())
                .Build();
        }
    }
}
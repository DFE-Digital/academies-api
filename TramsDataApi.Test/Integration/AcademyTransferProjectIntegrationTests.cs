using System;
using System.Collections.Generic;
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
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Test.Integration
{
    [Collection("Database")]
    public class AcademyTransferProjectIntegrationTests : IClassFixture<TramsDataApiFactory>
    {
        private readonly HttpClient _client;
        private readonly TramsDbContext _dbContext;
        
        public AcademyTransferProjectIntegrationTests(TramsDataApiFactory fixture){
            _client = fixture.CreateClient();
            _client.BaseAddress = new Uri("https://trams-api.com/");
            _dbContext = fixture.Services.GetRequiredService<TramsDbContext>();
        }

        [Fact]
        public async Task CanCreateAcademyTransferProject()
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
            
            var createRequest = Builder<CreateOrUpdateAcademyTransferProjectRequest>.CreateNew()
                .With(c => c.OutgoingTrustUkprn = randomGenerator.NextString(8,8))
                .With(c => c.ProjectUrn = randomGenerator.Int().ToString())
                .With(c => c.Benefits = benefitsRequest)
                .With(c => c.Dates = datesRequest)
                .With(c => c.Rationale = Builder<AcademyTransferProjectRationaleRequest>.CreateNew().Build())
                .With(c => c.Features = Builder<AcademyTransferProjectFeaturesRequest>.CreateNew().Build())
                .With(c => c.TransferringAcademies = (List<TransferringAcademiesRequest>) Builder<TransferringAcademiesRequest>
                    .CreateListOfSize(5).All()
                    .With(ta => ta.IncomingTrustUkprn = randomGenerator.Phrase(8))
                    .With(ta => ta.OutgoingAcademyUkprn = randomGenerator.Phrase(8)).Build())
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

            var createdProject = _dbContext.AcademyTransferProjects.FirstOrDefault(atp => atp.ProjectNumber == result.ProjectNumber);
            createdProject.Should().NotBe(null);
            createdProject.OutgoingTrustUkprn.Should().BeEquivalentTo(createRequest.OutgoingTrustUkprn);
        }
    }
    
    
}
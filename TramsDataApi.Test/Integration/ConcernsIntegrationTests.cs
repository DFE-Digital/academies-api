using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoFixture;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.Test.Utils;
using Xunit;

namespace TramsDataApi.Test.Integration
{
    [Collection("Database")]
    public class ConcernsIntegrationTests : IClassFixture<TramsDataApiFactory>, IDisposable
    {
        
        private readonly HttpClient _client;
        private readonly TramsDbContext _dbContext;
        private readonly Fixture _fixture;

        public ConcernsIntegrationTests(TramsDataApiFactory fixture)
        {
            _client = fixture.CreateClient();
            _client.DefaultRequestHeaders.Add("ApiKey", "testing-api-key");
            _dbContext = fixture.Services.GetRequiredService<TramsDbContext>();
            _fixture = new Fixture();
        }

        [Fact]
        public async Task CanCreateNewConcernCase()
        {
            var randomGenerator = new RandomGenerator();

            var createRequest = Builder<ConcernCaseRequest>.CreateNew()
                .With(c => c.CreatedBy = "12345")
                .With(c => c.Description = "Description for case")
                .With(c => c.CrmEnquiry = "5678")
                .With(c => c.TrustUkprn = "100223")
                .With(c => c.ReasonForReview = "We have concerns")
                .With(c => c.DeEscalation = new DateTime(2022,04,01))
                .With(c => c.Issue = "Here is the issue")
                .With(c => c.CurrentStatus = "Case status")
                .With(c => c.CaseAim = "Here is the aim")
                .With(c => c.DeEscalationPoint = "Point of de-escalation")
                .With(c => c.NextSteps = "Here are the next steps")
                .With(c => c.DirectionOfTravel = "Up")
                .With(c => c.ConcernsStatusId = 1)
                .Build();
            
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://trams-api.com/v2/concerns-cases"),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                },
                Content =  JsonContent.Create(createRequest)
            };
            
            var response = await _client.SendAsync(httpRequestMessage);
            response.StatusCode.Should().Be(201);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ConcernsCaseResponse>(jsonString);
            
            var createdCase = _dbContext.ConcernsCase.FirstOrDefault(c => c.Urn == result.Urn);
            createdCase.Should().NotBe(null);
            createdCase.Description.Should().BeEquivalentTo(createRequest.Description);
        }

        public void Dispose()
        {
            _dbContext.ConcernsCase.RemoveRange(_dbContext.ConcernsCase);
            _dbContext.SaveChanges();
        }
    }
}
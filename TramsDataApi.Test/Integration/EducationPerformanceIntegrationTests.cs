using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.EducationalPerformance;
using Xunit;

namespace TramsDataApi.Test.Integration
{
    [Collection("Database")]
    public class EducationPerformanceIntegrationTests : IClassFixture<TramsDataApiFactory>, IDisposable
    {
        private readonly HttpClient _client;
        private readonly LegacyTramsDbContext _legacyDbContext;
        private readonly RandomGenerator _randomGenerator;


        public EducationPerformanceIntegrationTests(TramsDataApiFactory fixture)
        {
            _client = fixture.CreateClient();
            _client.DefaultRequestHeaders.Add("ApiKey", "testing-api-key");
            _legacyDbContext = fixture.Services.GetRequiredService<LegacyTramsDbContext>();
            _randomGenerator = new RandomGenerator();
        }

        [Fact]
        public async Task CanGetKeyStage1PerformanceData()
        {

            var accountGuid = Guid.NewGuid();
            var accountUrn = "147259";

            var account = Builder<Account>.CreateNew()
                .With(a => a.Name = "Gillshill Primary School")
                .With(a => a.SipUrn = accountUrn)
                .With(a => a.Id = accountGuid)
                .Build();

            var phonics = Builder<SipPhonics>.CreateListOfSize(3)
                .All()
                .With(ph => ph.SipYear = _randomGenerator.DateTime().Year.ToString())
                .With(ph => ph.SipKs1readingpercentageresults = _randomGenerator.Int())
                .With(ph => ph.SipKs1writingpercentageresults = _randomGenerator.Int())
                .With(ph => ph.SipKs1mathspercentageresults = _randomGenerator.Int())
                .With(ph => ph.SipUrn = accountUrn)
                .Build();
            
            _legacyDbContext.Account.Add(account);
            _legacyDbContext.SipPhonics.AddRange(phonics);
            _legacyDbContext.SaveChanges();

            var expectedKs1Response = phonics.Select(ph => new KeyStage1PerformanceResponse
            {
                Year = ph.SipYear,
                Reading = ph.SipKs1readingpercentageresults,
                Writing = ph.SipKs1writingpercentageresults,
                Maths = ph.SipKs1mathspercentageresults
            }).ToList();
                
            var expected = new EducationalPerformanceResponse
            {
                SchoolName = account.Name,
                KeyStage1Responses = expectedKs1Response
            };
            
            var response = await _client.GetAsync($"/educationPerformance/{accountUrn}");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<EducationalPerformanceResponse>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);

        }
        

        public void Dispose()
        {
            _legacyDbContext.Account.RemoveRange(_legacyDbContext.Account);
            _legacyDbContext.SipPhonics.RemoveRange(_legacyDbContext.SipPhonics);
            // _legacyDbContext.SipEducationalperformancedata.RemoveRange(_legacyDbContext.SipEducationalperformancedata);
            _legacyDbContext.SaveChanges();
        }
    }
}
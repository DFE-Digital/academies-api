using System;
using System.Collections.Generic;
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
        public async Task CanGetEducationPerformanceData()
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

            var educationPerformanceData = Builder<SipEducationalperformancedata>.CreateNew()
                .With(epd => epd.SipParentaccountid = accountGuid)
                .With(epd => epd.SipName = "2016-2017")
                .With(epd => epd.SipMeetingexpectedstandardinrwm = 20)
                .With(epd => epd.SipMeetingexpectedstandardinrwmdisadv = 10)
                .With(epd => epd.SipMeetinghigherstandardinrwm = 12)
                .With(epd => epd.SipMeetinghigherstandardrwmdisadv = 50)
                .With(epd => epd.SipProgress8score = 70)
                .With(epd => epd.SipProgress8scoredisadvantaged = 50)
                .Build();

            _legacyDbContext.Account.Add(account);
            _legacyDbContext.SipPhonics.AddRange(phonics);
            _legacyDbContext.SipEducationalperformancedata.AddRange(educationPerformanceData);
            _legacyDbContext.SaveChanges();

            var expectedKs1Response = phonics.Select(ph => new KeyStage1PerformanceResponse
            {
                Year = ph.SipYear,
                Reading = ph.SipKs1readingpercentageresults,
                Writing = ph.SipKs1writingpercentageresults,
                Maths = ph.SipKs1mathspercentageresults
            }).ToList();

            var expectedKs2Response = Builder<KeyStage2PerformanceResponse>.CreateListOfSize(1)
                .All()
                .With(epd => epd.Year = "2016-2017")
                .With(epd => epd.PercentageAchievingHigherStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = 12,
                    Disadvantaged = 50
                })
                .With(epd => epd.PercentageMeetingExpectedStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = 20,
                    Disadvantaged = 10
                })
                .With(epd => epd.ProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = 70,
                    Disadvantaged = 50
                })
                .Build().ToList();
            
            
            var expected = new EducationalPerformanceResponse
            {
                SchoolName = account.Name,
                KeyStage1 = expectedKs1Response,
                KeyStage2 = expectedKs2Response
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
            _legacyDbContext.SipEducationalperformancedata.RemoveRange(_legacyDbContext.SipEducationalperformancedata);
            _legacyDbContext.SaveChanges();
        }
    }
}
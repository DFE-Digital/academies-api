using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
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
        public async Task CanGetEducationPerformanceDataWithKeyStage1and2Data()
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
                .With(epd => epd.Id = Guid.NewGuid())
                .With(epd => epd.SipParentaccountid = accountGuid)
                .With(epd => epd.SipName = "2016-2017")
                .With(epd => epd.SipMeetingexpectedstandardinrwm = 20)
                .With(epd => epd.SipMeetingexpectedstandardinrwmdisadv = 10)
                .With(epd => epd.SipMeetinghigherstandardinrwm = 12)
                .With(epd => epd.SipMeetinghigherstandardrwmdisadv = 50)
                .With(epd => epd.SipProgress8score = 70)
                .With(epd => epd.SipProgress8scoredisadvantaged = 50)
                .With(epd => epd.SipReadingprogressscore = 2)
                .With(epd => epd.SipReadingprogressscoredisadv = 7)
                .With(epd => epd.SipWritingprogressscore = 3)
                .With(epd => epd.SipWritingprogressscoredisadv = 8)
                .With(epd => epd.SipMathsprogressscore = 4)
                .With(epd => epd.SipMathsprogressscoredisadv = 9)
                .With(epd => epd.SipAttainment8score = 50.00M)
                .With(epd => epd.SipAttainment8scoredisadvantaged =  50.00M)
                .With(epd => epd.SipAttainment8scoreenglish =  50.00M)
                .With(epd => epd.SipAttainment8scoreenglishdisadvantaged = 50.00M)
                .With(epd => epd.SipAttainment8scoremaths = 50.00M)
                .With(epd => epd.SipAttainment8scoremathsdisadvantaged =  50.00M)
                .With(epd => epd.SipAttainment8scoreebacc =  50.00M)
                .With(epd => epd.SipAttainment8scoreebaccdisadvantaged =  50.00M)
                .With(epd => epd.SipNumberofpupilsprogress8 = _randomGenerator.Int())
                .With(epd => epd.SipNumberofpupilsprogress8disadvantaged =  _randomGenerator.Int())
                .With(epd => epd.SipProgress8upperconfidence =  50.00M)
                .With(epd => epd.SipProgress8lowerconfidence =  50.00M)
                .With(epd => epd.SipProgress8english =  50.00M)
                .With(epd => epd.SipProgress8englishdisadvantaged =  50.00M)
                .With(epd => epd.SipProgress8maths = 50.00M)
                .With(epd => epd.SipProgress8mathsdisadvantaged = 50.00M)
                .With(epd => epd.SipProgress8ebacc = 50.00M)
                .With(epd => epd.SipProgress8ebaccdisadvantaged = 50.00M)
                .With(epd => epd.SipProgress8score = 50.00M)
                .With(epd => epd.SipProgress8scoredisadvantaged = 50.00M)
                .Build();

            var nationalAverageEducationPerformanceData = Builder<SipEducationalperformancedata>.CreateNew()
                .With(epd => epd.Id = Guid.NewGuid())
                .With(epd => epd.SipParentaccountid = null)
                .With(epd => epd.SipPerformancetype = 123)
                .With(epd => epd.SipName = "2016-2017")
                .With(epd => epd.SipAttainment8score = 100.23M)
                .With(epd => epd.SipAttainment8scoredisadvantaged =  54.19M)
                .With(epd => epd.SipAttainment8scoreenglish =  58.51M)
                .With(epd => epd.SipAttainment8scoreenglishdisadvantaged = 58.65M)
                .With(epd => epd.SipAttainment8scoremaths = 45.41M)
                .With(epd => epd.SipAttainment8scoremathsdisadvantaged =  41.70M)
                .With(epd => epd.SipAttainment8scoreebacc =  85.35M)
                .With(epd => epd.SipAttainment8scoreebaccdisadvantaged =  98.30M)
                .With(epd => epd.SipNumberofpupilsprogress8 = _randomGenerator.Int())
                .With(epd => epd.SipNumberofpupilsprogress8disadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipProgress8upperconfidence =  11.05M)
                .With(epd => epd.SipProgress8lowerconfidence =  65.90M)
                .With(epd => epd.SipProgress8english =  56.12M)
                .With(epd => epd.SipProgress8englishdisadvantaged =  89.21M)
                .With(epd => epd.SipProgress8maths = 50.96M)
                .With(epd => epd.SipProgress8mathsdisadvantaged = 97.11M)
                .With(epd => epd.SipProgress8ebacc = 32.45M)
                .With(epd => epd.SipProgress8ebaccdisadvantaged = 22.79M)
                .With(epd => epd.SipProgress8score = 105.77M)
                .With(epd => epd.SipProgress8scoredisadvantaged = 67.98M)
                .With(epd => epd.SipMeetingexpectedstandardinrwm = 55.00M)
                .With(epd => epd.SipMeetingexpectedstandardinrwmdisadv = 77.00M)
                .With(epd => epd.SipMeetinghigherstandardinrwm = 88.00M)
                .With(epd => epd.SipMeetinghigherstandardrwmdisadv = 22.00M)
                .With(epd => epd.SipReadingprogressscore = 2)
                .With(epd => epd.SipReadingprogressscoredisadv = 7)
                .With(epd => epd.SipWritingprogressscore = 3)
                .With(epd => epd.SipWritingprogressscoredisadv = 8)
                .With(epd => epd.SipMathsprogressscore = 4)
                .With(epd => epd.SipMathsprogressscoredisadv = 9)
                .Build();
            
            var laAverageEducationPerformanceData = Builder<SipEducationalperformancedata>.CreateNew()
                .With(epd => epd.Id = Guid.NewGuid())
                .With(epd => epd.SipParentaccountid = null)
                .With(epd => epd.SipPerformancetype = 234)
                .With(epd => epd.SipName = "2016-2017")
                .With(epd => epd.SipAttainment8score = 100.23M)
                .With(epd => epd.SipAttainment8scoredisadvantaged =  54.19M)
                .With(epd => epd.SipAttainment8scoreenglish =  58.51M)
                .With(epd => epd.SipAttainment8scoreenglishdisadvantaged = 58.65M)
                .With(epd => epd.SipAttainment8scoremaths = 45.41M)
                .With(epd => epd.SipAttainment8scoremathsdisadvantaged =  41.70M)
                .With(epd => epd.SipAttainment8scoreebacc =  85.35M)
                .With(epd => epd.SipAttainment8scoreebaccdisadvantaged =  98.30M)
                .With(epd => epd.SipNumberofpupilsprogress8 = _randomGenerator.Int())
                .With(epd => epd.SipNumberofpupilsprogress8disadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipProgress8upperconfidence =  11.05M)
                .With(epd => epd.SipProgress8lowerconfidence =  65.90M)
                .With(epd => epd.SipProgress8english =  56.12M)
                .With(epd => epd.SipProgress8englishdisadvantaged =  89.21M)
                .With(epd => epd.SipProgress8maths = 50.96M)
                .With(epd => epd.SipProgress8mathsdisadvantaged = 97.11M)
                .With(epd => epd.SipProgress8ebacc = 32.45M)
                .With(epd => epd.SipProgress8ebaccdisadvantaged = 22.79M)
                .With(epd => epd.SipProgress8score = 105.77M)
                .With(epd => epd.SipProgress8scoredisadvantaged = 67.98M)
                .With(epd => epd.SipMeetingexpectedstandardinrwm = 55.00M)
                .With(epd => epd.SipMeetingexpectedstandardinrwmdisadv = 77.00M)
                .With(epd => epd.SipMeetinghigherstandardinrwm = 88.00M)
                .With(epd => epd.SipMeetinghigherstandardrwmdisadv = 22.00M)
                .With(epd => epd.SipReadingprogressscore = 2)
                .With(epd => epd.SipReadingprogressscoredisadv = 7)
                .With(epd => epd.SipWritingprogressscore = 3)
                .With(epd => epd.SipWritingprogressscoredisadv = 8)
                .With(epd => epd.SipMathsprogressscore = 4)
                .With(epd => epd.SipMathsprogressscoredisadv = 9)
                .Build();
                
            var globalOptionMetadata = Builder<GlobalOptionSetMetadata>.CreateNew()
                .With(gom => gom.LocalizedLabelLanguageCode = 100)
                .With(gom => gom.Option = 123)
                .With(gom => gom.OptionSetName = "sip_performancetype")
                .With(gom => gom.LocalizedLabel = "National")
                .Build();
            
            var globalOptionMetadata2 = Builder<GlobalOptionSetMetadata>.CreateNew()
                .With(gom => gom.Option = 234)
                .With(gom => gom.OptionSetName = "sip_performancetype")
                .With(gom => gom.LocalizedLabel = "Authority")
                .Build();

            _legacyDbContext.GlobalOptionSetMetadata.AddRange(new List<GlobalOptionSetMetadata>{globalOptionMetadata, globalOptionMetadata2});
            _legacyDbContext.Account.Add(account);
            _legacyDbContext.SipPhonics.AddRange(phonics);
            _legacyDbContext.SipEducationalperformancedata
                .AddRange(new List<SipEducationalperformancedata> 
                {
                    educationPerformanceData, nationalAverageEducationPerformanceData, laAverageEducationPerformanceData
                });
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
                    NotDisadvantaged = "12.00",
                    Disadvantaged = "50.00"
                })
                .With(epd => epd.PercentageMeetingExpectedStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = "20.00",
                    Disadvantaged = "10.00"
                })
                .With(epd => epd.ReadingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = "2.00",
                    Disadvantaged = "7.00"
                })
                .With(epd => epd.WritingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = "3.00",
                    Disadvantaged = "8.00"
                })
                .With(epd => epd.MathsProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = "4.00",
                    Disadvantaged = "9.00"
                })
                .With(epd => epd.NationalAveragePercentageAchievingHigherStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = "88.00",
                    Disadvantaged = "22.00"
                })
                .With(epd => epd.NationalAveragePercentageMeetingExpectedStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = "55.00",
                    Disadvantaged = "77.00"
                })
                .With(epd => epd.NationalAverageReadingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = "2.00",
                    Disadvantaged = "7.00"
                })
                .With(epd => epd.NationalAverageWritingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = "3.00",
                    Disadvantaged = "8.00"
                })
                .With(epd => epd.NationalAverageMathsProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = "4.00",
                    Disadvantaged = "9.00"
                })
                .With(epd => epd.LAAveragePercentageAchievingHigherStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = "88.00",
                    Disadvantaged = "22.00"
                })
                .With(epd => epd.LAAveragePercentageMeetingExpectedStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = "55.00",
                    Disadvantaged = "77.00"
                })
                .With(epd => epd.LAAverageReadingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = "2.00",
                    Disadvantaged = "7.00"
                })
                .With(epd => epd.LAAverageWritingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = "3.00",
                    Disadvantaged = "8.00"
                })
                .With(epd => epd.LAAverageMathsProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = "4.00",
                    Disadvantaged = "9.00"
                })
                .Build().ToList();


            var expectedKs4Response = new List<KeyStage4PerformanceResponse> {KeyStage4PerformanceResponseFactory
                .Create(educationPerformanceData, nationalAverageEducationPerformanceData, laAverageEducationPerformanceData)};

            var expected = new EducationalPerformanceResponse
            {
                SchoolName = account.Name,
                KeyStage1 = expectedKs1Response,
                KeyStage2 = expectedKs2Response,
                KeyStage4 = expectedKs4Response
            };
            
            var response = await _client.GetAsync($"/educationPerformance/{accountUrn}");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<EducationalPerformanceResponse>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
            
            _legacyDbContext.Account.RemoveRange(_legacyDbContext.Account);
            _legacyDbContext.SipPhonics.RemoveRange(_legacyDbContext.SipPhonics);
            _legacyDbContext.SipEducationalperformancedata.RemoveRange(_legacyDbContext.SipEducationalperformancedata);
            _legacyDbContext.GlobalOptionSetMetadata.RemoveRange(_legacyDbContext.GlobalOptionSetMetadata);
        }
        
        [Fact]
        public async Task CanGetEducationPerformanceDataWithKeyStage4Data()
        {

            var accountGuid = Guid.NewGuid();
            var accountUrn = "147259";

            var account = Builder<Account>.CreateNew()
                .With(a => a.Name = "Gillshill Primary School")
                .With(a => a.SipUrn = accountUrn)
                .With(a => a.Id = accountGuid)
                .Build();

            
            var educationPerformanceData = Builder<SipEducationalperformancedata>.CreateNew()
                .With(epd => epd.Id = Guid.NewGuid())
                .With(epd => epd.SipParentaccountid = accountGuid)
                .With(epd => epd.SipName = "2016-2017")
                .With(epd => epd.SipMeetingexpectedstandardinrwm = 20.00M)
                .With(epd => epd.SipMeetingexpectedstandardinrwmdisadv = 10.00M)
                .With(epd => epd.SipMeetinghigherstandardinrwm = 12.00M)
                .With(epd => epd.SipMeetinghigherstandardrwmdisadv = 50.00M)
                .With(epd => epd.SipProgress8score = 70.00M)
                .With(epd => epd.SipProgress8scoredisadvantaged = 50.00M)
                .With(epd => epd.SipReadingprogressscore = .00M)
                .With(epd => epd.SipReadingprogressscoredisadv = 7.00M)
                .With(epd => epd.SipWritingprogressscore = 3.00M)
                .With(epd => epd.SipWritingprogressscoredisadv = 8.00M)
                .With(epd => epd.SipMathsprogressscore = 4.00M)
                .With(epd => epd.SipMathsprogressscoredisadv = 9.00M)
                .With(epd => epd.SipAttainment8score = 99.99M)
                .With(epd => epd.SipAttainment8scoredisadvantaged =  54.10M)
                .With(epd => epd.SipAttainment8scoreenglish =  52.56M)
                .With(epd => epd.SipAttainment8scoreenglishdisadvantaged = 54.66M)
                .With(epd => epd.SipAttainment8scoremaths = 45.80M)
                .With(epd => epd.SipAttainment8scoremathsdisadvantaged =  54.72M)
                .With(epd => epd.SipAttainment8scoreebacc =  32.99M)
                .With(epd => epd.SipAttainment8scoreebaccdisadvantaged =  21.45M)
                .With(epd => epd.SipNumberofpupilsprogress8 = _randomGenerator.Int())
                .With(epd => epd.SipNumberofpupilsprogress8disadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipProgress8upperconfidence =  66.10M)
                .With(epd => epd.SipProgress8lowerconfidence =  73.81M)
                .With(epd => epd.SipProgress8english =  77.40M)
                .With(epd => epd.SipProgress8englishdisadvantaged =  43.83M)
                .With(epd => epd.SipProgress8maths = 60.51M)
                .With(epd => epd.SipProgress8mathsdisadvantaged = 70.41M)
                .With(epd => epd.SipProgress8ebacc = 54.27M)
                .With(epd => epd.SipProgress8ebaccdisadvantaged = 100.49M)
                .With(epd => epd.SipProgress8score = 99.17M)
                .With(epd => epd.SipProgress8scoredisadvantaged = 37.78M)
                .Build();

            var nationalEducationPerformance1 = Builder<SipEducationalperformancedata>.CreateNew()
                .With(epd => epd.Id = Guid.NewGuid())
                .With(epd => epd.SipParentaccountid = null)
                .With(epd => epd.SipPerformancetype = 123)
                .With(epd => epd.SipName = "2016-2017")
                .With(epd => epd.SipAttainment8score = 100.23M)
                .With(epd => epd.SipAttainment8scoredisadvantaged =  54.19M)
                .With(epd => epd.SipAttainment8scoreenglish =  58.51M)
                .With(epd => epd.SipAttainment8scoreenglishdisadvantaged = 58.65M)
                .With(epd => epd.SipAttainment8scoremaths = 45.41M)
                .With(epd => epd.SipAttainment8scoremathsdisadvantaged =  41.70M)
                .With(epd => epd.SipAttainment8scoreebacc =  85.35M)
                .With(epd => epd.SipAttainment8scoreebaccdisadvantaged =  98.30M)
                .With(epd => epd.SipNumberofpupilsprogress8 = _randomGenerator.Int())
                .With(epd => epd.SipNumberofpupilsprogress8disadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipProgress8upperconfidence =  11.05M)
                .With(epd => epd.SipProgress8lowerconfidence =  65.90M)
                .With(epd => epd.SipProgress8english =  56.12M)
                .With(epd => epd.SipProgress8englishdisadvantaged =  89.21M)
                .With(epd => epd.SipProgress8maths = 50.96M)
                .With(epd => epd.SipProgress8mathsdisadvantaged = 97.11M)
                .With(epd => epd.SipProgress8ebacc = 32.45M)
                .With(epd => epd.SipProgress8ebaccdisadvantaged = 22.79M)
                .With(epd => epd.SipProgress8score = 105.77M)
                .With(epd => epd.SipProgress8scoredisadvantaged = 67.98M)
                .With(epd => epd.SipMeetingexpectedstandardinrwm = 55.00M)
                .With(epd => epd.SipMeetingexpectedstandardinrwmdisadv = 77.00M)
                .With(epd => epd.SipMeetinghigherstandardinrwm = 88.00M)
                .With(epd => epd.SipMeetinghigherstandardrwmdisadv = 22.00M)
                .With(epd => epd.SipReadingprogressscore = .00M)
                .With(epd => epd.SipReadingprogressscoredisadv = 7.00M)
                .With(epd => epd.SipWritingprogressscore = 3.00M)
                .With(epd => epd.SipWritingprogressscoredisadv = 8.00M)
                .With(epd => epd.SipMathsprogressscore = 4.00M)
                .With(epd => epd.SipMathsprogressscoredisadv = 9.00M)
                .Build();
            
            var nationalEducationPerformance2 = Builder<SipEducationalperformancedata>.CreateNew()
                .With(epd => epd.Id = Guid.NewGuid())
                .With(epd => epd.SipParentaccountid = null)
                .With(epd => epd.SipPerformancetype = 123)
                .With(epd => epd.SipName = "2017-2018")
                .With(epd => epd.SipAttainment8score = 100.23M)
                .With(epd => epd.SipAttainment8scoredisadvantaged =  54.19M)
                .With(epd => epd.SipAttainment8scoreenglish =  58.51M)
                .With(epd => epd.SipAttainment8scoreenglishdisadvantaged = 58.65M)
                .With(epd => epd.SipAttainment8scoremaths = 45.41M)
                .With(epd => epd.SipAttainment8scoremathsdisadvantaged =  41.70M)
                .With(epd => epd.SipAttainment8scoreebacc =  85.35M)
                .With(epd => epd.SipAttainment8scoreebaccdisadvantaged =  98.30M)
                .With(epd => epd.SipNumberofpupilsprogress8 = _randomGenerator.Int())
                .With(epd => epd.SipNumberofpupilsprogress8disadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipProgress8upperconfidence =  11.05M)
                .With(epd => epd.SipProgress8lowerconfidence =  65.90M)
                .With(epd => epd.SipProgress8english =  56.12M)
                .With(epd => epd.SipProgress8englishdisadvantaged =  89.21M)
                .With(epd => epd.SipProgress8maths = 50.96M)
                .With(epd => epd.SipProgress8mathsdisadvantaged = 97.11M)
                .With(epd => epd.SipProgress8ebacc = 32.45M)
                .With(epd => epd.SipProgress8ebaccdisadvantaged = 22.79M)
                .With(epd => epd.SipProgress8score = 105.77M)
                .With(epd => epd.SipProgress8scoredisadvantaged = 67.98M)
                .Build();
            
            var laEducationPerformance1 = Builder<SipEducationalperformancedata>.CreateNew()
                .With(epd => epd.Id = Guid.NewGuid())
                .With(epd => epd.SipParentaccountid = null)
                .With(epd => epd.SipPerformancetype = 234)
                .With(epd => epd.SipName = "2017-2018")
                .With(epd => epd.SipAttainment8score = 100.23M)
                .With(epd => epd.SipAttainment8scoredisadvantaged =  54.19M)
                .With(epd => epd.SipAttainment8scoreenglish =  58.51M)
                .With(epd => epd.SipAttainment8scoreenglishdisadvantaged = 58.65M)
                .With(epd => epd.SipAttainment8scoremaths = 45.41M)
                .With(epd => epd.SipAttainment8scoremathsdisadvantaged =  41.70M)
                .With(epd => epd.SipAttainment8scoreebacc =  85.35M)
                .With(epd => epd.SipAttainment8scoreebaccdisadvantaged =  98.30M)
                .With(epd => epd.SipNumberofpupilsprogress8 = _randomGenerator.Int())
                .With(epd => epd.SipNumberofpupilsprogress8disadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipProgress8upperconfidence =  11.05M)
                .With(epd => epd.SipProgress8lowerconfidence =  65.90M)
                .With(epd => epd.SipProgress8english =  56.12M)
                .With(epd => epd.SipProgress8englishdisadvantaged =  89.21M)
                .With(epd => epd.SipProgress8maths = 50.96M)
                .With(epd => epd.SipProgress8mathsdisadvantaged = 97.11M)
                .With(epd => epd.SipProgress8ebacc = 32.45M)
                .With(epd => epd.SipProgress8ebaccdisadvantaged = 22.79M)
                .With(epd => epd.SipProgress8score = 105.77M)
                .With(epd => epd.SipProgress8scoredisadvantaged = 67.98M)
                .With(epd => epd.SipProgress8scoredisadvantaged = 67.98M)
                .Build();
            
            var laEducationPerformance2 = Builder<SipEducationalperformancedata>.CreateNew()
                .With(epd => epd.Id = Guid.NewGuid())
                .With(epd => epd.SipParentaccountid = null)
                .With(epd => epd.SipPerformancetype = 234)
                .With(epd => epd.SipName = "2016-2017")
                .With(epd => epd.SipAttainment8score = 100.23M)
                .With(epd => epd.SipAttainment8scoredisadvantaged =  54.19M)
                .With(epd => epd.SipAttainment8scoreenglish =  58.51M)
                .With(epd => epd.SipAttainment8scoreenglishdisadvantaged = 58.65M)
                .With(epd => epd.SipAttainment8scoremaths = 45.41M)
                .With(epd => epd.SipAttainment8scoremathsdisadvantaged =  41.70M)
                .With(epd => epd.SipAttainment8scoreebacc =  85.35M)
                .With(epd => epd.SipAttainment8scoreebaccdisadvantaged =  98.30M)
                .With(epd => epd.SipNumberofpupilsprogress8 = _randomGenerator.Int())
                .With(epd => epd.SipNumberofpupilsprogress8disadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipProgress8upperconfidence =  11.05M)
                .With(epd => epd.SipProgress8lowerconfidence =  65.90M)
                .With(epd => epd.SipProgress8english =  56.12M)
                .With(epd => epd.SipProgress8englishdisadvantaged =  89.21M)
                .With(epd => epd.SipProgress8maths = 50.96M)
                .With(epd => epd.SipProgress8mathsdisadvantaged = 97.11M)
                .With(epd => epd.SipProgress8ebacc = 32.45M)
                .With(epd => epd.SipProgress8ebaccdisadvantaged = 22.79M)
                .With(epd => epd.SipProgress8score = 105.77M)
                .With(epd => epd.SipProgress8scoredisadvantaged = 67.98M)
                .With(epd => epd.SipMeetingexpectedstandardinrwm = 55.00M)
                .With(epd => epd.SipMeetingexpectedstandardinrwmdisadv = 77.00M)
                .With(epd => epd.SipMeetinghigherstandardinrwm = 88.00M)
                .With(epd => epd.SipMeetinghigherstandardrwmdisadv = 22.00M)
                .With(epd => epd.SipReadingprogressscore = .00M)
                .With(epd => epd.SipReadingprogressscoredisadv = 7.00M)
                .With(epd => epd.SipWritingprogressscore = 3.00M)
                .With(epd => epd.SipWritingprogressscoredisadv = 8.00M)
                .With(epd => epd.SipMathsprogressscore = 4.00M)
                .With(epd => epd.SipMathsprogressscoredisadv = 9.00M)
                .Build();

            var educationPerformanceDataList = new List<SipEducationalperformancedata>
            {
                educationPerformanceData, 
                nationalEducationPerformance1, 
                nationalEducationPerformance2, 
                laEducationPerformance1, 
                laEducationPerformance2
            };

            var globalOptionMetadata = Builder<GlobalOptionSetMetadata>.CreateNew()
                .With(gom => gom.Option = 123)
                .With(gom => gom.OptionSetName = "sip_performancetype")
                .With(gom => gom.LocalizedLabel = "National")
                .Build();
            
            var globalOptionMetadata2 = Builder<GlobalOptionSetMetadata>.CreateNew()
                .With(gom => gom.Option = 234)
                .With(gom => gom.OptionSetName = "sip_performancetype")
                .With(gom => gom.LocalizedLabel = "Authority")
                .Build();

            _legacyDbContext.GlobalOptionSetMetadata.AddRange(new List<GlobalOptionSetMetadata>{globalOptionMetadata, globalOptionMetadata2});
            _legacyDbContext.Account.Add(account);
            _legacyDbContext.SipEducationalperformancedata.AddRange(educationPerformanceDataList);
            _legacyDbContext.SaveChanges();

            var expectedKeyStage2Response = KeyStage2PerformanceResponseFactory
                .Create(educationPerformanceData, nationalEducationPerformance1, laEducationPerformance2);

            var expectedKeyStage4Response = new KeyStage4PerformanceResponse
            {
                Year = educationPerformanceData.SipName,
                SipAttainment8score = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}", educationPerformanceData.SipAttainment8score),
                    Disadvantaged = String.Format("{0:0.00}", educationPerformanceData.SipAttainment8scoredisadvantaged)
                },
                SipAttainment8scoreenglish = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}", educationPerformanceData.SipAttainment8scoreenglish),
                    Disadvantaged = String.Format("{0:0.00}",
                        educationPerformanceData.SipAttainment8scoreenglishdisadvantaged)
                },
                SipAttainment8scoremaths = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}", educationPerformanceData.SipAttainment8scoremaths),
                    Disadvantaged = String.Format("{0:0.00}",
                        educationPerformanceData.SipAttainment8scoremathsdisadvantaged)
                },
                SipAttainment8scoreebacc = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}", educationPerformanceData.SipAttainment8scoreebacc),
                    Disadvantaged = String.Format("{0:0.00}",
                        educationPerformanceData.SipAttainment8scoreebaccdisadvantaged)
                },
                SipNumberofpupilsprogress8 = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationPerformanceData.SipNumberofpupilsprogress8.ToString(),
                    Disadvantaged = educationPerformanceData.SipNumberofpupilsprogress8disadvantaged.ToString()
                },
                SipProgress8upperconfidence = educationPerformanceData.SipProgress8upperconfidence,
                SipProgress8lowerconfidence = educationPerformanceData.SipProgress8lowerconfidence,
                SipProgress8english = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}", educationPerformanceData.SipProgress8english),
                    Disadvantaged = String.Format("{0:0.00}", educationPerformanceData.SipProgress8englishdisadvantaged)
                },
                SipProgress8maths = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}", educationPerformanceData.SipProgress8maths),
                    Disadvantaged = String.Format("{0:0.00}", educationPerformanceData.SipProgress8mathsdisadvantaged)
                },
                SipProgress8ebacc = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}", educationPerformanceData.SipProgress8ebacc.ToString()),
                    Disadvantaged = String.Format("{0:0.00}",
                        educationPerformanceData.SipProgress8ebaccdisadvantaged.ToString())
                },
                SipProgress8Score = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}", educationPerformanceData.SipProgress8score.ToString()),
                    Disadvantaged = String.Format("{0:0.00}",
                        educationPerformanceData.SipProgress8scoredisadvantaged.ToString())
                },
                NationalAverageA8Score = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}", nationalEducationPerformance1.SipAttainment8score),
                    Disadvantaged = String.Format("{0:0.00}",
                        nationalEducationPerformance1.SipAttainment8scoredisadvantaged)
                },
                NationalAverageA8English = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged =
                        String.Format("{0:0.00}", nationalEducationPerformance1.SipAttainment8scoreenglish),
                    Disadvantaged = String.Format("{0:0.00}",
                        nationalEducationPerformance1.SipAttainment8scoreenglishdisadvantaged)
                },
                NationalAverageA8Maths = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}", nationalEducationPerformance1.SipAttainment8scoremaths),
                    Disadvantaged = String.Format("{0:0.00}",
                        nationalEducationPerformance1.SipAttainment8scoremathsdisadvantaged)
                },
                NationalAverageA8EBacc = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}", nationalEducationPerformance1.SipAttainment8scoreebacc),
                    Disadvantaged = String.Format("{0:0.00}",
                        nationalEducationPerformance1.SipAttainment8scoreebaccdisadvantaged)
                },
                NationalAverageP8PupilsIncluded = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalEducationPerformance1.SipNumberofpupilsprogress8.ToString(),
                    Disadvantaged = nationalEducationPerformance1.SipNumberofpupilsprogress8disadvantaged.ToString()
                },
                NationalAverageP8Score = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}", nationalEducationPerformance1.SipProgress8score),
                    Disadvantaged = String.Format("{0:0.00}",
                        nationalEducationPerformance1.SipProgress8scoredisadvantaged)
                },
                NationalAverageP8English = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}",
                        nationalEducationPerformance1.SipProgress8english.ToString()),
                    Disadvantaged = String.Format("{0:0.00}",
                        nationalEducationPerformance1.SipProgress8englishdisadvantaged.ToString())
                },
                NationalAverageP8Maths = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}",
                        nationalEducationPerformance1.SipProgress8maths.ToString()),
                    Disadvantaged = String.Format("{0:0.00}",
                        nationalEducationPerformance1.SipProgress8mathsdisadvantaged.ToString())
                },
                NationalAverageP8Ebacc = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}",
                        nationalEducationPerformance1.SipProgress8ebacc.ToString()),
                    Disadvantaged = String.Format("{0:0.00}",
                        nationalEducationPerformance1.SipProgress8ebaccdisadvantaged.ToString())
                },
                NationalAverageP8LowerConfidence = nationalEducationPerformance1.SipProgress8lowerconfidence,
                NationalAverageP8UpperConfidence = nationalEducationPerformance1.SipProgress8upperconfidence,
                
                LAAverageA8Score = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}", laEducationPerformance2.SipAttainment8score),
                    Disadvantaged = String.Format("{0:0.00}",
                        laEducationPerformance2.SipAttainment8scoredisadvantaged)
                },
                LAAverageA8English = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged =
                        String.Format("{0:0.00}", laEducationPerformance2.SipAttainment8scoreenglish),
                    Disadvantaged = String.Format("{0:0.00}",
                        laEducationPerformance2.SipAttainment8scoreenglishdisadvantaged)
                },
                LAAverageA8Maths = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}", nationalEducationPerformance1.SipAttainment8scoremaths),
                    Disadvantaged = String.Format("{0:0.00}",
                        nationalEducationPerformance1.SipAttainment8scoremathsdisadvantaged)
                },
                LAAverageA8EBacc = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}", laEducationPerformance2.SipAttainment8scoreebacc),
                    Disadvantaged = String.Format("{0:0.00}",
                        laEducationPerformance2.SipAttainment8scoreebaccdisadvantaged)
                },
                LAAverageP8PupilsIncluded = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = laEducationPerformance2.SipNumberofpupilsprogress8.ToString(),
                    Disadvantaged = laEducationPerformance2.SipNumberofpupilsprogress8disadvantaged.ToString()
                },
                LAAverageP8Score = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}", laEducationPerformance2.SipProgress8score),
                    Disadvantaged = String.Format("{0:0.00}",
                        laEducationPerformance2.SipProgress8scoredisadvantaged)
                },
                LAAverageP8English = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}",
                        laEducationPerformance2.SipProgress8english.ToString()),
                    Disadvantaged = String.Format("{0:0.00}",
                        laEducationPerformance2.SipProgress8englishdisadvantaged.ToString())
                },
                LAAverageP8Maths = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}",
                        laEducationPerformance2.SipProgress8maths.ToString()),
                    Disadvantaged = String.Format("{0:0.00}",
                        laEducationPerformance2.SipProgress8mathsdisadvantaged.ToString())
                },
                LAAverageP8Ebacc = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = String.Format("{0:0.00}",
                        laEducationPerformance2.SipProgress8ebacc.ToString()),
                    Disadvantaged = String.Format("{0:0.00}",
                        laEducationPerformance2.SipProgress8ebaccdisadvantaged.ToString())
                },
                LAAverageP8LowerConfidence = laEducationPerformance2.SipProgress8lowerconfidence,
                LAAverageP8UpperConfidence = laEducationPerformance2.SipProgress8upperconfidence
            };

            var expected = new EducationalPerformanceResponse
            {
                SchoolName = account.Name,
                KeyStage1 = new List<KeyStage1PerformanceResponse>(),
                KeyStage2 = new List<KeyStage2PerformanceResponse> { expectedKeyStage2Response },
                KeyStage4 = new List<KeyStage4PerformanceResponse> { expectedKeyStage4Response }
            };
            
            var response = await _client.GetAsync($"/educationPerformance/{accountUrn}");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<EducationalPerformanceResponse>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
            
            _legacyDbContext.Account.RemoveRange(_legacyDbContext.Account);
            _legacyDbContext.SipEducationalperformancedata.RemoveRange(_legacyDbContext.SipEducationalperformancedata);
            _legacyDbContext.GlobalOptionSetMetadata.RemoveRange(_legacyDbContext.GlobalOptionSetMetadata);

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
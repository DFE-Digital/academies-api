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
                .Build().ToList();
            
            var expectedKs4Response = new List<KeyStage4PerformanceResponse> {KeyStage4PerformanceResponseFactory.Create(educationPerformanceData)};

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


            var educationPerformanceData = Builder<SipEducationalperformancedata>.CreateListOfSize(1)
                .All()
                .With(epd => epd.SipParentaccountid = accountGuid)
                .With(epd => epd.SipName = "2016-2017")
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
                .Build().ToList();

            _legacyDbContext.Account.Add(account);
            _legacyDbContext.SipEducationalperformancedata.AddRange(educationPerformanceData);
            _legacyDbContext.SaveChanges();

            var expectedKeyStage2Response = educationPerformanceData
                .Select(epd => KeyStage2PerformanceResponseFactory.Create(epd))
                .ToList();

            var expectedKeyStage4Response = educationPerformanceData
                .Select(epd => new KeyStage4PerformanceResponse
                {
                    Year = epd.SipName,
                    SipAttainment8score = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = epd.SipAttainment8score.ToString(),
                        Disadvantaged = epd.SipAttainment8scoredisadvantaged.ToString()
                    },
                    SipAttainment8scoreenglish = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = epd.SipAttainment8scoreenglish.ToString(),
                        Disadvantaged = epd.SipAttainment8scoreenglishdisadvantaged.ToString()
                    },
                    SipAttainment8scoremaths = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = epd.SipAttainment8scoremaths.ToString(),
                        Disadvantaged = epd.SipAttainment8scoremathsdisadvantaged.ToString()
                    },
                    SipAttainment8scoreebacc = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = epd.SipAttainment8scoreebacc.ToString(),
                        Disadvantaged = epd.SipAttainment8scoreebaccdisadvantaged.ToString()
                    },
                    SipNumberofpupilsprogress8 = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = epd.SipNumberofpupilsprogress8.ToString(),
                        Disadvantaged = epd.SipNumberofpupilsprogress8disadvantaged.ToString()
                    },
                    SipProgress8upperconfidence = epd.SipProgress8upperconfidence,
                    SipProgress8lowerconfidence = epd.SipProgress8lowerconfidence,
                    SipProgress8english = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = epd.SipProgress8english.ToString(),
                        Disadvantaged = epd.SipProgress8englishdisadvantaged.ToString()
                    },
                    SipProgress8maths = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = epd.SipProgress8maths.ToString(),
                        Disadvantaged = epd.SipProgress8mathsdisadvantaged.ToString()
                    },
                    SipProgress8ebacc = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = epd.SipProgress8ebacc.ToString(),
                        Disadvantaged = epd.SipProgress8ebaccdisadvantaged.ToString()
                    }
                }).ToList();
            
            
            var expected = new EducationalPerformanceResponse
            {
                SchoolName = account.Name,
                KeyStage1 = new List<KeyStage1PerformanceResponse>(),
                KeyStage2 = expectedKeyStage2Response,
                KeyStage4 = expectedKeyStage4Response
            };
            
            var response = await _client.GetAsync($"/educationPerformance/{accountUrn}");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<EducationalPerformanceResponse>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
            
            _legacyDbContext.Account.RemoveRange(_legacyDbContext.Account);
            _legacyDbContext.SipEducationalperformancedata.RemoveRange(_legacyDbContext.SipEducationalperformancedata);

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
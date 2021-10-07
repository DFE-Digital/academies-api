using System;
using FizzWare.NBuilder;
using FizzWare.NBuilder.PropertyNaming;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Factories.EducationPerformanceFactories;
using TramsDataApi.ResponseModels.EducationalPerformance;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class KeyStage2ResponseFactoryTests
    {
        private readonly RandomGenerator _randomGenerator;

        public KeyStage2ResponseFactoryTests()
        {
            BuilderSetup.SetDefaultPropertyName(new RandomValuePropertyNamer(new BuilderSettings()));
            _randomGenerator = new RandomGenerator();
        }

        [Fact]
        public void KeyStage2ResponseFactory_CreatesKeyStage2Response_FromEducationPerformanceData()
        {
            var year = _randomGenerator.DateTime().Year.ToString();
            
            var educationalPerformanceData = Builder<SipEducationalperformancedata>.CreateNew()
                .With(epd => epd.SipParentaccountid = Guid.NewGuid())
                .With(epd => epd.SipName = year)
                .With(epd => epd.SipMathsprogressscore = _randomGenerator.Int())
                .With(epd => epd.SipMathsprogressscoredisadv = _randomGenerator.Int())
                .With(epd => epd.SipReadingprogressscore = _randomGenerator.Int())
                .With(epd => epd.SipReadingprogressscoredisadv = _randomGenerator.Int())
                .With(epd => epd.SipWritingprogressscore = _randomGenerator.Int())
                .With(epd => epd.SipWritingprogressscoredisadv = _randomGenerator.Int())
                .With(epd => epd.SipMeetingexpectedstandardinrwm = _randomGenerator.Int())
                .With(epd => epd.SipMeetingexpectedstandardinrwmdisadv = _randomGenerator.Int())
                .With(epd => epd.SipMeetinghigherstandardinrwm = _randomGenerator.Int())
                .With(epd => epd.SipMeetinghigherstandardrwmdisadv = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8score = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoredisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoreenglish = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoreenglishdisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoremaths = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoremathsdisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoreebacc = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoreebaccdisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipNumberofpupilsprogress8 = _randomGenerator.Int())
                .With(epd => epd.SipNumberofpupilsprogress8disadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipProgress8upperconfidence = _randomGenerator.Int())
                .With(epd => epd.SipProgress8lowerconfidence = _randomGenerator.Int())
                .With(epd => epd.SipProgress8english = _randomGenerator.Int())
                .With(epd => epd.SipProgress8englishdisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipProgress8maths = _randomGenerator.Int())
                .With(epd => epd.SipProgress8mathsdisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipProgress8ebacc = _randomGenerator.Int())
                .With(epd => epd.SipProgress8ebaccdisadvantaged = _randomGenerator.Int())
                .Build();
            
            var nationalAveragePerformanceData = Builder<SipEducationalperformancedata>.CreateNew()
                .With(epd => epd.SipParentaccountid = Guid.NewGuid())
                .With(epd => epd.SipName = year)
                .With(epd => epd.SipMathsprogressscore = _randomGenerator.Int())
                .With(epd => epd.SipMathsprogressscoredisadv = _randomGenerator.Int())
                .With(epd => epd.SipReadingprogressscore = _randomGenerator.Int())
                .With(epd => epd.SipReadingprogressscoredisadv = _randomGenerator.Int())
                .With(epd => epd.SipWritingprogressscore = _randomGenerator.Int())
                .With(epd => epd.SipWritingprogressscoredisadv = _randomGenerator.Int())
                .With(epd => epd.SipMeetingexpectedstandardinrwm = _randomGenerator.Int())
                .With(epd => epd.SipMeetingexpectedstandardinrwmdisadv = _randomGenerator.Int())
                .With(epd => epd.SipMeetinghigherstandardinrwm = _randomGenerator.Int())
                .With(epd => epd.SipMeetinghigherstandardrwmdisadv = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8score = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoredisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoreenglish = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoreenglishdisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoremaths = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoremathsdisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoreebacc = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoreebaccdisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipNumberofpupilsprogress8 = _randomGenerator.Int())
                .With(epd => epd.SipNumberofpupilsprogress8disadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipProgress8upperconfidence = _randomGenerator.Int())
                .With(epd => epd.SipProgress8lowerconfidence = _randomGenerator.Int())
                .With(epd => epd.SipProgress8english = _randomGenerator.Int())
                .With(epd => epd.SipProgress8englishdisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipProgress8maths = _randomGenerator.Int())
                .With(epd => epd.SipProgress8mathsdisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipProgress8ebacc = _randomGenerator.Int())
                .With(epd => epd.SipProgress8ebaccdisadvantaged = _randomGenerator.Int())
                .Build();
            
            var laAveragePerformanceData = Builder<SipEducationalperformancedata>.CreateNew()
                .With(epd => epd.SipParentaccountid = Guid.NewGuid())
                .With(epd => epd.SipName = year)
                .With(epd => epd.SipMathsprogressscore = _randomGenerator.Int())
                .With(epd => epd.SipMathsprogressscoredisadv = _randomGenerator.Int())
                .With(epd => epd.SipReadingprogressscore = _randomGenerator.Int())
                .With(epd => epd.SipReadingprogressscoredisadv = _randomGenerator.Int())
                .With(epd => epd.SipWritingprogressscore = _randomGenerator.Int())
                .With(epd => epd.SipWritingprogressscoredisadv = _randomGenerator.Int())
                .With(epd => epd.SipMeetingexpectedstandardinrwm = _randomGenerator.Int())
                .With(epd => epd.SipMeetingexpectedstandardinrwmdisadv = _randomGenerator.Int())
                .With(epd => epd.SipMeetinghigherstandardinrwm = _randomGenerator.Int())
                .With(epd => epd.SipMeetinghigherstandardrwmdisadv = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8score = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoredisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoreenglish = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoreenglishdisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoremaths = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoremathsdisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoreebacc = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoreebaccdisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipNumberofpupilsprogress8 = _randomGenerator.Int())
                .With(epd => epd.SipNumberofpupilsprogress8disadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipProgress8upperconfidence = _randomGenerator.Int())
                .With(epd => epd.SipProgress8lowerconfidence = _randomGenerator.Int())
                .With(epd => epd.SipProgress8english = _randomGenerator.Int())
                .With(epd => epd.SipProgress8englishdisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipProgress8maths = _randomGenerator.Int())
                .With(epd => epd.SipProgress8mathsdisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipProgress8ebacc = _randomGenerator.Int())
                .With(epd => epd.SipProgress8ebaccdisadvantaged = _randomGenerator.Int())
                .Build();


            var expectedKeyStage2Response = new KeyStage2PerformanceResponse
            {
                Year = educationalPerformanceData.SipName,
                PercentageMeetingExpectedStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationalPerformanceData.SipMeetingexpectedstandardinrwm.ToString(),
                    Disadvantaged = educationalPerformanceData.SipMeetingexpectedstandardinrwmdisadv.ToString()
                },
                PercentageAchievingHigherStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationalPerformanceData.SipMeetinghigherstandardinrwm.ToString(),
                    Disadvantaged = educationalPerformanceData.SipMeetinghigherstandardrwmdisadv.ToString()
                },
                ReadingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationalPerformanceData.SipReadingprogressscore.ToString(),
                    Disadvantaged = educationalPerformanceData.SipReadingprogressscoredisadv.ToString()
                },
                WritingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationalPerformanceData.SipWritingprogressscore.ToString(),
                    Disadvantaged = educationalPerformanceData.SipWritingprogressscoredisadv.ToString()
                },
                MathsProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationalPerformanceData.SipMathsprogressscore.ToString(),
                    Disadvantaged = educationalPerformanceData.SipMathsprogressscoredisadv.ToString()
                },
                NationalAveragePercentageMeetingExpectedStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalAveragePerformanceData.SipMeetingexpectedstandardinrwm.ToString(),
                    Disadvantaged = nationalAveragePerformanceData.SipMeetingexpectedstandardinrwmdisadv.ToString()
                },
                NationalAveragePercentageAchievingHigherStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalAveragePerformanceData.SipMeetinghigherstandardinrwm.ToString(),
                    Disadvantaged = nationalAveragePerformanceData.SipMeetinghigherstandardrwmdisadv.ToString()
                },
                NationalAverageReadingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalAveragePerformanceData?.SipReadingprogressscore.ToString(),
                    Disadvantaged = nationalAveragePerformanceData?.SipReadingprogressscoredisadv.ToString()
                },
                NationalAverageWritingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalAveragePerformanceData?.SipWritingprogressscore.ToString(),
                    Disadvantaged = nationalAveragePerformanceData?.SipWritingprogressscoredisadv.ToString()
                },
                NationalAverageMathsProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalAveragePerformanceData?.SipMathsprogressscore.ToString(),
                    Disadvantaged = nationalAveragePerformanceData?.SipMathsprogressscoredisadv.ToString()
                },
                LAAveragePercentageMeetingExpectedStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = laAveragePerformanceData?.SipMeetingexpectedstandardinrwm.ToString(),
                    Disadvantaged = laAveragePerformanceData?.SipMeetingexpectedstandardinrwmdisadv.ToString()
                },
                LAAveragePercentageAchievingHigherStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = laAveragePerformanceData?.SipMeetinghigherstandardinrwm.ToString(),
                    Disadvantaged = laAveragePerformanceData?.SipMeetinghigherstandardrwmdisadv.ToString()
                },
                LAAverageReadingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = laAveragePerformanceData?.SipReadingprogressscore.ToString(),
                    Disadvantaged = laAveragePerformanceData?.SipReadingprogressscoredisadv.ToString()
                },
                LAAverageWritingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = laAveragePerformanceData?.SipWritingprogressscore.ToString(),
                    Disadvantaged = laAveragePerformanceData?.SipWritingprogressscoredisadv.ToString()
                },
                LAAverageMathsProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = laAveragePerformanceData?.SipMathsprogressscore.ToString(),
                    Disadvantaged = laAveragePerformanceData?.SipMathsprogressscoredisadv.ToString()
                }
            };
            
            var result = KeyStage2PerformanceResponseFactory.Create(educationalPerformanceData, nationalAveragePerformanceData, laAveragePerformanceData);
             
            result.Should().BeEquivalentTo(expectedKeyStage2Response);
        }
        
         [Fact]
        public void KeyStage2ResponseFactory_CreatesKeyStage2Response_WithoutNationalAverage()
        {
            var year = _randomGenerator.DateTime().Year.ToString();
            
            var educationalPerformanceData = Builder<SipEducationalperformancedata>.CreateNew()
                .With(epd => epd.SipParentaccountid = Guid.NewGuid())
                .With(epd => epd.SipName = year)
                .With(epd => epd.SipMathsprogressscore = _randomGenerator.Int())
                .With(epd => epd.SipMathsprogressscoredisadv = _randomGenerator.Int())
                .With(epd => epd.SipReadingprogressscore = _randomGenerator.Int())
                .With(epd => epd.SipReadingprogressscoredisadv = _randomGenerator.Int())
                .With(epd => epd.SipWritingprogressscore = _randomGenerator.Int())
                .With(epd => epd.SipWritingprogressscoredisadv = _randomGenerator.Int())
                .With(epd => epd.SipMeetingexpectedstandardinrwm = _randomGenerator.Int())
                .With(epd => epd.SipMeetingexpectedstandardinrwmdisadv = _randomGenerator.Int())
                .With(epd => epd.SipMeetinghigherstandardinrwm = _randomGenerator.Int())
                .With(epd => epd.SipMeetinghigherstandardrwmdisadv = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8score = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoredisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoreenglish = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoreenglishdisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoremaths = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoremathsdisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoreebacc = _randomGenerator.Int())
                .With(epd => epd.SipAttainment8scoreebaccdisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipNumberofpupilsprogress8 = _randomGenerator.Int())
                .With(epd => epd.SipNumberofpupilsprogress8disadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipProgress8upperconfidence = _randomGenerator.Int())
                .With(epd => epd.SipProgress8lowerconfidence = _randomGenerator.Int())
                .With(epd => epd.SipProgress8english = _randomGenerator.Int())
                .With(epd => epd.SipProgress8englishdisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipProgress8maths = _randomGenerator.Int())
                .With(epd => epd.SipProgress8mathsdisadvantaged = _randomGenerator.Int())
                .With(epd => epd.SipProgress8ebacc = _randomGenerator.Int())
                .With(epd => epd.SipProgress8ebaccdisadvantaged = _randomGenerator.Int())
                .Build();

            var expectedKeyStage2Response = new KeyStage2PerformanceResponse
            {
                Year = educationalPerformanceData.SipName,
                PercentageMeetingExpectedStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationalPerformanceData.SipMeetingexpectedstandardinrwm.ToString(),
                    Disadvantaged = educationalPerformanceData.SipMeetingexpectedstandardinrwmdisadv.ToString()
                },
                PercentageAchievingHigherStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationalPerformanceData.SipMeetinghigherstandardinrwm.ToString(),
                    Disadvantaged = educationalPerformanceData.SipMeetinghigherstandardrwmdisadv.ToString()
                },
                ReadingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationalPerformanceData.SipReadingprogressscore.ToString(),
                    Disadvantaged = educationalPerformanceData.SipReadingprogressscoredisadv.ToString()
                },
                WritingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationalPerformanceData.SipWritingprogressscore.ToString(),
                    Disadvantaged = educationalPerformanceData.SipWritingprogressscoredisadv.ToString()
                },
                MathsProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationalPerformanceData.SipMathsprogressscore.ToString(),
                    Disadvantaged = educationalPerformanceData.SipMathsprogressscoredisadv.ToString()
                },
                NationalAveragePercentageMeetingExpectedStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                NationalAveragePercentageAchievingHigherStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                NationalAverageReadingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                NationalAverageWritingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                NationalAverageMathsProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                LAAveragePercentageMeetingExpectedStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                LAAveragePercentageAchievingHigherStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                LAAverageReadingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                LAAverageWritingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                LAAverageMathsProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                }
            };
            
            var result = KeyStage2PerformanceResponseFactory.Create(educationalPerformanceData, null, null);
             
            result.Should().BeEquivalentTo(expectedKeyStage2Response);
        }
    }
}
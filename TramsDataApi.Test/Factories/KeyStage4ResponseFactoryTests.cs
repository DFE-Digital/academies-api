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
    public class KeyStage4ResponseFactoryTests
    {
        private readonly RandomGenerator _randomGenerator;

        public KeyStage4ResponseFactoryTests()
        {
            BuilderSetup.SetDefaultPropertyName(new RandomValuePropertyNamer(new BuilderSettings()));
            _randomGenerator = new RandomGenerator();
        }

        [Fact]
        public void KeyStage4ResponseFactory_CreatesKeyStage4Response_FromEducationPerformanceData()
        {

            var year = _randomGenerator.DateTime().Year.ToString();
            var educationPerformanceData = Builder<SipEducationalperformancedata>.CreateNew()
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

            var nationalEducationPerformance = Builder<SipEducationalperformancedata>.CreateNew()
                .Build();
            
            var localAuthorityEducationPerformance = Builder<SipEducationalperformancedata>.CreateNew()
                .Build();

            var expectedKeyStage4Response = new KeyStage4PerformanceResponse
            {
                Year = educationPerformanceData.SipName,
                SipAttainment8score = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationPerformanceData.SipAttainment8score.ToString(),
                    Disadvantaged = educationPerformanceData.SipAttainment8scoredisadvantaged.ToString()
                },
                SipAttainment8scoreenglish = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationPerformanceData.SipAttainment8scoreenglish.ToString(),
                    Disadvantaged = educationPerformanceData.SipAttainment8scoreenglishdisadvantaged.ToString()
                },
                SipAttainment8scoremaths = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationPerformanceData.SipAttainment8scoremaths.ToString(),
                    Disadvantaged = educationPerformanceData.SipAttainment8scoremathsdisadvantaged.ToString()
                },
                SipAttainment8scoreebacc = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationPerformanceData.SipAttainment8scoreebacc.ToString(),
                    Disadvantaged = educationPerformanceData.SipAttainment8scoreebaccdisadvantaged.ToString()
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
                    NotDisadvantaged = educationPerformanceData.SipProgress8english.ToString(),
                    Disadvantaged = educationPerformanceData.SipProgress8englishdisadvantaged.ToString()
                },
                SipProgress8maths = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationPerformanceData.SipProgress8maths.ToString(),
                    Disadvantaged = educationPerformanceData.SipProgress8mathsdisadvantaged.ToString()
                },
                SipProgress8ebacc = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationPerformanceData.SipProgress8ebacc.ToString(),
                    Disadvantaged = educationPerformanceData.SipProgress8ebaccdisadvantaged.ToString()
                },
                SipProgress8Score = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationPerformanceData.SipProgress8score.ToString(),
                    Disadvantaged = educationPerformanceData.SipProgress8scoredisadvantaged.ToString()
                },
                Enteringebacc = educationPerformanceData.SipEnteringEbacc,
                NationalAverageA8Score = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalEducationPerformance?.SipAttainment8score.ToString(),
                    Disadvantaged = nationalEducationPerformance?.SipAttainment8scoredisadvantaged.ToString()
                },
                NationalAverageA8English = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalEducationPerformance?.SipAttainment8scoreenglish.ToString(),
                    Disadvantaged = nationalEducationPerformance?.SipAttainment8scoreenglishdisadvantaged.ToString()
                },
                NationalAverageA8Maths = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalEducationPerformance?.SipAttainment8scoremaths.ToString(),
                    Disadvantaged = nationalEducationPerformance?.SipAttainment8scoremathsdisadvantaged.ToString()
                },
                NationalAverageA8EBacc = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalEducationPerformance?.SipAttainment8scoreebacc.ToString(),
                    Disadvantaged = nationalEducationPerformance?.SipAttainment8scoreebaccdisadvantaged.ToString()
                },
                NationalAverageP8PupilsIncluded = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalEducationPerformance?.SipNumberofpupilsprogress8.ToString(),
                    Disadvantaged = nationalEducationPerformance?.SipNumberofpupilsprogress8disadvantaged.ToString()
                },
                NationalAverageP8Score = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalEducationPerformance?.SipProgress8score.ToString(),
                    Disadvantaged = nationalEducationPerformance?.SipProgress8scoredisadvantaged.ToString()
                },
                NationalAverageP8English = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalEducationPerformance?.SipProgress8english?.ToString(),
                    Disadvantaged = nationalEducationPerformance?.SipProgress8englishdisadvantaged.ToString()
                },
                NationalAverageP8Maths = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = 
                        nationalEducationPerformance?.SipProgress8maths?.ToString(),
                    Disadvantaged = nationalEducationPerformance?.SipProgress8mathsdisadvantaged.ToString().ToString()
                },
                NationalAverageP8Ebacc = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalEducationPerformance?.SipProgress8ebacc.ToString(),
                    Disadvantaged = nationalEducationPerformance?.SipProgress8ebaccdisadvantaged.ToString()
                },
                NationalAverageP8LowerConfidence = nationalEducationPerformance?.SipProgress8lowerconfidence,
                NationalAverageP8UpperConfidence = nationalEducationPerformance?.SipProgress8upperconfidence,
                NationalEnteringEbacc = nationalEducationPerformance?.SipEnteringEbacc,
                LAAverageA8Score = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = localAuthorityEducationPerformance?.SipAttainment8score.ToString(),
                    Disadvantaged = localAuthorityEducationPerformance?.SipAttainment8scoredisadvantaged.ToString()
                },
                LAAverageA8English = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = localAuthorityEducationPerformance?.SipAttainment8scoreenglish.ToString(),
                    Disadvantaged = localAuthorityEducationPerformance?.SipAttainment8scoreenglishdisadvantaged.ToString()
                },
                LAAverageA8Maths = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = localAuthorityEducationPerformance?.SipAttainment8scoremaths.ToString(),
                    Disadvantaged = localAuthorityEducationPerformance?.SipAttainment8scoremathsdisadvantaged.ToString()
                },
                LAAverageA8EBacc = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = localAuthorityEducationPerformance?.SipAttainment8scoreebacc.ToString(),
                    Disadvantaged = localAuthorityEducationPerformance?.SipAttainment8scoreebaccdisadvantaged.ToString()
                },
                LAAverageP8PupilsIncluded = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = localAuthorityEducationPerformance?.SipNumberofpupilsprogress8.ToString(),
                    Disadvantaged = localAuthorityEducationPerformance?.SipNumberofpupilsprogress8disadvantaged.ToString()
                },
                LAAverageP8Score = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = localAuthorityEducationPerformance?.SipProgress8score.ToString(),
                    Disadvantaged = localAuthorityEducationPerformance?.SipProgress8scoredisadvantaged.ToString()
                },
                LAAverageP8English = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = localAuthorityEducationPerformance?.SipProgress8english?.ToString(),
                    Disadvantaged = localAuthorityEducationPerformance?.SipProgress8englishdisadvantaged.ToString()
                },
                LAAverageP8Maths = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = 
                        localAuthorityEducationPerformance?.SipProgress8maths?.ToString(),
                    Disadvantaged = localAuthorityEducationPerformance?.SipProgress8mathsdisadvantaged.ToString().ToString()
                },
                LAAverageP8Ebacc = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = localAuthorityEducationPerformance?.SipProgress8ebacc.ToString(),
                    Disadvantaged = localAuthorityEducationPerformance?.SipProgress8ebaccdisadvantaged.ToString()
                },
                LAAverageP8LowerConfidence = localAuthorityEducationPerformance?.SipProgress8lowerconfidence,
                LAAverageP8UpperConfidence = localAuthorityEducationPerformance?.SipProgress8upperconfidence,
                LAEnteringEbacc = localAuthorityEducationPerformance?.SipEnteringEbacc
            };

            var result = KeyStage4PerformanceResponseFactory.Create(educationPerformanceData, nationalEducationPerformance, localAuthorityEducationPerformance);
             
            result.Should().BeEquivalentTo(expectedKeyStage4Response);
        }
        
        [Fact]
        public void KeyStage4ResponseFactory_CreatesKeyStage4ResponseWithEmptyNationalData_FromJustEducationPerformanceData()
        {

            var year = _randomGenerator.DateTime().Year.ToString();
            var educationPerformanceData = Builder<SipEducationalperformancedata>.CreateNew()
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
            

            var expectedKeyStage4Response = new KeyStage4PerformanceResponse
            {
                Year = educationPerformanceData.SipName,
                SipAttainment8score = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationPerformanceData.SipAttainment8score.ToString(),
                    Disadvantaged = educationPerformanceData.SipAttainment8scoredisadvantaged.ToString()
                },
                SipAttainment8scoreenglish = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationPerformanceData.SipAttainment8scoreenglish.ToString(),
                    Disadvantaged = educationPerformanceData.SipAttainment8scoreenglishdisadvantaged.ToString()
                },
                SipAttainment8scoremaths = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationPerformanceData.SipAttainment8scoremaths.ToString(),
                    Disadvantaged = educationPerformanceData.SipAttainment8scoremathsdisadvantaged.ToString()
                },
                SipAttainment8scoreebacc = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationPerformanceData.SipAttainment8scoreebacc.ToString(),
                    Disadvantaged = educationPerformanceData.SipAttainment8scoreebaccdisadvantaged.ToString()
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
                    NotDisadvantaged = educationPerformanceData.SipProgress8english.ToString(),
                    Disadvantaged = educationPerformanceData.SipProgress8englishdisadvantaged.ToString()
                },
                SipProgress8maths = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationPerformanceData.SipProgress8maths.ToString(),
                    Disadvantaged = educationPerformanceData.SipProgress8mathsdisadvantaged.ToString()
                },
                SipProgress8ebacc = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationPerformanceData.SipProgress8ebacc.ToString(),
                    Disadvantaged = educationPerformanceData.SipProgress8ebaccdisadvantaged.ToString()
                },
                SipProgress8Score = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationPerformanceData.SipProgress8score.ToString(),
                    Disadvantaged = educationPerformanceData.SipProgress8scoredisadvantaged.ToString()
                },
                Enteringebacc = educationPerformanceData.SipEnteringEbacc,
                NationalAverageA8Score = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                NationalAverageA8English = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                NationalAverageA8Maths = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                NationalAverageA8EBacc = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                NationalAverageP8PupilsIncluded = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                NationalAverageP8Score = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                NationalAverageP8English = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                NationalAverageP8Maths = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                NationalAverageP8Ebacc = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                NationalAverageP8LowerConfidence = null,
                NationalAverageP8UpperConfidence = null,
                
                LAAverageA8Score = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                LAAverageA8English = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                LAAverageA8Maths = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                LAAverageA8EBacc = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                LAAverageP8PupilsIncluded = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                LAAverageP8Score = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                LAAverageP8English = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                LAAverageP8Maths = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                LAAverageP8Ebacc = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                },
                LAAverageP8LowerConfidence = null,
                LAAverageP8UpperConfidence = null,
            };

            var result = KeyStage4PerformanceResponseFactory.Create(educationPerformanceData, null, null);
             
            result.Should().BeEquivalentTo(expectedKeyStage4Response);
        }
    }
}
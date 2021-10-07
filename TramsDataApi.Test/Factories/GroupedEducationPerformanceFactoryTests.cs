using FizzWare.NBuilder;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories.EducationPerformanceFactories;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class GroupedEducationPerformanceFactoryTests
    {
        private readonly RandomGenerator _randomGenerator;

        public GroupedEducationPerformanceFactoryTests()
        {
            _randomGenerator = new RandomGenerator();
        }

        [Fact]
        public void GroupedEducationPerformanceFactory_CanGroupMultipleEducationPerformanceObjects()
        {
            var year = "2017-2018";
            var nationalEducationPerformanceData1 = Builder<SipEducationalperformancedata>.CreateNew()
                .With(nepd => nepd.SipParentaccountid = null)
                .With(nepd => nepd.SipPerformancetype = null)
                .With(nepd => nepd.SipName = year)
                .With(nepd => nepd.SipMathsprogressscore = _randomGenerator.Int())
                .With(nepd => nepd.SipMathsprogressscoredisadv = _randomGenerator.Int())
                .With(nepd => nepd.SipReadingprogressscore = _randomGenerator.Int())
                .With(nepd => nepd.SipReadingprogressscoredisadv = _randomGenerator.Int())
                .With(nepd => nepd.SipWritingprogressscore = _randomGenerator.Int())
                .With(nepd => nepd.SipWritingprogressscoredisadv = _randomGenerator.Int())
                .With(nepd => nepd.SipMeetingexpectedstandardinrwm = _randomGenerator.Int())
                .With(nepd => nepd.SipMeetingexpectedstandardinrwmdisadv = _randomGenerator.Int())
                .With(nepd => nepd.SipMeetinghigherstandardinrwm = _randomGenerator.Int())
                .With(nepd => nepd.SipMeetinghigherstandardrwmdisadv = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8score = null)
                .With(nepd => nepd.SipAttainment8scoredisadvantaged = null)
                .With(nepd => nepd.SipAttainment8scoreenglish = null)
                .With(nepd => nepd.SipAttainment8scoreenglishdisadvantaged = null)
                .With(nepd => nepd.SipAttainment8scoremaths = null)
                .With(nepd => nepd.SipAttainment8scoremathsdisadvantaged = null)
                .With(nepd => nepd.SipAttainment8scoreebacc = null)
                .With(nepd => nepd.SipAttainment8scoreebaccdisadvantaged = null)
                .With(nepd => nepd.SipNumberofpupilsprogress8 = _randomGenerator.Int())
                .With(nepd => nepd.SipNumberofpupilsprogress8disadvantaged = _randomGenerator.Int())
                .With(nepd => nepd.SipProgress8upperconfidence = _randomGenerator.Int())
                .With(nepd => nepd.SipProgress8lowerconfidence = _randomGenerator.Int())
                .With(nepd => nepd.SipProgress8english = _randomGenerator.Int())
                .With(nepd => nepd.SipProgress8englishdisadvantaged = _randomGenerator.Int())
                .With(nepd => nepd.SipProgress8maths = _randomGenerator.Int())
                .With(nepd => nepd.SipProgress8mathsdisadvantaged = _randomGenerator.Int())
                .With(nepd => nepd.SipProgress8ebacc = _randomGenerator.Int())
                .With(nepd => nepd.SipProgress8ebaccdisadvantaged = _randomGenerator.Int())
                .Build();
            
            var nationalEducationPerformanceData2 = Builder<SipEducationalperformancedata>.CreateNew()
                .With(nepd => nepd.SipParentaccountid = null)
                .With(nepd => nepd.SipPerformancetype = null)
                .With(nepd => nepd.SipName = year)
                .With(nepd => nepd.SipMathsprogressscore = null)
                .With(nepd => nepd.SipMathsprogressscoredisadv = null)
                .With(nepd => nepd.SipReadingprogressscore = null)
                .With(nepd => nepd.SipReadingprogressscoredisadv = null)
                .With(nepd => nepd.SipWritingprogressscore = null)
                .With(nepd => nepd.SipWritingprogressscoredisadv = null)
                .With(nepd => nepd.SipMeetingexpectedstandardinrwm = null)
                .With(nepd => nepd.SipMeetingexpectedstandardinrwmdisadv = null)
                .With(nepd => nepd.SipMeetinghigherstandardinrwm = null)
                .With(nepd => nepd.SipMeetinghigherstandardrwmdisadv = null)
                .With(nepd => nepd.SipAttainment8score = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoredisadvantaged = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoreenglish = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoreenglishdisadvantaged = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoremaths = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoremathsdisadvantaged = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoreebacc = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoreebaccdisadvantaged = _randomGenerator.Int())
                .With(nepd => nepd.SipNumberofpupilsprogress8 = null)
                .With(nepd => nepd.SipNumberofpupilsprogress8disadvantaged = null)
                .With(nepd => nepd.SipProgress8upperconfidence = null)
                .With(nepd => nepd.SipProgress8lowerconfidence = null)
                .With(nepd => nepd.SipProgress8english = null)
                .With(nepd => nepd.SipProgress8englishdisadvantaged = null)
                .With(nepd => nepd.SipProgress8maths = null)
                .With(nepd => nepd.SipProgress8mathsdisadvantaged = null)
                .With(nepd => nepd.SipProgress8ebacc = null)
                .With(nepd => nepd.SipProgress8ebaccdisadvantaged = null)
                .Build();
            
            var expected = Builder<SipEducationalperformancedata>.CreateNew()
                .With(nepd => nepd.SipParentaccountid = null)
                .With(nepd => nepd.SipPerformancetype = null)
                .With(nepd => nepd.SipName = year)
                .With(nepd => nepd.SipMathsprogressscore = nationalEducationPerformanceData1.SipMathsprogressscore)
                .With(nepd => nepd.SipMathsprogressscoredisadv = nationalEducationPerformanceData1.SipMathsprogressscoredisadv)
                .With(nepd => nepd.SipReadingprogressscore = nationalEducationPerformanceData1.SipReadingprogressscore)
                .With(nepd => nepd.SipReadingprogressscoredisadv = nationalEducationPerformanceData1.SipReadingprogressscoredisadv)
                .With(nepd => nepd.SipWritingprogressscore = nationalEducationPerformanceData1.SipWritingprogressscore)
                .With(nepd => nepd.SipWritingprogressscoredisadv = nationalEducationPerformanceData1.SipWritingprogressscoredisadv)
                .With(nepd => nepd.SipMeetingexpectedstandardinrwm = nationalEducationPerformanceData1.SipMeetingexpectedstandardinrwm)
                .With(nepd => nepd.SipMeetingexpectedstandardinrwmdisadv = nationalEducationPerformanceData1.SipMeetingexpectedstandardinrwmdisadv)
                .With(nepd => nepd.SipMeetinghigherstandardinrwm = nationalEducationPerformanceData1.SipMeetinghigherstandardinrwm)
                .With(nepd => nepd.SipMeetinghigherstandardrwmdisadv = nationalEducationPerformanceData1.SipMeetinghigherstandardrwmdisadv)
                .With(nepd => nepd.SipAttainment8score = nationalEducationPerformanceData2.SipAttainment8score)
                .With(nepd => nepd.SipAttainment8scoredisadvantaged = nationalEducationPerformanceData2.SipAttainment8scoredisadvantaged)
                .With(nepd => nepd.SipAttainment8scoreenglish = nationalEducationPerformanceData2.SipAttainment8scoreenglish)
                .With(nepd => nepd.SipAttainment8scoreenglishdisadvantaged = nationalEducationPerformanceData2.SipAttainment8scoreenglishdisadvantaged)
                .With(nepd => nepd.SipAttainment8scoremaths = nationalEducationPerformanceData2.SipAttainment8scoremaths)
                .With(nepd => nepd.SipAttainment8scoremathsdisadvantaged = nationalEducationPerformanceData2.SipAttainment8scoremathsdisadvantaged)
                .With(nepd => nepd.SipAttainment8scoreebacc = nationalEducationPerformanceData2.SipAttainment8scoreebacc)
                .With(nepd => nepd.SipAttainment8scoreebaccdisadvantaged = nationalEducationPerformanceData2.SipAttainment8scoreebaccdisadvantaged)
                .With(nepd => nepd.SipNumberofpupilsprogress8 = nationalEducationPerformanceData1.SipNumberofpupilsprogress8)
                .With(nepd => nepd.SipNumberofpupilsprogress8disadvantaged = nationalEducationPerformanceData1.SipNumberofpupilsprogress8disadvantaged)
                .With(nepd => nepd.SipProgress8upperconfidence = nationalEducationPerformanceData1.SipProgress8upperconfidence)
                .With(nepd => nepd.SipProgress8lowerconfidence = nationalEducationPerformanceData1.SipProgress8lowerconfidence)
                .With(nepd => nepd.SipProgress8english = nationalEducationPerformanceData1.SipProgress8english)
                .With(nepd => nepd.SipProgress8englishdisadvantaged = nationalEducationPerformanceData1.SipProgress8englishdisadvantaged)
                .With(nepd => nepd.SipProgress8maths = nationalEducationPerformanceData1.SipProgress8maths)
                .With(nepd => nepd.SipProgress8mathsdisadvantaged = nationalEducationPerformanceData1.SipProgress8mathsdisadvantaged)
                .With(nepd => nepd.SipProgress8ebacc = nationalEducationPerformanceData1.SipProgress8ebacc)
                .With(nepd => nepd.SipProgress8ebaccdisadvantaged = nationalEducationPerformanceData1.SipProgress8ebaccdisadvantaged)
                .Build();

            var result = GroupedEducationPerformanceFactory.Create(nationalEducationPerformanceData1,
                nationalEducationPerformanceData2);
            
            result.Should().BeEquivalentTo(result);
        }
    }
}
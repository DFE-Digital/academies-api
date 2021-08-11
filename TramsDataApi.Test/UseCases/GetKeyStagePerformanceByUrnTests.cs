using System;
using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using FizzWare.NBuilder.PropertyNaming;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.EducationalPerformance;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class GetKeyStagePerformanceByUrnTests
    {
        private RandomGenerator _randomGenerator;

        public GetKeyStagePerformanceByUrnTests()
        {
            _randomGenerator = new RandomGenerator();
        }
        
        [Fact]
        public void TestGetKeyStagePerformanceByUrn_ReturnsNull_WhenNoAccountIsFound()
        {
            var urn = "mockurn";
            var mockEducationPerformanceGateway = new Mock<IEducationPerformanceGateway>();
            mockEducationPerformanceGateway.Setup(gateway => gateway.GetAccountByUrn(urn)).Returns(() => null);
            var useCase = new GetKeyStagePerformanceByUrn(mockEducationPerformanceGateway.Object);

            useCase.Execute(urn).Should().BeNull();
        }
        
        [Fact]
        public void TestGetKeyStagePerformanceByUrn_ReturnsAEducationPerformanceResponse_WhenDataIsFound()
        {
            var urn = "123453";
            var guid = Guid.NewGuid();
            var year = "2017-2018";
            
            var account = Builder<Account>.CreateNew()
                .With(a => a.SipUrn = urn)
                .With(a => a.Id = guid)
                .Build();
            var phonics = Builder<SipPhonics>.CreateListOfSize(5)
                .All()
                .With(ph => ph.SipUrn = urn)
                .Build();

            var educationPerformanceData = Builder<SipEducationalperformancedata>.CreateNew()
                .With(epd => epd.SipParentaccountid = guid)
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

            var nationalEducationPerformanceData1 = Builder<SipEducationalperformancedata>.CreateNew()
                .With(nepd => nepd.SipParentaccountid = null)
                .With(nepd => nepd.SipPerformancetype = _randomGenerator.Int())
                .With(nepd => nepd.SipName = "2018-2019")
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
                .With(nepd => nepd.SipAttainment8score = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoredisadvantaged = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoreenglish = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoreenglishdisadvantaged = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoremaths = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoremathsdisadvantaged = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoreebacc = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoreebaccdisadvantaged = _randomGenerator.Int())
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
                .With(nepd => nepd.SipParentaccountid = guid)
                .With(nepd => nepd.SipPerformancetype = _randomGenerator.Int())
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
            
            var nationalEducationPerformanceData3 = Builder<SipEducationalperformancedata>.CreateNew()
                .With(nepd => nepd.SipParentaccountid = guid)
                .With(nepd => nepd.SipPerformancetype = _randomGenerator.Int())
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
                .With(nepd => nepd.SipAttainment8score = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoredisadvantaged = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoreenglish = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoreenglishdisadvantaged = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoremaths = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoremathsdisadvantaged = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoreebacc = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoreebaccdisadvantaged = _randomGenerator.Int())
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

            var nationalEducationPerformanceDataList = new List<SipEducationalperformancedata>
            {
                nationalEducationPerformanceData1,
                nationalEducationPerformanceData2,
                nationalEducationPerformanceData3

            };
            
             var localAuthorityEducationPerformance = Builder<SipEducationalperformancedata>.CreateNew()
                .With(nepd => nepd.SipParentaccountid = guid)
                .With(nepd => nepd.SipPerformancetype = _randomGenerator.Int())
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
                .With(nepd => nepd.SipAttainment8score = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoredisadvantaged = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoreenglish = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoreenglishdisadvantaged = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoremaths = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoremathsdisadvantaged = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoreebacc = _randomGenerator.Int())
                .With(nepd => nepd.SipAttainment8scoreebaccdisadvantaged = _randomGenerator.Int())
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

             var localAuthorityPerformanceDataList = new List<SipEducationalperformancedata>
                 {localAuthorityEducationPerformance};
            
            var mockEducationPerformanceGateway = new Mock<IEducationPerformanceGateway>();
            mockEducationPerformanceGateway.Setup(gateway => gateway.GetAccountByUrn(urn)).Returns(() => account);
            mockEducationPerformanceGateway.Setup(gateway => gateway.GetPhonicsByUrn(urn)).Returns(() => phonics);
            mockEducationPerformanceGateway.Setup(gateway => gateway.GetEducationalPerformanceForAccount(account)).Returns(() => new List<SipEducationalperformancedata> {educationPerformanceData});
            mockEducationPerformanceGateway.Setup(gateway => gateway.GetNationalEducationalPerformanceData()).Returns(nationalEducationPerformanceDataList);
            mockEducationPerformanceGateway.Setup(gateway => gateway.GetLocalAuthorityEducationalPerformanceData(account)).Returns(localAuthorityPerformanceDataList);

            
            var expectedKs1 = phonics.Select(ph => new KeyStage1PerformanceResponse
            {
                Year = ph.SipYear,
                Reading = ph.SipKs1readingpercentageresults,
                Writing = ph.SipKs1writingpercentageresults,
                Maths = ph.SipKs1mathspercentageresults
            }).ToList();

            var expectedKs2 = new KeyStage2PerformanceResponse
            {
                Year = educationPerformanceData.SipName,
                PercentageMeetingExpectedStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationPerformanceData.SipMeetingexpectedstandardinrwm.ToString(),
                    Disadvantaged = educationPerformanceData.SipMeetingexpectedstandardinrwmdisadv.ToString()
                },
                PercentageAchievingHigherStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationPerformanceData.SipMeetinghigherstandardinrwm.ToString(),
                    Disadvantaged = educationPerformanceData.SipMeetinghigherstandardrwmdisadv.ToString()
                },
                ReadingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationPerformanceData.SipReadingprogressscore.ToString(),
                    Disadvantaged = educationPerformanceData.SipReadingprogressscoredisadv.ToString()
                },
                WritingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationPerformanceData.SipWritingprogressscore.ToString(),
                    Disadvantaged = educationPerformanceData.SipWritingprogressscoredisadv.ToString()
                },
                MathsProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationPerformanceData.SipMathsprogressscore.ToString(),
                    Disadvantaged = educationPerformanceData.SipMathsprogressscoredisadv.ToString()
                },
                NationalAveragePercentageMeetingExpectedStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalEducationPerformanceData2?.SipMeetingexpectedstandardinrwm.ToString(),
                    Disadvantaged = nationalEducationPerformanceData2?.SipMeetingexpectedstandardinrwmdisadv.ToString()
                },
                NationalAveragePercentageAchievingHigherStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalEducationPerformanceData2?.SipMeetinghigherstandardinrwm.ToString(),
                    Disadvantaged = nationalEducationPerformanceData2?.SipMeetinghigherstandardrwmdisadv.ToString()
                },
                NationalAverageReadingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalEducationPerformanceData2?.SipReadingprogressscore.ToString(),
                    Disadvantaged = nationalEducationPerformanceData2?.SipReadingprogressscoredisadv.ToString()
                },
                NationalAverageWritingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalEducationPerformanceData2?.SipWritingprogressscore.ToString(),
                    Disadvantaged = nationalEducationPerformanceData2?.SipWritingprogressscoredisadv.ToString()
                },
                NationalAverageMathsProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalEducationPerformanceData2?.SipMathsprogressscore.ToString(),
                    Disadvantaged = nationalEducationPerformanceData2?.SipMathsprogressscoredisadv.ToString()
                },
                LAAveragePercentageMeetingExpectedStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = localAuthorityEducationPerformance?.SipMeetingexpectedstandardinrwm.ToString(),
                    Disadvantaged = localAuthorityEducationPerformance?.SipMeetingexpectedstandardinrwmdisadv.ToString()
                },
                LAAveragePercentageAchievingHigherStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = localAuthorityEducationPerformance?.SipMeetinghigherstandardinrwm.ToString(),
                    Disadvantaged = localAuthorityEducationPerformance?.SipMeetinghigherstandardrwmdisadv.ToString()
                },
                LAAverageReadingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = localAuthorityEducationPerformance?.SipReadingprogressscore.ToString(),
                    Disadvantaged = localAuthorityEducationPerformance?.SipReadingprogressscoredisadv.ToString()
                },
                LAAverageWritingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = localAuthorityEducationPerformance?.SipWritingprogressscore.ToString(),
                    Disadvantaged = localAuthorityEducationPerformance?.SipWritingprogressscoredisadv.ToString()
                },
                LAAverageMathsProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = localAuthorityEducationPerformance?.SipMathsprogressscore.ToString(),
                    Disadvantaged = localAuthorityEducationPerformance?.SipMathsprogressscoredisadv.ToString()
                }
            };

            var expectedKs4 = new KeyStage4PerformanceResponse
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
                    NotDisadvantaged = nationalEducationPerformanceData3?.SipAttainment8score.ToString(),
                    Disadvantaged = nationalEducationPerformanceData3?.SipAttainment8scoredisadvantaged.ToString()
                },
                NationalAverageA8English = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalEducationPerformanceData3?.SipAttainment8scoreenglish.ToString(),
                    Disadvantaged = nationalEducationPerformanceData3?.SipAttainment8scoreenglishdisadvantaged.ToString()
                },
                NationalAverageA8Maths = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalEducationPerformanceData3?.SipAttainment8scoremaths.ToString(),
                    Disadvantaged = nationalEducationPerformanceData3?.SipAttainment8scoremathsdisadvantaged.ToString()
                },
                NationalAverageA8EBacc = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalEducationPerformanceData3?.SipAttainment8scoreebacc.ToString(),
                    Disadvantaged = nationalEducationPerformanceData3?.SipAttainment8scoreebaccdisadvantaged.ToString()
                },
                NationalAverageP8PupilsIncluded = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalEducationPerformanceData2?.SipNumberofpupilsprogress8.ToString(),
                    Disadvantaged = nationalEducationPerformanceData2?.SipNumberofpupilsprogress8disadvantaged.ToString()
                },
                NationalAverageP8Score = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalEducationPerformanceData2?.SipProgress8score.ToString(),
                    Disadvantaged = nationalEducationPerformanceData2?.SipProgress8scoredisadvantaged.ToString()
                },
                NationalAverageP8English = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalEducationPerformanceData2?.SipProgress8english?.ToString(),
                    Disadvantaged = nationalEducationPerformanceData2?.SipProgress8englishdisadvantaged.ToString()
                },
                NationalAverageP8Maths = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = 
                        nationalEducationPerformanceData2?.SipProgress8maths?.ToString(),
                    Disadvantaged = nationalEducationPerformanceData2?.SipProgress8mathsdisadvantaged.ToString().ToString()
                },
                NationalAverageP8Ebacc = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalEducationPerformanceData2?.SipProgress8ebacc.ToString(),
                    Disadvantaged = nationalEducationPerformanceData2?.SipProgress8ebaccdisadvantaged.ToString()
                },
                NationalAverageP8LowerConfidence = nationalEducationPerformanceData2?.SipProgress8lowerconfidence,
                NationalAverageP8UpperConfidence = nationalEducationPerformanceData2?.SipProgress8upperconfidence,
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
            };

            var expectedKS5 = new KeyStage5PerformanceResponse
            {
                Year = educationPerformanceData.SipName,
                AcademicQualificationAverage = educationPerformanceData.SipAcademicLevelAveragePspe,
                AppliedGeneralQualificationAverage = educationPerformanceData.SipAppliedGeneralAveragePspe,
                NationalAcademicQualificationAverage = nationalEducationPerformanceData2.SipAcademicLevelAveragePspe,
                NationalAppliedGeneralQualificationAverage = nationalEducationPerformanceData2.SipAppliedGeneralAveragePspe,
                LAAcademicQualificationAverage = localAuthorityEducationPerformance?.SipAcademicLevelAveragePspe,
                LAAppliedGeneralQualificationAverage = localAuthorityEducationPerformance?.SipAppliedGeneralAveragePspe
            };
            
            var expected = new EducationalPerformanceResponse
            {
                SchoolName = account.Name,
                KeyStage1 = expectedKs1,
                KeyStage2 = new List<KeyStage2PerformanceResponse>{ expectedKs2 },
                KeyStage4 = new List<KeyStage4PerformanceResponse>{ expectedKs4 },
                KeyStage5 = new List<KeyStage5PerformanceResponse>{ expectedKS5 }
            };
            
            var useCase = new GetKeyStagePerformanceByUrn(mockEducationPerformanceGateway.Object);
            var result = useCase.Execute(urn);
            
            result.Should().BeEquivalentTo(expected);
        }
    }
}
using System;
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
            var account = Builder<Account>.CreateNew()
                .With(a => a.SipUrn = urn)
                .With(a => a.Id = guid)
                .Build();
            var phonics = Builder<SipPhonics>.CreateListOfSize(5)
                .All()
                .With(ph => ph.SipUrn = urn)
                .Build();

            var educationPerformanceData = Builder<SipEducationalperformancedata>.CreateListOfSize(1)
                .All()
                .With(epd => epd.SipParentaccountid = guid)
                .With(epd => epd.SipName = _randomGenerator.DateTime().Year.ToString())
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
            
            var mockEducationPerformanceGateway = new Mock<IEducationPerformanceGateway>();
            mockEducationPerformanceGateway.Setup(gateway => gateway.GetAccountByUrn(urn)).Returns(() => account);
            mockEducationPerformanceGateway.Setup(gateway => gateway.GetPhonicsByUrn(urn)).Returns(() => phonics);
            mockEducationPerformanceGateway.Setup(gateway => gateway.GetEducationalPerformanceForAccount(account)).Returns(() => educationPerformanceData);

            var expectedKs1 = phonics.Select(ph => new KeyStage1PerformanceResponse
            {
                Year = ph.SipYear,
                Reading = ph.SipKs1readingpercentageresults,
                Writing = ph.SipKs1writingpercentageresults,
                Maths = ph.SipKs1mathspercentageresults
            }).ToList();

            var expectedKs2 = educationPerformanceData
                .Select(epd => new KeyStage2PerformanceResponse
            {
                Year = epd.SipName,
                PercentageMeetingExpectedStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = epd.SipMeetingexpectedstandardinrwm.ToString(),
                    Disadvantaged = epd.SipMeetingexpectedstandardinrwmdisadv.ToString()
                },
                PercentageAchievingHigherStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = epd.SipMeetinghigherstandardinrwm.ToString(),
                    Disadvantaged = epd.SipMeetinghigherstandardrwmdisadv.ToString()
                },
                ReadingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = epd.SipReadingprogressscore.ToString(),
                    Disadvantaged = epd.SipReadingprogressscoredisadv.ToString()
                },
                WritingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = epd.SipWritingprogressscore.ToString(),
                    Disadvantaged = epd.SipWritingprogressscoredisadv.ToString()
                },
                MathsProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = epd.SipMathsprogressscore.ToString(),
                    Disadvantaged = epd.SipMathsprogressscoredisadv.ToString()
                }
            }).ToList();

            var expectedKs4 = educationPerformanceData
                .Select(epd => KeyStage4PerformanceResponseFactory.Create(epd)).ToList();
            
            var expected = new EducationalPerformanceResponse
            {
                SchoolName = account.Name,
                KeyStage1 = expectedKs1,
                KeyStage2 = expectedKs2,
                KeyStage4 = expectedKs4
            };
            
            var useCase = new GetKeyStagePerformanceByUrn(mockEducationPerformanceGateway.Object);
            var result = useCase.Execute(urn);
            
            result.Should().BeEquivalentTo(expected);
        }
    }
}
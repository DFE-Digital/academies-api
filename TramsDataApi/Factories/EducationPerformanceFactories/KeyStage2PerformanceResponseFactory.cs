using TramsDataApi.DatabaseModels;
using System.Globalization;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.EducationalPerformance;

namespace TramsDataApi.Factories
{
    public class KeyStage2PerformanceResponseFactory
    {
        public static KeyStage2PerformanceResponse Create(SipEducationalperformancedata educationalPerformanceData)
        {
            if (educationalPerformanceData == null)
            {
                return null;
            }

            return new KeyStage2PerformanceResponse
            {
                Year = educationalPerformanceData.SipName,
                PercentageMeetingExpectedStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationalPerformanceData.SipMeetingexpectedstandardinrwm,
                    Disadvantaged = educationalPerformanceData.SipMeetingexpectedstandardinrwmdisadv
                },
                PercentageAchievingHigherStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationalPerformanceData.SipMeetinghigherstandardinrwm,
                    Disadvantaged = educationalPerformanceData.SipMeetinghigherstandardrwmdisadv
                },
                ReadingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationalPerformanceData.SipReadingprogressscore,
                    Disadvantaged = educationalPerformanceData.SipReadingprogressscoredisadv
                },
                WritingProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationalPerformanceData.SipWritingprogressscore,
                    Disadvantaged = educationalPerformanceData.SipWritingprogressscoredisadv
                },
                MathsProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = educationalPerformanceData.SipMathsprogressscore,
                    Disadvantaged = educationalPerformanceData.SipMathsprogressscoredisadv
                }
            };
        }

    }
}
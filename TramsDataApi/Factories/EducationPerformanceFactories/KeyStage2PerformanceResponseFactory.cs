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
                }
            };
        }

    }
}
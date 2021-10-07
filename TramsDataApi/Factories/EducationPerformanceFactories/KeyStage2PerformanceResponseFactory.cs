using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.EducationalPerformance;

namespace TramsDataApi.Factories.EducationPerformanceFactories
{
    public static class KeyStage2PerformanceResponseFactory
    {
        public static KeyStage2PerformanceResponse Create(SipEducationalperformancedata educationalPerformanceData, 
            SipEducationalperformancedata nationalAveragePerformanceData,
            SipEducationalperformancedata laAveragePerformanceData)
        {
            if (educationalPerformanceData == null) return null;

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
                },
                NationalAveragePercentageMeetingExpectedStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalAveragePerformanceData?.SipMeetingexpectedstandardinrwm.ToString(),
                    Disadvantaged = nationalAveragePerformanceData?.SipMeetingexpectedstandardinrwmdisadv.ToString()
                },
                NationalAveragePercentageAchievingHigherStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = nationalAveragePerformanceData?.SipMeetinghigherstandardinrwm.ToString(),
                    Disadvantaged = nationalAveragePerformanceData?.SipMeetinghigherstandardrwmdisadv.ToString()
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
        }

    }
}
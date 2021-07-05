using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Factories
{
    public class GroupedEducationPerformanceFactory
    {
        public static SipEducationalperformancedata Create(SipEducationalperformancedata nationalEducationPerformance1,
            SipEducationalperformancedata nationalEducationPerformance2)
        {
            return new SipEducationalperformancedata
                {
                    Id = nationalEducationPerformance1.Id,
                    SipName = nationalEducationPerformance1.SipName,
                    SipMeetingexpectedstandardinrwm = nationalEducationPerformance1.SipMeetingexpectedstandardinrwm ?? nationalEducationPerformance2.SipMeetingexpectedstandardinrwm,
                    SipMeetingexpectedstandardinrwmdisadv = nationalEducationPerformance1.SipMeetingexpectedstandardinrwmdisadv ?? nationalEducationPerformance2.SipMeetingexpectedstandardinrwmdisadv,
                    SipMeetinghigherstandardinrwm = nationalEducationPerformance1.SipMeetinghigherstandardinrwm ?? nationalEducationPerformance2.SipMeetinghigherstandardinrwm,
                    SipMeetinghigherstandardrwmdisadv = nationalEducationPerformance1.SipMeetinghigherstandardrwmdisadv ?? nationalEducationPerformance2.SipMeetinghigherstandardrwmdisadv,
                    SipProgress8score = nationalEducationPerformance1.SipProgress8score ?? nationalEducationPerformance2.SipProgress8score,
                    SipProgress8scoredisadvantaged = nationalEducationPerformance1.SipProgress8scoredisadvantaged ?? nationalEducationPerformance2.SipProgress8scoredisadvantaged,
                    SipParentaccountid = nationalEducationPerformance1.SipParentaccountid,
                    SipReadingprogressscore = nationalEducationPerformance1.SipReadingprogressscore ?? nationalEducationPerformance2.SipReadingprogressscore,
                    SipReadingprogressscoredisadv = nationalEducationPerformance1.SipReadingprogressscoredisadv ?? nationalEducationPerformance2.SipReadingprogressscoredisadv,
                    SipWritingprogressscoredisadv = nationalEducationPerformance1.SipWritingprogressscoredisadv ?? nationalEducationPerformance2.SipWritingprogressscoredisadv,
                    SipWritingprogressscore = nationalEducationPerformance1.SipWritingprogressscore ?? nationalEducationPerformance2.SipWritingprogressscore,
                    SipMathsprogressscore = nationalEducationPerformance1.SipMathsprogressscore ?? nationalEducationPerformance2.SipMathsprogressscore,
                    SipMathsprogressscoredisadv = nationalEducationPerformance1.SipMathsprogressscoredisadv ?? nationalEducationPerformance2.SipMathsprogressscoredisadv,
                    SipAttainment8score = nationalEducationPerformance1.SipAttainment8score ?? nationalEducationPerformance2.SipAttainment8score,
                    SipAttainment8scoredisadvantaged = nationalEducationPerformance1.SipAttainment8scoredisadvantaged ?? nationalEducationPerformance2.SipAttainment8scoredisadvantaged,
                    SipAttainment8scoreenglish = nationalEducationPerformance1.SipAttainment8scoreenglish ?? nationalEducationPerformance2.SipAttainment8scoreenglish,
                    SipAttainment8scoreenglishdisadvantaged = nationalEducationPerformance1.SipAttainment8scoreenglishdisadvantaged ?? nationalEducationPerformance2.SipAttainment8scoreenglishdisadvantaged,
                    SipAttainment8scoremaths = nationalEducationPerformance1.SipAttainment8scoremaths ?? nationalEducationPerformance2.SipAttainment8scoremaths,
                    SipAttainment8scoremathsdisadvantaged = nationalEducationPerformance1.SipAttainment8scoremathsdisadvantaged ?? nationalEducationPerformance2.SipAttainment8scoremathsdisadvantaged,
                    SipAttainment8scoreebacc = nationalEducationPerformance1.SipAttainment8scoreebacc ?? nationalEducationPerformance2.SipAttainment8scoreebacc,
                    SipAttainment8scoreebaccdisadvantaged = nationalEducationPerformance1.SipAttainment8scoreebaccdisadvantaged ?? nationalEducationPerformance2.SipAttainment8scoreebaccdisadvantaged,
                    SipNumberofpupilsprogress8 = nationalEducationPerformance1.SipNumberofpupilsprogress8 ?? nationalEducationPerformance2.SipNumberofpupilsprogress8,
                    SipNumberofpupilsprogress8disadvantaged = nationalEducationPerformance1.SipNumberofpupilsprogress8disadvantaged ?? nationalEducationPerformance2.SipNumberofpupilsprogress8disadvantaged,
                    SipProgress8upperconfidence = nationalEducationPerformance1.SipProgress8upperconfidence ?? nationalEducationPerformance2.SipProgress8upperconfidence,
                    SipProgress8lowerconfidence = nationalEducationPerformance1.SipProgress8lowerconfidence ?? nationalEducationPerformance2.SipProgress8lowerconfidence,
                    SipProgress8english = nationalEducationPerformance1.SipProgress8english ?? nationalEducationPerformance2.SipProgress8english,
                    SipProgress8englishdisadvantaged = nationalEducationPerformance1.SipProgress8englishdisadvantaged ?? nationalEducationPerformance2.SipProgress8englishdisadvantaged,
                    SipProgress8maths = nationalEducationPerformance1.SipProgress8maths ?? nationalEducationPerformance2.SipProgress8maths,
                    SipProgress8mathsdisadvantaged = nationalEducationPerformance1.SipProgress8mathsdisadvantaged ?? nationalEducationPerformance2.SipProgress8mathsdisadvantaged,
                    SipProgress8ebacc = nationalEducationPerformance1.SipProgress8ebacc ?? nationalEducationPerformance2.SipProgress8ebacc,
                    SipProgress8ebaccdisadvantaged = nationalEducationPerformance1.SipProgress8ebaccdisadvantaged ?? nationalEducationPerformance2.SipProgress8ebaccdisadvantaged,
                    SipPerformancetype = nationalEducationPerformance1.SipPerformancetype ?? nationalEducationPerformance2.SipPerformancetype
                };
        }
    }
}
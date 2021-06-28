using System;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.EducationalPerformance;

namespace TramsDataApi.Factories
{
    public class KeyStage4PerformanceResponseFactory
    {
        public static KeyStage4PerformanceResponse Create(SipEducationalperformancedata educationalPerformanceData)
        {
            if (educationalPerformanceData == null)
            {
                return null;
            }

            return new KeyStage4PerformanceResponse
            {
                 Year = educationalPerformanceData.SipName,
                    SipAttainment8score = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = educationalPerformanceData.SipAttainment8score.ToString(),
                        Disadvantaged = educationalPerformanceData.SipAttainment8scoredisadvantaged.ToString()
                    },
                    SipAttainment8scoreenglish = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = educationalPerformanceData.SipAttainment8scoreenglish.ToString(),
                        Disadvantaged = educationalPerformanceData.SipAttainment8scoreenglishdisadvantaged.ToString()
                    },
                    SipAttainment8scoremaths = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = educationalPerformanceData.SipAttainment8scoremaths.ToString(),
                        Disadvantaged = educationalPerformanceData.SipAttainment8scoremathsdisadvantaged.ToString()
                    },
                    SipAttainment8scoreebacc = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = educationalPerformanceData.SipAttainment8scoreebacc.ToString(),
                        Disadvantaged = educationalPerformanceData.SipAttainment8scoreebaccdisadvantaged.ToString()
                    },
                    SipNumberofpupilsprogress8 = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = educationalPerformanceData.SipNumberofpupilsprogress8.ToString(),
                        Disadvantaged = educationalPerformanceData.SipNumberofpupilsprogress8disadvantaged.ToString()
                    },
                    SipProgress8upperconfidence = educationalPerformanceData.SipProgress8upperconfidence,
                    SipProgress8lowerconfidence = educationalPerformanceData.SipProgress8lowerconfidence,
                    SipProgress8english = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = educationalPerformanceData.SipProgress8english.ToString(),
                        Disadvantaged = educationalPerformanceData.SipProgress8englishdisadvantaged.ToString()
                    },
                    SipProgress8maths = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = educationalPerformanceData.SipProgress8maths.ToString(),
                        Disadvantaged = educationalPerformanceData.SipProgress8mathsdisadvantaged.ToString()
                    },
                    SipProgress8ebacc = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = educationalPerformanceData.SipProgress8ebacc.ToString(),
                        Disadvantaged = educationalPerformanceData.SipProgress8ebaccdisadvantaged.ToString()
                    }
            };
        }
    }
}
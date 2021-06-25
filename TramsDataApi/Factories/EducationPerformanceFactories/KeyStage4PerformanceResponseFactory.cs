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
                        NotDisadvantaged = educationalPerformanceData.SipAttainment8score,
                        Disadvantaged = educationalPerformanceData.SipAttainment8scoredisadvantaged
                    },
                    SipAttainment8scoreenglish = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = educationalPerformanceData.SipAttainment8scoreenglish,
                        Disadvantaged = educationalPerformanceData.SipAttainment8scoreenglishdisadvantaged
                    },
                    SipAttainment8scoremaths = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = educationalPerformanceData.SipAttainment8scoremaths,
                        Disadvantaged = educationalPerformanceData.SipAttainment8scoremathsdisadvantaged
                    },
                    SipAttainment8scoreebacc = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = educationalPerformanceData.SipAttainment8scoreebacc,
                        Disadvantaged = educationalPerformanceData.SipAttainment8scoreebaccdisadvantaged
                    },
                    SipNumberofpupilsprogress8 = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = educationalPerformanceData.SipNumberofpupilsprogress8,
                        Disadvantaged = educationalPerformanceData.SipNumberofpupilsprogress8disadvantaged
                    },
                    SipProgress8upperconfidence = educationalPerformanceData.SipProgress8upperconfidence,
                    SipProgress8lowerconfidence = educationalPerformanceData.SipProgress8lowerconfidence,
                    SipProgress8english = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = educationalPerformanceData.SipProgress8english,
                        Disadvantaged = educationalPerformanceData.SipProgress8englishdisadvantaged
                    },
                    SipProgress8maths = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = educationalPerformanceData.SipProgress8maths,
                        Disadvantaged = educationalPerformanceData.SipProgress8mathsdisadvantaged
                    },
                    SipProgress8ebacc = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = educationalPerformanceData.SipProgress8ebacc,
                        Disadvantaged = educationalPerformanceData.SipProgress8ebaccdisadvantaged
                    }
            };
        }
    }
}
using System;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.EducationalPerformance;

namespace TramsDataApi.Factories
{
    public class KeyStage4PerformanceResponseFactory
    {
        public static KeyStage4PerformanceResponse Create(SipEducationalperformancedata educationalPerformanceData, SipEducationalperformancedata nationalEducationPerformance)
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
                     Disadvantaged = 
                         educationalPerformanceData.SipProgress8englishdisadvantaged.ToString()
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
                 },
                 SipProgress8Score = new DisadvantagedPupilsResponse
                 {
                     NotDisadvantaged = educationalPerformanceData.SipProgress8score.ToString(),
                     Disadvantaged = educationalPerformanceData.SipProgress8scoredisadvantaged.ToString()
                 },
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
                NationalAverage = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = null,
                    Disadvantaged = null
                }
            };
        }
    }
}
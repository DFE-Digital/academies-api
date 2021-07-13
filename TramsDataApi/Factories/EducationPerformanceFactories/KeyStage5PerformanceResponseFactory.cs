using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.EducationalPerformance;

namespace TramsDataApi.Factories
{
    public class KeyStage5PerformanceResponseFactory
    {
        public static KeyStage5PerformanceResponse Create(SipEducationalperformancedata educationalPerformanceData,
            SipEducationalperformancedata nationalEducationPerformance,
            SipEducationalperformancedata localAuthorityEducationPerformance)
        {
            return new KeyStage5PerformanceResponse
            {
                Year = educationalPerformanceData.SipName,
                AcademicQualificationAverage = educationalPerformanceData.SipAcademiclevelaveragepspe,
                AppliedGeneralQualificationAverage = educationalPerformanceData.SipAppliedgeneralaveragepspe,
                NationalAcademicQualificationAverage = nationalEducationPerformance.SipAcademiclevelaveragepspe,
                NationalAppliedGeneralQualificationAverage = nationalEducationPerformance.SipAppliedgeneralaveragepspe,
                LAAcademicQualificationAverage = localAuthorityEducationPerformance.SipAcademiclevelaveragepspe,
                LAAppliedGeneralQualificationAverage = localAuthorityEducationPerformance.SipAppliedgeneralaveragepspe
            };
        }
    }
}
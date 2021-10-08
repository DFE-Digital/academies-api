using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.EducationalPerformance;

namespace TramsDataApi.Factories.EducationPerformanceFactories
{
    public static class KeyStage1PerformanceResponseFactory
    {
        public static KeyStage1PerformanceResponse Create(SipPhonics phonic)
        {
            if (phonic == null) return null;

            return new KeyStage1PerformanceResponse
            {
                Year = phonic.SipYear,
                Reading = phonic.SipKs1readingpercentageresults,
                Writing = phonic.SipKs1writingpercentageresults,
                Maths = phonic.SipKs1mathspercentageresults
            };
        }
    }
}
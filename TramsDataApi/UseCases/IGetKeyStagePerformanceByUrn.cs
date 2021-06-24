using System.Collections.Generic;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.EducationalPerformance;

namespace TramsDataApi.UseCases
{
    public interface IGetKeyStagePerformanceByUrn
    {
        public EducationalPerformanceResponse Execute(string urn);
    }
}
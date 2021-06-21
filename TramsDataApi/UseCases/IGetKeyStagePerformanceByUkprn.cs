using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetKeyStagePerformanceByUkprn
    {
        public List<SipPhonics> Execute(string year);
    }
}
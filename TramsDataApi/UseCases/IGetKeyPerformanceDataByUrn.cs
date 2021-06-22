using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetKeyPerformanceDataByUrn
    {
        KeyPerformanceDataResponse Execute(GetKeyPerformanceDataRequest request);
    }
}

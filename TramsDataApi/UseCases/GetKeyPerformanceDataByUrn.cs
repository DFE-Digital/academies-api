using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class GetKeyPerformanceDataByUrn : IGetKeyPerformanceDataByUrn, IUseCase<GetKeyPerformanceDataRequest, KeyPerformanceDataResponse>
    {
        private readonly IKeyPerformanceDataGateway _keyPerformanceDataGateway;

        public GetKeyPerformanceDataByUrn(IKeyPerformanceDataGateway keyPerformanceDataGateway)
        {
            _keyPerformanceDataGateway = keyPerformanceDataGateway;
        }
        public KeyPerformanceDataResponse Execute(GetKeyPerformanceDataRequest request)
        {
            var keyPerformanceData = _keyPerformanceDataGateway.GetKeyPerformanceDataByUrn(request.URN);
            return (KeyPerformanceDataResponse)keyPerformanceData;
        }
    }
}

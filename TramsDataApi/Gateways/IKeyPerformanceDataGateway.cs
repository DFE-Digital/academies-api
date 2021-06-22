using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TramsDataApi.Gateways
{
    public interface IKeyPerformanceDataGateway
    {
        public Object GetKeyPerformanceDataByUrn(int urn);

    }
}

using System.Collections.Generic;
using TramsDataApi.CensusData;

namespace TramsDataApi.Gateways
{
    public interface ICensusDataGateway
    {
        IList<CensusDataModel> GetCensusDataByURNs(IEnumerable<string> urns);
    }
}
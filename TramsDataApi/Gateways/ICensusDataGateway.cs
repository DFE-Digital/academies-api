using TramsDataApi.CensusData;

namespace TramsDataApi.Gateways
{
    public interface ICensusDataGateway
    {
        public CensusDataModel GetCensusDataByURN(string urn);
    }
}
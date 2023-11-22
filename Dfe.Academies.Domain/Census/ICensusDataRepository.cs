namespace Dfe.Academies.Domain.Census
{
    public interface ICensusDataRepository
    {
        public CensusData GetCensusDataByURN(int urn);
    }
}
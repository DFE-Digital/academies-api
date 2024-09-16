using Dfe.Academies.Domain.Census;

namespace Dfe.Academies.Domain.Interfaces.Repositories
{
    public interface ICensusDataRepository
    {
        public CensusData GetCensusDataByURN(int urn);
    }
}
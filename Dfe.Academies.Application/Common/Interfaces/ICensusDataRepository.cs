using Dfe.Academies.Domain.Census;

namespace Dfe.Academies.Application.Common.Interfaces
{
    public interface ICensusDataRepository
    {
        public CensusData GetCensusDataByURN(int urn);
    }
}
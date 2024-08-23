using CsvHelper;
using Dfe.Academies.Application.Common.Interfaces;
using Dfe.Academies.Domain.Census;
using System.Globalization;

namespace Dfe.Academies.Infrastructure.Repositories
{
    public class CensusDataRepository : ICensusDataRepository
    {
        private readonly IEnumerable<CensusData> records;

        public CensusDataRepository()
        {
            var reader = new StreamReader("CensusData/2022-2023_england_census.csv");
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            records = csv.GetRecords<CensusData>().ToList();
        }

        public CensusData GetCensusDataByURN(int urn)
        {
            return records.FirstOrDefault(censusData => censusData.URN == urn.ToString());
        }
    }
}

using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using TramsDataApi.CensusData;
using System;
using System.Collections.Generic;

namespace TramsDataApi.Gateways
{
    public class CensusDataGateway : ICensusDataGateway
    {
        public IList<CensusDataModel> GetCensusDataByURNs(IEnumerable<string> urns)
        {
            using (var reader = new StreamReader("CensusData/2018-2019_england_census.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<CensusDataModel>().Where(censusData => urns.Contains(censusData.URN)).ToList();
                
                if (!records.Any())
                {
                    return null;
                }

                return records;
            }
        }
    }
}
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using TramsDataApi.CensusData;
using System;


namespace TramsDataApi.Gateways
{
    public class CensusDataGateway : ICensusDataGateway
    {
        
        public CensusDataModel GetCensusDataByURN(string urn)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            
            
            using (var reader = new StreamReader($"{projectDirectory}/TramsDataApi/CensusData/2018-2019_england_census.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<CensusDataModel>();
                return records.FirstOrDefault(censusData => censusData.URN == urn);
            }
        }
    }
}
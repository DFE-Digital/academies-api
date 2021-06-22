using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class KeyPerformanceDataGateway : IKeyPerformanceDataGateway
    {
        private readonly LegacyTramsDbContext _dbContext;

        public KeyPerformanceDataGateway(LegacyTramsDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public object GetKeyPerformanceDataByUrn(int urn)
        {
            throw new NotImplementedException();
        }
    }
}

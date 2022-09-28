using System;
using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class ConcernsTypeGateway : IConcernsTypeGateway
    {
        private readonly TramsDbContext _tramsDbContext;

        public ConcernsTypeGateway(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext;
        }

        public ConcernsType GetConcernsTypeByUrn(int urn)
        {
            return _tramsDbContext.ConcernsTypes.FirstOrDefault(t => t.Urn == urn);
        }

        public IList<ConcernsType> GetTypes()
        {
            return _tramsDbContext.ConcernsTypes.ToList();
        }
    }
}
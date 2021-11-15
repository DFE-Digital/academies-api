using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class ConcernsStatusGateway : IConcernsStatusGateway
    {
        private readonly TramsDbContext _tramsDbContext;
        
        public ConcernsStatusGateway(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext;
        }
        
        public IList<ConcernsStatus> GetStatuses()
        {
            return _tramsDbContext.ConcernsStatus.ToList();
        }

        public ConcernsStatus GetStatusByUrn(int urn)
        {
            return _tramsDbContext.ConcernsStatus.FirstOrDefault(s => s.Urn == urn);
        }
    }
}
using System.Linq;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
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
    }
}
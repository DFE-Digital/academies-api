using System.Linq;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class ConcernsCaseGateway : IConcernsCaseGateway
    {
        private readonly TramsDbContext _tramsDbContext;
        
        public ConcernsCaseGateway(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext;
        }

        public ConcernsCase SaveConcernsCase(ConcernsCase concernsCase)
        {
            _tramsDbContext.ConcernsCase.Update(concernsCase);
            _tramsDbContext.SaveChanges();

            return concernsCase;
        }

        public ConcernsCase GetConcernsCaseByTrustUkprn(string trustUkprn)
        {
            return _tramsDbContext.ConcernsCase.FirstOrDefault(c => c.TrustUkprn == trustUkprn);
        }

        public ConcernsCase GetConcernsCaseByUrn(string urn)
        {
            return _tramsDbContext.ConcernsCase.FirstOrDefault(c => c.Urn == urn);
        }
    }
}
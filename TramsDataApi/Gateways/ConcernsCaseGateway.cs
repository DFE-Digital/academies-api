using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public IList<ConcernsCase> GetConcernsCaseByTrustUkprn(string trustUkPrn, int page, int count)
        {
            return _tramsDbContext.ConcernsCase
                .Where(c => c.TrustUkprn == trustUkPrn)
                .Skip((page - 1) * count)
                .Take(count)
                .AsNoTracking()
                .ToList();
        }

        public ConcernsCase GetConcernsCaseByUrn(int urn)
        {
            var concernsCase = _tramsDbContext.ConcernsCase
                .AsNoTracking()
                .FirstOrDefault(c => c.Urn == urn);
            
            return concernsCase;
        }
        
        public ConcernsCase GetConcernsCaseIncludingRecordsByUrn(int urn)
        {
            var concernsCase = _tramsDbContext.ConcernsCase
                .Include(c => c.ConcernsRecords)
                .ThenInclude(record => record.ConcernsRating)
                .Include(c => c.ConcernsRecords)
                .ThenInclude(record => record.ConcernsType)
                .AsNoTracking()
                .FirstOrDefault(c => c.Urn == urn);
            
            return concernsCase;
        }

        public ConcernsCase Update(ConcernsCase concernsCase)
        {
            var entity = _tramsDbContext.ConcernsCase.Update(concernsCase);
            _tramsDbContext.SaveChanges();
            return entity.Entity;
        }
    }
}
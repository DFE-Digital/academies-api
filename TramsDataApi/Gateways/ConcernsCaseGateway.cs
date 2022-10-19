using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
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
                .Include(x => x.Decisions)
                .ThenInclude(x => x.DecisionTypes)
                .AsNoTracking()
                .ToList();
        }

        public ConcernsCase GetConcernsCaseByUrn(int urn)
        {
            var concernsCase = _tramsDbContext.ConcernsCase
                .Include(x => x.Decisions)
                .ThenInclude(x => x.DecisionTypes)
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
                .Include(c => c.ConcernsRecords)
                .ThenInclude(record => record.ConcernsMeansOfReferral)
                .Include(x => x.Decisions)
                .ThenInclude(x => x.DecisionTypes)
                .AsNoTracking()
                .FirstOrDefault(c => c.Urn == urn);
            
            return concernsCase;
        }

        public IList<ConcernsCase> GetConcernsCasesByOwnerId(string ownerId, int? statusUrn, int page, int count)
        {

            var query = _tramsDbContext.ConcernsCase
                .Include(x => x.Decisions)
                .ThenInclude(x => x.DecisionTypes)
                .Where(c => c.CreatedBy == ownerId);

            if (statusUrn != null)
            {
                query = query.Where(c => c.StatusUrn == statusUrn);
            }

            query = query.Skip((page - 1) * count)
                .Take(count)
                .AsNoTracking();
            
            return query.ToList();
        }

        public ConcernsCase Update(ConcernsCase concernsCase)
        {
            var entity = _tramsDbContext.ConcernsCase.Update(concernsCase);
            _tramsDbContext.SaveChanges();
            return entity.Entity;
        }
    }
}
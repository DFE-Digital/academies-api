using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class ConcernsRecordGateway : IConcernsRecordGateway
    {
        private readonly TramsDbContext _tramsDbContext;

        public ConcernsRecordGateway(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext;
        }

        public ConcernsRecord SaveConcernsCase(ConcernsRecord concernsRecord)
        {
            _tramsDbContext.ConcernsRecord.Update(concernsRecord);
            _tramsDbContext.SaveChanges();

            return concernsRecord;
        }

        public ConcernsRecord Update(ConcernsRecord concernsRecord)
        {
            var entity = _tramsDbContext.ConcernsRecord.Update(concernsRecord);
            _tramsDbContext.SaveChanges();
            return entity.Entity;
        }

        public ConcernsRecord GetConcernsRecordByUrn(int urn)
        {
            return _tramsDbContext.ConcernsRecord.FirstOrDefault(r => r.Urn == urn);
        }
    }
}
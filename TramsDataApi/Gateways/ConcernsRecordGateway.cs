using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class ConcernsRecordGateway : IConcernsRecordGateway
    {
        private TramsDbContext _tramsDbContext;

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
    }
}
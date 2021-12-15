using System.Linq;
using Microsoft.EntityFrameworkCore;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class A2BSchoolLeaseGateway : IA2BSchoolLeaseGateway
    {
        private readonly TramsDbContext _tramsDbContext;

        public A2BSchoolLeaseGateway(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext;
        }
        public A2BSchoolLease CreateA2BSchoolLease(A2BSchoolLease schoolLease)
        {
            _tramsDbContext.A2BSchoolLeases.Add(schoolLease);
            _tramsDbContext.SaveChanges();

            return schoolLease;
        }

        public A2BSchoolLease GetByLeaseId(string leaseId)
        {
            return _tramsDbContext.A2BSchoolLeases
                .AsNoTracking()
                .FirstOrDefault(k => k.SchoolLeaseId == leaseId);
        }
    }
}
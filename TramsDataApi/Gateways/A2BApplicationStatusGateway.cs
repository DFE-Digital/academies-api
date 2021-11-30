using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.ApplyToBecome;

namespace TramsDataApi.Gateways
{
    public class A2BApplicationStatusGateway : IA2BApplicationStatusGateway
    {
        private readonly TramsDbContext _tramsDbContext;
        
        public A2BApplicationStatusGateway(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext;
        }
        
        public A2BApplicationStatus GetByStatusId(int applicationStatusId)
        {
            return _tramsDbContext.A2BApplicationStatus
                .AsNoTracking()
                .FirstOrDefault(s => s.ApplicationStatusId == applicationStatusId);
        }

        public A2BApplicationStatus CreateA2BApplicationStatus(A2BApplicationStatus status)
        {
            _tramsDbContext.A2BApplicationStatus.Add(status);
            _tramsDbContext.SaveChanges();

            return status;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.ApplyToBecome;

namespace TramsDataApi.Gateways
{
    public class A2BApplicationGateway : IA2BApplicationGateway
    {
        private readonly TramsDbContext _tramsDbContext;
        
        public A2BApplicationGateway(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext;
        }

        public ConcernsCase SaveConcernsCase(ConcernsCase concernsCase)
        {
             _tramsDbContext.ConcernsCase.Update(concernsCase);
             _tramsDbContext.SaveChanges();
        
             return concernsCase;
        }

        public A2BApplication GetByApplicationId(int applicationId)
        {
            return _tramsDbContext.A2BApplications
                .AsNoTracking()
                .First(a => a.ApplicationId == applicationId);
        }

        public A2BApplication CreateA2BApplication(A2BApplication application)
        {
            _tramsDbContext.A2BApplications.Add(application);
            _tramsDbContext.SaveChanges();

            return application;
        }
    }
}
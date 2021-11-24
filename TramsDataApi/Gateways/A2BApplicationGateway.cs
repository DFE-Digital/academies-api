using System.Linq;
using Microsoft.EntityFrameworkCore;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class A2BApplicationGateway : IA2BApplicationGateway
    {
        private readonly TramsDbContext _tramsDbContext;
        
        public A2BApplicationGateway(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext;
        }
        
        public A2BApplication GetByApplicationId(int applicationId)
        {
            return _tramsDbContext.A2BApplications
                .AsNoTracking()
                .FirstOrDefault(a => a.ApplicationId == applicationId);
        }

        public A2BApplication CreateA2BApplication(A2BApplication application)
        {
            _tramsDbContext.A2BApplications.Add(application);
            _tramsDbContext.SaveChanges();

            return application;
        }
    }
}
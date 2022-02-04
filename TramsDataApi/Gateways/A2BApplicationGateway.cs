using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class A2BApplicationGateway : IA2BApplicationGateway
    {
        private readonly TramsDbContext _tramsDbContext;
        private readonly ILogger<A2BApplicationGateway> _logger;
        
        public A2BApplicationGateway(TramsDbContext tramsDbContext, ILogger<A2BApplicationGateway> logger)
        {
            _tramsDbContext = tramsDbContext;
            _logger = logger;
        }
        
        public A2BApplication GetByApplicationId(string applicationId)
        {
            return _tramsDbContext.A2BApplications
                .AsNoTracking()
                .Include(a => a.KeyPersons)
                .Include(a => a.ApplyingSchools)
                .FirstOrDefault(a => a.ApplicationId == applicationId);
        }

        public A2BApplication CreateA2BApplication(A2BApplication application)
        {
            try
            {
                _tramsDbContext.A2BApplications.Add(application);
                _tramsDbContext.SaveChanges();

                _logger.LogInformation("Successfully created A2BApplication with Id {id}", application.ApplicationId);
            }
            catch (DbUpdateException e)
            {
                _logger.LogError("Failed to create application with Id {id}, {e}", application.ApplicationId, e);
                return null;
            }
            catch (Exception e)
            {
                _logger.LogError(
                    "An application exception has occurred whilst creating A2BApplication with Id {id}, {e}",
                    application.ApplicationId, e);
                
                return null;
            }
          
            return application;
        }
    }
}
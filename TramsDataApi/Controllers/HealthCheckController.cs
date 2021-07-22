using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly LegacyTramsDbContext _dbContext;
        private readonly ILogger<HealthCheckController> _logger;

        public HealthCheckController(LegacyTramsDbContext context, ILogger<HealthCheckController> logger)
        {
            _dbContext = context;
            _logger = logger;
        }
        
        
        [HttpGet]
        public string Get()
        {
            _logger.LogInformation($"Returning OK Health Check");
            return "Health check ok";
        }
        
        [HttpGet]
        [Route("/check_db")]
        public bool CheckDbConnection()
        {
            _logger.LogInformation($"Returning Database Health Check");
            return _dbContext.Database.CanConnect();
        }
    }
}
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class HealthCheckController : ControllerBase
    {
        private readonly LegacyTramsDbContext _dbContext;

        public HealthCheckController(LegacyTramsDbContext context)
        {
            _dbContext = context;
        }
        
        
        [HttpGet]
        public string Get()
        {
            return "Health check ok";
        }
        
        [HttpGet]
        [Route("/check_db")]
        public bool CheckDbConnection()
        {
            return _dbContext.Database.CanConnect();
        }
    }
}
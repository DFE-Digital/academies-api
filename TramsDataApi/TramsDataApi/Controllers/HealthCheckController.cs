using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TramsDataApi.Data;

namespace TramsDataApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly TramsDbContext _dbContext;

        public HealthCheckController(TramsDbContext context)
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
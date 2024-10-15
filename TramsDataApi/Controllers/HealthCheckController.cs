using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using TramsDataApi.DatabaseModels;
using Swashbuckle.AspNetCore.Annotations;

namespace TramsDataApi.Controllers
{
    /// <summary>
    /// Provides endpoints for checking the health of the API and database.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    [SwaggerTag("Health Check Endpoints")]
    public class HealthCheckController : ControllerBase
    {
        private readonly LegacyTramsDbContext _dbContext;
        private readonly ILogger<HealthCheckController> _logger;

        /// <summary>
        /// Constructor that initializes database and logger.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="logger">Logging service.</param>
        public HealthCheckController(LegacyTramsDbContext context, ILogger<HealthCheckController> logger)
        {
            _dbContext = context;
            _logger = logger;
        }

        /// <summary>
        /// Provides a basic health check for the API.
        /// </summary>
        /// <returns>String message indicating health status.</returns>
        [HttpGet]
        [HttpHead]
        [SwaggerOperation(Summary = "Performs a basic health check", Description = "Checks if the API is operational.")]
        [SwaggerResponse(200, "API is healthy.")]
        public string Get()
        {
            _logger.LogInformation("Returning OK Health Check");
            return "Health check ok";
        }

        /// <summary>
        /// Checks the database connectivity.
        /// </summary>
        /// <returns>Boolean indicating whether the database can be connected to.</returns>
        [HttpGet]
        [HttpHead]
        [Route("/check_db")]
        [SwaggerOperation(Summary = "Performs a database health check", Description = "Checks if the database is reachable.")]
        [SwaggerResponse(200, "Database is healthy.")]
        public bool CheckDbConnection()
        {
            _logger.LogInformation("Returning Database Health Check");
            return _dbContext.Database.CanConnect();
        }
    }
}
